using DevExpress.XtraEditors;

using DotSpExtensions;

using ShellDotSp.Plugin.GelatoClubLblDesigner.Presenters;

using System;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ShellDotSp.Plugin.GelatoClubLblDesigner.Forms
{
    public partial class FrmEtichetta : XtraForm
    {
        private readonly MainPresenter _presenter;
        private readonly ErrorProvider _errorProvider;

        public string Codice { get; set; }
        public string StrutturaGs1 { get; set; }
        public string Note { get; set; }

        public FrmEtichetta(MainPresenter presenter)
        {
            InitializeComponent();

            _presenter = presenter;

            components = components ?? new Container();
            _errorProvider = new ErrorProvider(components)
            {
                ContainerControl = this,
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };
            _errorProvider.SetIconAlignment(txCodice, ErrorIconAlignment.MiddleRight);
            _errorProvider.SetIconAlignment(txStrutturaGs1, ErrorIconAlignment.MiddleRight);

            txCodice.Validating += TxCodice_Validating;
            txCodice.EditValueChanged += TxCodice_EditValueChanged;
            txStrutturaGs1.EditValueChanged += TxStrutturaGs1_EditValueChanged;

            btnAnnulla.CausesValidation = false;

            AggiornaConferma();
        }

        public static bool TryValidaCodice(string codice, out string errore)
        {
            errore = null;
            if (string.IsNullOrWhiteSpace(codice))
                errore = "Inserire il codice dell'etichetta.";
            else if (codice.Length > 50)
                errore = "Il codice non può superare 50 caratteri.";
            else if (codice.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                errore = "Il codice contiene caratteri non ammessi in un nome di file (ad esempio: < > : \" / \\ | ? *).";
            else if (codice.EndsWith(".", StringComparison.Ordinal) || codice.EndsWith(" ", StringComparison.Ordinal))
                errore = "Il codice non può terminare con un punto o uno spazio.";
            else if (codice.EndsWith(".repx", StringComparison.OrdinalIgnoreCase))
                errore = "Inserire il codice senza l'estensione .repx: viene aggiunta automaticamente.";
            else
            {
                // Windows riserva questi nomi anche quando sono seguiti da un'estensione.
                string nomeBase = codice.Split('.')[0].TrimEnd(' ');
                if (Regex.IsMatch(nomeBase, @"\A(CON|PRN|AUX|NUL|CONIN\$|CONOUT\$|COM[1-9¹²³]|LPT[1-9¹²³])\z",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
                    errore = "Il codice è un nome riservato da Windows. Scegliere un altro codice.";
            }

            return errore == null;
        }

        public bool ValidaCodice()
        {
            bool valido = TryValidaCodice(txCodice.Text, out string errore);

            SetErrore(txCodice, errore);

            AggiornaConferma();

            return valido;
        }

        private void TxCodice_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !ValidaCodice();
        }

        private void TxCodice_EditValueChanged(object sender, EventArgs e)
        {
            ValidaCodice();
        }

        private void AggiornaConferma()
        {
            bool codicePresente = Obbligatorio(txCodice);
            bool codiceValido = TryValidaCodice(txCodice.Text, out string erroreCodice);
            if (codicePresente)
                SetErrore(txCodice, erroreCodice);

            bool strutturaPresente = Obbligatorio(txStrutturaGs1);
            btnConferma.Enabled = codicePresente && codiceValido && strutturaPresente;
        }

        private void TxStrutturaGs1_EditValueChanged(object sender, EventArgs e)
        {
            AggiornaConferma();
        }

        private void SetErrore(BaseEdit editor, string errore)
        {
            // L'icona esterna lascia invariato lo spazio per il testo nell'editor.
            editor.ErrorText = string.Empty;
            _errorProvider.SetError(editor, errore ?? string.Empty);
        }

        private bool Obbligatorio(BaseEdit editor, bool maggioreDiZero = false)
        {
            var value = editor.EditValue;

            if (value == null ||
                value == DBNull.Value ||
                string.IsNullOrWhiteSpace(value.ToString()))
            {
                SetErrore(editor, "Campo obbligatorio.");
                return false;
            }

            if (maggioreDiZero)
            {
                if (!decimal.TryParse(value.ToString(), out var numero))
                {
                    SetErrore(editor, "Inserire un numero valido.");
                    return false;
                }

                if (numero <= 0)
                {
                    SetErrore(editor, "Inserire un numero maggiore di zero.");
                    return false;
                }
            }

            SetErrore(editor, null);
            return true;
        }

        private void FrmEtichetta_Load(object sender, EventArgs e)
        {
            if (StrutturaGs1.IsNotNull())
            {
                txStrutturaGs1.Text = StrutturaGs1.ToDb();
            }
            else
            {
                txStrutturaGs1.Text = "01-15-37#-10";
            }

            txCodice.Text = Codice.ToDb();
            txCodice.Enabled = Codice.IsNull();
            txNote.Text = Note.ToDb();


            AggiornaConferma();
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            Codice = txCodice.Text.ToDb();
            StrutturaGs1 = txStrutturaGs1.Text.ToDb();
            Note = txNote.Text.ToDb();

            DialogResult = DialogResult.OK;
        }
    }
}


