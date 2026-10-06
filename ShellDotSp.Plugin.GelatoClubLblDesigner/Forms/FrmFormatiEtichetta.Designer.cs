namespace ShellDotSp.Plugin.GelatoClubLblDesigner.Forms
{
    partial class FrmFormatiEtichetta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFormatiEtichetta));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAnnulla = new DevExpress.XtraEditors.SimpleButton();
            this.btnConferma = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bndFormati = new System.Windows.Forms.BindingSource(this.components);
            this.lkFormati = new DevExpress.XtraEditors.LookUpEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bndFormati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkFormati.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAnnulla);
            this.panel1.Controls.Add(this.btnConferma);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 72);
            this.panel1.TabIndex = 3;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.btnAnnulla.Appearance.Options.UseFont = true;
            this.btnAnnulla.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAnnulla.ImageOptions.SvgImage")));
            this.btnAnnulla.Location = new System.Drawing.Point(266, 15);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(140, 45);
            this.btnAnnulla.TabIndex = 20;
            this.btnAnnulla.Text = "ANNULLA";
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnConferma
            // 
            this.btnConferma.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.btnConferma.Appearance.Options.UseFont = true;
            this.btnConferma.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConferma.ImageOptions.SvgImage")));
            this.btnConferma.Location = new System.Drawing.Point(12, 15);
            this.btnConferma.Name = "btnConferma";
            this.btnConferma.Size = new System.Drawing.Size(140, 45);
            this.btnConferma.TabIndex = 19;
            this.btnConferma.Text = "CONFERMA";
            this.btnConferma.Click += new System.EventHandler(this.btnConferma_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(149, 18);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "FORMATI ETICHETTE";
            // 
            // bndFormati
            // 
            this.bndFormati.DataSource = typeof(ShellDotSp.Plugin.GelatoClubCore.Model.TabellaLookupCollection);
            // 
            // lkFormati
            // 
            this.lkFormati.Location = new System.Drawing.Point(12, 57);
            this.lkFormati.Name = "lkFormati";
            this.lkFormati.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkFormati.Properties.Appearance.Options.UseFont = true;
            this.lkFormati.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lkFormati.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lkFormati.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkFormati.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Valore", "Valore", 39, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkFormati.Properties.DataSource = this.bndFormati;
            this.lkFormati.Properties.DisplayMember = "Valore";
            this.lkFormati.Properties.NullText = "<sel. formato>";
            this.lkFormati.Properties.ShowFooter = false;
            this.lkFormati.Properties.ShowHeader = false;
            this.lkFormati.Properties.ShowLines = false;
            this.lkFormati.Properties.ValueMember = "Codice";
            this.lkFormati.Size = new System.Drawing.Size(394, 26);
            this.lkFormati.TabIndex = 6;
            this.lkFormati.EditValueChanged += new System.EventHandler(this.lkFormati_EditValueChanged);
            // 
            // FrmFormatiEtichetta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(418, 312);
            this.Controls.Add(this.lkFormati);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFormatiEtichetta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FORMATI";
            this.Load += new System.EventHandler(this.FrmFormatiEtichetta_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bndFormati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkFormati.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnConferma;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.BindingSource bndFormati;
        private DevExpress.XtraEditors.LookUpEdit lkFormati;
        private DevExpress.XtraEditors.SimpleButton btnAnnulla;
    }
}