using ShellDotSp.Contract.Plugin;
using ShellDotSp.Plugin.GelatoClubLblDesigner.UI;

using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;

namespace ShellDotSp.Plugin.GelatoClubLblDesigner
{
    [Export(typeof(IPlugin))]
    [ExportMetadata("Codice", "GELCLULBLDESIGNER")]
    [ExportMetadata("Versione", "1.0.0")]
    [ExportMetadata("Descrizione", "Label designer")]
    public class Main : IPlugin
    {

        private static readonly Lazy<MainControlShellLabelDesigner> _instance =
            new Lazy<MainControlShellLabelDesigner>(() => new MainControlShellLabelDesigner());
        private static readonly Lazy<FooterControlShellLabelDesigner> _instanceFooter =
           new Lazy<FooterControlShellLabelDesigner>(() => new FooterControlShellLabelDesigner());

        public Main()
        {
        }

        public string Caption
        {
            get
            {
                return "DESIGNER ETICHETTE";
            }
        }
        public string Title
        {
            get
            {
                return "DESIGNER ETICHETTE";
            }
        }
        public Bitmap Image
        {
            get
            {
                return global::ShellDotSp.Plugin.GelatoClubLblDesigner._48x48.control_ink_picturefilled;
            }
        }

        public bool Authorize => throw new NotImplementedException();

        public bool ShowFooter => false;

        public void Finalizza()
        {
            _instance.Value.Finalizza();
            _instanceFooter.Value.Finalizza();
        }
        public void Inizializza()
        {
            _instance.Value.Inizializza();
            _instanceFooter.Value.Inizializza();
        }

        public UserControl GetControl()
        {
            return _instance.Value;
        }
        public UserControl GetFooterControl()
        {
            return _instanceFooter.Value;
        }

    }
}
