using DevExpress.XtraReports.UI;

using NPoco;

using ShellDotSp.Core.Base;
using ShellDotSp.Core.Model;
using ShellDotSp.Plugin.GelatoClubCore.Barcode;
using ShellDotSp.Plugin.GelatoClubCore.Helpers;
using ShellDotSp.Plugin.GelatoClubCore.Model;
using ShellDotSp.Plugin.GelatoClubProduzione.Core;
using ShellDotSp.Plugin.GelatoClubProduzione.Interfaces;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShellDotSp.Plugin.GelatoClubProduzione.Presenters
{
    public class MainPresenter : Presenter<IMainView>
    {

        public List<LookUpData> Linee { get; set; }
        public LookUpData LineaSelezionata { get; set; }
        public StatoLinea StatoLineaCorrente { get; set; }
        public VArticoloGestionale ArticoloSelezionato { get; set; }
        public string Lotto { get; set; }
        private ApplicationPaths _paths = ApplicationPaths.Instance;
        public DateTime DataConfezionamento { get; set; }
        public DateTime DataScadenza { get; set; }
        public string CodiceBarcode { get; set; }

        public MainPresenter(IMainView View) : base(View)
        {

        }

        protected override void CloseView(object sender, EventArgs e)
        {
            Dispose();
        }
        protected override void ViewInitialized(object sender, EventArgs e)
        {
            LoadData();
            View.UpdateUI(MessaggioPlugin.ViewInizializzata);
        }

        private void LoadData()
        {
            string sql = "SELECT * FROM fnc_get_tabella(@0)";

            Linee = Repository.Query<TabellaLookUp>(sql, "LINEE")
                .Select(x => new LookUpData
                {
                    Id = x.Id,
                    Codice = x.Codice,
                    Descrizione = x.Valore
                })
                .ToList();
        }

        internal void SetLineaSelezionata(LookUpData linea)
        {
            LineaSelezionata = linea;
            View.UpdateUI(MessaggioPlugin.LineaSelezionata);
        }
        internal void SetArticoloSelezionato(VArticoloGestionale articolo)
        {
            ArticoloSelezionato = articolo;
            View.UpdateUI(MessaggioPlugin.ArticoloSelezionato);
        }
        internal void SetDataConfezionamento(DateTime dataConfezionamento)
        {
            DataConfezionamento = dataConfezionamento;
        }

        internal void VerificaStatoLineaCorrente()
        {
            if (LineaSelezionata == null)
                return;

            string sql = "SELECT * FROM StatoLinee WHERE CodiceLinea=@0";

            StatoLineaCorrente = Repository.Query<StatoLinea>(sql, LineaSelezionata.Codice).FirstOrDefault();

            if (StatoLineaCorrente == null)
            {
                StatoLineaCorrente = new StatoLinea
                {
                    CodiceLinea = LineaSelezionata.Codice,
                    Stato = "STOP",
                    CodiceArticolo = null
                };

                Repository.Insert(StatoLineaCorrente);
            }

            View.UpdateUI(MessaggioPlugin.StatoLineaAggiornato);
        }

        public List<VArticoloGestionale> SearchArticoli(string search)
        {
            try
            {
                // campi su cui cercare
                string[] fields =
                {
                "CodiceArticolo",
                "DescrizioneArticolo"
                // aggiungi altri se ti servono
             };

                var sql = new Sql("SELECT * FROM vw_articoli_gestionale WHERE UM=@0 ", "CNF");

                if (!string.IsNullOrWhiteSpace(search))
                {
                    // split su spazi, rimuove doppi spazi
                    var tokens = search
                        .Trim()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var token in tokens)
                    {
                        // per ogni parola: deve comparire in almeno uno dei campi
                        sql.Append("AND (");
                        for (int i = 0; i < fields.Length; i++)
                        {
                            if (i > 0) sql.Append(" OR ");
                            sql.Append($"{fields[i]} LIKE @0", $"%{token}%");
                        }
                        sql.Append(")");
                    }
                }

                sql.Append(" ORDER BY DescrizioneArticolo");

                return Repository.Query<VArticoloGestionale>(sql.SQL, sql.Arguments).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return new List<VArticoloGestionale>();
            }
        }

        internal ReturnValue InviaArticoloInProduzione()
        {
            ReturnValue returnValue = new ReturnValue();

            try
            {
                string etichettaFalback = "Label10x10_001";
                string etichetta = etichettaFalback;

                string sql = "SELECT * FROM dbo.TabellaLookUp WHERE Tabella=@0 AND Codice=@1";
                TabellaLookUp stampante = Repository.Query<TabellaLookUp>(sql, "Stampanti", LineaSelezionata.Codice).SingleOrDefault();

                Log.Info("Stampante associata alla linea: {stampante}", stampante != null ? stampante.Valore : "Nessuna");

                string sqlEtichettaPers = "SELECT * FROM dbo.EtichettePersonalizzate WHERE CodiceArticolo=@0";
                var etichettaPersonalizzata = Repository.Query<EtichettaPersonalizzata>(sqlEtichettaPers, ArticoloSelezionato.CodiceArticolo).SingleOrDefault();

                if (etichettaPersonalizzata != null)
                {
                    etichetta = etichettaPersonalizzata.CodiceLayout;
                }

                string sqlEtichettaReale = "SELECT * FROM dbo.TabellaLookUp WHERE Tabella=@0 AND Codice=@1";
                var etichettaReale = Repository.Query<TabellaLookUp>(sqlEtichettaReale, "Etichette", etichetta).SingleOrDefault();

                CalcoloDataScadenza(CalcoloScadenza.Mesi, ArticoloSelezionato.MesiValiditaLotto, ArticoloSelezionato.ScadenzaAFineMese == "S");

                CalcolaCodiceBarcode(etichettaReale.ValoreStr1);

                ReportData reportData = ReportDataMapper.ToReportData(ArticoloSelezionato);
                reportData.Lotto = Lotto;
                reportData.DataScadenza = DataScadenza;
                reportData.CodiceBarcode = CodiceBarcode;

                string fileName = Path.Combine(_paths.Etichette, $"{etichetta}.repx");

                if (File.Exists(fileName))
                {
                    List<ReportData> ds = new List<ReportData> { reportData };

                    using (XtraReport report = new XtraReport())
                    {

                        report.LoadLayout(fileName);
                        report.DataSource = ds;
                        //report.Print(stampante.Valore);
                        StampaReport(report, 10000, stampante.Valore);
                    }
                }
                else
                {
                    returnValue.Status = ReturnValueStatus.Error;
                    returnValue.StatusMessage = $"File etichetta non trovato: {fileName}";
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                returnValue.Status = ReturnValueStatus.Error;
                returnValue.StatusMessage = $"{ex.Message}";
            }

            SetArticoloSelezionato(null);
            SetLineaSelezionata(null);

            return returnValue;
        }

        private void StampaReport(XtraReport report, short numeroCopie, string nomeStampante)
        {
            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                printTool.PrintingSystem.StartPrint += (s, e) =>
                {
                    e.PrintDocument.PrinterSettings.Copies = numeroCopie;
                };

                printTool.Print(nomeStampante);
            }
        }

        internal void CalcoloDataScadenza(CalcoloScadenza calcoloIn, int tmc, bool fineMese)
        {
            DateTime dataScadenza = DateTime.Today;
            DateTime dataInizio = DataConfezionamento;

            switch (calcoloIn)
            {
                case CalcoloScadenza.Giorni:
                    dataScadenza = dataInizio.AddDays(tmc);
                    break;
                case CalcoloScadenza.Mesi:
                    dataScadenza = dataInizio.AddMonths(tmc);

                    if (fineMese)
                    {
                        dataScadenza = new DateTime(dataScadenza.Year, dataScadenza.Month, DateTime.DaysInMonth(dataScadenza.Year, dataScadenza.Month));
                    }

                    break;
                case CalcoloScadenza.Anni:
                    dataScadenza = dataInizio.AddYears(tmc);
                    break;
            }

            DataScadenza = dataScadenza;
            View.UpdateUI(MessaggioPlugin.DataScadenzaCalcolata);
        }

        internal void CalcolaLotto()
        {
            Lotto = $"{DataConfezionamento.DayOfYear:000}";
            View.UpdateUI(MessaggioPlugin.LottoCalcolato);
        }

        internal void CalcolaCodiceBarcode(string template)
        {
            string[] parts = template.Split('-');
            bool hasFnc = false;
            StringBuilder bld = new StringBuilder();
            string internalPart = string.Empty;

            foreach (var part in parts)
            {
                int idxFnc = part.IndexOf("#", StringComparison.InvariantCultureIgnoreCase);

                hasFnc = idxFnc >= 0;

                if (hasFnc)
                {
                    internalPart = part.Replace("#", string.Empty);
                }
                else
                {
                    internalPart = part;
                }

                switch (internalPart)
                {
                    case "01":
                        var result = Gtin14.NormalizeGtin14(ArticoloSelezionato.Barcode);

                        Log.Info("GTIN14 normalization result for {barcode}: IsValid={isValid}, Gtin14={gtin14}, CheckDigitCalculated={checkDigitCalculated}",
                            ArticoloSelezionato.Barcode, result.IsValid, result.Gtin14, result.CheckDigitCalculated);

                        bld.Append($"01{result.Gtin14}");
                        break;
                    case "37":
                        bld.Append($"37{ArticoloSelezionato.QuantBarcode:f0}");
                        if (hasFnc)
                        {
                            bld.Append("#");
                        }
                        break;
                    case "10":
                        bld.Append($"10{Lotto}");
                        if (hasFnc)
                        {
                            bld.Append("#");
                        }
                        break;
                    case "15":
                        bld.Append($"15{DataScadenza:yyMMdd}");
                        break;
                }
            }

            CodiceBarcode = bld.ToString();
        }
    }
}