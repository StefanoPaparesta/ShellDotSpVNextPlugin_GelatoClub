namespace ShellDotSp.Plugin.GelatoClubProduzione.Forms
{
    partial class FrmTestiPersonalizzati
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTestiPersonalizzati));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChiudi = new DevExpress.XtraEditors.SimpleButton();
            this.lblCodiceArticolo = new DevExpress.XtraEditors.LabelControl();
            this.lblTipoDesc = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeleteTesto = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddTesto = new DevExpress.XtraEditors.SimpleButton();
            this.txDescrizioneCompleta = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txDescrizioneBreve = new DevExpress.XtraEditors.TextEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bndEtichetteTesti = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescrizioneBreve = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescrizioneCompleta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txDescrizioneCompleta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txDescrizioneBreve.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndEtichetteTesti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnChiudi);
            this.panel1.Controls.Add(this.lblCodiceArticolo);
            this.panel1.Controls.Add(this.lblTipoDesc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 78);
            this.panel1.TabIndex = 0;
            // 
            // btnChiudi
            // 
            this.btnChiudi.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiudi.Appearance.Options.UseFont = true;
            this.btnChiudi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnChiudi.ImageOptions.SvgImage")));
            this.btnChiudi.Location = new System.Drawing.Point(376, 16);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(171, 45);
            this.btnChiudi.TabIndex = 20;
            this.btnChiudi.Text = "CHIUDI";
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // lblCodiceArticolo
            // 
            this.lblCodiceArticolo.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodiceArticolo.Appearance.Options.UseFont = true;
            this.lblCodiceArticolo.Location = new System.Drawing.Point(4, 16);
            this.lblCodiceArticolo.Name = "lblCodiceArticolo";
            this.lblCodiceArticolo.Size = new System.Drawing.Size(91, 18);
            this.lblCodiceArticolo.TabIndex = 0;
            this.lblCodiceArticolo.Text = "CODICE ART:";
            // 
            // lblTipoDesc
            // 
            this.lblTipoDesc.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDesc.Appearance.Options.UseFont = true;
            this.lblTipoDesc.Location = new System.Drawing.Point(3, 43);
            this.lblTipoDesc.Name = "lblTipoDesc";
            this.lblTipoDesc.Size = new System.Drawing.Size(92, 18);
            this.lblTipoDesc.TabIndex = 1;
            this.lblTipoDesc.Text = "TIPO TESTO:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDeleteTesto);
            this.panel2.Controls.Add(this.btnAddTesto);
            this.panel2.Controls.Add(this.txDescrizioneCompleta);
            this.panel2.Controls.Add(this.labelControl2);
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Controls.Add(this.txDescrizioneBreve);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(559, 162);
            this.panel2.TabIndex = 1;
            // 
            // btnDeleteTesto
            // 
            this.btnDeleteTesto.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDeleteTesto.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDeleteTesto.ImageOptions.SvgImage")));
            this.btnDeleteTesto.Location = new System.Drawing.Point(507, 116);
            this.btnDeleteTesto.Name = "btnDeleteTesto";
            this.btnDeleteTesto.Size = new System.Drawing.Size(40, 40);
            this.btnDeleteTesto.TabIndex = 7;
            this.btnDeleteTesto.Click += new System.EventHandler(this.btnDeleteTesto_Click);
            // 
            // btnAddTesto
            // 
            this.btnAddTesto.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAddTesto.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddTesto.ImageOptions.SvgImage")));
            this.btnAddTesto.Location = new System.Drawing.Point(507, 18);
            this.btnAddTesto.Name = "btnAddTesto";
            this.btnAddTesto.Size = new System.Drawing.Size(40, 40);
            this.btnAddTesto.TabIndex = 6;
            this.btnAddTesto.Click += new System.EventHandler(this.btnAddTesto_Click);
            // 
            // txDescrizioneCompleta
            // 
            this.txDescrizioneCompleta.Location = new System.Drawing.Point(3, 89);
            this.txDescrizioneCompleta.Name = "txDescrizioneCompleta";
            this.txDescrizioneCompleta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txDescrizioneCompleta.Properties.Appearance.Options.UseFont = true;
            this.txDescrizioneCompleta.Size = new System.Drawing.Size(498, 67);
            this.txDescrizioneCompleta.TabIndex = 5;
            this.txDescrizioneCompleta.TextChanged += new System.EventHandler(this.txDescrizioni_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(4, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(115, 18);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "DESC.COMPLETA";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(4, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 18);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "DESC.BREVE";
            // 
            // txDescrizioneBreve
            // 
            this.txDescrizioneBreve.Location = new System.Drawing.Point(4, 36);
            this.txDescrizioneBreve.Name = "txDescrizioneBreve";
            this.txDescrizioneBreve.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txDescrizioneBreve.Properties.Appearance.Options.UseFont = true;
            this.txDescrizioneBreve.Properties.MaxLength = 50;
            this.txDescrizioneBreve.Size = new System.Drawing.Size(497, 22);
            this.txDescrizioneBreve.TabIndex = 2;
            this.txDescrizioneBreve.TextChanged += new System.EventHandler(this.txDescrizioni_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 162);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(559, 338);
            this.panel3.TabIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bndEtichetteTesti;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(559, 338);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseDoubleClick);
            // 
            // bndEtichetteTesti
            // 
            this.bndEtichetteTesti.DataSource = typeof(ShellDotSp.Plugin.GelatoClubCore.Model.EtichettaTestoCollection);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView1.Appearance.HorzLine.Options.UseFont = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView1.Appearance.VertLine.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescrizioneBreve,
            this.colDescrizioneCompleta});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colDescrizioneBreve
            // 
            this.colDescrizioneBreve.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescrizioneBreve.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescrizioneBreve.FieldName = "DescrizioneBreve";
            this.colDescrizioneBreve.Name = "colDescrizioneBreve";
            this.colDescrizioneBreve.OptionsColumn.AllowEdit = false;
            this.colDescrizioneBreve.OptionsColumn.AllowMove = false;
            this.colDescrizioneBreve.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDescrizioneBreve.OptionsFilter.AllowFilter = false;
            this.colDescrizioneBreve.Visible = true;
            this.colDescrizioneBreve.VisibleIndex = 0;
            this.colDescrizioneBreve.Width = 153;
            // 
            // colDescrizioneCompleta
            // 
            this.colDescrizioneCompleta.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescrizioneCompleta.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescrizioneCompleta.FieldName = "DescrizioneCompleta";
            this.colDescrizioneCompleta.Name = "colDescrizioneCompleta";
            this.colDescrizioneCompleta.OptionsColumn.AllowEdit = false;
            this.colDescrizioneCompleta.OptionsColumn.AllowMove = false;
            this.colDescrizioneCompleta.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDescrizioneCompleta.OptionsFilter.AllowFilter = false;
            this.colDescrizioneCompleta.Visible = true;
            this.colDescrizioneCompleta.VisibleIndex = 1;
            this.colDescrizioneCompleta.Width = 404;
            // 
            // FrmTestiPersonalizzati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 578);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTestiPersonalizzati";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TESTI PERSONALIZZATI";
            this.Load += new System.EventHandler(this.FrmTestiPersonalizzati_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txDescrizioneCompleta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txDescrizioneBreve.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndEtichetteTesti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnChiudi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bndEtichetteTesti;
        private DevExpress.XtraGrid.Columns.GridColumn colDescrizioneBreve;
        private DevExpress.XtraGrid.Columns.GridColumn colDescrizioneCompleta;
        private DevExpress.XtraEditors.LabelControl lblTipoDesc;
        private DevExpress.XtraEditors.LabelControl lblCodiceArticolo;
        private DevExpress.XtraEditors.SimpleButton btnAddTesto;
        private DevExpress.XtraEditors.MemoEdit txDescrizioneCompleta;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txDescrizioneBreve;
        private DevExpress.XtraEditors.SimpleButton btnDeleteTesto;
    }
}