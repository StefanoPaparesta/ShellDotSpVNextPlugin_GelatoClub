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

        public List<EtichettaTesto> Testi1 = new List<EtichettaTesto>();
        public List<LookUpdataTesto> TestiStandard1 = new List<LookUpdataTesto>();
        public List<EtichettaTesto> Testi2 = new List<EtichettaTesto>();
        public List<LookUpdataTesto> TestiStandard2 = new List<LookUpdataTesto>();
        public List<Etichetta> Etichette { get; set; }
        public EtichettaPersonalizzata EtichettaSelezionata { get; set; }

        public EtichettaTesto Testo1Selezionato { get; set; }
        public EtichettaTesto Testo2Selezionato { get; set; }

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

            TestiStandard1 = Repository.Query<TabellaLookUp>(sql, "TestiStandard1")
                .Select(x => new LookUpdataTesto
                {
                    Id = x.Id,
                    Codice = x.Codice,
                    CodiceNumerico = x.CodiceNumerico,
                    DescrizioneBreve = x.Valore,
                    DescrizioneCompleta = x.ValoreStr1
                })
                .ToList();


            TestiStandard2 = Repository.Query<TabellaLookUp>(sql, "TestiStandard2")
                 .Select(x => new LookUpdataTesto
                 {
                     Id = x.Id,
                     Codice = x.Codice,
                     CodiceNumerico = x.CodiceNumerico,
                     DescrizioneBreve = x.Valore,
                     DescrizioneCompleta = x.ValoreStr1
                 })
                .ToList();

            Etichette = Repository.Query<TabellaLookUp>(sql, "Etichette")
               .Select(x => new Etichetta
               {
                   Id = x.Id,
                   Codice = x.Codice,
                   Valore = x.Valore,
                   ValoreStr1 = x.ValoreStr1
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

            EtichettaTesto testo1Stampa = null;
            EtichettaTesto testo2Stampa = null;
            string layoutEtichetta = null;

            var (testo1, testo2, continuaTesti) = GestisciTestiPers();

            if (!continuaTesti)
            {
                returnValue.Status = ReturnValueStatus.Error;
                returnValue.StatusMessage = $"Errore gestione testi personalizzati";

                return returnValue;
            }
            else
            {
                testo1Stampa = Testi1.Where(c => c.Id == testo1.IdTesto).SingleOrDefault();
                testo2Stampa = Testi2.Where(c => c.Id == testo2.IdTesto).SingleOrDefault();
            }

            var (etichettaPers, continuaEtichettaPers) = GestisciEtichettePers();

            if (!continuaTesti)
            {
                returnValue.Status = ReturnValueStatus.Error;
                returnValue.StatusMessage = $"Errore gestione etichetta personalizzata";

                return returnValue;
            }
            else
            {
                layoutEtichetta = etichettaPers.CodiceLayout;
            }

            try
            {


                string sql = "SELECT * FROM dbo.TabellaLookUp WHERE Tabella=@0 AND Codice=@1";
                TabellaLookUp stampante = Repository.Query<TabellaLookUp>(sql, "Stampanti", LineaSelezionata.Codice).SingleOrDefault();

                Log.Info("Stampante associata alla linea: {stampante}", stampante != null ? stampante.Valore : "Nessuna");


                var etichettaReale = Etichette
                    .Where(c => c.Codice == layoutEtichetta)
                    .SingleOrDefault();

                if (etichettaReale == null)
                {
                    returnValue.Status = ReturnValueStatus.Error;
                    returnValue.StatusMessage = $"Errore ricerca etichetta reale";

                    return returnValue;
                }

                CalcoloDataScadenza(CalcoloScadenza.Mesi, ArticoloSelezionato.MesiValiditaLotto, ArticoloSelezionato.ScadenzaAFineMese == "S");

                CalcolaCodiceBarcode(etichettaReale.ValoreStr1);

                ReportData reportData = ReportDataMapper.ToReportData(ArticoloSelezionato);
                reportData.Lotto = Lotto;
                reportData.DataScadenza = DataScadenza;
                reportData.CodiceBarcode = CodiceBarcode;
                reportData.Descrizione1 = testo1Stampa.DescrizioneCompleta;
                reportData.Descrizione2 = testo2Stampa.DescrizioneCompleta;

                string fileName = Path.Combine(_paths.Etichette, $"{etichettaReale.Valore}.repx");

                if (File.Exists(fileName))
                {
                    List<ReportData> ds = new List<ReportData> { reportData };

                    using (XtraReport report = new XtraReport())
                    {

                        report.LoadLayout(fileName);
                        report.DataSource = ds;
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
            if (ArticoloSelezionato != null)
            {
                CalcoloDataScadenza(CalcoloScadenza.Mesi, ArticoloSelezionato.MesiValiditaLotto, ArticoloSelezionato.ScadenzaAFineMese == "S");
            }

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

        internal void GetTesti()
        {
            string sqlGetTesti = "SELECT * FROM EtichetteTesti WHERE CodiceArticolo=@0 AND Tipo=@1 ORDER BY Id";

            var testi1 = Repository.Query<EtichettaTesto>(sqlGetTesti, ArticoloSelezionato.CodiceArticolo, 1).ToList();

            var testi2 = Repository.Query<EtichettaTesto>(sqlGetTesti, ArticoloSelezionato.CodiceArticolo, 2).ToList();

            Testi1.Clear();
            Testi2.Clear();

            Testi1.AddRange(TestiStandard1.Select(x => new EtichettaTesto
            {
                Id = x.CodiceNumerico,
                CodiceArticolo = null,
                DescrizioneBreve = x.DescrizioneBreve,
                DescrizioneCompleta = x.DescrizioneCompleta
            })
            .ToList());
            Testi1.AddRange(testi1);

            Testi2.AddRange(TestiStandard2.Select(x => new EtichettaTesto
            {
                Id = x.CodiceNumerico,
                CodiceArticolo = null,
                DescrizioneBreve = x.DescrizioneBreve,
                DescrizioneCompleta = x.DescrizioneCompleta
            })
           .ToList());
            Testi2.AddRange(testi2);

            View.UpdateUI(MessaggioPlugin.TestiInizializzati);
        }

        internal void GetEtichetta()
        {
            string sqlGetEtichetta = "SELECT * FROM EtichettePersonalizzate WHERE CodiceArticolo=@0";

            EtichettaSelezionata = Repository
                .Query<EtichettaPersonalizzata>(sqlGetEtichetta, ArticoloSelezionato.CodiceArticolo)
                .SingleOrDefault();

            View.UpdateUI(MessaggioPlugin.EtichettaInizializzata);
        }

        internal List<EtichettaTesto> GetTesti(int tipoTesto, string codiceArticolo)
        {
            List<EtichettaTesto> testi = new List<EtichettaTesto>();

            string sql = "SELECT * FROM EtichetteTesti WHERE CodiceArticolo=@0 AND Tipo=@1 ORDER BY Id";

            testi = Repository.Query<EtichettaTesto>(sql, codiceArticolo, tipoTesto).ToList();

            return testi;
        }

        internal void SetTesto1(EtichettaTesto testo)
        {
            Testo1Selezionato = testo;
        }

        internal void SetTesto2(EtichettaTesto testo)
        {
            Testo2Selezionato = testo;
        }

        internal List<string> VerificaDatiStampa()
        {
            List<string> errors = new List<string>();

            if (Testo1Selezionato == null)
            {
                errors.Add("OBBLIGATORIO SELEZIONARE IL TESTO 1");
            }

            if (Testo2Selezionato == null)
            {
                errors.Add("OBBLIGATORIO SELEZIONARE IL TESTO 2");
            }

            if (EtichettaSelezionata == null)
            {
                errors.Add("OBBLIGATORIO SELEZIONARE IL LAYOUT ETICHETTA");
            }

            return errors;
        }

        internal (int idTesto1, int idTesto2) SelezionaTestiPers()
        {
            int idTesto1 = 0;
            int idTesto2 = 0;

            string verificaTesto = "SELECT * FROM EtichetteTestiPersonalizzati WHERE CodiceArticolo=@0 AND Tipo=@1";

            var testo1 = Repository
                .Query<EtichettaTestoPersonalizzata>(verificaTesto, ArticoloSelezionato.CodiceArticolo, 1)
                .SingleOrDefault();

            var testo2 = Repository
                .Query<EtichettaTestoPersonalizzata>(verificaTesto, ArticoloSelezionato.CodiceArticolo, 2)
                .SingleOrDefault();

            if (testo1 != null)
            {
                idTesto1 = testo1.IdTesto;
            }

            if (testo2 != null)
            {
                idTesto2 = testo2.IdTesto;
            }

            return (idTesto1, idTesto2);
        }

        internal (EtichettaTestoPersonalizzata testo1, EtichettaTestoPersonalizzata testo2, bool continua) GestisciTestiPers()
        {
            bool continua = false;
            EtichettaTestoPersonalizzata testo1 = null;
            EtichettaTestoPersonalizzata testo2 = null;

            try
            {
                string verificaTesto = "SELECT * FROM EtichetteTestiPersonalizzati WHERE CodiceArticolo=@0 AND Tipo=@1";

                testo1 = Repository
                   .Query<EtichettaTestoPersonalizzata>(verificaTesto, ArticoloSelezionato.CodiceArticolo, 1)
                   .SingleOrDefault();

                testo2 = Repository
                   .Query<EtichettaTestoPersonalizzata>(verificaTesto, ArticoloSelezionato.CodiceArticolo, 2)
                   .SingleOrDefault();

                if (testo1 == null)
                {
                    testo1 = new EtichettaTestoPersonalizzata();
                }

                testo1.CodiceArticolo = ArticoloSelezionato.CodiceArticolo;
                testo1.IdTesto = Testo1Selezionato.Id;
                testo1.Tipo = 1;

                if (testo2 == null)
                {
                    testo2 = new EtichettaTestoPersonalizzata();
                }

                testo2.CodiceArticolo = ArticoloSelezionato.CodiceArticolo;
                testo2.IdTesto = Testo2Selezionato.Id;
                testo2.Tipo = 2;

                if (testo1.Id == 0)
                {
                    Repository.Insert(testo1);
                }
                else
                {
                    Repository.Update(testo1);
                }

                if (testo2.Id == 0)
                {
                    Repository.Insert(testo2);
                }
                else
                {
                    Repository.Update(testo2);
                }

                continua = true;
            }
            catch (Exception ex)
            {
                continua = false;

                Log.Error(ex.ToString());
            }

            return (testo1, testo2, continua);
        }

        internal (EtichettaPersonalizzata etichetta, bool continua) GestisciEtichettePers()
        {
            EtichettaPersonalizzata etichetta = null;
            bool continua = false;

            try
            {
                string verificaEtichetta = "SELECT * FROM EtichettePersonalizzate WHERE CodiceArticolo=@0";

                etichetta = Repository
                    .Query<EtichettaPersonalizzata>(verificaEtichetta, ArticoloSelezionato.CodiceArticolo)
                    .SingleOrDefault();

                if (etichetta == null)
                {
                    etichetta = new EtichettaPersonalizzata();
                }

                etichetta.CodiceArticolo = ArticoloSelezionato.CodiceArticolo;
                etichetta.CodiceLayout = EtichettaSelezionata.CodiceLayout;

                if (etichetta.Id == 0)
                {
                    Repository.Insert(etichetta);
                }
                else
                {
                    Repository.Update(etichetta);
                }

                continua = true;
            }
            catch (Exception ex)
            {
                continua = false;

                Log.Error(ex.ToString());
            }

            return (etichetta, continua);
        }

        internal void SalvaEtichettaTesto(EtichettaTesto testoSelezionato)
        {
            try
            {
                if (testoSelezionato.Id == 0)
                {
                    Repository.Insert(testoSelezionato);
                }
                else
                {
                    Repository.Update(testoSelezionato);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }

        internal void CancellaEtichettaTesto(EtichettaTesto testoSelezionato)
        {
            string deleteEtichettaTesto = "DELETE FROM EtichetteTesti WHERE Id=@0";
            string deleteEitchettaTestoPers = "DELETE FROM EtichetteTestiPersonalizzati WHERE IdTesto=@0";

            try
            {
                Repository.StartConversation();

                Repository.Execute(deleteEtichettaTesto, testoSelezionato.Id);
                Repository.Execute(deleteEitchettaTestoPers, testoSelezionato.Id);

                Repository.StopConversation();
            }
            catch (Exception ex)
            {
                Repository.AbortConversation();
                Log.Error(ex.ToString());
            }

        }

        internal bool VerificaEsistenzaTesto(int idTesto, int tipoTesto)
        {
            bool result = false;

            if (tipoTesto == 1)
            {
                result = Testi1.Where(c => c.Id == idTesto).Any();
            }

            if (tipoTesto == 2)
            {
                result = Testi2.Where(c => c.Id == idTesto).Any();
            }

            return result;
        }

        internal void SetEtichetta(EtichettaPersonalizzata etichetta)
        {
            EtichettaSelezionata = etichetta;
        }

        internal void ImnportaTestiDaArticolo(VArticoloGestionale articoloProvenienza)
        {
            string sql = "EXEC stp_importa_testi_personalizzati @0,@1";
            Repository.Execute(sql, articoloProvenienza.CodiceArticolo, ArticoloSelezionato.CodiceArticolo);

            GetTesti();
        }
    }
}