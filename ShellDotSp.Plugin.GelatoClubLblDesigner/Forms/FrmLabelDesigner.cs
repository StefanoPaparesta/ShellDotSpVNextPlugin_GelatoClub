using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

using NLog;

using ShellDotSp.Core.Model;
using ShellDotSp.Plugin.GelatoClubCore.Config;

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ShellDotSp.Plugin.GelatoClubLblDesigner.Forms
{
    public partial class FrmLabelDesigner : XtraForm
    {
        private ApplicationPaths _paths = ApplicationPaths.Instance;
        private CfgPlugin _cfg = CfgPlugin.Instance;

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

        public event EventHandler<EtichettaSalvataEventArgs> EtichettaSalvata;

        private byte[] _savedLayout;
        private readonly Type _dataSourceType;
        private readonly Func<object> _previewDataFactory;
        private readonly int _larghezza;
        private readonly int _altezza;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public FrmLabelDesigner()
        {
            InitializeComponent();

            reportDesigner1.SetCommandVisibility(ReportCommand.NewReport, CommandVisibility.None);
            reportDesigner1.SetCommandVisibility(ReportCommand.NewReportWizard, CommandVisibility.None);
            reportDesigner1.SetCommandVisibility(ReportCommand.OpenFile, CommandVisibility.None);
            reportDesigner1.SetCommandVisibility(ReportCommand.SaveFileAs, CommandVisibility.None);
            reportDesigner1.SetCommandVisibility(ReportCommand.SaveAll, CommandVisibility.None);
            reportDesigner1.SetCommandVisibility(ReportCommand.Close, CommandVisibility.None);

            reportDesigner1.DesignPanelLoaded += ReportDesigner_DesignPanelLoaded;
        }

        public FrmLabelDesigner(string fileName) : this()
        {
            OpenOrCreateLabel(fileName);
        }

        public FrmLabelDesigner(string fileName, Type dataSourceType, int Larghezza, int Altezza,
            Func<object> previewDataFactory = null) : this()
        {
            _dataSourceType = dataSourceType ?? throw new ArgumentNullException(nameof(dataSourceType));
            _previewDataFactory = previewDataFactory;

            _larghezza = Larghezza;
            _altezza = Altezza;

            OpenOrCreateLabel(fileName);
        }

        private void OpenOrCreateLabel(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Specificare il percorso del REPX.", nameof(fileName));

            if (File.Exists(fileName))
            {
                string fName = Path.GetFileNameWithoutExtension(fileName);
                var existingReport = new XtraReport();
                try
                {
                    existingReport.LoadLayoutFromXml(fileName);
                    bool nomeModificato = existingReport.Name != fName || existingReport.DisplayName != fName;
                    // Imposta il nome prima che il designer crei il componente e il titolo del documento.
                    existingReport.Name = fName;
                    existingReport.DisplayName = fName;
                    reportDesigner1.OpenReport(existingReport);
                    reportDesigner1.ActiveDesignPanel.FileName = Path.GetFullPath(fileName);
                    reportDesigner1.ActiveDesignPanel.ReportState = nomeModificato
                        ? ReportState.Changed : ReportState.Saved;
                    if (!nomeModificato)
                        _savedLayout = GetLayout(reportDesigner1.ActiveDesignPanel);
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
                Name = Path.GetFileNameWithoutExtension(fileName),
                DisplayName = Path.GetFileNameWithoutExtension(fileName),
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
                reportDesigner1.ActiveDesignPanel.FileName = Path.GetFullPath(fileName);
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
            ConfigureDockPanels();
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
                _logger.Debug($"Toolbox item: {item.DisplayName}");

                if (HiddenToolboxItems.Contains(item.DisplayName))
                    toolbox.RemoveToolboxItem(item);
            }
        }

        private void ReportDesigner_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            ConfigureDockPanels();
            ConfigureToolbox(e.DesignerHost);
            ((XRDesignPanel)sender).SelectedTabIndexChanged += DesignPanel_SelectedTabIndexChanged;
            ((XRDesignPanel)sender).AddCommandHandler(new SaveLabelCommandHandler(this, (XRDesignPanel)sender));
            if (_previewDataFactory != null)
            {
                var tabs = ((XRDesignPanel)sender).GetService(typeof(ReportTabControl)) as ReportTabControl;
                if (tabs != null)
                    tabs.PreviewReportCreated += PreviewReportCreated;
            }
            if (_dataSourceType == null)
                return;

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

            var host = (IDesignerHost)panel.GetService(typeof(IDesignerHost));
            fieldListDockPanel1.UpdateDataSource(host);
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
                string fileName = _panel.FileName;

                if (command == ReportCommand.SaveFileAs || string.IsNullOrWhiteSpace(fileName))
                {
                    using (var dialog = XRDesignPanel.CreateSaveFileDialog(_panel.Report, fileName))
                    {
                        if (dialog.ShowDialog(_owner) != DialogResult.OK)
                            return;
                        fileName = dialog.FileName;
                    }
                }

                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(fileName)));
                    _panel.Report.SaveLayoutToXml(fileName);
                    _panel.FileName = fileName;
                    _owner._savedLayout = GetLayout(_panel);
                    _panel.ReportState = ReportState.Saved;
                }
                catch (Exception ex)
                {
                    _owner._logger.Error(ex, "Errore durante il salvataggio dell'etichetta");
                    XtraMessageBox.Show(_owner, ex.Message, "Salvataggio etichetta",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    _owner.EtichettaSalvata?.Invoke(_owner,
                        new EtichettaSalvataEventArgs(fileName, _panel.Report));


                }
                catch (Exception ex)
                {
                    _owner._logger.Error(ex, "Errore nelle operazioni successive al salvataggio dell'etichetta");
                    XtraMessageBox.Show(_owner, "Etichetta salvata, ma le operazioni successive sono fallite: " + ex.Message,
                        "Operazioni dopo il salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmLabelDesigner_Load(object sender, EventArgs e)
        {

        }
    }

    public sealed class EtichettaSalvataEventArgs : EventArgs
    {
        public string FileName { get; }
        public XtraReport Report { get; }

        public EtichettaSalvataEventArgs(string fileName, XtraReport report)
        {
            FileName = fileName;
            Report = report;
        }
    }
}
