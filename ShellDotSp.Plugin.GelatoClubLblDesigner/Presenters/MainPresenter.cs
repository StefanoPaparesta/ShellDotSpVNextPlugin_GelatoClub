using ShellDotSp.Core.Base;
using ShellDotSp.Core.Model;
using ShellDotSp.Plugin.GelatoClubCore.Config;
using ShellDotSp.Plugin.GelatoClubCore.Model;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Core;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Interfaces;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ShellDotSp.Plugin.GelatoClubLblDesigner.Presenters
{
    public class MainPresenter : Presenter<IMainView>
    {

        public List<RepositoryEtichetta> Etichette { get; set; } = new List<RepositoryEtichetta>();
        public RepositoryEtichetta EtichettaSelezionata { get; set; }
        private CfgPlugin _cfg = CfgPlugin.Instance;
        private readonly ApplicationPaths _paths = ApplicationPaths.Instance;

        public MainPresenter(IMainView View) : base(View)
        {

        }

        protected override void CloseView(object sender, EventArgs e)
        {
            Dispose();
        }

        protected override void ViewInitialized(object sender, EventArgs e)
        {
            Log.Info("MainPresenter.ViewInitialized");

            SetEtichetta(null);

            LoadEtichette();
        }

        public void LoadEtichette()
        {
            string sql = "SELECT Id, Codice, Descrizione, Versione, StrutturaGs1 FROM RepositoryEtichette ORDER BY Id";
            Etichette = Repository.Query<RepositoryEtichetta>(sql).ToList();

            View.UpdateUI(MessaggioPlugin.EtichetteCaricate);
        }

        // Importazione temporanea dei layout esistenti; non modifica i file originali.
        public int ImportaEtichetteDaFile()
        {
            if (string.IsNullOrWhiteSpace(_cfg.RepositoryEtichette))
                throw new InvalidOperationException("Il repository delle etichette non è configurato.");

            if (!Directory.Exists(_cfg.RepositoryEtichette))
                throw new DirectoryNotFoundException("La cartella del repository delle etichette non esiste: " + _cfg.RepositoryEtichette);

            var files = Directory.GetFiles(_cfg.RepositoryEtichette, "*", SearchOption.TopDirectoryOnly)
                .Where(file => string.Equals(Path.GetExtension(file), ".repx", StringComparison.OrdinalIgnoreCase))
                .OrderBy(file => file, StringComparer.OrdinalIgnoreCase)
                .ToArray();
            int importate = 0;

            Repository.StartConversation();

            try
            {
                var codiciEsistenti = new HashSet<string>(
                    Repository.Query<RepositoryEtichetta>("SELECT Codice FROM RepositoryEtichette")
                        .Select(etichetta => etichetta.Codice),
                    StringComparer.OrdinalIgnoreCase);

                foreach (string file in files)
                {
                    string codice = Path.GetFileNameWithoutExtension(file);

                    if (codiciEsistenti.Contains(codice))
                        continue;

                    Repository.Insert(new RepositoryEtichetta
                    {
                        Codice = codice,
                        Descrizione = codice,
                        StrutturaGs1 = "01-15-37#-10",
                        Versione = 1,
                        Layout = File.ReadAllBytes(file)
                    });

                    codiciEsistenti.Add(codice);

                    importate++;
                }

                Repository.StopConversation();
            }
            catch
            {
                Repository.AbortConversation();
                throw;
            }

            LoadEtichette();

            return importate;
        }

        internal RepositoryEtichetta CaricaEtichettaSelezionata()
        {
            if (EtichettaSelezionata == null)
                throw new InvalidOperationException("Selezionare un'etichetta.");

            var timer = Stopwatch.StartNew();
            var etichetta = Repository.Query<RepositoryEtichetta>(
                "SELECT * FROM RepositoryEtichette WHERE Id=@0", EtichettaSelezionata.Id).SingleOrDefault();
            Log.Info($"Apertura designer: lettura DB {timer.ElapsedMilliseconds} ms, layout {etichetta?.Layout?.Length ?? 0} byte.");
            if (etichetta == null)
                throw new InvalidOperationException("L'etichetta selezionata non esiste più nel database.");

            return etichetta;
        }

        internal void SalvaLayoutEtichetta(RepositoryEtichetta etichetta, byte[] layout, int? versioneConfermata = null)
        {
            if (etichetta == null)
                throw new ArgumentNullException(nameof(etichetta));
            if (layout == null || layout.Length == 0)
                throw new ArgumentException("Il layout dell'etichetta è vuoto.", nameof(layout));

            int nuovaVersione;
            Repository.StartConversation();
            try
            {
                var corrente = Repository.Query<RepositoryEtichetta>(
                    "SELECT Id, Versione FROM RepositoryEtichette WITH (UPDLOCK, HOLDLOCK) WHERE Id=@0",
                    etichetta.Id).SingleOrDefault();
                if (corrente == null)
                    throw new InvalidOperationException("L'etichetta non esiste più nel database.");
                if (corrente.Versione != (versioneConfermata ?? etichetta.Versione))
                    throw new ConflittoVersioneEtichettaException(etichetta.Versione, corrente.Versione);

                nuovaVersione = checked(corrente.Versione + 1);
                Repository.Execute(
                    "UPDATE RepositoryEtichette SET Layout=@0, Versione=@1 WHERE Id=@2",
                    layout, nuovaVersione, etichetta.Id);
                Repository.StopConversation();
            }
            catch
            {
                Repository.AbortConversation();
                throw;
            }

            etichetta.Layout = layout;
            etichetta.Versione = nuovaVersione;
        }

        internal sealed class ConflittoVersioneEtichettaException : InvalidOperationException
        {
            public int VersioneAperta { get; }
            public int VersioneCorrente { get; }

            public ConflittoVersioneEtichettaException(int versioneAperta, int versioneCorrente)
                : base("Un altro utente ha salvato una versione più recente dell'etichetta.")
            {
                VersioneAperta = versioneAperta;
                VersioneCorrente = versioneCorrente;
            }
        }

        internal void SetEtichetta(RepositoryEtichetta etichetta)
        {
            EtichettaSelezionata = etichetta;

            View.UpdateUI(MessaggioPlugin.EtichettaSelezionata);
        }

        internal void GestisciEtichetta(RepositoryEtichetta etichetta)
        {
            if (etichetta == null)
                throw new ArgumentNullException(nameof(etichetta));

            if (etichetta.Id == 0)
            {
                Repository.Insert(etichetta);
            }
            else
            {
                // I metadati provengono dall'elenco, che non carica il layout.
                Repository.Execute(
                    "UPDATE RepositoryEtichette SET Codice=@0, Descrizione=@1, StrutturaGs1=@2 WHERE Id=@3",
                    etichetta.Codice, etichetta.Descrizione, etichetta.StrutturaGs1, etichetta.Id);
            }
        }

        internal void CancellaEtichettaSelezionata()
        {

            try
            {
                Repository.StartConversation();

                string sql = "DELETE FROM RepositoryEtichette WHERE Id=@0";
                Repository.Execute(sql, EtichettaSelezionata.Id);

                string fileNameRepository = Path.Combine(_cfg.RepositoryEtichette, EtichettaSelezionata.Codice + ".repx");
                string fileNameLayout = Path.Combine(_paths.Etichette, EtichettaSelezionata.Codice + ".repx");

                if (File.Exists(fileNameRepository))
                    File.Delete(fileNameRepository);

                if (File.Exists(fileNameLayout))
                    File.Delete(fileNameLayout);

                Repository.StopConversation();
            }
            catch
            {
                Repository.AbortConversation();

                throw;
            }


        }

        internal List<TabellaLookUp> LoadFormati()
        {
            string sql = "SELECT * FROM TabellaLookUp WHERE Tabella=@0 ORDER BY Id";

            return Repository.Query<TabellaLookUp>(sql, "FormatiEtichette").ToList();
        }

        internal void ClonaEtichetta(string codiceNuovo)
        {
            if (EtichettaSelezionata == null)
                throw new InvalidOperationException("Selezionare un'etichetta da clonare.");

            if (!Forms.FrmEtichetta.TryValidaCodice(codiceNuovo, out string erroreCodice))
                throw new ArgumentException(erroreCodice, nameof(codiceNuovo));

            codiceNuovo = codiceNuovo.Trim();

            Repository.StartConversation();

            try
            {
                var originale = Repository.Query<RepositoryEtichetta>(
                    "SELECT * FROM RepositoryEtichette WHERE Id=@0", EtichettaSelezionata.Id).SingleOrDefault();
                if (originale == null)
                    throw new InvalidOperationException("L'etichetta da clonare non esiste più nel database.");
                if (Repository.Query<RepositoryEtichetta>(
                    "SELECT Id FROM RepositoryEtichette WITH (UPDLOCK, HOLDLOCK) WHERE Codice=@0", codiceNuovo).Any())
                    throw new InvalidOperationException("Esiste già un'etichetta con il codice indicato.");

                Repository.Insert(new RepositoryEtichetta
                {
                    Codice = codiceNuovo,
                    Descrizione = originale.Descrizione,
                    StrutturaGs1 = originale.StrutturaGs1,
                    Layout = originale.Layout,
                    Versione = originale.Layout != null && originale.Layout.Length > 0 ? 1 : 0
                });
                Repository.StopConversation();
            }
            catch
            {
                Repository.AbortConversation();
                throw;
            }
        }
    }
}
