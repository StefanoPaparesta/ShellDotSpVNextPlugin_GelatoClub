namespace ShellDotSp.Plugin.GelatoClubProduzione.Forms
{
    partial class FrmArticoli
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmArticoli));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConferma = new DevExpress.XtraEditors.SimpleButton();
            this.btnAnnulla = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAzzeraArticolo = new DevExpress.XtraEditors.SimpleButton();
            this.txRicerca = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bndArticoli = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodiceArticolo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescrizioneArticolo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescrUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txRicerca.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndArticoli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConferma);
            this.panel1.Controls.Add(this.btnAnnulla);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 569);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1119, 72);
            this.panel1.TabIndex = 1;
            // 
            // btnConferma
            // 
            this.btnConferma.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConferma.Appearance.Options.UseFont = true;
            this.btnConferma.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConferma.ImageOptions.SvgImage")));
            this.btnConferma.Location = new System.Drawing.Point(385, 15);
            this.btnConferma.Name = "btnConferma";
            this.btnConferma.Size = new System.Drawing.Size(171, 45);
            this.btnConferma.TabIndex = 19;
            this.btnConferma.Text = "CONFERMA";
            this.btnConferma.Click += new System.EventHandler(this.btnConferma_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnulla.Appearance.Options.UseFont = true;
            this.btnAnnulla.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAnnulla.ImageOptions.SvgImage")));
            this.btnAnnulla.Location = new System.Drawing.Point(562, 14);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(171, 45);
            this.btnAnnulla.TabIndex = 18;
            this.btnAnnulla.Text = "CHIUDI";
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAzzeraArticolo);
            this.panel2.Controls.Add(this.txRicerca);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1119, 61);
            this.panel2.TabIndex = 2;
            // 
            // btnAzzeraArticolo
            // 
            this.btnAzzeraArticolo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAzzeraArticolo.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAzzeraArticolo.Appearance.Options.UseFont = true;
            this.btnAzzeraArticolo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAzzeraArticolo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAzzeraArticolo.ImageOptions.SvgImage")));
            this.btnAzzeraArticolo.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnAzzeraArticolo.Location = new System.Drawing.Point(1041, 14);
            this.btnAzzeraArticolo.Margin = new System.Windows.Forms.Padding(2);
            this.btnAzzeraArticolo.Name = "btnAzzeraArticolo";
            this.btnAzzeraArticolo.Size = new System.Drawing.Size(67, 33);
            this.btnAzzeraArticolo.TabIndex = 9;
            this.btnAzzeraArticolo.Click += new System.EventHandler(this.btnAzzeraArticolo_Click);
            // 
            // txRicerca
            // 
            this.txRicerca.Location = new System.Drawing.Point(12, 17);
            this.txRicerca.Name = "txRicerca";
            this.txRicerca.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txRicerca.Properties.Appearance.Options.UseFont = true;
            this.txRicerca.Size = new System.Drawing.Size(1024, 26);
            this.txRicerca.TabIndex = 0;
            this.txRicerca.TextChanged += new System.EventHandler(this.txRicerca_TextChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bndArticoli;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 61);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1119, 508);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseClick);
            this.gridControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseDoubleClick);
            // 
            // bndArticoli
            // 
            this.bndArticoli.DataSource = typeof(ShellDotSp.Plugin.GelatoClubCore.Model.VArticoloGestionale);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HorzLine.Options.UseFont = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.VertLine.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodiceArticolo,
            this.colDescrizioneArticolo,
            this.colDescrUM});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colCodiceArticolo
            // 
            this.colCodiceArticolo.AppearanceCell.Options.UseTextOptions = true;
            this.colCodiceArticolo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodiceArticolo.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodiceArticolo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodiceArticolo.Caption = "CODICE";
            this.colCodiceArticolo.FieldName = "CodiceArticolo";
            this.colCodiceArticolo.Name = "colCodiceArticolo";
            this.colCodiceArticolo.OptionsColumn.AllowEdit = false;
            this.colCodiceArticolo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCodiceArticolo.OptionsFilter.AllowFilter = false;
            this.colCodiceArticolo.Visible = true;
            this.colCodiceArticolo.VisibleIndex = 0;
            this.colCodiceArticolo.Width = 150;
            // 
            // colDescrizioneArticolo
            // 
            this.colDescrizioneArticolo.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescrizioneArticolo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescrizioneArticolo.Caption = "DESCRIZIONE";
            this.colDescrizioneArticolo.FieldName = "DescrizioneArticolo";
            this.colDescrizioneArticolo.Name = "colDescrizioneArticolo";
            this.colDescrizioneArticolo.OptionsColumn.AllowEdit = false;
            this.colDescrizioneArticolo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDescrizioneArticolo.OptionsFilter.AllowFilter = false;
            this.colDescrizioneArticolo.Visible = true;
            this.colDescrizioneArticolo.VisibleIndex = 1;
            this.colDescrizioneArticolo.Width = 828;
            // 
            // colDescrUM
            // 
            this.colDescrUM.AppearanceCell.Options.UseTextOptions = true;
            this.colDescrUM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescrUM.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescrUM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescrUM.Caption = "UM";
            this.colDescrUM.FieldName = "UM";
            this.colDescrUM.Name = "colDescrUM";
            this.colDescrUM.OptionsColumn.AllowEdit = false;
            this.colDescrUM.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDescrUM.OptionsFilter.AllowFilter = false;
            this.colDescrUM.Visible = true;
            this.colDescrUM.VisibleIndex = 2;
            this.colDescrUM.Width = 122;
            // 
            // FrmArticoli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1119, 641);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmArticoli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ARTICOLI";
            this.Activated += new System.EventHandler(this.FrmClienti_Activated);
            this.Load += new System.EventHandler(this.FrmClienti_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txRicerca.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndArticoli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnAnnulla;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bndArticoli;
        private DevExpress.XtraEditors.TextEdit txRicerca;
        private DevExpress.XtraEditors.SimpleButton btnAzzeraArticolo;
        private DevExpress.XtraEditors.SimpleButton btnConferma;
        private DevExpress.XtraGrid.Columns.GridColumn colCodiceArticolo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescrizioneArticolo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescrUM;
    }
}