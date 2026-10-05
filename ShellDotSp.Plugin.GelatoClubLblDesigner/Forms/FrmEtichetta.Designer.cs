namespace ShellDotSp.Plugin.GelatoClubLblDesigner.Forms
{
    partial class FrmEtichetta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEtichetta));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConferma = new DevExpress.XtraEditors.SimpleButton();
            this.btnAnnulla = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txCodice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txStrutturaGs1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txNote = new DevExpress.XtraEditors.MemoEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txCodice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txStrutturaGs1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txNote.Properties)).BeginInit();
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
            this.panel1.TabIndex = 2;
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
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 18);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "CODICE";
            // 
            // txCodice
            // 
            this.txCodice.Location = new System.Drawing.Point(12, 47);
            this.txCodice.Name = "txCodice";
            this.txCodice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txCodice.Properties.Appearance.Options.UseFont = true;
            this.txCodice.Properties.MaxLength = 50;
            this.txCodice.Size = new System.Drawing.Size(394, 26);
            this.txCodice.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 79);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(116, 18);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "STRUTTURA GS1";
            // 
            // txStrutturaGs1
            // 
            this.txStrutturaGs1.Location = new System.Drawing.Point(12, 103);
            this.txStrutturaGs1.Name = "txStrutturaGs1";
            this.txStrutturaGs1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txStrutturaGs1.Properties.Appearance.Options.UseFont = true;
            this.txStrutturaGs1.Properties.MaxLength = 50;
            this.txStrutturaGs1.Size = new System.Drawing.Size(394, 26);
            this.txStrutturaGs1.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 135);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 18);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "NOTE";
            // 
            // txNote
            // 
            this.txNote.Location = new System.Drawing.Point(12, 159);
            this.txNote.Name = "txNote";
            this.txNote.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txNote.Properties.Appearance.Options.UseFont = true;
            this.txNote.Size = new System.Drawing.Size(394, 75);
            this.txNote.TabIndex = 9;
            // 
            // FrmEtichetta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(418, 312);
            this.Controls.Add(this.txNote);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txStrutturaGs1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txCodice);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEtichetta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETICHETTA";
            this.Load += new System.EventHandler(this.FrmEtichetta_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txCodice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txStrutturaGs1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txNote.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnConferma;
        private DevExpress.XtraEditors.SimpleButton btnAnnulla;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txCodice;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txStrutturaGs1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit txNote;
    }
}