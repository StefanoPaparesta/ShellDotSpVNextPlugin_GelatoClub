namespace ShellDotSp.Plugin.GelatoClubLblDesigner.Forms
{
    partial class FrmClona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClona));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConferma = new DevExpress.XtraEditors.SimpleButton();
            this.btnAnnulla = new DevExpress.XtraEditors.SimpleButton();
            this.txCodiceNuovo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txCodicePrecedente = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txCodiceNuovo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txCodicePrecedente.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConferma);
            this.panel1.Controls.Add(this.btnAnnulla);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 72);
            this.panel1.TabIndex = 3;
            // 
            // btnConferma
            // 
            this.btnConferma.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.btnConferma.Appearance.Options.UseFont = true;
            this.btnConferma.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConferma.ImageOptions.SvgImage")));
            this.btnConferma.Location = new System.Drawing.Point(12, 14);
            this.btnConferma.Name = "btnConferma";
            this.btnConferma.Size = new System.Drawing.Size(140, 45);
            this.btnConferma.TabIndex = 19;
            this.btnConferma.Text = "CONFERMA";
            this.btnConferma.Click += new System.EventHandler(this.btnConferma_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.btnAnnulla.Appearance.Options.UseFont = true;
            this.btnAnnulla.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAnnulla.ImageOptions.SvgImage")));
            this.btnAnnulla.Location = new System.Drawing.Point(266, 14);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(140, 45);
            this.btnAnnulla.TabIndex = 18;
            this.btnAnnulla.Text = "ANNULLA";
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // txCodiceNuovo
            // 
            this.txCodiceNuovo.Location = new System.Drawing.Point(12, 106);
            this.txCodiceNuovo.Name = "txCodiceNuovo";
            this.txCodiceNuovo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txCodiceNuovo.Properties.Appearance.Options.UseFont = true;
            this.txCodiceNuovo.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txCodiceNuovo.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txCodiceNuovo.Properties.MaxLength = 50;
            this.txCodiceNuovo.Size = new System.Drawing.Size(394, 26);
            this.txCodiceNuovo.TabIndex = 7;
            this.txCodiceNuovo.TextChanged += new System.EventHandler(this.txCodiceNuovo_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 82);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(109, 18);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "CODICE NUOVO";
            // 
            // txCodicePrecedente
            // 
            this.txCodicePrecedente.Enabled = false;
            this.txCodicePrecedente.Location = new System.Drawing.Point(12, 47);
            this.txCodicePrecedente.Name = "txCodicePrecedente";
            this.txCodicePrecedente.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txCodicePrecedente.Properties.Appearance.Options.UseFont = true;
            this.txCodicePrecedente.Properties.MaxLength = 50;
            this.txCodicePrecedente.Size = new System.Drawing.Size(394, 26);
            this.txCodicePrecedente.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 23);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(120, 18);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "CODICE VECCHIO";
            // 
            // FrmClona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(418, 312);
            this.Controls.Add(this.txCodicePrecedente);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txCodiceNuovo);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CLONA";
            this.Activated += new System.EventHandler(this.FrmClona_Activated);
            this.Load += new System.EventHandler(this.FrmClona_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txCodiceNuovo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txCodicePrecedente.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnConferma;
        private DevExpress.XtraEditors.SimpleButton btnAnnulla;
        private DevExpress.XtraEditors.TextEdit txCodiceNuovo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txCodicePrecedente;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}