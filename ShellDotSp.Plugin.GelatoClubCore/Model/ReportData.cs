using System;
using System.ComponentModel;

namespace ShellDotSp.Plugin.GelatoClubCore.Model
{
    public class ReportData
    {
        public string CodiceArticolo { get; set; }
        public string DescrizioneArticolo { get; set; }
        public string UM { get; set; }
        public string DescrUM { get; set; }
        public string Barcode { get; set; }
        public string Tipo { get; set; }
        public decimal QtaxPallet { get; set; }
        public decimal? DivisoreGs1 { get; set; }
        public string IdentificatoreSSCC { get; set; }
        public string EstensioneSSCC { get; set; }
        public string PrefissoAzGs1 { get; set; }
        public int MesiValiditaLotto { get; set; }
        public string ScadenzaAFineMese { get; set; }
        public string DescrCommercialeITA { get; set; }
        public string DescrLegaleITA { get; set; }
        public string DescrCommercialeINGLESE { get; set; }
        public string DescrCommercialeFRANCESE { get; set; }
        public string DescrCommercialeSPAGNOLO { get; set; }
        public string DescrCommercialeTEDESCO { get; set; }
        public string DescrCommercialeXXX { get; set; }
        public decimal QuantBarcode { get; set; }
        public string VolUMP { get; set; }

        public DateTime DataScadenza { get; set; }
        public string Lotto { get; set; }
        public string CodiceBarcode { get; set; }
    }
    public class ReportDataCollection : BindingList<ReportData> { }
}
