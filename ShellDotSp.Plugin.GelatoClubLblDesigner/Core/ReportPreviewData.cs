using ShellDotSp.Plugin.GelatoClubCore.Model;

using System;

namespace ShellDotSp.Plugin.GelatoClubLblDesigner.Core
{
    internal static class ReportPreviewData
    {
        public static object Create()
        {
            // Dati dimostrativi: barcode e valori principali ripresi dall'esempio Rivareno.
            return new ReportDataCollection
            {
                new ReportData
                {
                    CodiceArticolo = "DEMO-001",
                    DescrizioneArticolo = "Base gelato FIORDIPANNA",
                    UM = "L",
                    DescrUM = "Litri",
                    Barcode = "38054701210056",
                    CodiceBarcode = "0138054701210056152712053712#10278",
                    Tipo = "DEMO",
                    QtaxPallet = 60,
                    DivisoreGs1 = 1,
                    IdentificatoreSSCC = "00",
                    EstensioneSSCC = "0",
                    PrefissoAzGs1 = "3805470",
                    MesiValiditaLotto = 12,
                    ScadenzaAFineMese = "N",
                    DescrCommercialeITA = "Base gelato FIORDIPANNA",
                    DescrLegaleITA = "Miscela gelato UHT per la produzione di gelato",
                    DescrCommercialeINGLESE = "UHT ice cream mix gelato production",
                    DescrCommercialeFRANCESE = "Mélange UHT pour la production de glace",
                    DescrCommercialeSPAGNOLO = "Producto UHT para la elaboración de helados",
                    DescrCommercialeTEDESCO = "UHT-Mischung für die Speiseeisherstellung",
                    DescrCommercialeXXX = "UHT ice cream mix",
                    QuantBarcode = 12,
                    VolUMP = "12 L",
                    DataScadenza = new DateTime(2027, 12, 5),
                    Lotto = "278",
                    Descrizione1 = "Descrizione 1",
                    Descrizione2 = "Descrizione 2"
                }
            };
        }
    }
}
