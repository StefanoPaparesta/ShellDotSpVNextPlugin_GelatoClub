namespace ShellDotSp.Plugin.GelatoClubProduzione.UI
{
    partial class MainControlGelatoClubProduzione
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControlGelatoClubProduzione));
            this.lkLinee = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblArticolo = new DevExpress.XtraEditors.LabelControl();
            this.btnInvia = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txDataConfezionamento = new DevExpress.XtraEditors.DateEdit();
            this.timerDataConfezionamento = new System.Windows.Forms.Timer(this.components);
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblLotto = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblDescCommerciale = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lblDescLegaleITA = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.lblDescCommercialeEN = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblDescCommercialeES = new DevExpress.XtraEditors.LabelControl();
            this.lblDescCommercialeDE = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.lblDescCommercialeFR = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.lblTmc = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.lblScadenzaFineMese = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.lblTipoBc = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.lblBarcode = new DevExpress.XtraEditors.LabelControl();
            this.lblDataScadenza = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.bndLinee = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.lblQtaScatola = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lkLinee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txDataConfezionamento.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txDataConfezionamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndLinee)).BeginInit();
            this.SuspendLayout();
            // 
            // lkLinee
            // 
            this.lkLinee.Location = new System.Drawing.Point(23, 118);
            this.lkLinee.Name = "lkLinee";
            this.lkLinee.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkLinee.Properties.Appearance.Options.UseFont = true;
            this.lkLinee.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkLinee.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lkLinee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkLinee.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descrizione", "Descrizione", 63, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkLinee.Properties.DataSource = this.bndLinee;
            this.lkLinee.Properties.DisplayMember = "Descrizione";
            this.lkLinee.Properties.NullText = "<seleziona la linea>";
            this.lkLinee.Properties.ShowFooter = false;
            this.lkLinee.Properties.ShowHeader = false;
            this.lkLinee.Properties.ShowLines = false;
            this.lkLinee.Properties.ValueMember = "Codice";
            this.lkLinee.Size = new System.Drawing.Size(327, 30);
            this.lkLinee.TabIndex = 0;
            this.lkLinee.EditValueChanged += new System.EventHandler(this.lkLinee_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(23, 98);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "LINEA";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(357, 98);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "ARTICOLO";
            // 
            // lblArticolo
            // 
            this.lblArticolo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArticolo.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticolo.Appearance.Options.UseFont = true;
            this.lblArticolo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblArticolo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblArticolo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblArticolo.Location = new System.Drawing.Point(356, 118);
            this.lblArticolo.Name = "lblArticolo";
            this.lblArticolo.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblArticolo.Size = new System.Drawing.Size(652, 30);
            this.lblArticolo.TabIndex = 3;
            this.lblArticolo.Click += new System.EventHandler(this.lblArticolo_Click);
            // 
            // btnInvia
            // 
            this.btnInvia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvia.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvia.Appearance.Options.UseFont = true;
            this.btnInvia.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnInvia.ImageOptions.SvgImage")));
            this.btnInvia.Location = new System.Drawing.Point(1014, 103);
            this.btnInvia.Name = "btnInvia";
            this.btnInvia.Size = new System.Drawing.Size(217, 45);
            this.btnInvia.TabIndex = 20;
            this.btnInvia.Text = "INVIA ALLA LINEA";
            this.btnInvia.Click += new System.EventHandler(this.btnInvia_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(24, 18);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(150, 14);
            this.labelControl3.TabIndex = 21;
            this.labelControl3.Text = "DATA CONFEZIONAMENTO";
            // 
            // txDataConfezionamento
            // 
            this.txDataConfezionamento.EditValue = null;
            this.txDataConfezionamento.Location = new System.Drawing.Point(23, 38);
            this.txDataConfezionamento.Name = "txDataConfezionamento";
            this.txDataConfezionamento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txDataConfezionamento.Properties.Appearance.Options.UseFont = true;
            this.txDataConfezionamento.Properties.Appearance.Options.UseTextOptions = true;
            this.txDataConfezionamento.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txDataConfezionamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txDataConfezionamento.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txDataConfezionamento.Size = new System.Drawing.Size(327, 30);
            this.txDataConfezionamento.TabIndex = 22;
            this.txDataConfezionamento.EditValueChanged += new System.EventHandler(this.txDataConfezionamento_EditValueChanged);
            // 
            // timerDataConfezionamento
            // 
            this.timerDataConfezionamento.Interval = 3000;
            this.timerDataConfezionamento.Tag = "";
            this.timerDataConfezionamento.Tick += new System.EventHandler(this.timerDataConfezionamento_Tick);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(356, 18);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 14);
            this.labelControl4.TabIndex = 23;
            this.labelControl4.Text = "LOTTO";
            // 
            // lblLotto
            // 
            this.lblLotto.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblLotto.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotto.Appearance.Options.UseBackColor = true;
            this.lblLotto.Appearance.Options.UseFont = true;
            this.lblLotto.Appearance.Options.UseTextOptions = true;
            this.lblLotto.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblLotto.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLotto.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblLotto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLotto.Location = new System.Drawing.Point(357, 37);
            this.lblLotto.Name = "lblLotto";
            this.lblLotto.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblLotto.Size = new System.Drawing.Size(272, 30);
            this.lblLotto.TabIndex = 24;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(570, 184);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(99, 14);
            this.labelControl5.TabIndex = 25;
            this.labelControl5.Text = "DESC.LEGALE ITA";
            // 
            // lblDescCommerciale
            // 
            this.lblDescCommerciale.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescCommerciale.Appearance.Options.UseFont = true;
            this.lblDescCommerciale.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDescCommerciale.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblDescCommerciale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDescCommerciale.Location = new System.Drawing.Point(24, 204);
            this.lblDescCommerciale.Name = "lblDescCommerciale";
            this.lblDescCommerciale.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblDescCommerciale.Size = new System.Drawing.Size(527, 30);
            this.lblDescCommerciale.TabIndex = 26;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(24, 184);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(117, 14);
            this.labelControl7.TabIndex = 27;
            this.labelControl7.Text = "DESC. COMMERCIALE";
            // 
            // lblDescLegaleITA
            // 
            this.lblDescLegaleITA.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescLegaleITA.Appearance.Options.UseFont = true;
            this.lblDescLegaleITA.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDescLegaleITA.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblDescLegaleITA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDescLegaleITA.Location = new System.Drawing.Point(570, 204);
            this.lblDescLegaleITA.Name = "lblDescLegaleITA";
            this.lblDescLegaleITA.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblDescLegaleITA.Size = new System.Drawing.Size(527, 30);
            this.lblDescLegaleITA.TabIndex = 28;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(24, 251);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(136, 14);
            this.labelControl9.TabIndex = 29;
            this.labelControl9.Text = "DESC. COMMERCIALE EN";
            // 
            // lblDescCommercialeEN
            // 
            this.lblDescCommercialeEN.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescCommercialeEN.Appearance.Options.UseFont = true;
            this.lblDescCommercialeEN.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDescCommercialeEN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblDescCommercialeEN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDescCommercialeEN.Location = new System.Drawing.Point(24, 271);
            this.lblDescCommercialeEN.Name = "lblDescCommercialeEN";
            this.lblDescCommercialeEN.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblDescCommercialeEN.Size = new System.Drawing.Size(527, 30);
            this.lblDescCommercialeEN.TabIndex = 30;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(570, 251);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(135, 14);
            this.labelControl6.TabIndex = 31;
            this.labelControl6.Text = "DESC. COMMERCIALE ES";
            // 
            // lblDescCommercialeES
            // 
            this.lblDescCommercialeES.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescCommercialeES.Appearance.Options.UseFont = true;
            this.lblDescCommercialeES.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDescCommercialeES.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblDescCommercialeES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDescCommercialeES.Location = new System.Drawing.Point(570, 271);
            this.lblDescCommercialeES.Name = "lblDescCommercialeES";
            this.lblDescCommercialeES.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblDescCommercialeES.Size = new System.Drawing.Size(527, 30);
            this.lblDescCommercialeES.TabIndex = 32;
            // 
            // lblDescCommercialeDE
            // 
            this.lblDescCommercialeDE.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescCommercialeDE.Appearance.Options.UseFont = true;
            this.lblDescCommercialeDE.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDescCommercialeDE.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblDescCommercialeDE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDescCommercialeDE.Location = new System.Drawing.Point(24, 333);
            this.lblDescCommercialeDE.Name = "lblDescCommercialeDE";
            this.lblDescCommercialeDE.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblDescCommercialeDE.Size = new System.Drawing.Size(527, 30);
            this.lblDescCommercialeDE.TabIndex = 34;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(24, 313);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(136, 14);
            this.labelControl10.TabIndex = 33;
            this.labelControl10.Text = "DESC. COMMERCIALE DE";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(570, 313);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(135, 14);
            this.labelControl8.TabIndex = 35;
            this.labelControl8.Text = "DESC. COMMERCIALE FR";
            // 
            // lblDescCommercialeFR
            // 
            this.lblDescCommercialeFR.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescCommercialeFR.Appearance.Options.UseFont = true;
            this.lblDescCommercialeFR.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDescCommercialeFR.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblDescCommercialeFR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDescCommercialeFR.Location = new System.Drawing.Point(570, 333);
            this.lblDescCommercialeFR.Name = "lblDescCommercialeFR";
            this.lblDescCommercialeFR.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblDescCommercialeFR.Size = new System.Drawing.Size(527, 30);
            this.lblDescCommercialeFR.TabIndex = 36;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(24, 385);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(24, 14);
            this.labelControl11.TabIndex = 37;
            this.labelControl11.Text = "TMC";
            // 
            // lblTmc
            // 
            this.lblTmc.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTmc.Appearance.Options.UseFont = true;
            this.lblTmc.Appearance.Options.UseTextOptions = true;
            this.lblTmc.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTmc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTmc.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblTmc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTmc.Location = new System.Drawing.Point(24, 405);
            this.lblTmc.Name = "lblTmc";
            this.lblTmc.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblTmc.Size = new System.Drawing.Size(150, 30);
            this.lblTmc.TabIndex = 38;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(219, 385);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(118, 14);
            this.labelControl12.TabIndex = 39;
            this.labelControl12.Text = "Scadenza a fine mese";
            // 
            // lblScadenzaFineMese
            // 
            this.lblScadenzaFineMese.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScadenzaFineMese.Appearance.Options.UseFont = true;
            this.lblScadenzaFineMese.Appearance.Options.UseTextOptions = true;
            this.lblScadenzaFineMese.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblScadenzaFineMese.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblScadenzaFineMese.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblScadenzaFineMese.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblScadenzaFineMese.Location = new System.Drawing.Point(219, 405);
            this.lblScadenzaFineMese.Name = "lblScadenzaFineMese";
            this.lblScadenzaFineMese.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblScadenzaFineMese.Size = new System.Drawing.Size(150, 30);
            this.lblScadenzaFineMese.TabIndex = 40;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(401, 385);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(42, 14);
            this.labelControl13.TabIndex = 41;
            this.labelControl13.Text = "Tipo BC";
            // 
            // lblTipoBc
            // 
            this.lblTipoBc.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoBc.Appearance.Options.UseFont = true;
            this.lblTipoBc.Appearance.Options.UseTextOptions = true;
            this.lblTipoBc.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTipoBc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTipoBc.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblTipoBc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTipoBc.Location = new System.Drawing.Point(401, 405);
            this.lblTipoBc.Name = "lblTipoBc";
            this.lblTipoBc.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblTipoBc.Size = new System.Drawing.Size(150, 30);
            this.lblTipoBc.TabIndex = 42;
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Location = new System.Drawing.Point(570, 385);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(44, 14);
            this.labelControl14.TabIndex = 43;
            this.labelControl14.Text = "Barcode";
            // 
            // lblBarcode
            // 
            this.lblBarcode.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.Appearance.Options.UseFont = true;
            this.lblBarcode.Appearance.Options.UseTextOptions = true;
            this.lblBarcode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBarcode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBarcode.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblBarcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBarcode.Location = new System.Drawing.Point(570, 405);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblBarcode.Size = new System.Drawing.Size(216, 30);
            this.lblBarcode.TabIndex = 44;
            // 
            // lblDataScadenza
            // 
            this.lblDataScadenza.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblDataScadenza.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataScadenza.Appearance.Options.UseBackColor = true;
            this.lblDataScadenza.Appearance.Options.UseFont = true;
            this.lblDataScadenza.Appearance.Options.UseTextOptions = true;
            this.lblDataScadenza.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblDataScadenza.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDataScadenza.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblDataScadenza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDataScadenza.Location = new System.Drawing.Point(635, 37);
            this.lblDataScadenza.Name = "lblDataScadenza";
            this.lblDataScadenza.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblDataScadenza.Size = new System.Drawing.Size(272, 30);
            this.lblDataScadenza.TabIndex = 45;
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl16.Appearance.Options.UseFont = true;
            this.labelControl16.Location = new System.Drawing.Point(635, 17);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(96, 14);
            this.labelControl16.TabIndex = 46;
            this.labelControl16.Text = "DATA SCADENZA";
            // 
            // bndLinee
            // 
            this.bndLinee.DataSource = typeof(ShellDotSp.Plugin.GelatoClubCore.Model.LookUpDataCollection);
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(797, 385);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(63, 14);
            this.labelControl15.TabIndex = 47;
            this.labelControl15.Text = "Qta Scatola";
            // 
            // lblQtaScatola
            // 
            this.lblQtaScatola.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtaScatola.Appearance.Options.UseFont = true;
            this.lblQtaScatola.Appearance.Options.UseTextOptions = true;
            this.lblQtaScatola.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblQtaScatola.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblQtaScatola.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblQtaScatola.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblQtaScatola.Location = new System.Drawing.Point(797, 405);
            this.lblQtaScatola.Name = "lblQtaScatola";
            this.lblQtaScatola.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblQtaScatola.Size = new System.Drawing.Size(139, 30);
            this.lblQtaScatola.TabIndex = 48;
            // 
            // MainControlGelatoClubProduzione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblQtaScatola);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.lblDataScadenza);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.lblTipoBc);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.lblScadenzaFineMese);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.lblTmc);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.lblDescCommercialeFR);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.lblDescCommercialeDE);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.lblDescCommercialeES);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.lblDescCommercialeEN);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.lblDescLegaleITA);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.lblDescCommerciale);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lblLotto);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txDataConfezionamento);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnInvia);
            this.Controls.Add(this.lblArticolo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lkLinee);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainControlGelatoClubProduzione";
            this.Size = new System.Drawing.Size(1234, 563);
            ((System.ComponentModel.ISupportInitialize)(this.lkLinee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txDataConfezionamento.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txDataConfezionamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndLinee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bndLinee;
        private DevExpress.XtraEditors.LookUpEdit lkLinee;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblArticolo;
        private DevExpress.XtraEditors.SimpleButton btnInvia;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit txDataConfezionamento;
        private System.Windows.Forms.Timer timerDataConfezionamento;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblLotto;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblDescCommerciale;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl lblDescLegaleITA;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl lblDescCommercialeEN;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblDescCommercialeES;
        private DevExpress.XtraEditors.LabelControl lblDescCommercialeDE;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl lblDescCommercialeFR;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl lblTmc;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl lblScadenzaFineMese;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl lblTipoBc;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl lblBarcode;
        private DevExpress.XtraEditors.LabelControl lblDataScadenza;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl lblQtaScatola;
    }
}
