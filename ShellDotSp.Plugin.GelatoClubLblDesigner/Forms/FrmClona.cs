using DevExpress.XtraEditors;

using ShellDotSp.Plugin.GelatoClubLblDesigner.Presenters;

using System.Windows.Forms;

namespace ShellDotSp.Plugin.GelatoClubLblDesigner.Forms
{
    public partial class FrmClona : XtraForm
    {
        private readonly MainPresenter _presenter;

        public string CodicePrecedente { get; set; }
        public string CodiceNuovo { get; set; }

        public FrmClona(MainPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
        }

        private void FrmClona_Load(object sender, System.EventArgs e)
        {
            txCodicePrecedente.Text = CodicePrecedente;
            btnConferma.Enabled = false;
        }

        private void txCodiceNuovo_TextChanged(object sender, System.EventArgs e)
        {
            btnConferma.Enabled = !string.IsNullOrWhiteSpace(txCodiceNuovo.Text) && txCodiceNuovo.Text != CodicePrecedente;
        }

        private void btnConferma_Click(object sender, System.EventArgs e)
        {
            CodiceNuovo = txCodiceNuovo.Text;

            DialogResult = DialogResult.OK;
        }

        private void btnAnnulla_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmClona_Activated(object sender, System.EventArgs e)
        {
            txCodiceNuovo.Focus();
        }
    }
}
