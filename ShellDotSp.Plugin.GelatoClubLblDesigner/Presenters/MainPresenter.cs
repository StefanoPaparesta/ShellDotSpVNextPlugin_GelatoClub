using ShellDotSp.Core.Base;
using ShellDotSp.Core.Model;
using ShellDotSp.Plugin.GelatoClubCore.Config;
using ShellDotSp.Plugin.GelatoClubCore.Model;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Core;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Interfaces;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShellDotSp.Plugin.GelatoClubLblDesigner.Presenters
{
    public class MainPresenter : Presenter<IMainView>
    {

        public List<TabellaLookUp> Etichette { get; set; } = new List<TabellaLookUp>();
        public TabellaLookUp EtichettaSelezionata { get; set; }
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
            string sql = "SELECT * FROM TabellaLookUp WHERE Tabella=@0 ORDER BY Id";
            Etichette = Repository.Query<TabellaLookUp>(sql, "Etichette").ToList();

            View.UpdateUI(MessaggioPlugin.EtichetteCaricate);
        }

        internal string GetFileEtichettaSelezionata()
        {
            if (EtichettaSelezionata == null || string.IsNullOrWhiteSpace(EtichettaSelezionata.Codice))
                throw new InvalidOperationException("Selezionare un'etichetta con un codice valido.");

            if (string.IsNullOrWhiteSpace(_cfg.RepositoryEtichette))
                throw new InvalidOperationException("Il repository delle etichette non è configurato.");

            string fileName = Path.Combine(_cfg.RepositoryEtichette, EtichettaSelezionata.Codice + ".repx");

            return fileName;
        }

        internal void CopiaEtichettaSalvata(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName) ||
                !string.Equals(Path.GetExtension(fileName), ".repx", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Il file dell'etichetta deve essere un REPX.", nameof(fileName));

            if (string.IsNullOrWhiteSpace(_paths.Etichette))
                throw new InvalidOperationException("La cartella delle etichette non è configurata.");

            string sourcePath = Path.GetFullPath(fileName);
            string destinationPath = Path.GetFullPath(Path.Combine(_paths.Etichette, Path.GetFileName(fileName)));

            if (string.Equals(sourcePath, destinationPath, StringComparison.OrdinalIgnoreCase))
                return;

            Directory.CreateDirectory(_paths.Etichette);
            File.Copy(sourcePath, destinationPath, overwrite: true);
        }

        internal void SetEtichetta(TabellaLookUp etichetta)
        {
            EtichettaSelezionata = etichetta;

            View.UpdateUI(MessaggioPlugin.EtichettaSelezionata);
        }

        internal void GestisciEtichetta(TabellaLookUp etichetta)
        {
            if (etichetta == null)
                throw new ArgumentNullException(nameof(etichetta));

            if (etichetta.Id == 0)
            {
                Repository.Insert(etichetta);
            }
            else
            {
                Repository.Update(etichetta);
            }
        }

        internal void CancellaEtichettaSelezionata()
        {

            try
            {
                Repository.StartConversation();

                string sql = "DELETE FROM TabellaLookUp WHERE Id=@0";
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

        internal void ClonaEtichetta(string codicePrecente, string codiceNuovo, string note)
        {
            try
            {
                Repository.StartConversation();

                TabellaLookUp etichetta = new TabellaLookUp
                {
                    Tabella = "Etichette",
                    Codice = codiceNuovo,
                    Valore = codiceNuovo,
                    CodiceNumerico = 1,
                    ValoreStr1 = EtichettaSelezionata.ValoreStr1,
                    Note = note,
                };

                Repository.Insert(etichetta);

                string fileNameRepositoryPrec = Path.Combine(_cfg.RepositoryEtichette, EtichettaSelezionata.Codice + ".repx");
                string fileNameLayoutPrec = Path.Combine(_paths.Etichette, EtichettaSelezionata.Codice + ".repx");

                string fileNameRepositoryNuovo = Path.Combine(_cfg.RepositoryEtichette, codiceNuovo + ".repx");
                string fileNameLayoutNuovo = Path.Combine(_paths.Etichette, codiceNuovo + ".repx");

                if (File.Exists(fileNameRepositoryNuovo))
                    File.Delete(fileNameRepositoryNuovo);

                if (File.Exists(fileNameLayoutNuovo))
                    File.Delete(fileNameLayoutNuovo);

                File.Copy(fileNameRepositoryPrec, fileNameRepositoryNuovo);
                File.Copy(fileNameLayoutPrec, fileNameLayoutNuovo);

                Repository.StopConversation();
            }
            catch (Exception)
            {
                Repository.AbortConversation();
                throw;
            }
        }
    }
}
