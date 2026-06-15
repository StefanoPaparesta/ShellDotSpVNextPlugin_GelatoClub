using ShellDotSp.Plugin.GelatoClubCore.Model;

namespace ShellDotSp.Plugin.GelatoClubCore.Helpers
{
    public static class ReportDataMapper
    {
        public static ReportData ToReportData(this VArticoloGestionale src)
        {
            if (src == null) return null;

            return new ReportData
            {
                CodiceArticolo = src.CodiceArticolo,
                DescrizioneArticolo = src.DescrizioneArticolo,
                UM = src.UM,
                DescrUM = src.DescrUM,
                Barcode = src.Barcode,
                Tipo = src.Tipo,
                QtaxPallet = src.QtaxPallet,
                DivisoreGs1 = src.DivisoreGs1,
                IdentificatoreSSCC = src.IdentificatoreSSCC,
                EstensioneSSCC = src.EstensioneSSCC,
                PrefissoAzGs1 = src.PrefissoAzGs1,
                MesiValiditaLotto = src.MesiValiditaLotto,
                ScadenzaAFineMese = src.ScadenzaAFineMese,
                DescrCommercialeITA = src.DescrCommercialeITA,
                DescrLegaleITA = src.DescrLegaleITA,
                DescrCommercialeINGLESE = src.DescrCommercialeINGLESE,
                DescrCommercialeFRANCESE = src.DescrCommercialeFRANCESE,
                DescrCommercialeSPAGNOLO = src.DescrCommercialeSPAGNOLO,
                DescrCommercialeTEDESCO = src.DescrCommercialeTEDESCO,
                DescrCommercialeXXX = src.DescrCommercialeXXX,
                VolUMP = src.VolUMP,
                QuantBarcode = src.QuantBarcode
            };
        }
    }
}
