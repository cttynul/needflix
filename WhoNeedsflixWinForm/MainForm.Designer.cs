namespace WhoNeedsflixWinForm
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.searchTextBox = new MetroFramework.Controls.MetroTextBox();
            this.searchButton = new MetroFramework.Controls.MetroButton();
            this._labelResult = new MetroFramework.Controls.MetroLink();
            this._geckoWebBrowser = new Gecko.GeckoWebBrowser();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this._richDescription = new System.Windows.Forms.RichTextBox();
            this._radioGuarda = new MetroFramework.Controls.MetroRadioButton();
            this._radioA01 = new MetroFramework.Controls.MetroRadioButton();
            this._tvShowTimeLabel = new MetroFramework.Controls.MetroLink();
            this._gridTVSeries = new MetroFramework.Controls.MetroGrid();
            this._labelCountResult = new MetroFramework.Controls.MetroLabel();
            this._helpButton = new MetroFramework.Controls.MetroLink();
            this._combobox = new MetroFramework.Controls.MetroComboBox();
            this._radioAnime = new MetroFramework.Controls.MetroRadioButton();
            this._iconizeBtn = new MetroFramework.Controls.MetroLink();
            this._maximizeBtn = new MetroFramework.Controls.MetroLink();
            this._closeBtn = new MetroFramework.Controls.MetroLink();
            this._searchIcon = new MetroFramework.Controls.MetroLink();
            this._fullscreenHeaderBtn = new MetroFramework.Controls.MetroLink();
            this._settingsIcon = new MetroFramework.Controls.MetroLink();
            this._aboutIcon = new MetroFramework.Controls.MetroLink();
            this._helpIcon = new MetroFramework.Controls.MetroLink();
            this._mainPic = new System.Windows.Forms.PictureBox();
            this._showFavsIcon = new MetroFramework.Controls.MetroLink();
            this._addToFavBtn = new MetroFramework.Controls.MetroLink();
            this._trailerButton = new System.Windows.Forms.PictureBox();
            this._guardaButton = new System.Windows.Forms.PictureBox();
            this._header = new System.Windows.Forms.PictureBox();
            this._headerBGHome = new System.Windows.Forms.PictureBox();
            this._backBtn = new MetroFramework.Controls.MetroLink();
            this._downloadButton = new System.Windows.Forms.Label();
            this._miniNoFullScreen = new System.Windows.Forms.PictureBox();
            this._showBottomBar = new System.Windows.Forms.PictureBox();
            this._hideButtonBar = new System.Windows.Forms.PictureBox();
            this._homeBtn = new System.Windows.Forms.PictureBox();
            this._footerBackground = new System.Windows.Forms.PictureBox();
            this._fullScreen = new System.Windows.Forms.PictureBox();
            this._headerPlayerImage = new System.Windows.Forms.PictureBox();
            this._headerBackground = new System.Windows.Forms.PictureBox();
            this._resultPictureBox = new System.Windows.Forms.PictureBox();
            this._nextBtn = new MetroFramework.Controls.MetroLink();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._backgroundToBePopuled = new System.Windows.Forms.PictureBox();
            this.episodioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriesDictionaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridTVSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mainPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._trailerButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._guardaButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._header)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._headerBGHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._miniNoFullScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._showBottomBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._hideButtonBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._homeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._footerBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._fullScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._headerPlayerImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._headerBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._resultPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._backgroundToBePopuled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesDictionaryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            // 
            // 
            // 
            this.searchTextBox.CustomButton.Image = null;
            this.searchTextBox.CustomButton.Location = new System.Drawing.Point(637, 1);
            this.searchTextBox.CustomButton.Name = "";
            this.searchTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.searchTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.searchTextBox.CustomButton.TabIndex = 1;
            this.searchTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.searchTextBox.CustomButton.UseSelectable = true;
            this.searchTextBox.CustomButton.Visible = false;
            this.searchTextBox.Lines = new string[] {
        "Inserisci il Film o la Serie TV da cercare"};
            this.searchTextBox.Location = new System.Drawing.Point(223, 33);
            this.searchTextBox.MaxLength = 32767;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.PasswordChar = '\0';
            this.searchTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchTextBox.SelectedText = "";
            this.searchTextBox.SelectionLength = 0;
            this.searchTextBox.SelectionStart = 0;
            this.searchTextBox.ShortcutsEnabled = true;
            this.searchTextBox.Size = new System.Drawing.Size(659, 23);
            this.searchTextBox.Style = MetroFramework.MetroColorStyle.Red;
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.Text = "Inserisci il Film o la Serie TV da cercare";
            this.searchTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.searchTextBox.UseCustomBackColor = true;
            this.searchTextBox.UseSelectable = true;
            this.searchTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.searchTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.searchTextBox.Click += new System.EventHandler(this.searchTextBox_Click);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(780, 226);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(0, 0);
            this.searchButton.Style = MetroFramework.MetroColorStyle.Red;
            this.searchButton.TabIndex = 0;
            this.searchButton.Text = "Cerca";
            this.searchButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.searchButton.UseSelectable = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // _labelResult
            // 
            this._labelResult.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._labelResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this._labelResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this._labelResult.FontSize = MetroFramework.MetroLinkSize.Tall;
            this._labelResult.FontWeight = MetroFramework.MetroLinkWeight.Light;
            this._labelResult.ForeColor = System.Drawing.SystemColors.Control;
            this._labelResult.Location = new System.Drawing.Point(332, 168);
            this._labelResult.Name = "_labelResult";
            this._labelResult.Size = new System.Drawing.Size(426, 31);
            this._labelResult.Style = MetroFramework.MetroColorStyle.Red;
            this._labelResult.TabIndex = 3;
            this._labelResult.Text = "NoResult";
            this._labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._labelResult.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._labelResult.UseCustomBackColor = true;
            this._labelResult.UseSelectable = true;
            this._labelResult.Click += new System.EventHandler(this._labelResult_Click);
            // 
            // _geckoWebBrowser
            // 
            this._geckoWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._geckoWebBrowser.FrameEventsPropagateToMainWindow = false;
            this._geckoWebBrowser.Location = new System.Drawing.Point(0, 0);
            this._geckoWebBrowser.Name = "_geckoWebBrowser";
            this._geckoWebBrowser.Size = new System.Drawing.Size(1041, 562);
            this._geckoWebBrowser.TabIndex = 5;
            this._geckoWebBrowser.UseHttpActivityObserver = false;
            this._geckoWebBrowser.Visible = false;
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = null;
            // 
            // _richDescription
            // 
            this._richDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._richDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this._richDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._richDescription.Cursor = System.Windows.Forms.Cursors.Arrow;
            this._richDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._richDescription.ForeColor = System.Drawing.SystemColors.Window;
            this._richDescription.Location = new System.Drawing.Point(338, 205);
            this._richDescription.MaxLength = 793;
            this._richDescription.Name = "_richDescription";
            this._richDescription.ReadOnly = true;
            this._richDescription.Size = new System.Drawing.Size(599, 273);
            this._richDescription.TabIndex = 9;
            this._richDescription.Text = "";
            // 
            // _radioGuarda
            // 
            this._radioGuarda.AutoSize = true;
            this._radioGuarda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._radioGuarda.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this._radioGuarda.Location = new System.Drawing.Point(290, 62);
            this._radioGuarda.Name = "_radioGuarda";
            this._radioGuarda.Size = new System.Drawing.Size(91, 25);
            this._radioGuarda.Style = MetroFramework.MetroColorStyle.Red;
            this._radioGuarda.TabIndex = 38;
            this._radioGuarda.Text = "Serie TV";
            this._radioGuarda.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._radioGuarda.UseCustomBackColor = true;
            this._radioGuarda.UseSelectable = true;
            this._radioGuarda.CheckedChanged += new System.EventHandler(this._radioGuarda_CheckedChanged);
            // 
            // _radioA01
            // 
            this._radioA01.AutoSize = true;
            this._radioA01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._radioA01.Checked = true;
            this._radioA01.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this._radioA01.Location = new System.Drawing.Point(223, 62);
            this._radioA01.Name = "_radioA01";
            this._radioA01.Size = new System.Drawing.Size(61, 25);
            this._radioA01.Style = MetroFramework.MetroColorStyle.Red;
            this._radioA01.TabIndex = 39;
            this._radioA01.TabStop = true;
            this._radioA01.Text = "Film";
            this._radioA01.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._radioA01.UseCustomBackColor = true;
            this._radioA01.UseSelectable = true;
            this._radioA01.CheckedChanged += new System.EventHandler(this._radioA01_CheckedChanged);
            // 
            // _tvShowTimeLabel
            // 
            this._tvShowTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._tvShowTimeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this._tvShowTimeLabel.FontWeight = MetroFramework.MetroLinkWeight.Light;
            this._tvShowTimeLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this._tvShowTimeLabel.ImageSize = 24;
            this._tvShowTimeLabel.Location = new System.Drawing.Point(12, 568);
            this._tvShowTimeLabel.Name = "_tvShowTimeLabel";
            this._tvShowTimeLabel.Size = new System.Drawing.Size(257, 36);
            this._tvShowTimeLabel.Style = MetroFramework.MetroColorStyle.White;
            this._tvShowTimeLabel.TabIndex = 42;
            this._tvShowTimeLabel.Text = "Aggiorna le ultime serie viste su TVShowTime";
            this._tvShowTimeLabel.UseCustomBackColor = true;
            this._tvShowTimeLabel.UseCustomForeColor = true;
            this._tvShowTimeLabel.UseSelectable = true;
            this._tvShowTimeLabel.Click += new System.EventHandler(this._tvShowTimeLabel_Click);
            // 
            // _gridTVSeries
            // 
            this._gridTVSeries.AllowUserToAddRows = false;
            this._gridTVSeries.AllowUserToDeleteRows = false;
            this._gridTVSeries.AllowUserToResizeRows = false;
            this._gridTVSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._gridTVSeries.AutoGenerateColumns = false;
            this._gridTVSeries.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this._gridTVSeries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._gridTVSeries.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._gridTVSeries.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._gridTVSeries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._gridTVSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridTVSeries.ColumnHeadersVisible = false;
            this._gridTVSeries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.episodioDataGridViewTextBoxColumn,
            this.urlDataGridViewTextBoxColumn});
            this._gridTVSeries.DataSource = this.seriesDictionaryBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridTVSeries.DefaultCellStyle = dataGridViewCellStyle2;
            this._gridTVSeries.EnableHeadersVisualStyles = false;
            this._gridTVSeries.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this._gridTVSeries.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this._gridTVSeries.Location = new System.Drawing.Point(338, 205);
            this._gridTVSeries.MultiSelect = false;
            this._gridTVSeries.Name = "_gridTVSeries";
            this._gridTVSeries.ReadOnly = true;
            this._gridTVSeries.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._gridTVSeries.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this._gridTVSeries.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this._gridTVSeries.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._gridTVSeries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridTVSeries.ShowEditingIcon = false;
            this._gridTVSeries.Size = new System.Drawing.Size(599, 273);
            this._gridTVSeries.Style = MetroFramework.MetroColorStyle.Silver;
            this._gridTVSeries.TabIndex = 47;
            this._gridTVSeries.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._gridTVSeries.UseCustomBackColor = true;
            this._gridTVSeries.Visible = false;
            this._gridTVSeries.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._gridTVSeries_Click);
            this._gridTVSeries.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._gridTVSeries_Click);
            // 
            // _labelCountResult
            // 
            this._labelCountResult.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._labelCountResult.Location = new System.Drawing.Point(856, 498);
            this._labelCountResult.Name = "_labelCountResult";
            this._labelCountResult.Size = new System.Drawing.Size(113, 19);
            this._labelCountResult.TabIndex = 52;
            this._labelCountResult.Text = "Risultati: 00 di 00";
            this._labelCountResult.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._labelCountResult.Visible = false;
            // 
            // _helpButton
            // 
            this._helpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._helpButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this._helpButton.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this._helpButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this._helpButton.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this._helpButton.ImageSize = 0;
            this._helpButton.Location = new System.Drawing.Point(766, 551);
            this._helpButton.Name = "_helpButton";
            this._helpButton.Size = new System.Drawing.Size(217, 65);
            this._helpButton.Style = MetroFramework.MetroColorStyle.White;
            this._helpButton.TabIndex = 32;
            this._helpButton.UseCustomBackColor = true;
            this._helpButton.UseCustomForeColor = true;
            this._helpButton.UseSelectable = true;
            this._helpButton.Click += new System.EventHandler(this._helpButton_LinkClicked);
            // 
            // _combobox
            // 
            this._combobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._combobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._combobox.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this._combobox.FormattingEnabled = true;
            this._combobox.ItemHeight = 19;
            this._combobox.Location = new System.Drawing.Point(472, 62);
            this._combobox.Name = "_combobox";
            this._combobox.Size = new System.Drawing.Size(410, 25);
            this._combobox.TabIndex = 60;
            this._combobox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._combobox.UseCustomBackColor = true;
            this._combobox.UseSelectable = true;
            this._combobox.UseStyleColors = true;
            this._combobox.SelectedIndexChanged += new System.EventHandler(this._combobox_SelectedIndexChanged);
            // 
            // _radioAnime
            // 
            this._radioAnime.AutoSize = true;
            this._radioAnime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._radioAnime.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this._radioAnime.Location = new System.Drawing.Point(387, 62);
            this._radioAnime.Name = "_radioAnime";
            this._radioAnime.Size = new System.Drawing.Size(79, 25);
            this._radioAnime.Style = MetroFramework.MetroColorStyle.Red;
            this._radioAnime.TabIndex = 64;
            this._radioAnime.Text = "Anime";
            this._radioAnime.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._radioAnime.UseCustomBackColor = true;
            this._radioAnime.UseSelectable = true;
            this._radioAnime.CheckedChanged += new System.EventHandler(this._radioAnime_CheckedChanged);
            // 
            // _iconizeBtn
            // 
            this._iconizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._iconizeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._iconizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this._iconizeBtn.Image = global::WhoNeedsflixWinForm.Properties.Resources.Minimize;
            this._iconizeBtn.ImageSize = 18;
            this._iconizeBtn.Location = new System.Drawing.Point(970, 0);
            this._iconizeBtn.Name = "_iconizeBtn";
            this._iconizeBtn.Size = new System.Drawing.Size(20, 20);
            this._iconizeBtn.TabIndex = 63;
            this._iconizeBtn.UseCustomBackColor = true;
            this._iconizeBtn.UseSelectable = true;
            this._iconizeBtn.Click += new System.EventHandler(this._iconizeBtn_Click);
            // 
            // _maximizeBtn
            // 
            this._maximizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._maximizeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._maximizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this._maximizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("_maximizeBtn.Image")));
            this._maximizeBtn.ImageSize = 18;
            this._maximizeBtn.Location = new System.Drawing.Point(990, 0);
            this._maximizeBtn.Name = "_maximizeBtn";
            this._maximizeBtn.Size = new System.Drawing.Size(20, 20);
            this._maximizeBtn.TabIndex = 62;
            this._maximizeBtn.UseCustomBackColor = true;
            this._maximizeBtn.UseSelectable = true;
            this._maximizeBtn.Click += new System.EventHandler(this._maximizeBtn_Click);
            // 
            // _closeBtn
            // 
            this._closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._closeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this._closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("_closeBtn.Image")));
            this._closeBtn.ImageSize = 18;
            this._closeBtn.Location = new System.Drawing.Point(1011, 0);
            this._closeBtn.Name = "_closeBtn";
            this._closeBtn.Size = new System.Drawing.Size(20, 20);
            this._closeBtn.TabIndex = 61;
            this._closeBtn.UseCustomBackColor = true;
            this._closeBtn.UseSelectable = true;
            this._closeBtn.Click += new System.EventHandler(this._closeBtn_Click);
            // 
            // _searchIcon
            // 
            this._searchIcon.AccessibleDescription = "";
            this._searchIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._searchIcon.AutoSize = true;
            this._searchIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._searchIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this._searchIcon.Image = global::WhoNeedsflixWinForm.Properties.Resources.search_material;
            this._searchIcon.ImageSize = 20;
            this._searchIcon.Location = new System.Drawing.Point(888, 33);
            this._searchIcon.Name = "_searchIcon";
            this._searchIcon.Size = new System.Drawing.Size(23, 23);
            this._searchIcon.Style = MetroFramework.MetroColorStyle.White;
            this._searchIcon.TabIndex = 59;
            this._searchIcon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._searchIcon.UseCustomBackColor = true;
            this._searchIcon.UseCustomForeColor = true;
            this._searchIcon.UseSelectable = true;
            this._searchIcon.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // _fullscreenHeaderBtn
            // 
            this._fullscreenHeaderBtn.AccessibleDescription = "";
            this._fullscreenHeaderBtn.AutoSize = true;
            this._fullscreenHeaderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._fullscreenHeaderBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this._fullscreenHeaderBtn.Image = global::WhoNeedsflixWinForm.Properties.Resources.stretch_2_;
            this._fullscreenHeaderBtn.ImageSize = 20;
            this._fullscreenHeaderBtn.Location = new System.Drawing.Point(1, 1);
            this._fullscreenHeaderBtn.Name = "_fullscreenHeaderBtn";
            this._fullscreenHeaderBtn.Size = new System.Drawing.Size(30, 29);
            this._fullscreenHeaderBtn.Style = MetroFramework.MetroColorStyle.White;
            this._fullscreenHeaderBtn.TabIndex = 56;
            this._fullscreenHeaderBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._fullscreenHeaderBtn.UseCustomBackColor = true;
            this._fullscreenHeaderBtn.UseCustomForeColor = true;
            this._fullscreenHeaderBtn.UseSelectable = true;
            this._fullscreenHeaderBtn.Click += new System.EventHandler(this._fullScreen_Click);
            // 
            // _settingsIcon
            // 
            this._settingsIcon.AccessibleDescription = "";
            this._settingsIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._settingsIcon.AutoSize = true;
            this._settingsIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._settingsIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this._settingsIcon.Image = global::WhoNeedsflixWinForm.Properties.Resources.settings_material;
            this._settingsIcon.ImageSize = 20;
            this._settingsIcon.Location = new System.Drawing.Point(975, 33);
            this._settingsIcon.Name = "_settingsIcon";
            this._settingsIcon.Size = new System.Drawing.Size(23, 23);
            this._settingsIcon.Style = MetroFramework.MetroColorStyle.White;
            this._settingsIcon.TabIndex = 55;
            this._settingsIcon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._settingsIcon.UseCustomBackColor = true;
            this._settingsIcon.UseCustomForeColor = true;
            this._settingsIcon.UseSelectable = true;
            this._settingsIcon.Click += new System.EventHandler(this._settingsIcon_Click);
            // 
            // _aboutIcon
            // 
            this._aboutIcon.AccessibleDescription = "";
            this._aboutIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._aboutIcon.AutoSize = true;
            this._aboutIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._aboutIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this._aboutIcon.Image = global::WhoNeedsflixWinForm.Properties.Resources.info_rounded;
            this._aboutIcon.ImageSize = 20;
            this._aboutIcon.Location = new System.Drawing.Point(1004, 33);
            this._aboutIcon.Name = "_aboutIcon";
            this._aboutIcon.Size = new System.Drawing.Size(23, 23);
            this._aboutIcon.TabIndex = 54;
            this._aboutIcon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._aboutIcon.UseCustomBackColor = true;
            this._aboutIcon.UseCustomForeColor = true;
            this._aboutIcon.UseSelectable = true;
            // 
            // _helpIcon
            // 
            this._helpIcon.AccessibleDescription = "";
            this._helpIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._helpIcon.AutoSize = true;
            this._helpIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._helpIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this._helpIcon.Image = global::WhoNeedsflixWinForm.Properties.Resources.help_rounded_white;
            this._helpIcon.ImageSize = 20;
            this._helpIcon.Location = new System.Drawing.Point(946, 33);
            this._helpIcon.Name = "_helpIcon";
            this._helpIcon.Size = new System.Drawing.Size(23, 23);
            this._helpIcon.Style = MetroFramework.MetroColorStyle.White;
            this._helpIcon.TabIndex = 53;
            this._helpIcon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._helpIcon.UseCustomBackColor = true;
            this._helpIcon.UseCustomForeColor = true;
            this._helpIcon.UseSelectable = true;
            // 
            // _mainPic
            // 
            this._mainPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._mainPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this._mainPic.Cursor = System.Windows.Forms.Cursors.Arrow;
            this._mainPic.Image = global::WhoNeedsflixWinForm.Properties.Resources.Blackground;
            this._mainPic.Location = new System.Drawing.Point(-5, 138);
            this._mainPic.Name = "_mainPic";
            this._mainPic.Size = new System.Drawing.Size(1041, 424);
            this._mainPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._mainPic.TabIndex = 35;
            this._mainPic.TabStop = false;
            // 
            // _showFavsIcon
            // 
            this._showFavsIcon.AccessibleDescription = "";
            this._showFavsIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._showFavsIcon.AutoSize = true;
            this._showFavsIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._showFavsIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this._showFavsIcon.Image = global::WhoNeedsflixWinForm.Properties.Resources.heart_white;
            this._showFavsIcon.ImageSize = 20;
            this._showFavsIcon.Location = new System.Drawing.Point(917, 33);
            this._showFavsIcon.Name = "_showFavsIcon";
            this._showFavsIcon.Size = new System.Drawing.Size(23, 23);
            this._showFavsIcon.Style = MetroFramework.MetroColorStyle.White;
            this._showFavsIcon.TabIndex = 50;
            this._showFavsIcon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._showFavsIcon.UseCustomBackColor = true;
            this._showFavsIcon.UseCustomForeColor = true;
            this._showFavsIcon.UseSelectable = true;
            this._showFavsIcon.Click += new System.EventHandler(this._showFavsButton_Click);
            // 
            // _addToFavBtn
            // 
            this._addToFavBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._addToFavBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this._addToFavBtn.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this._addToFavBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this._addToFavBtn.Image = global::WhoNeedsflixWinForm.Properties.Resources.favs;
            this._addToFavBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._addToFavBtn.Location = new System.Drawing.Point(632, 484);
            this._addToFavBtn.Name = "_addToFavBtn";
            this._addToFavBtn.Size = new System.Drawing.Size(149, 44);
            this._addToFavBtn.Style = MetroFramework.MetroColorStyle.White;
            this._addToFavBtn.TabIndex = 49;
            this._addToFavBtn.Text = "Aggiungi ai preferiti";
            this._addToFavBtn.UseCustomBackColor = true;
            this._addToFavBtn.UseCustomForeColor = true;
            this._addToFavBtn.UseSelectable = true;
            this._addToFavBtn.Visible = false;
            this._addToFavBtn.Click += new System.EventHandler(this._addToFavBtn_Click);
            // 
            // _trailerButton
            // 
            this._trailerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._trailerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this._trailerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this._trailerButton.Image = global::WhoNeedsflixWinForm.Properties.Resources.TrailerButton;
            this._trailerButton.Location = new System.Drawing.Point(477, 484);
            this._trailerButton.Name = "_trailerButton";
            this._trailerButton.Size = new System.Drawing.Size(149, 44);
            this._trailerButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._trailerButton.TabIndex = 48;
            this._trailerButton.TabStop = false;
            this._trailerButton.Visible = false;
            this._trailerButton.Click += new System.EventHandler(this._trailerButton_Click);
            // 
            // _guardaButton
            // 
            this._guardaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._guardaButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this._guardaButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this._guardaButton.Image = global::WhoNeedsflixWinForm.Properties.Resources.PlayButton;
            this._guardaButton.Location = new System.Drawing.Point(332, 484);
            this._guardaButton.Name = "_guardaButton";
            this._guardaButton.Size = new System.Drawing.Size(149, 44);
            this._guardaButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._guardaButton.TabIndex = 46;
            this._guardaButton.TabStop = false;
            this._guardaButton.Visible = false;
            this._guardaButton.Click += new System.EventHandler(this._labelResult_Click);
            // 
            // _header
            // 
            this._header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._header.Image = global::WhoNeedsflixWinForm.Properties.Resources.Header;
            this._header.Location = new System.Drawing.Point(46, 23);
            this._header.Name = "_header";
            this._header.Size = new System.Drawing.Size(155, 64);
            this._header.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._header.TabIndex = 11;
            this._header.TabStop = false;
            // 
            // _headerBGHome
            // 
            this._headerBGHome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._headerBGHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this._headerBGHome.Image = global::WhoNeedsflixWinForm.Properties.Resources.BackgroundHeaderHome;
            this._headerBGHome.Location = new System.Drawing.Point(-8, 1);
            this._headerBGHome.Name = "_headerBGHome";
            this._headerBGHome.Size = new System.Drawing.Size(1041, 132);
            this._headerBGHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._headerBGHome.TabIndex = 44;
            this._headerBGHome.TabStop = false;
            this._headerBGHome.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow);
            // 
            // _backBtn
            // 
            this._backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this._backBtn.Image = global::WhoNeedsflixWinForm.Properties.Resources.left_materialpack;
            this._backBtn.ImageSize = 32;
            this._backBtn.Location = new System.Drawing.Point(12, 274);
            this._backBtn.Name = "_backBtn";
            this._backBtn.Size = new System.Drawing.Size(38, 33);
            this._backBtn.Style = MetroFramework.MetroColorStyle.White;
            this._backBtn.TabIndex = 36;
            this._backBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._backBtn.UseCustomBackColor = true;
            this._backBtn.UseCustomForeColor = true;
            this._backBtn.UseSelectable = true;
            this._backBtn.Click += new System.EventHandler(this._backBtn_Click);
            // 
            // _downloadButton
            // 
            this._downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._downloadButton.BackColor = System.Drawing.Color.Black;
            this._downloadButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this._downloadButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._downloadButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this._downloadButton.Image = global::WhoNeedsflixWinForm.Properties.Resources.cloud_computing;
            this._downloadButton.Location = new System.Drawing.Point(43, 560);
            this._downloadButton.Name = "_downloadButton";
            this._downloadButton.Size = new System.Drawing.Size(84, 56);
            this._downloadButton.TabIndex = 31;
            this._downloadButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._downloadButton.Click += new System.EventHandler(this._downloadButton_Click);
            // 
            // _miniNoFullScreen
            // 
            this._miniNoFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._miniNoFullScreen.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._miniNoFullScreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this._miniNoFullScreen.Image = global::WhoNeedsflixWinForm.Properties.Resources.diagonal_3_;
            this._miniNoFullScreen.Location = new System.Drawing.Point(918, 576);
            this._miniNoFullScreen.Name = "_miniNoFullScreen";
            this._miniNoFullScreen.Padding = new System.Windows.Forms.Padding(3);
            this._miniNoFullScreen.Size = new System.Drawing.Size(25, 25);
            this._miniNoFullScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._miniNoFullScreen.TabIndex = 29;
            this._miniNoFullScreen.TabStop = false;
            this._miniNoFullScreen.Visible = false;
            this._miniNoFullScreen.Click += new System.EventHandler(this._miniFullScreen_Click);
            // 
            // _showBottomBar
            // 
            this._showBottomBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._showBottomBar.BackColor = System.Drawing.Color.Black;
            this._showBottomBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._showBottomBar.Image = global::WhoNeedsflixWinForm.Properties.Resources.slim_up;
            this._showBottomBar.Location = new System.Drawing.Point(977, 579);
            this._showBottomBar.Name = "_showBottomBar";
            this._showBottomBar.Padding = new System.Windows.Forms.Padding(3);
            this._showBottomBar.Size = new System.Drawing.Size(25, 25);
            this._showBottomBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._showBottomBar.TabIndex = 28;
            this._showBottomBar.TabStop = false;
            this._showBottomBar.Visible = false;
            // 
            // _hideButtonBar
            // 
            this._hideButtonBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._hideButtonBar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._hideButtonBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._hideButtonBar.Image = global::WhoNeedsflixWinForm.Properties.Resources.slim_down;
            this._hideButtonBar.Location = new System.Drawing.Point(975, 560);
            this._hideButtonBar.Name = "_hideButtonBar";
            this._hideButtonBar.Size = new System.Drawing.Size(56, 56);
            this._hideButtonBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._hideButtonBar.TabIndex = 27;
            this._hideButtonBar.TabStop = false;
            this._hideButtonBar.Click += new System.EventHandler(this._hideButtonBar_Click);
            // 
            // _homeBtn
            // 
            this._homeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._homeBtn.BackColor = System.Drawing.Color.Black;
            this._homeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this._homeBtn.Image = global::WhoNeedsflixWinForm.Properties.Resources.left_arrow;
            this._homeBtn.Location = new System.Drawing.Point(1, 560);
            this._homeBtn.Name = "_homeBtn";
            this._homeBtn.Size = new System.Drawing.Size(56, 56);
            this._homeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._homeBtn.TabIndex = 26;
            this._homeBtn.TabStop = false;
            this._homeBtn.Visible = false;
            this._homeBtn.Click += new System.EventHandler(this._homeBtn_Click);
            // 
            // _footerBackground
            // 
            this._footerBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._footerBackground.BackColor = System.Drawing.Color.Black;
            this._footerBackground.Location = new System.Drawing.Point(124, 560);
            this._footerBackground.Name = "_footerBackground";
            this._footerBackground.Size = new System.Drawing.Size(802, 56);
            this._footerBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._footerBackground.TabIndex = 23;
            this._footerBackground.TabStop = false;
            this._footerBackground.Visible = false;
            // 
            // _fullScreen
            // 
            this._fullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._fullScreen.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._fullScreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this._fullScreen.Image = global::WhoNeedsflixWinForm.Properties.Resources.stretch_2_;
            this._fullScreen.Location = new System.Drawing.Point(917, 560);
            this._fullScreen.Name = "_fullScreen";
            this._fullScreen.Size = new System.Drawing.Size(66, 56);
            this._fullScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._fullScreen.TabIndex = 12;
            this._fullScreen.TabStop = false;
            this._fullScreen.Visible = false;
            this._fullScreen.Click += new System.EventHandler(this._fullScreen_Click);
            // 
            // _headerPlayerImage
            // 
            this._headerPlayerImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._headerPlayerImage.BackColor = System.Drawing.Color.Black;
            this._headerPlayerImage.Image = global::WhoNeedsflixWinForm.Properties.Resources.Header_Player;
            this._headerPlayerImage.Location = new System.Drawing.Point(888, 1);
            this._headerPlayerImage.Name = "_headerPlayerImage";
            this._headerPlayerImage.Size = new System.Drawing.Size(145, 55);
            this._headerPlayerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._headerPlayerImage.TabIndex = 19;
            this._headerPlayerImage.TabStop = false;
            this._headerPlayerImage.Visible = false;
            // 
            // _headerBackground
            // 
            this._headerBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._headerBackground.BackColor = System.Drawing.Color.Black;
            this._headerBackground.Location = new System.Drawing.Point(0, 0);
            this._headerBackground.Name = "_headerBackground";
            this._headerBackground.Size = new System.Drawing.Size(1036, 56);
            this._headerBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._headerBackground.TabIndex = 8;
            this._headerBackground.TabStop = false;
            this._headerBackground.Visible = false;
            this._headerBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow);
            // 
            // _resultPictureBox
            // 
            this._resultPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._resultPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this._resultPictureBox.Location = new System.Drawing.Point(68, 168);
            this._resultPictureBox.Name = "_resultPictureBox";
            this._resultPictureBox.Size = new System.Drawing.Size(258, 361);
            this._resultPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._resultPictureBox.TabIndex = 2;
            this._resultPictureBox.TabStop = false;
            // 
            // _nextBtn
            // 
            this._nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._nextBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this._nextBtn.Image = global::WhoNeedsflixWinForm.Properties.Resources.right_materialpack;
            this._nextBtn.ImageSize = 32;
            this._nextBtn.Location = new System.Drawing.Point(975, 274);
            this._nextBtn.Name = "_nextBtn";
            this._nextBtn.Size = new System.Drawing.Size(46, 33);
            this._nextBtn.Style = MetroFramework.MetroColorStyle.White;
            this._nextBtn.TabIndex = 37;
            this._nextBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._nextBtn.UseCustomBackColor = true;
            this._nextBtn.UseCustomForeColor = true;
            this._nextBtn.UseSelectable = true;
            this._nextBtn.Click += new System.EventHandler(this._nextResult_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.pictureBox1.Location = new System.Drawing.Point(46, 167);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(938, 378);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // _backgroundToBePopuled
            // 
            this._backgroundToBePopuled.Cursor = System.Windows.Forms.Cursors.Hand;
            this._backgroundToBePopuled.Dock = System.Windows.Forms.DockStyle.Fill;
            this._backgroundToBePopuled.Location = new System.Drawing.Point(0, 0);
            this._backgroundToBePopuled.Name = "_backgroundToBePopuled";
            this._backgroundToBePopuled.Size = new System.Drawing.Size(1033, 616);
            this._backgroundToBePopuled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._backgroundToBePopuled.TabIndex = 45;
            this._backgroundToBePopuled.TabStop = false;
            this._backgroundToBePopuled.Visible = false;
            // 
            // episodioDataGridViewTextBoxColumn
            // 
            this.episodioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.episodioDataGridViewTextBoxColumn.DataPropertyName = "Episodio";
            this.episodioDataGridViewTextBoxColumn.HeaderText = "Episodio";
            this.episodioDataGridViewTextBoxColumn.Name = "episodioDataGridViewTextBoxColumn";
            this.episodioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // urlDataGridViewTextBoxColumn
            // 
            this.urlDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.urlDataGridViewTextBoxColumn.DataPropertyName = "Url";
            this.urlDataGridViewTextBoxColumn.HeaderText = "Url";
            this.urlDataGridViewTextBoxColumn.Name = "urlDataGridViewTextBoxColumn";
            this.urlDataGridViewTextBoxColumn.ReadOnly = true;
            this.urlDataGridViewTextBoxColumn.Visible = false;
            // 
            // seriesDictionaryBindingSource
            // 
            this.seriesDictionaryBindingSource.DataSource = typeof(WhoNeedsflixWinForm.Utils.SeriesDictionary);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(1033, 616);
            this.Controls.Add(this._radioAnime);
            this.Controls.Add(this._iconizeBtn);
            this.Controls.Add(this._maximizeBtn);
            this.Controls.Add(this._closeBtn);
            this.Controls.Add(this._combobox);
            this.Controls.Add(this._searchIcon);
            this.Controls.Add(this._fullscreenHeaderBtn);
            this.Controls.Add(this._settingsIcon);
            this.Controls.Add(this._aboutIcon);
            this.Controls.Add(this._helpIcon);
            this.Controls.Add(this._mainPic);
            this.Controls.Add(this._labelCountResult);
            this.Controls.Add(this._showFavsIcon);
            this.Controls.Add(this._addToFavBtn);
            this.Controls.Add(this._trailerButton);
            this.Controls.Add(this._gridTVSeries);
            this.Controls.Add(this._guardaButton);
            this.Controls.Add(this._header);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this._radioGuarda);
            this.Controls.Add(this._radioA01);
            this.Controls.Add(this._headerBGHome);
            this.Controls.Add(this._backBtn);
            this.Controls.Add(this._tvShowTimeLabel);
            this.Controls.Add(this._helpButton);
            this.Controls.Add(this._downloadButton);
            this.Controls.Add(this._miniNoFullScreen);
            this.Controls.Add(this._showBottomBar);
            this.Controls.Add(this._hideButtonBar);
            this.Controls.Add(this._homeBtn);
            this.Controls.Add(this._footerBackground);
            this.Controls.Add(this._fullScreen);
            this.Controls.Add(this._headerPlayerImage);
            this.Controls.Add(this._richDescription);
            this.Controls.Add(this._headerBackground);
            this.Controls.Add(this._labelResult);
            this.Controls.Add(this._resultPictureBox);
            this.Controls.Add(this._nextBtn);
            this.Controls.Add(this._geckoWebBrowser);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._backgroundToBePopuled);
            this.Controls.Add(this.searchButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Needflix";
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridTVSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mainPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._trailerButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._guardaButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._header)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._headerBGHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._miniNoFullScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._showBottomBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._hideButtonBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._homeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._footerBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._fullScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._headerPlayerImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._headerBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._resultPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._backgroundToBePopuled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesDictionaryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox searchTextBox;
        private MetroFramework.Controls.MetroButton searchButton;
        private System.Windows.Forms.PictureBox _resultPictureBox;
        private MetroFramework.Controls.MetroLink _labelResult;
        private Gecko.GeckoWebBrowser _geckoWebBrowser;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private System.Windows.Forms.PictureBox _headerBackground;
        private System.Windows.Forms.RichTextBox _richDescription;
        private System.Windows.Forms.PictureBox _fullScreen;
        private System.Windows.Forms.PictureBox _header;
        private System.Windows.Forms.PictureBox _headerPlayerImage;
        private System.Windows.Forms.PictureBox _footerBackground;
        private System.Windows.Forms.PictureBox _homeBtn;
        private System.Windows.Forms.PictureBox _hideButtonBar;
        private System.Windows.Forms.PictureBox _showBottomBar;
        private System.Windows.Forms.PictureBox _miniNoFullScreen;
        private System.Windows.Forms.Label _downloadButton;
        private MetroFramework.Controls.MetroLink _helpButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox _mainPic;
        private MetroFramework.Controls.MetroLink _backBtn;
        private MetroFramework.Controls.MetroLink _nextBtn;
        private MetroFramework.Controls.MetroRadioButton _radioGuarda;
        private MetroFramework.Controls.MetroRadioButton _radioA01;
        private MetroFramework.Controls.MetroLink _tvShowTimeLabel;
        private System.Windows.Forms.PictureBox _headerBGHome;
        private System.Windows.Forms.PictureBox _backgroundToBePopuled;
        private System.Windows.Forms.PictureBox _guardaButton;
        private MetroFramework.Controls.MetroGrid _gridTVSeries;
        private System.Windows.Forms.BindingSource seriesDictionaryBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn episodioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
        private System.Windows.Forms.PictureBox _trailerButton;
        private MetroFramework.Controls.MetroLink _addToFavBtn;
        private MetroFramework.Controls.MetroLink _showFavsIcon;
        private MetroFramework.Controls.MetroLabel _labelCountResult;
        private MetroFramework.Controls.MetroLink _helpIcon;
        private MetroFramework.Controls.MetroLink _aboutIcon;
        private MetroFramework.Controls.MetroLink _settingsIcon;
        private MetroFramework.Controls.MetroLink _fullscreenHeaderBtn;
        private MetroFramework.Controls.MetroLink _searchIcon;
        private MetroFramework.Controls.MetroComboBox _combobox;
        private MetroFramework.Controls.MetroLink _closeBtn;
        private MetroFramework.Controls.MetroLink _maximizeBtn;
        private MetroFramework.Controls.MetroLink _iconizeBtn;
        private MetroFramework.Controls.MetroRadioButton _radioAnime;
    }
}

