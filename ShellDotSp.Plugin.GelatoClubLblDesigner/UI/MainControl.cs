using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using DotSpExtensions.Winforms;

using NLog.Fluent;

using ShellDotSp.Plugin.GelatoClubCore.Config;
using ShellDotSp.Plugin.GelatoClubCore.Model;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Core;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Forms;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Interfaces;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Presenters;

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ShellDotSp.Plugin.GelatoClubLblDesigner.UI
{
    [ToolboxItem(false)]
    public partial class MainControlShellLabelDesigner : UserControl, IMainView
    {

        private static int _reportOpeningCount;
        private MainPresenter _presenter;
        private MsgBoxHelper _msg = new MsgBoxHelper("Designer");
        private CfgPlugin _cfg = CfgPlugin.Instance;

        public MainControlShellLabelDesigner()
        {
            InitializeComponent();
            _presenter = new MainPresenter(this);
        }


        public string Caption { get; set; }

        private event EventHandler viewInitialized;
        private event EventHandler closeView;

        public event EventHandler CloseView
        {
            add { closeView += value; }
            remove { closeView -= value; }
        }
        public event EventHandler ViewInitialized
        {
            add { viewInitialized += value; }
            remove { viewInitialized -= value; }
        }

        private void InvokeViewInitialized(EventArgs e)
        {
            viewInitialized?.Invoke(this, e);
        }
        private void InvokeCloseView(EventArgs e)
        {
            closeView?.Invoke(this, e);
        }

        public void Finalizza()
        {
            InvokeCloseView(EventArgs.Empty);
        }

        public void Inizializza()
        {
            InvokeViewInitialized(EventArgs.Empty);

            btnImporta.Enabled = _cfg.AbilitaImporFileEtichette;
        }

        public void UpdateUI(MessaggioPlugin messaggio)
        {
            Type t = this.GetType();
            MethodInfo method = t.GetMethod(messaggio.ToString(),
                BindingFlags.NonPublic | BindingFlags.Instance);

            if (method != null)
            {
                method.Invoke(this, null);
            }
            else
            {
                Log.Warn()
                    .Message("Metodo non trovato: " + messaggio.ToString())
                    .Write();
            }
        }

        private void ViewInizializzata()
        {

        }

        private void EtichetteCaricate()
        {
            bndEtichette.DataSource = _presenter.Etichette;
        }

        private void EtichettaSelezionata()
        {
            btnModifica.Enabled = _presenter.EtichettaSelezionata != null;
            btnDesigner.Enabled = _presenter.EtichettaSelezionata != null;
            btnCancella.Enabled = _presenter.EtichettaSelezionata != null;
            btnClona.Enabled = _presenter.EtichettaSelezionata != null;
        }

        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridView view = grid.Views[0] as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            view.SelectRow(hitInfo.RowHandle);

            if ((e.Button & MouseButtons.Left) != 0 & hitInfo.InRow & !view.IsGroupRow(hitInfo.RowHandle))
            {
                if (view.GetSelectedRows().Length == 1)
                {
                    _presenter.SetEtichetta((RepositoryEtichetta)view.GetRow(hitInfo.RowHandle));
                }
            }
        }

        private void btnDesigner_Click(object sender, EventArgs e)
        {
            if (_presenter.EtichettaSelezionata == null)
                return;

            var openingWatch = Stopwatch.StartNew();
            int openingNumber = System.Threading.Interlocked.Increment(ref _reportOpeningCount);

            try
            {
                Log.Info().Message("REPORT_OPEN inizio dal clic apertura={0} primaApertura={1} etichetta={2}",
                    openingNumber, openingNumber == 1, _presenter.EtichettaSelezionata.Codice).Write();
                var databaseWatch = Stopwatch.StartNew();
                RepositoryEtichetta etichetta = _presenter.CaricaEtichettaSelezionata();
                databaseWatch.Stop();
                Log.Info().Message("REPORT_OPEN recupero DB apertura={0} etichetta={1} durataDbMs={2} totaleDalClicMs={3} layoutBytes={4}",
                    openingNumber, etichetta.Codice, databaseWatch.ElapsedMilliseconds,
                    openingWatch.ElapsedMilliseconds, etichetta.Layout == null ? 0 : etichetta.Layout.Length).Write();

                bool etichettaNuova = etichetta.Layout == null || etichetta.Layout.Length == 0;

                int Larghezza = 0;
                int Altezza = 0;

                if (etichettaNuova)
                {
                    using (FrmFormatiEtichetta frm = new FrmFormatiEtichetta(_presenter))
                    {

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            Larghezza = frm.Larghezza;
                            Altezza = frm.Altezza;
                        }
                        else
                        {
                            return;
                        }

                    }
                }


                var designerWatch = Stopwatch.StartNew();
                var parentForm = FindForm();

                using (var wait = new DevExpress.XtraSplashScreen.SplashScreenManager(parentForm, typeof(WaitForm1), false, false))
                {
                    wait.ClosingDelay = 0;
                    wait.ShowWaitForm();
                    try
                    {
                        bool ricarica;
                        do
                        {
                            ricarica = false;
                            using (var designer = new FrmLabelDesigner(etichetta, (layout, versioneConfermata) => _presenter.SalvaLayoutEtichetta(etichetta, layout, versioneConfermata), typeof(ReportDataCollection), Larghezza, Altezza,
                                ReportPreviewData.Create))
                            {
                                EventHandler shown = (s, args) =>
                                {
                                    if (wait.IsSplashFormVisible)
                                        wait.CloseWaitForm();
                                    openingWatch.Stop();
                                    designerWatch.Stop();
                                    Log.Info().Message("REPORT_OPEN finestra mostrata id={0} apertura={1} primaApertura={2} etichetta={3} totaleMs={4} aperturaDesignerMs={5}",
                                        designer.OpeningId, openingNumber, openingNumber == 1, etichetta.Codice,
                                        openingWatch.ElapsedMilliseconds, designerWatch.ElapsedMilliseconds).Write();
                                };
                                designer.Shown += shown;
                                try
                                {
                                    designer.ShowDialog(this);
                                    ricarica = designer.ReloadRequested;
                                }
                                finally
                                {
                                    designer.Shown -= shown;
                                }
                            }

                            if (ricarica)
                                etichetta = _presenter.CaricaEtichettaSelezionata();
                        } while (ricarica);
                    }
                    finally
                    {
                        if (wait.IsSplashFormVisible)
                            wait.CloseWaitForm();
                    }
                }

                _presenter.LoadEtichette();
                _presenter.SetEtichetta(null);
            }
            catch (Exception ex)
            {
                Log.Error().Exception(ex).Message("Errore durante l'apertura del designer dell'etichetta").Write();
                DevExpress.XtraEditors.XtraMessageBox.Show(this, ex.Message,
                    "Designer etichette", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuovo_Click(object sender, EventArgs e)
        {
            using (FrmEtichetta frm = new FrmEtichetta(_presenter))
            {
                try
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        RepositoryEtichetta etichetta = new RepositoryEtichetta
                        {
                            Codice = frm.Codice,
                            Versione = 0,
                            StrutturaGs1 = frm.StrutturaGs1,
                            Descrizione = frm.Note
                        };

                        _presenter.GestisciEtichetta(etichetta);
                    }
                }
                catch (Exception ex)
                {
                    _msg.Error(ex.ToString());
                }
            }

            _presenter.LoadEtichette();
            _presenter.SetEtichetta(null);
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            using (FrmEtichetta frm = new FrmEtichetta(_presenter))
            {
                try
                {
                    frm.Codice = _presenter.EtichettaSelezionata.Codice;
                    frm.StrutturaGs1 = _presenter.EtichettaSelezionata.StrutturaGs1;
                    frm.Note = _presenter.EtichettaSelezionata.Descrizione;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        _presenter.EtichettaSelezionata.StrutturaGs1 = frm.StrutturaGs1;
                        _presenter.EtichettaSelezionata.Descrizione = frm.Note;

                        _presenter.GestisciEtichetta(_presenter.EtichettaSelezionata);
                    }
                }
                catch (Exception ex)
                {
                    _msg.Error(ex.Message);
                }

                _presenter.LoadEtichette();
                _presenter.SetEtichetta(null);
            }
        }

        private void btnCancella_Click(object sender, EventArgs e)
        {
            var response = _msg.Question("Sei sicuro di voler cancellare l'etichetta selezionata?");

            if (response == DialogResult.No)
                return;

            try
            {
                _presenter.CancellaEtichettaSelezionata();
            }
            catch (Exception ex)
            {
                _msg.Error(ex.Message);
            }

            _presenter.LoadEtichette();
            _presenter.SetEtichetta(null);
        }

        private void btnClona_Click(object sender, EventArgs e)
        {
            if (_presenter.EtichettaSelezionata == null)
                return;

            using (var frm = new FrmClona(_presenter))
            {
                frm.CodicePrecedente = _presenter.EtichettaSelezionata.Codice;
                if (frm.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    _presenter.ClonaEtichetta(frm.CodiceNuovo);
                    _presenter.LoadEtichette();
                    _presenter.SetEtichetta(null);
                }
                catch (Exception ex)
                {
                    Log.Error().Exception(ex).Message("Errore durante la clonazione dell'etichetta").Write();
                    _msg.Error(ex.Message);
                }
            }
        }

        private void btnImporta_Click(object sender, EventArgs e)
        {
            var response = _msg.Question("Sei sicuro di voler importare le etichette dal repository su file ?");

            if (response == DialogResult.No)
                return;

            int numeroImportate = _presenter.ImportaEtichetteDaFile();

            if (numeroImportate > 0)
            {
                _msg.Info($"Importate {numeroImportate} etichette !!");
            }
            else
            {
                _msg.Error($"Importate {numeroImportate} etichette !!");
            }
        }
    }
}

