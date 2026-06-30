using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using DotSpExtensions.Winforms;

using ShellDotSp.Plugin.GelatoClubCore.Model;
using ShellDotSp.Plugin.GelatoClubProduzione.Presenters;

using System.Drawing;
using System.Windows.Forms;

namespace ShellDotSp.Plugin.GelatoClubProduzione.Forms
{
    public partial class FrmTestiPersonalizzati : XtraForm
    {
        private readonly MainPresenter _presenter;
        private MsgBoxHelper _msg = new MsgBoxHelper("GELATO CLUB");

        public int TipoTesto { get; set; }
        public string CodiceArticolo { get; set; }
        public EtichettaTesto TestoSelezionato { get; set; }


        public FrmTestiPersonalizzati(MainPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
        }

        private void FrmTestiPersonalizzati_Load(object sender, System.EventArgs e)
        {
            Text = $"{CodiceArticolo} Descrizione {TipoTesto}";
            lblCodiceArticolo.Text = $"CODICE ART: {CodiceArticolo}";
            lblTipoDesc.Text = $"TIPO TESTO: {TipoTesto}";

            btnAddTesto.Enabled = false;
            btnDeleteTesto.Enabled = false;

            SetEtichettaTesto(null);

            LoadTesti();
        }

        private void LoadTesti()
        {
            bndEtichetteTesti.DataSource = _presenter.GetTesti(TipoTesto, CodiceArticolo);
        }

        private void SetEtichettaTesto(EtichettaTesto testo)
        {
            TestoSelezionato = testo;

            btnAddTesto.Enabled = TestoSelezionato != null;
            btnDeleteTesto.Enabled = TestoSelezionato != null;

            txDescrizioneBreve.Text = TestoSelezionato?.DescrizioneBreve ?? null;
            txDescrizioneCompleta.Text = TestoSelezionato?.DescrizioneCompleta ?? null;
        }

        private void txDescrizioni_TextChanged(object sender, System.EventArgs e)
        {
            btnAddTesto.Enabled = txDescrizioneBreve.Text.Length != 0 && txDescrizioneCompleta.Text.Length != 0;
        }

        private void btnChiudi_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAddTesto_Click(object sender, System.EventArgs e)
        {
            if (TestoSelezionato == null)
            {
                TestoSelezionato = new EtichettaTesto();
            }

            TestoSelezionato.CodiceArticolo = CodiceArticolo;
            TestoSelezionato.Tipo = TipoTesto;
            TestoSelezionato.DescrizioneBreve = txDescrizioneBreve.Text;
            TestoSelezionato.DescrizioneCompleta = txDescrizioneCompleta.Text;

            _presenter.SalvaEtichettaTesto(TestoSelezionato);

            LoadTesti();

            SetEtichettaTesto(null);
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridView view = grid.Views[0] as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            view.SelectRow(hitInfo.RowHandle);

            if ((e.Button & MouseButtons.Left) != 0 & hitInfo.InRow & !view.IsGroupRow(hitInfo.RowHandle))
            {
                if (view.GetSelectedRows().Length == 1)
                {
                    SetEtichettaTesto((EtichettaTesto)view.GetRow(hitInfo.RowHandle));
                }
            }
        }

        private void btnDeleteTesto_Click(object sender, System.EventArgs e)
        {
            var response = _msg.Question("Confermi la cancellazione del testo selezionato ?");

            if (response == DialogResult.Yes)
            {
                _presenter.CancellaEtichettaTesto(TestoSelezionato);

                LoadTesti();

                SetEtichettaTesto(null);
            }
        }
    }
}
