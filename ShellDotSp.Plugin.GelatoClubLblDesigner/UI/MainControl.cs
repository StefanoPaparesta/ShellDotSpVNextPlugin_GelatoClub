using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using DotSpExtensions.Winforms;

using NLog.Fluent;

using ShellDotSp.Plugin.GelatoClubCore.Model;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Core;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Forms;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Interfaces;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Presenters;

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ShellDotSp.Plugin.GelatoClubLblDesigner.UI
{
    [ToolboxItem(false)]
    public partial class MainControlShellLabelDesigner : UserControl, IMainView
    {

        private MainPresenter _presenter;
        private MsgBoxHelper _msg = new MsgBoxHelper("Designer");

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
                    _presenter.SetEtichetta((TabellaLookUp)view.GetRow(hitInfo.RowHandle));
                }
            }
        }

        private void Designer_EtichettaSalvata(object sender, EtichettaSalvataEventArgs e)
        {
            _presenter.CopiaEtichettaSalvata(e.FileName);
        }

        private void btnDesigner_Click(object sender, EventArgs e)
        {
            if (_presenter.EtichettaSelezionata == null)
                return;

            try
            {
                string fileName = _presenter.GetFileEtichettaSelezionata();

                bool etichettaNuova = !File.Exists(fileName);

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

                var parentForm = FindForm();

                using (var wait = new DevExpress.XtraSplashScreen.SplashScreenManager(parentForm, typeof(WaitForm1), false, false))
                {
                    wait.ClosingDelay = 0;
                    wait.ShowWaitForm();
                    try
                    {
                        using (var designer = new FrmLabelDesigner(fileName, typeof(ReportDataCollection), Larghezza, Altezza,
                            ReportPreviewData.Create))
                        {
                            EventHandler shown = (s, args) =>
                            {
                                if (wait.IsSplashFormVisible)
                                    wait.CloseWaitForm();
                            };
                            designer.Shown += shown;
                            designer.EtichettaSalvata += Designer_EtichettaSalvata;
                            try
                            {
                                designer.ShowDialog(this);
                            }
                            finally
                            {
                                designer.Shown -= shown;
                                designer.EtichettaSalvata -= Designer_EtichettaSalvata;
                            }
                        }
                    }
                    finally
                    {
                        if (wait.IsSplashFormVisible)
                            wait.CloseWaitForm();
                    }
                }

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
                        TabellaLookUp etichetta = new TabellaLookUp
                        {
                            Tabella = "Etichette",
                            Codice = frm.Codice,
                            Valore = frm.Codice,
                            CodiceNumerico = 1,
                            ValoreStr1 = frm.StrutturaGs1,
                            Note = frm.Note
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
                    frm.StrutturaGs1 = _presenter.EtichettaSelezionata.ValoreStr1;
                    frm.Note = _presenter.EtichettaSelezionata.Note;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        _presenter.EtichettaSelezionata.ValoreStr1 = frm.StrutturaGs1;
                        _presenter.EtichettaSelezionata.Note = frm.Note;

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
            var response = _msg.Question("Sei sicuro di voler clonare l'etichetta selezionata?");

            if (response == DialogResult.No)
                return;

            using (FrmClona frm = new FrmClona(_presenter))
            {
                frm.CodicePrecedente = _presenter.EtichettaSelezionata.Codice;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _presenter.ClonaEtichetta(frm.CodicePrecedente,
                            frm.CodiceNuovo,
                            _presenter.EtichettaSelezionata.Note);
                    }
                    catch (Exception ex)
                    {
                        _msg.Error(ex.Message);
                    }
                }

                _presenter.LoadEtichette();
                _presenter.SetEtichetta(null);
            }
        }
    }
}
