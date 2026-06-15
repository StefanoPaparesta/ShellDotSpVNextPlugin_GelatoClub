using ShellDotSp.Contract.Plugin;
using ShellDotSp.Plugin.GelatoClubProduzione.UI;

using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;

namespace ShellDotSp.Plugin.DePetrisPacchi
{
    [Export(typeof(IPlugin))]
    [ExportMetadata("Codice", "GELCLUPROD")]
    [ExportMetadata("Versione", "1.0.0")]
    [ExportMetadata("Descrizione", "Produzione")]
    public class Main : IPlugin
    {

        private static readonly Lazy<MainControlGelatoClubProduzione> _instance =
            new Lazy<MainControlGelatoClubProduzione>(() => new MainControlGelatoClubProduzione());
        private static readonly Lazy<FooterControlGelatoClubProduzione> _instanceFooter =
           new Lazy<FooterControlGelatoClubProduzione>(() => new FooterControlGelatoClubProduzione());

        public Main()
        {

        }

        public string Caption
        {
            get
            {
                return "ETICHETTE";
            }
        }
        public string Title
        {
            get
            {
                return "ETICHETTE";
            }
        }
        public Bitmap Image
        {
            get
            {
                return global::ShellDotSp.Plugin.GelatoClubProduzione._48x48.hand_delivery_filled;
            }
        }

        public bool Authorize => throw new NotImplementedException();

        public bool ShowFooter => true;

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
