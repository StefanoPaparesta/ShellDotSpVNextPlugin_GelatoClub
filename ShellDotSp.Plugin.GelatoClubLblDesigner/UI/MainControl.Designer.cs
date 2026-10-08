namespace ShellDotSp.Plugin.GelatoClubLblDesigner.UI
{
    partial class MainControlShellLabelDesigner
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">
        /// ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare il contenuto del metodo
        /// con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControlShellLabelDesigner));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClona = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancella = new DevExpress.XtraEditors.SimpleButton();
            this.btnNuovo = new DevExpress.XtraEditors.SimpleButton();
            this.btnDesigner = new DevExpress.XtraEditors.SimpleButton();
            this.btnModifica = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bndEtichette = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoreStr1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersione = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnImporta = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndEtichette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 435);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnImporta);
            this.panel1.Controls.Add(this.btnClona);
            this.panel1.Controls.Add(this.btnCancella);
            this.panel1.Controls.Add(this.btnNuovo);
            this.panel1.Controls.Add(this.btnDesigner);
            this.panel1.Controls.Add(this.btnModifica);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 70);
            this.panel1.TabIndex = 0;
            // 
            // btnClona
            // 
            this.btnClona.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClona.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnClona.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClona.ImageOptions.SvgImage")));
            this.btnClona.Location = new System.Drawing.Point(767, 10);
            this.btnClona.Name = "btnClona";
            this.btnClona.Size = new System.Drawing.Size(50, 50);
            this.btnClona.TabIndex = 4;
            this.btnClona.ToolTip = "CLONA";
            this.btnClona.Click += new System.EventHandler(this.btnClona_Click);
            // 
            // btnCancella
            // 
            this.btnCancella.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancella.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCancella.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancella.ImageOptions.SvgImage")));
            this.btnCancella.Location = new System.Drawing.Point(713, 10);
            this.btnCancella.Name = "btnCancella";
            this.btnCancella.Size = new System.Drawing.Size(50, 50);
            this.btnCancella.TabIndex = 3;
            this.btnCancella.ToolTip = "CANCELLA";
            this.btnCancella.Click += new System.EventHandler(this.btnCancella_Click);
            // 
            // btnNuovo
            // 
            this.btnNuovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuovo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnNuovo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNuovo.ImageOptions.SvgImage")));
            this.btnNuovo.Location = new System.Drawing.Point(847, 10);
            this.btnNuovo.Name = "btnNuovo";
            this.btnNuovo.Size = new System.Drawing.Size(50, 50);
            this.btnNuovo.TabIndex = 2;
            this.btnNuovo.ToolTip = "NUOVO";
            this.btnNuovo.Click += new System.EventHandler(this.btnNuovo_Click);
            // 
            // btnDesigner
            // 
            this.btnDesigner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesigner.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDesigner.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDesigner.ImageOptions.SvgImage")));
            this.btnDesigner.Location = new System.Drawing.Point(577, 10);
            this.btnDesigner.Name = "btnDesigner";
            this.btnDesigner.Size = new System.Drawing.Size(50, 50);
            this.btnDesigner.TabIndex = 1;
            this.btnDesigner.ToolTip = "DESIGNER";
            this.btnDesigner.Click += new System.EventHandler(this.btnDesigner_Click);
            // 
            // btnModifica
            // 
            this.btnModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifica.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnModifica.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnModifica.ImageOptions.SvgImage")));
            this.btnModifica.Location = new System.Drawing.Point(660, 10);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(50, 50);
            this.btnModifica.TabIndex = 0;
            this.btnModifica.ToolTip = "MODIFICA";
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bndEtichette;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 73);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(894, 359);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseClick);
            // 
            // bndEtichette
            // 
            this.bndEtichette.DataSource = typeof(ShellDotSp.Plugin.GelatoClubCore.Model.RepositoryEtichettaCollection);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView1.Appearance.HorzLine.Options.UseFont = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView1.Appearance.VertLine.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodice,
            this.colValoreStr1,
            this.colNote,
            this.colVersione});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colCodice
            // 
            this.colCodice.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodice.Caption = "CODICE";
            this.colCodice.FieldName = "Codice";
            this.colCodice.Name = "colCodice";
            this.colCodice.OptionsColumn.AllowEdit = false;
            this.colCodice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCodice.OptionsFilter.AllowAutoFilter = false;
            this.colCodice.OptionsFilter.AllowFilter = false;
            this.colCodice.Visible = true;
            this.colCodice.VisibleIndex = 0;
            this.colCodice.Width = 254;
            // 
            // colValoreStr1
            // 
            this.colValoreStr1.AppearanceCell.Options.UseTextOptions = true;
            this.colValoreStr1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoreStr1.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoreStr1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoreStr1.Caption = "STRUTTURA GS1";
            this.colValoreStr1.FieldName = "StrutturaGs1";
            this.colValoreStr1.Name = "colValoreStr1";
            this.colValoreStr1.OptionsColumn.AllowEdit = false;
            this.colValoreStr1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colValoreStr1.OptionsFilter.AllowAutoFilter = false;
            this.colValoreStr1.OptionsFilter.AllowFilter = false;
            this.colValoreStr1.Visible = true;
            this.colValoreStr1.VisibleIndex = 1;
            this.colValoreStr1.Width = 199;
            // 
            // colNote
            // 
            this.colNote.AppearanceHeader.Options.UseTextOptions = true;
            this.colNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNote.Caption = "NOTE";
            this.colNote.FieldName = "Descrizione";
            this.colNote.Name = "colNote";
            this.colNote.OptionsColumn.AllowEdit = false;
            this.colNote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colNote.OptionsFilter.AllowAutoFilter = false;
            this.colNote.OptionsFilter.AllowFilter = false;
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 2;
            this.colNote.Width = 376;
            // 
            // colVersione
            // 
            this.colVersione.AppearanceCell.Options.UseTextOptions = true;
            this.colVersione.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVersione.AppearanceHeader.Options.UseTextOptions = true;
            this.colVersione.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVersione.Caption = "VERSIONE";
            this.colVersione.FieldName = "Versione";
            this.colVersione.Name = "colVersione";
            this.colVersione.OptionsColumn.AllowEdit = false;
            this.colVersione.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colVersione.OptionsFilter.AllowAutoFilter = false;
            this.colVersione.OptionsFilter.AllowFilter = false;
            this.colVersione.Visible = true;
            this.colVersione.VisibleIndex = 3;
            this.colVersione.Width = 99;
            // 
            // btnImporta
            // 
            this.btnImporta.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnImporta.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnImporta.Location = new System.Drawing.Point(3, 10);
            this.btnImporta.Name = "btnImporta";
            this.btnImporta.Size = new System.Drawing.Size(50, 50);
            this.btnImporta.TabIndex = 5;
            this.btnImporta.ToolTip = "DESIGNER";
            this.btnImporta.Click += new System.EventHandler(this.btnImporta_Click);
            // 
            // MainControlShellLabelDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainControlShellLabelDesigner";
            this.Size = new System.Drawing.Size(900, 435);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndEtichette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bndEtichette;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCodice;
        private DevExpress.XtraGrid.Columns.GridColumn colValoreStr1;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraEditors.SimpleButton btnModifica;
        private DevExpress.XtraEditors.SimpleButton btnDesigner;
        private DevExpress.XtraEditors.SimpleButton btnNuovo;
        private DevExpress.XtraEditors.SimpleButton btnCancella;
        private DevExpress.XtraEditors.SimpleButton btnClona;
        private DevExpress.XtraGrid.Columns.GridColumn colVersione;
        private DevExpress.XtraEditors.SimpleButton btnImporta;
    }
}
