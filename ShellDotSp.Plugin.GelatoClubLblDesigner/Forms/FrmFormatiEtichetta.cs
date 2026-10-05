using DevExpress.XtraEditors;

using ShellDotSp.Plugin.GelatoClubCore.Model;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Presenters;

using System.Windows.Forms;

namespace ShellDotSp.Plugin.GelatoClubLblDesigner.Forms
{
    public partial class FrmFormatiEtichetta : XtraForm
    {
        public int Larghezza { get; set; }
        public int Altezza { get; set; }

        private readonly MainPresenter _presenter;

        public FrmFormatiEtichetta(MainPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            btnConferma.Enabled = false;
        }

        private void FrmFormatiEtichetta_Load(object sender, System.EventArgs e)
        {
            btnConferma.Enabled = false;

            bndFormati.DataSource = _presenter.LoadFormati();
            btnConferma.Enabled = TryGetFormatoValido(out _);
        }

        private void lkFormati_EditValueChanged(object sender, System.EventArgs e)
        {
            btnConferma.Enabled = TryGetFormatoValido(out _);
        }

        private bool TryGetFormatoValido(out TabellaLookUp formato)
        {
            formato = lkFormati.GetSelectedDataRow() as TabellaLookUp;
            return formato != null
                && formato.CodiceNumerico > 0
                && formato.ValoreNum1 > 0
                && formato.ValoreNum1 <= int.MaxValue
                && formato.ValoreNum1 == decimal.Truncate(formato.ValoreNum1);
        }

        private void btnConferma_Click(object sender, System.EventArgs e)
        {
            if (TryGetFormatoValido(out var formatoSelezionato))
            {
                Larghezza = formatoSelezionato.CodiceNumerico;
                Altezza = (int)formatoSelezionato.ValoreNum1;

                DialogResult = DialogResult.OK;
            }
            else
            {
                btnConferma.Enabled = false;
            }
        }

        private void btnAnnulla_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
