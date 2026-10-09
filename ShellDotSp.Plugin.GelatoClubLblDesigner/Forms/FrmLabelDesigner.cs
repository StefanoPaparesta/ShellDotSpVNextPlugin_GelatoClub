using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

using NLog;

using ShellDotSp.Plugin.GelatoClubCore.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ShellDotSp.Plugin.GelatoClubLblDesigner.Forms
{
    public partial class FrmLabelDesigner : XtraForm
    {
        private readonly Action<byte[]> _saveLayout;

        private static readonly HashSet<string> HiddenToolboxItems =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Gauge",
                "Chart",
                "Sparkline",
                "Pivot Grid",
                "Table of Contents",
                "Zip Code",
                "Page Break",
                "Cross-band Line",
                "Cross-band Box",
                "Cross Tab",
                "PDF Content",
                "PDF Signature",
                "Sub-Report",
                "Character Comb"
            };

        private byte[] _savedLayout;
        private readonly Type _dataSourceType;
        private readonly Func<object> _previewDataFactory;
        private readonly int _larghezza;
        private readonly int _altezza;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public FrmLabelDesigner()
        {
            var timer = Stopwatch.StartNew();
            InitializeComponent();
            _logger.Info($"Apertura designer: inizializzazione controlli {timer.ElapsedMilliseconds} ms.");

            reportDesigner1.SetCommandVisibility(ReportCommand.NewReport, CommandVisibility.None);
            reportDesigner1.SetCommandVisibility(ReportCommand.NewReportWizard, CommandVisibility.None);
            reportDesigner1.SetCommandVisibility(ReportCommand.OpenFile, CommandVisibility.None);
            reportDesigner1.SetCommandVisibility(ReportCommand.SaveFileAs, CommandVisibility.None);
            reportDesigner1.SetCommandVisibility(ReportCommand.SaveAll, CommandVisibility.None);
            reportDesigner1.SetCommandVisibility(ReportCommand.Close, CommandVisibility.None);

            reportDesigner1.DesignPanelLoaded += ReportDesigner_DesignPanelLoaded;
        }

        public FrmLabelDesigner(RepositoryEtichetta etichetta, Action<byte[]> saveLayout, Type dataSourceType, int Larghezza, int Altezza,
            Func<object> previewDataFactory = null) : this()
        {
            _saveLayout = saveLayout ?? throw new ArgumentNullException(nameof(saveLayout));
            _dataSourceType = dataSourceType ?? throw new ArgumentNullException(nameof(dataSourceType));
            _previewDataFactory = previewDataFactory;

            _larghezza = Larghezza;
            _altezza = Altezza;

            OpenOrCreateLabel(etichetta);
        }

        private void OpenOrCreateLabel(RepositoryEtichetta etichetta)
        {
            if (etichetta == null || string.IsNullOrWhiteSpace(etichetta.Codice))
                throw new ArgumentException("Specificare un'etichetta con un codice valido.", nameof(etichetta));

            if (etichetta.Layout != null && etichetta.Layout.Length > 0)
            {
                string fName = etichetta.Codice;
                var existingReport = new XtraReport();
                try
                {
                    var timer = Stopwatch.StartNew();
                    using (var stream = new MemoryStream(etichetta.Layout, false))
                        existingReport.LoadLayoutFromXml(stream);
                    _logger.Info($"Apertura designer: caricamento XML {timer.ElapsedMilliseconds} ms.");
                    bool nomeModificato = existingReport.Name != fName || existingReport.DisplayName != fName;
                    // Imposta il nome prima che il designer crei il componente e il titolo del documento.
                    existingReport.Name = fName;
                    existingReport.DisplayName = fName;
                    timer.Restart();
                    reportDesigner1.OpenReport(existingReport);
                    _logger.Info($"Apertura designer: OpenReport {timer.ElapsedMilliseconds} ms.");
                    reportDesigner1.ActiveDesignPanel.ReportState = nomeModificato
                        ? ReportState.Changed : ReportState.Saved;
                    if (!nomeModificato)
                    {
                        timer.Restart();
                        _savedLayout = GetLayout(reportDesigner1.ActiveDesignPanel);
                        _logger.Info($"Apertura designer: snapshot layout {timer.ElapsedMilliseconds} ms.");
                    }
                }
                catch
                {
                    existingReport.Dispose();
                    throw;
                }

                return;
            }

            var report = new XtraReport
            {
                ReportUnit = ReportUnit.TenthsOfAMillimeter,
                Margins = new Margins(0, 0, 0, 0),
                PaperKind = PaperKind.Custom,
                PageWidth = _larghezza * 10,
                PageHeight = _altezza * 10,
                Name = etichetta.Codice,
                DisplayName = etichetta.Codice,
                Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
            };
            var topMargin = new TopMarginBand();
            var detail = new DetailBand();
            var bottomMargin = new BottomMarginBand();

            report.Bands.AddRange(new Band[]
            {
                topMargin,
                detail,
                bottomMargin
            });

            // Dopo l'aggiunta le bande usano le unità del report, evitando conversioni da pollici.
            topMargin.HeightF = 0;
            bottomMargin.HeightF = 0;
            detail.HeightF = report.PageHeight - report.Margins.Top - report.Margins.Bottom;

            try
            {
                reportDesigner1.OpenReport(report);
                reportDesigner1.ActiveDesignPanel.ReportState = ReportState.Changed;
            }
            catch
            {
                report.Dispose();
                throw;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // Il designer ripristina il layout durante l'apertura: applica la vista dopo il caricamento.
            var timer = Stopwatch.StartNew();
            ConfigureDockPanels();
            _logger.Info($"Apertura designer: pannelli OnShown {timer.ElapsedMilliseconds} ms.");
            BeginInvoke(new Action(CollapseBottomPanels));
        }

        private void CollapseBottomPanels()
        {
            groupAndSortDockPanel1.Visibility = DockVisibility.AutoHide;
            errorListDockPanel1.Visibility = DockVisibility.AutoHide;
            groupAndSortDockPanel1.HideImmediately();
            errorListDockPanel1.HideImmediately();
        }

        private void ConfigureDockPanels()
        {
            xrDesignDockManager1.ForceInitialize();
            xrDesignDockManager1.BeginUpdate();
            try
            {
                fieldListDockPanel1.Visibility = DockVisibility.Visible;
                propertyGridDockPanel1.Visibility = DockVisibility.Visible;
            }
            finally
            {
                xrDesignDockManager1.EndUpdate();
            }

            panelContainer1.TabsPosition = TabsPosition.Bottom;
            panelContainer1.ActiveChild = fieldListDockPanel1;
        }

        private void ConfigureToolbox(IDesignerHost host)
        {
            var toolbox = host.GetService(typeof(IToolboxService)) as IToolboxService;
            if (toolbox == null)
                return;

            var items = toolbox.GetToolboxItems().Cast<ToolboxItem>().ToArray();
            foreach (var item in items)
            {
                //_logger.Debug($"Toolbox item: {item.DisplayName}");

                if (HiddenToolboxItems.Contains(item.DisplayName))
                    toolbox.RemoveToolboxItem(item);
            }
        }

        private void ReportDesigner_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            var timer = Stopwatch.StartNew();
            ConfigureDockPanels();
            _logger.Info($"Apertura designer: pannelli DesignPanelLoaded {timer.ElapsedMilliseconds} ms.");
            timer.Restart();
            ConfigureToolbox(e.DesignerHost);
            _logger.Info($"Apertura designer: toolbox {timer.ElapsedMilliseconds} ms.");
            timer.Restart();
            ((XRDesignPanel)sender).SelectedTabIndexChanged += DesignPanel_SelectedTabIndexChanged;
            ((XRDesignPanel)sender).AddCommandHandler(new SaveLabelCommandHandler(this, (XRDesignPanel)sender));
            if (_previewDataFactory != null)
            {
                var tabs = ((XRDesignPanel)sender).GetService(typeof(ReportTabControl)) as ReportTabControl;
                if (tabs != null)
                    tabs.PreviewReportCreated += PreviewReportCreated;
            }
            _logger.Info($"Apertura designer: collegamento comandi e anteprima {timer.ElapsedMilliseconds} ms.");
            if (_dataSourceType == null)
                return;
            timer.Restart();

            var panel = (XRDesignPanel)sender;
            var report = panel.Report;
            var dataSource = report.ComponentStorage.OfType<ObjectDataSource>()
                .FirstOrDefault(source => source.DataSource as Type == _dataSourceType);

            if (dataSource == null)
            {
                string name = _dataSourceType.Name;
                int suffix = 1;
                while (report.ComponentStorage.OfType<ObjectDataSource>().Any(source => source.Name == name))
                    name = _dataSourceType.Name + suffix++;

                dataSource = new ObjectDataSource
                {
                    Name = name,
                    DataSource = _dataSourceType,
                    // Espone lo schema senza creare istanze o caricare dati di produzione.
                    Constructor = null
                };
                report.ComponentStorage.Add(dataSource);
            }

            report.DataSource = dataSource;
            report.DataMember = string.Empty;

            _logger.Info($"Apertura designer: configurazione sorgente dati {timer.ElapsedMilliseconds} ms.");
            timer.Restart();
            var host = (IDesignerHost)panel.GetService(typeof(IDesignerHost));
            fieldListDockPanel1.UpdateDataSource(host);
            _logger.Info($"Apertura designer: aggiornamento elenco campi {timer.ElapsedMilliseconds} ms.");
        }

        private static byte[] GetLayout(XRDesignPanel panel)
        {
            using (var stream = new MemoryStream())
            {
                panel.Report.SaveLayoutToXml(stream);
                return stream.ToArray();
            }
        }

        private void RestoreUnchangedReportState()
        {
            var panel = reportDesigner1.ActiveDesignPanel;
            if (_savedLayout == null || panel == null || panel.Report == null ||
                panel.ReportState != ReportState.Changed)
                return;

            if (_savedLayout.SequenceEqual(GetLayout(panel)))
                panel.ReportState = ReportState.Saved;
        }

        private void DesignPanel_SelectedTabIndexChanged(object sender, EventArgs e)
        {
            var panel = (XRDesignPanel)sender;
            if (panel.SelectedTabIndex != 0 || !IsHandleCreated)
                return;

            // Attende che il designer abbia terminato il rientro dall'anteprima.
            BeginInvoke(new Action(() =>
            {
                if (!IsDisposed && !Disposing)
                    RestoreUnchangedReportState();
            }));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            RestoreUnchangedReportState();
            base.OnFormClosing(e);
        }

        private void PreviewReportCreated(object sender, EventArgs e)
        {
            var previewReport = ((ReportTabControl)sender).PreviewReport;
            var data = _previewDataFactory();
            if (data == null)
                throw new InvalidOperationException("La sorgente dei dati di anteprima non ha restituito dati.");

            // Modifica soltanto la copia di anteprima, lasciando nel REPX la sorgente basata sul tipo.
            DevExpress.XtraReports.DataSourceManager.ReplaceDataSource(previewReport, previewReport.DataSource, data);
            previewReport.DataMember = string.Empty;
        }

        private sealed class SaveLabelCommandHandler : ICommandHandler
        {
            private readonly FrmLabelDesigner _owner;
            private readonly XRDesignPanel _panel;

            public SaveLabelCommandHandler(FrmLabelDesigner owner, XRDesignPanel panel)
            {
                _owner = owner;
                _panel = panel;
            }

            public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
            {
                bool handles = command == ReportCommand.SaveFile || command == ReportCommand.SaveFileAs;
                useNextHandler = !handles;
                return handles;
            }

            public void HandleCommand(ReportCommand command, object[] args)
            {
                try
                {
                    byte[] layout = GetLayout(_panel);
                    _owner._saveLayout(layout);
                    // Il pannello risulta salvato soltanto dopo il completamento della scrittura nel DB.
                    _owner._savedLayout = layout;
                    _panel.ReportState = ReportState.Saved;
                }
                catch (Exception ex)
                {
                    _owner._logger.Error(ex, "Errore durante il salvataggio dell'etichetta nel database");
                    XtraMessageBox.Show(_owner, ex.Message, "Salvataggio etichetta",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmLabelDesigner_Load(object sender, EventArgs e)
        {

        }
    }

}
