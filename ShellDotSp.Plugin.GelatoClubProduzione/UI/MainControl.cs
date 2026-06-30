using DotSpExtensions.Winforms;

using NLog;
using NLog.Fluent;

using ShellDotSp.Plugin.GelatoClubCore.Helpers;
using ShellDotSp.Plugin.GelatoClubCore.Model;
using ShellDotSp.Plugin.GelatoClubProduzione.Core;
using ShellDotSp.Plugin.GelatoClubProduzione.Forms;
using ShellDotSp.Plugin.GelatoClubProduzione.Interfaces;
using ShellDotSp.Plugin.GelatoClubProduzione.Presenters;

using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ShellDotSp.Plugin.GelatoClubProduzione.UI
{
    [ToolboxItem(false)]
    public partial class MainControlGelatoClubProduzione : UserControl, IMainView
    {

        private MainPresenter _presenter;
        private MsgBoxHelper _msg = new MsgBoxHelper("GELATO CLUB");
        private Logger _logger = LogManager.GetCurrentClassLogger();
        private bool _dataConfezionamentoManuale = false;
        private bool _etichettaSelFromPresenter = false;

        public MainControlGelatoClubProduzione()
        {
            InitializeComponent();
            _presenter = new MainPresenter(this);
        }

        public string Caption { get; set; }
        public bool IsLottoManuale { get; set; } = false;

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

            timerDataConfezionamento.Enabled = true;
            txDataConfezionamento.DateTime = DateTime.Today;
            txDataConfezionamento.Enabled = false;

            btnInvia.Enabled = false;
            lkDescrizione1.Enabled = false;
            lkDescrizione2.Enabled = false;
            lkEtichette.Enabled = false;
            btnManageDesc1.Enabled = false;
            btnManageDesc2.Enabled = false;
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
            bndLinee.DataSource = _presenter.Linee;
            bndEtichette.DataSource = _presenter.Etichette;
            lblArticolo.Cursor = Cursors.Default;
        }
        private void LineaSelezionata()
        {

            if (_presenter.LineaSelezionata == null)
            {
                lkLinee.EditValue = null;
            }

            _presenter.VerificaStatoLineaCorrente();
        }
        private void StatoLineaAggiornato()
        {
            if (_presenter.StatoLineaCorrente.Stato == "STOP")
            {
                if (_presenter.ArticoloSelezionato != null)
                {
                    lblArticolo.Text = _presenter.ArticoloSelezionato.DescrizioneArticolo;
                    lblArticolo.BackColor = Color.YellowGreen;
                }
                else
                {
                    lblArticolo.BackColor = SystemColors.Control;
                    lblArticolo.Text = string.Empty;
                }

                lblArticolo.Cursor = Cursors.Hand;

                btnInvia.Enabled = _presenter.ArticoloSelezionato != null;

            }
            else
            {

                lblArticolo.Cursor = Cursors.Default;
            }
        }
        private void ArticoloSelezionato()
        {

            lkEtichette.EditValue = null;
            lkEtichette.Enabled = _presenter.ArticoloSelezionato != null;

            if (_presenter.ArticoloSelezionato != null)
            {
                lblArticolo.Text = $"{_presenter.ArticoloSelezionato.CodiceArticolo} - {_presenter.ArticoloSelezionato.DescrizioneArticolo}";

                lblDescCommerciale.Text = _presenter.ArticoloSelezionato.DescrCommercialeITA;
                lblDescLegaleITA.Text = _presenter.ArticoloSelezionato.DescrLegaleITA;
                lblDescCommercialeDE.Text = _presenter.ArticoloSelezionato.DescrCommercialeTEDESCO;
                lblDescCommercialeEN.Text = _presenter.ArticoloSelezionato.DescrCommercialeINGLESE;
                lblDescCommercialeES.Text = _presenter.ArticoloSelezionato.DescrCommercialeSPAGNOLO;
                lblDescCommercialeFR.Text = _presenter.ArticoloSelezionato.DescrCommercialeFRANCESE;
                lblTmc.Text = _presenter.ArticoloSelezionato.MesiValiditaLotto.ToString();
                lblScadenzaFineMese.Text = _presenter.ArticoloSelezionato.ScadenzaAFineMese;
                lblTipoBc.Text = _presenter.ArticoloSelezionato.Tipo;
                lblBarcode.Text = _presenter.ArticoloSelezionato.Barcode;
                lblQtaScatola.Text = _presenter.ArticoloSelezionato.QuantBarcode.ToString("f0");

                _presenter.CalcoloDataScadenza(CalcoloScadenza.Mesi, _presenter.ArticoloSelezionato.MesiValiditaLotto, _presenter.ArticoloSelezionato.ScadenzaAFineMese == "S");

                bndDescrizione1.Clear();
                bndDescrizione2.Clear();

                _presenter.GetTesti();

                lkDescrizione1.Properties.ForceInitialize();
                lkDescrizione2.Properties.ForceInitialize();

                var (idTesto1, idTesto2) = _presenter.SelezionaTestiPers();

                if (idTesto1 != 0)
                {
                    lkDescrizione1.EditValue = idTesto1;
                }
                else
                {
                    lkDescrizione1.EditValue = null;
                }

                if (idTesto2 != 0)
                {
                    lkDescrizione2.EditValue = idTesto2;
                }
                else
                {
                    lkDescrizione2.EditValue = null;
                }

                _presenter.GetEtichetta();
            }
            else
            {
                lblArticolo.Text = string.Empty;

                lblDescCommerciale.Text = string.Empty;
                lblDescLegaleITA.Text = string.Empty;
                lblDescCommercialeDE.Text = string.Empty;
                lblDescCommercialeEN.Text = string.Empty;
                lblDescCommercialeES.Text = string.Empty;
                lblDescCommercialeFR.Text = string.Empty;
                lblTmc.Text = string.Empty;
                lblScadenzaFineMese.Text = string.Empty;
                lblTipoBc.Text = string.Empty;
                lblBarcode.Text = string.Empty;
                lblDataScadenza.Text = string.Empty;
                lblQtaScatola.Text = string.Empty;

                lkDescrizione1.Enabled = _presenter.ArticoloSelezionato != null;
                lkDescrizione2.Enabled = _presenter.ArticoloSelezionato != null;
                btnManageDesc1.Enabled = _presenter.ArticoloSelezionato != null;
                btnManageDesc2.Enabled = _presenter.ArticoloSelezionato != null;

                lkDescrizione1.EditValue = null;
                lkDescrizione2.EditValue = null;
                bndDescrizione1.Clear();
                bndDescrizione2.Clear();

            }

            _presenter.VerificaStatoLineaCorrente();
        }
        private void LottoCalcolato()
        {
            lblLotto.Text = _presenter.Lotto;
        }
        private void DataScadenzaCalcolata()
        {
            lblDataScadenza.Text = _presenter.DataScadenza.ToString("dd/MM/yyyy");
            _logger.Info("DATA SCADENZA CALCOLATA {dt:dd/MM/yyyy}", _presenter.DataScadenza);
        }
        private void TestiInizializzati()
        {
            lkDescrizione1.Enabled = _presenter.ArticoloSelezionato != null;
            lkDescrizione2.Enabled = _presenter.ArticoloSelezionato != null;
            btnManageDesc1.Enabled = _presenter.ArticoloSelezionato != null;
            btnManageDesc2.Enabled = _presenter.ArticoloSelezionato != null;

            bndDescrizione1.DataSource = _presenter.Testi1;
            bndDescrizione2.DataSource = _presenter.Testi2;
        }
        private void EtichettaInizializzata()
        {
            _etichettaSelFromPresenter = true;
            lkEtichette.EditValue = _presenter.EtichettaSelezionata?.CodiceLayout ?? null;
        }

        private void lkLinee_EditValueChanged(object sender, EventArgs e)
        {
            var linea = lkLinee.GetSelectedDataRow() as LookUpData;

            _presenter.SetLineaSelezionata(linea);
        }

        private void lblArticolo_Click(object sender, EventArgs e)
        {
            if (_presenter.StatoLineaCorrente != null &&
                _presenter.StatoLineaCorrente.Stato == "STOP" &&
                _presenter.LineaSelezionata != null)
            {
                using (var frm = new FrmArticoli(_presenter))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        _presenter.SetArticoloSelezionato(frm.ArticoloSelezionato);
                    }
                }
            }
        }

        private void btnInvia_Click(object sender, EventArgs e)
        {
            var errors = _presenter.VerificaDatiStampa();

            if (errors.Count != 0)
            {
                _msg.ShowErrors(errors);
                return;
            }

            var response = _msg.Question("Confermi l'invio dell'articolo selezionato in produzione ?");

            if (response == DialogResult.Yes)
            {
                var result = _presenter.InviaArticoloInProduzione();

                if (result.Status == ReturnValueStatus.Error)
                {
                    _msg.Error(result.StatusMessage);
                }
            }

        }

        private void timerDataConfezionamento_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Today;

            if (!_dataConfezionamentoManuale)
            {
                if (txDataConfezionamento.DateTime != now)
                {
                    txDataConfezionamento.DateTime = now;
                    _presenter.SetDataConfezionamento(now);
                    _logger.Info("CAMBIO DATA CONFEZIONAMENTO");
                }
            }
            else
            {
                _logger.Info("DATA CONFEZIONAMENTO MANUALE {dt}", txDataConfezionamento.DateTime);
            }


            if (!IsLottoManuale)
            {
                _presenter.CalcolaLotto();
            }
            if (IsLottoManuale)
            {
                _logger.Info("NO CALCOLA LOTTO => E' inserito un lotto manuale");
            }
        }

        private void txDataConfezionamento_EditValueChanged(object sender, EventArgs e)
        {
            _presenter.SetDataConfezionamento(txDataConfezionamento.DateTime);

            _presenter.CalcolaLotto();
        }

        private void lkDescrizione1_EditValueChanged(object sender, EventArgs e)
        {
            var testo1 = (EtichettaTesto)lkDescrizione1.GetSelectedDataRow();

            _presenter.SetTesto1(testo1);
        }

        private void lkDescrizione2_EditValueChanged(object sender, EventArgs e)
        {
            var testo2 = (EtichettaTesto)lkDescrizione2.GetSelectedDataRow();

            _presenter.SetTesto2(testo2);
        }

        private void btnManageDesc1_Click(object sender, EventArgs e)
        {
            using (FrmTestiPersonalizzati frm = new FrmTestiPersonalizzati(_presenter))
            {
                frm.TipoTesto = 1;
                frm.CodiceArticolo = _presenter.ArticoloSelezionato.CodiceArticolo;

                frm.ShowDialog();

                _presenter.GetTesti();

                var testoSelezionato = (EtichettaTesto)lkDescrizione1.GetSelectedDataRow();

                if (testoSelezionato != null)
                {
                    var exist = _presenter.VerificaEsistenzaTesto(testoSelezionato.Id, 1);

                    if (!exist)
                        lkDescrizione1.EditValue = null;
                }
                else
                {
                    lkDescrizione1.EditValue = null;
                }
            }
        }

        private void lkEtichette_EditValueChanged(object sender, EventArgs e)
        {
            var etichetta = (Etichetta)lkEtichette.GetSelectedDataRow();

            if (!_etichettaSelFromPresenter)
            {
                if (etichetta != null)
                {
                    EtichettaPersonalizzata etiPers = new EtichettaPersonalizzata
                    {
                        CodiceArticolo = _presenter.ArticoloSelezionato.CodiceArticolo,
                        CodiceLayout = etichetta.Codice
                    };

                    _presenter.SetEtichetta(etiPers);
                }
                else
                {
                    _presenter.SetEtichetta(null);
                }
            }
            else
            {
                _etichettaSelFromPresenter = false;
            }
        }
    }
}
