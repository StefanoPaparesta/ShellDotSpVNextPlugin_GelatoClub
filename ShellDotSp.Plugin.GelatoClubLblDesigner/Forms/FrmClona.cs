using DevExpress.XtraEditors;

using ShellDotSp.Plugin.GelatoClubLblDesigner.Presenters;

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ShellDotSp.Plugin.GelatoClubLblDesigner.Forms
{
    public partial class FrmClona : XtraForm
    {
        private readonly MainPresenter _presenter;
        private readonly ErrorProvider _errorProvider;

        public string CodicePrecedente { get; set; }
        public string CodiceNuovo { get; set; }

        public FrmClona(MainPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;

            components = components ?? new Container();
            _errorProvider = new ErrorProvider(components)
            {
                ContainerControl = this,
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };
            _errorProvider.SetIconAlignment(txCodiceNuovo, ErrorIconAlignment.MiddleRight);

            btnAnnulla.CausesValidation = false;
        }

        private void FrmClona_Load(object sender, System.EventArgs e)
        {
            txCodicePrecedente.Text = CodicePrecedente;
            btnConferma.Enabled = false;
        }

        private void txCodiceNuovo_TextChanged(object sender, System.EventArgs e)
        {
            ValidaCodiceNuovo();
        }

        private bool ValidaCodiceNuovo()
        {
            bool valido = FrmEtichetta.TryValidaCodice(txCodiceNuovo.Text, out string errore);

            if (valido && string.Equals(txCodiceNuovo.Text.Trim(), CodicePrecedente?.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                valido = false;
                errore = "Il nuovo codice deve essere diverso da quello dell'etichetta originale.";
            }

            txCodiceNuovo.ErrorText = string.Empty;
            _errorProvider.SetError(txCodiceNuovo, errore ?? string.Empty);
            btnConferma.Enabled = valido;

            return valido;
        }

        private void btnConferma_Click(object sender, System.EventArgs e)
        {
            if (!ValidaCodiceNuovo())
                return;

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
