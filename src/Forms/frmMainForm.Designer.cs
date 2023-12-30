namespace OLKI.Programme.ReFiDa.src.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblNewDateFormat = new System.Windows.Forms.Label();
            this.grbFiles = new System.Windows.Forms.GroupBox();
            this.nudShortenFilenamesLimit = new System.Windows.Forms.NumericUpDown();
            this.chkShortenFilenames = new System.Windows.Forms.CheckBox();
            this.chkSelectAllRenameableFiles = new System.Windows.Forms.CheckBox();
            this.btnRefreshFileList = new System.Windows.Forms.Button();
            this.chkCheckForAlreadyInTargetFormat = new System.Windows.Forms.CheckBox();
            this.lsvFiles = new OLKI.Toolbox.Widgets.SortListView();
            this.cohFilesOldFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cohFilesNewFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cohFilesDirectory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cohFilesNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExecutetConvert = new System.Windows.Forms.Button();
            this.chkFileSourceDirectorySub = new System.Windows.Forms.CheckBox();
            this.grbExecute = new System.Windows.Forms.GroupBox();
            this.chkQuitAfterRename = new System.Windows.Forms.CheckBox();
            this.chkInstantRename = new System.Windows.Forms.CheckBox();
            this.lblFileSourceDirectory = new System.Windows.Forms.Label();
            this.btnFileSourceDirectoryBrowse = new System.Windows.Forms.Button();
            this.txtFileSourceDirectoryPath = new System.Windows.Forms.TextBox();
            this.grbPrepare = new System.Windows.Forms.GroupBox();
            this.lblFormatOutlook = new System.Windows.Forms.LinkLabel();
            this.lblFormatHelp = new System.Windows.Forms.LinkLabel();
            this.uscNewDate = new OLKI.Programme.ReFiDa.src.Forms.uscDateFormatEditor();
            this.txtFilenamePreview = new System.Windows.Forms.TextBox();
            this.grbDateSearchFormats = new System.Windows.Forms.GroupBox();
            this.uscSearchDate = new OLKI.Programme.ReFiDa.src.Forms.uscDateFormatEditor();
            this.lsvDateSearchFormats = new OLKI.Toolbox.Widgets.SortListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDateSearchFormaRemove = new System.Windows.Forms.Button();
            this.btnDateSearchFormatAdd = new System.Windows.Forms.Button();
            this.lblDateSource = new System.Windows.Forms.Label();
            this.cboDateSource = new System.Windows.Forms.ComboBox();
            this.tabFileSource = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblFileSourceSelect = new System.Windows.Forms.Label();
            this.btnFileSourceSelectBrowse = new System.Windows.Forms.Button();
            this.txtFileSourceSelectPath = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnFileSourceDirectoryRefresh = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblFileSourceDragAndDrop = new System.Windows.Forms.Label();
            this.grbFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShortenFilenamesLimit)).BeginInit();
            this.grbExecute.SuspendLayout();
            this.grbPrepare.SuspendLayout();
            this.grbDateSearchFormats.SuspendLayout();
            this.tabFileSource.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNewDateFormat
            // 
            this.lblNewDateFormat.AutoSize = true;
            this.lblNewDateFormat.Location = new System.Drawing.Point(6, 130);
            this.lblNewDateFormat.Name = "lblNewDateFormat";
            this.lblNewDateFormat.Size = new System.Drawing.Size(125, 13);
            this.lblNewDateFormat.TabIndex = 4;
            this.lblNewDateFormat.Text = "Neues Format für Datum:";
            // 
            // grbFiles
            // 
            this.grbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFiles.Controls.Add(this.nudShortenFilenamesLimit);
            this.grbFiles.Controls.Add(this.chkShortenFilenames);
            this.grbFiles.Controls.Add(this.chkSelectAllRenameableFiles);
            this.grbFiles.Controls.Add(this.btnRefreshFileList);
            this.grbFiles.Controls.Add(this.chkCheckForAlreadyInTargetFormat);
            this.grbFiles.Controls.Add(this.lsvFiles);
            this.grbFiles.Location = new System.Drawing.Point(13, 216);
            this.grbFiles.Name = "grbFiles";
            this.grbFiles.Size = new System.Drawing.Size(749, 254);
            this.grbFiles.TabIndex = 0;
            this.grbFiles.TabStop = false;
            this.grbFiles.Text = "Vorschau";
            // 
            // nudShortenFilenamesLimit
            // 
            this.nudShortenFilenamesLimit.Location = new System.Drawing.Point(519, 24);
            this.nudShortenFilenamesLimit.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudShortenFilenamesLimit.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudShortenFilenamesLimit.Name = "nudShortenFilenamesLimit";
            this.nudShortenFilenamesLimit.Size = new System.Drawing.Size(60, 20);
            this.nudShortenFilenamesLimit.TabIndex = 2;
            this.nudShortenFilenamesLimit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudShortenFilenamesLimit.ValueChanged += new System.EventHandler(this.nudShortenFilenamesLimit_ValueChanged);
            // 
            // chkShortenFilenames
            // 
            this.chkShortenFilenames.AutoSize = true;
            this.chkShortenFilenames.Location = new System.Drawing.Point(324, 24);
            this.chkShortenFilenames.Name = "chkShortenFilenames";
            this.chkShortenFilenames.Size = new System.Drawing.Size(189, 17);
            this.chkShortenFilenames.TabIndex = 1;
            this.chkShortenFilenames.Text = "Lange Dateipfade kürzen. Grenze:";
            this.chkShortenFilenames.UseVisualStyleBackColor = true;
            this.chkShortenFilenames.CheckedChanged += new System.EventHandler(this.chkShortenFilenames_CheckedChanged);
            // 
            // chkSelectAllRenameableFiles
            // 
            this.chkSelectAllRenameableFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSelectAllRenameableFiles.AutoSize = true;
            this.chkSelectAllRenameableFiles.Location = new System.Drawing.Point(6, 231);
            this.chkSelectAllRenameableFiles.Name = "chkSelectAllRenameableFiles";
            this.chkSelectAllRenameableFiles.Size = new System.Drawing.Size(373, 17);
            this.chkSelectAllRenameableFiles.TabIndex = 5;
            this.chkSelectAllRenameableFiles.Text = "Nach dem aktualisieren der Liste alle umbenennbaren Dateien auswählen";
            this.chkSelectAllRenameableFiles.UseVisualStyleBackColor = true;
            this.chkSelectAllRenameableFiles.CheckedChanged += new System.EventHandler(this.chkSelectAllRenameableFiles_CheckedChanged);
            // 
            // btnRefreshFileList
            // 
            this.btnRefreshFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshFileList.Image = global::OLKI.Programme.ReFiDa.Properties.Resources._112_RefreshArrow_Blue_16x16_72;
            this.btnRefreshFileList.Location = new System.Drawing.Point(603, 19);
            this.btnRefreshFileList.Name = "btnRefreshFileList";
            this.btnRefreshFileList.Size = new System.Drawing.Size(140, 24);
            this.btnRefreshFileList.TabIndex = 3;
            this.btnRefreshFileList.Text = "Liste Aktualisieren";
            this.btnRefreshFileList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefreshFileList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshFileList.UseVisualStyleBackColor = true;
            this.btnRefreshFileList.Click += new System.EventHandler(this.btnRefreshFileList_Click);
            // 
            // chkCheckForAlreadyInTargetFormat
            // 
            this.chkCheckForAlreadyInTargetFormat.AutoSize = true;
            this.chkCheckForAlreadyInTargetFormat.Location = new System.Drawing.Point(6, 23);
            this.chkCheckForAlreadyInTargetFormat.Name = "chkCheckForAlreadyInTargetFormat";
            this.chkCheckForAlreadyInTargetFormat.Size = new System.Drawing.Size(312, 17);
            this.chkCheckForAlreadyInTargetFormat.TabIndex = 0;
            this.chkCheckForAlreadyInTargetFormat.Text = "Dateien die bereits dem Zielformat entsprechen überspringen";
            this.chkCheckForAlreadyInTargetFormat.UseVisualStyleBackColor = true;
            this.chkCheckForAlreadyInTargetFormat.CheckedChanged += new System.EventHandler(this.chkCheckForAlreadyInTargetFormat_CheckedChanged);
            // 
            // lsvFiles
            // 
            this.lsvFiles.AllowDrop = true;
            this.lsvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lsvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cohFilesOldFilename,
            this.cohFilesNewFilename,
            this.cohFilesDirectory,
            this.cohFilesNote});
            this.lsvFiles.FullRowSelect = true;
            this.lsvFiles.GridLines = true;
            this.lsvFiles.HideSelection = false;
            this.lsvFiles.Location = new System.Drawing.Point(6, 49);
            this.lsvFiles.Name = "lsvFiles";
            this.lsvFiles.ShowItemToolTips = true;
            this.lsvFiles.Size = new System.Drawing.Size(737, 176);
            this.lsvFiles.TabIndex = 4;
            this.lsvFiles.UseCompatibleStateImageBehavior = false;
            this.lsvFiles.View = System.Windows.Forms.View.Details;
            this.lsvFiles.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lsvFiles_ColumnWidthChanged);
            this.lsvFiles.SelectedIndexChanged += new System.EventHandler(this.lsvFiles_SelectedIndexChanged);
            this.lsvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lsvFiles_DragDrop);
            this.lsvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lsvFiles_DragEnter);
            this.lsvFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvFilesPreview_KeyDown);
            this.lsvFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsvFiles_MouseDoubleClick);
            // 
            // cohFilesOldFilename
            // 
            this.cohFilesOldFilename.Text = "Dateiname alt";
            this.cohFilesOldFilename.Width = 200;
            // 
            // cohFilesNewFilename
            // 
            this.cohFilesNewFilename.Text = "Dateiname neu";
            this.cohFilesNewFilename.Width = 200;
            // 
            // cohFilesDirectory
            // 
            this.cohFilesDirectory.Text = "Ordner";
            this.cohFilesDirectory.Width = 200;
            // 
            // cohFilesNote
            // 
            this.cohFilesNote.Text = "Hinweis";
            this.cohFilesNote.Width = 115;
            // 
            // btnExecutetConvert
            // 
            this.btnExecutetConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecutetConvert.Image = global::OLKI.Programme.ReFiDa.Properties.Resources.FilesRename;
            this.btnExecutetConvert.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExecutetConvert.Location = new System.Drawing.Point(264, 19);
            this.btnExecutetConvert.Name = "btnExecutetConvert";
            this.btnExecutetConvert.Size = new System.Drawing.Size(478, 55);
            this.btnExecutetConvert.TabIndex = 1;
            this.btnExecutetConvert.Text = "Ausgewählte Dateiein umbenennen";
            this.btnExecutetConvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExecutetConvert.UseVisualStyleBackColor = true;
            this.btnExecutetConvert.Click += new System.EventHandler(this.btnExecutetConvert_Click);
            // 
            // chkFileSourceDirectorySub
            // 
            this.chkFileSourceDirectorySub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFileSourceDirectorySub.AutoSize = true;
            this.chkFileSourceDirectorySub.Checked = true;
            this.chkFileSourceDirectorySub.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFileSourceDirectorySub.Location = new System.Drawing.Point(611, 11);
            this.chkFileSourceDirectorySub.Name = "chkFileSourceDirectorySub";
            this.chkFileSourceDirectorySub.Size = new System.Drawing.Size(82, 17);
            this.chkFileSourceDirectorySub.TabIndex = 3;
            this.chkFileSourceDirectorySub.Text = "Unterordner";
            this.chkFileSourceDirectorySub.UseVisualStyleBackColor = true;
            this.chkFileSourceDirectorySub.CheckedChanged += new System.EventHandler(this.chkFileSourceDirectorySub_CheckedChanged);
            // 
            // grbExecute
            // 
            this.grbExecute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbExecute.Controls.Add(this.chkQuitAfterRename);
            this.grbExecute.Controls.Add(this.chkInstantRename);
            this.grbExecute.Controls.Add(this.btnExecutetConvert);
            this.grbExecute.Location = new System.Drawing.Point(13, 476);
            this.grbExecute.Name = "grbExecute";
            this.grbExecute.Size = new System.Drawing.Size(748, 80);
            this.grbExecute.TabIndex = 2;
            this.grbExecute.TabStop = false;
            this.grbExecute.Text = "Ausführen";
            // 
            // chkQuitAfterRename
            // 
            this.chkQuitAfterRename.AutoSize = true;
            this.chkQuitAfterRename.Location = new System.Drawing.Point(6, 57);
            this.chkQuitAfterRename.Name = "chkQuitAfterRename";
            this.chkQuitAfterRename.Size = new System.Drawing.Size(187, 17);
            this.chkQuitAfterRename.TabIndex = 2;
            this.chkQuitAfterRename.Text = "Nach dem Umbenennen beenden";
            this.chkQuitAfterRename.UseVisualStyleBackColor = true;
            this.chkQuitAfterRename.CheckedChanged += new System.EventHandler(this.chkQuitAfterRename_CheckedChanged);
            // 
            // chkInstantRename
            // 
            this.chkInstantRename.AutoSize = true;
            this.chkInstantRename.Location = new System.Drawing.Point(6, 19);
            this.chkInstantRename.Name = "chkInstantRename";
            this.chkInstantRename.Size = new System.Drawing.Size(252, 17);
            this.chkInstantRename.TabIndex = 0;
            this.chkInstantRename.Text = "Beim laden von Dateien sofort alle umbenennen";
            this.chkInstantRename.UseVisualStyleBackColor = true;
            this.chkInstantRename.CheckedChanged += new System.EventHandler(this.chkInstantRename_CheckedChanged);
            // 
            // lblFileSourceDirectory
            // 
            this.lblFileSourceDirectory.AutoSize = true;
            this.lblFileSourceDirectory.Location = new System.Drawing.Point(6, 11);
            this.lblFileSourceDirectory.Name = "lblFileSourceDirectory";
            this.lblFileSourceDirectory.Size = new System.Drawing.Size(65, 13);
            this.lblFileSourceDirectory.TabIndex = 0;
            this.lblFileSourceDirectory.Text = "Suchordner:";
            // 
            // btnFileSourceDirectoryBrowse
            // 
            this.btnFileSourceDirectoryBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileSourceDirectoryBrowse.Image = global::OLKI.Programme.ReFiDa.Properties.Resources.Browse;
            this.btnFileSourceDirectoryBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileSourceDirectoryBrowse.Location = new System.Drawing.Point(445, 6);
            this.btnFileSourceDirectoryBrowse.Name = "btnFileSourceDirectoryBrowse";
            this.btnFileSourceDirectoryBrowse.Size = new System.Drawing.Size(160, 24);
            this.btnFileSourceDirectoryBrowse.TabIndex = 2;
            this.btnFileSourceDirectoryBrowse.Text = "Durchsuchen";
            this.btnFileSourceDirectoryBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileSourceDirectoryBrowse.UseVisualStyleBackColor = false;
            this.btnFileSourceDirectoryBrowse.Click += new System.EventHandler(this.btnFileSourceDirectoryBrowse_Click);
            // 
            // txtFileSourceDirectoryPath
            // 
            this.txtFileSourceDirectoryPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileSourceDirectoryPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFileSourceDirectoryPath.Location = new System.Drawing.Point(77, 8);
            this.txtFileSourceDirectoryPath.Name = "txtFileSourceDirectoryPath";
            this.txtFileSourceDirectoryPath.Size = new System.Drawing.Size(362, 20);
            this.txtFileSourceDirectoryPath.TabIndex = 1;
            this.txtFileSourceDirectoryPath.TextChanged += new System.EventHandler(this.txtFileSourceDirectoryPath_TextChanged);
            // 
            // grbPrepare
            // 
            this.grbPrepare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPrepare.Controls.Add(this.lblFormatOutlook);
            this.grbPrepare.Controls.Add(this.lblFormatHelp);
            this.grbPrepare.Controls.Add(this.uscNewDate);
            this.grbPrepare.Controls.Add(this.txtFilenamePreview);
            this.grbPrepare.Controls.Add(this.grbDateSearchFormats);
            this.grbPrepare.Controls.Add(this.lblDateSource);
            this.grbPrepare.Controls.Add(this.cboDateSource);
            this.grbPrepare.Controls.Add(this.tabFileSource);
            this.grbPrepare.Controls.Add(this.lblNewDateFormat);
            this.grbPrepare.Location = new System.Drawing.Point(13, 12);
            this.grbPrepare.Name = "grbPrepare";
            this.grbPrepare.Size = new System.Drawing.Size(749, 198);
            this.grbPrepare.TabIndex = 0;
            this.grbPrepare.TabStop = false;
            this.grbPrepare.Text = "Datein laden ";
            // 
            // lblFormatOutlook
            // 
            this.lblFormatOutlook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormatOutlook.AutoSize = true;
            this.lblFormatOutlook.Location = new System.Drawing.Point(180, 111);
            this.lblFormatOutlook.Name = "lblFormatOutlook";
            this.lblFormatOutlook.Size = new System.Drawing.Size(182, 13);
            this.lblFormatOutlook.TabIndex = 3;
            this.lblFormatOutlook.TabStop = true;
            this.lblFormatOutlook.Text = "Spezielle Foramte für Outlook E-Mails";
            this.lblFormatOutlook.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFormatOutlook_LinkClicked);
            this.lblFormatOutlook.EnabledChanged += new System.EventHandler(this.lblFormatOutlook_EnabledChanged);
            // 
            // lblFormatHelp
            // 
            this.lblFormatHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormatHelp.AutoSize = true;
            this.lblFormatHelp.Location = new System.Drawing.Point(253, 130);
            this.lblFormatHelp.Name = "lblFormatHelp";
            this.lblFormatHelp.Size = new System.Drawing.Size(109, 13);
            this.lblFormatHelp.TabIndex = 5;
            this.lblFormatHelp.TabStop = true;
            this.lblFormatHelp.Text = "Hilfe zur Formatierung";
            this.lblFormatHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFormatHelp_LinkClicked);
            // 
            // uscNewDate
            // 
            this.uscNewDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uscNewDate.DateFormat = null;
            this.uscNewDate.DatePosition = OLKI.Programme.ReFiDa.src.DateFormatProvider.DatePositionIndicator.AfterFilename;
            this.uscNewDate.Location = new System.Drawing.Point(6, 146);
            this.uscNewDate.Name = "uscNewDate";
            this.uscNewDate.Seperator = null;
            this.uscNewDate.Size = new System.Drawing.Size(356, 20);
            this.uscNewDate.TabIndex = 6;
            this.uscNewDate.Changed += new System.EventHandler(this.uscNewDate_Changed);
            // 
            // txtFilenamePreview
            // 
            this.txtFilenamePreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilenamePreview.Location = new System.Drawing.Point(6, 172);
            this.txtFilenamePreview.Name = "txtFilenamePreview";
            this.txtFilenamePreview.ReadOnly = true;
            this.txtFilenamePreview.Size = new System.Drawing.Size(356, 20);
            this.txtFilenamePreview.TabIndex = 7;
            // 
            // grbDateSearchFormats
            // 
            this.grbDateSearchFormats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDateSearchFormats.Controls.Add(this.uscSearchDate);
            this.grbDateSearchFormats.Controls.Add(this.lsvDateSearchFormats);
            this.grbDateSearchFormats.Controls.Add(this.btnDateSearchFormaRemove);
            this.grbDateSearchFormats.Controls.Add(this.btnDateSearchFormatAdd);
            this.grbDateSearchFormats.Location = new System.Drawing.Point(368, 83);
            this.grbDateSearchFormats.Name = "grbDateSearchFormats";
            this.grbDateSearchFormats.Size = new System.Drawing.Size(375, 107);
            this.grbDateSearchFormats.TabIndex = 8;
            this.grbDateSearchFormats.TabStop = false;
            this.grbDateSearchFormats.Text = "Suchmuster und Suchreihenfolge";
            this.grbDateSearchFormats.EnabledChanged += new System.EventHandler(this.grbDateSearchFormats_EnabledChanged);
            // 
            // uscSearchDate
            // 
            this.uscSearchDate.DateFormat = null;
            this.uscSearchDate.DatePosition = OLKI.Programme.ReFiDa.src.DateFormatProvider.DatePositionIndicator.AfterFilename;
            this.uscSearchDate.Location = new System.Drawing.Point(6, 81);
            this.uscSearchDate.Name = "uscSearchDate";
            this.uscSearchDate.Seperator = null;
            this.uscSearchDate.Size = new System.Drawing.Size(363, 20);
            this.uscSearchDate.TabIndex = 3;
            this.uscSearchDate.Changed += new System.EventHandler(this.uscSearchDate_Changed);
            // 
            // lsvDateSearchFormats
            // 
            this.lsvDateSearchFormats.AllowDragAndDropSort = true;
            this.lsvDateSearchFormats.AllowDrop = true;
            this.lsvDateSearchFormats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lsvDateSearchFormats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.lsvDateSearchFormats.FullRowSelect = true;
            this.lsvDateSearchFormats.GridLines = true;
            this.lsvDateSearchFormats.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvDateSearchFormats.HideSelection = false;
            this.lsvDateSearchFormats.Location = new System.Drawing.Point(6, 19);
            this.lsvDateSearchFormats.MultiSelect = false;
            this.lsvDateSearchFormats.Name = "lsvDateSearchFormats";
            this.lsvDateSearchFormats.ShowItemToolTips = true;
            this.lsvDateSearchFormats.Size = new System.Drawing.Size(217, 56);
            this.lsvDateSearchFormats.TabIndex = 0;
            this.lsvDateSearchFormats.UseCompatibleStateImageBehavior = false;
            this.lsvDateSearchFormats.View = System.Windows.Forms.View.Details;
            this.lsvDateSearchFormats.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lsvDateSearchFormats_ItemDrag);
            this.lsvDateSearchFormats.SelectedIndexChanged += new System.EventHandler(this.lsvDateSearchFormats_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Datumsformat";
            this.columnHeader5.Width = 196;
            // 
            // btnDateSearchFormaRemove
            // 
            this.btnDateSearchFormaRemove.Image = global::OLKI.Programme.ReFiDa.Properties.Resources.Delete;
            this.btnDateSearchFormaRemove.Location = new System.Drawing.Point(229, 51);
            this.btnDateSearchFormaRemove.Name = "btnDateSearchFormaRemove";
            this.btnDateSearchFormaRemove.Size = new System.Drawing.Size(140, 24);
            this.btnDateSearchFormaRemove.TabIndex = 2;
            this.btnDateSearchFormaRemove.Text = "Löschen";
            this.btnDateSearchFormaRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDateSearchFormaRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDateSearchFormaRemove.UseVisualStyleBackColor = true;
            this.btnDateSearchFormaRemove.Click += new System.EventHandler(this.btnDateSearchFormaRemove_Click);
            // 
            // btnDateSearchFormatAdd
            // 
            this.btnDateSearchFormatAdd.Image = global::OLKI.Programme.ReFiDa.Properties.Resources.New;
            this.btnDateSearchFormatAdd.Location = new System.Drawing.Point(229, 19);
            this.btnDateSearchFormatAdd.Name = "btnDateSearchFormatAdd";
            this.btnDateSearchFormatAdd.Size = new System.Drawing.Size(140, 24);
            this.btnDateSearchFormatAdd.TabIndex = 1;
            this.btnDateSearchFormatAdd.Text = "Hinzufügen";
            this.btnDateSearchFormatAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDateSearchFormatAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDateSearchFormatAdd.UseVisualStyleBackColor = true;
            this.btnDateSearchFormatAdd.Click += new System.EventHandler(this.btnDateSearchFormatAdd_Click);
            // 
            // lblDateSource
            // 
            this.lblDateSource.AutoSize = true;
            this.lblDateSource.Location = new System.Drawing.Point(6, 90);
            this.lblDateSource.Name = "lblDateSource";
            this.lblDateSource.Size = new System.Drawing.Size(89, 13);
            this.lblDateSource.TabIndex = 1;
            this.lblDateSource.Text = "Quelle für Datum:";
            // 
            // cboDateSource
            // 
            this.cboDateSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDateSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDateSource.FormattingEnabled = true;
            this.cboDateSource.Items.AddRange(new object[] {
            "Dateieigenschaft - Datei bearbeitet",
            "Dateieigenschaft - Datei erstellt",
            "Dateiname - Datum am Anfang oder Ende",
            "E-Mail Outlook (*.msg) - Empfangen",
            "E-Mail Thunderbird (*.eml) - Empfangen"});
            this.cboDateSource.Location = new System.Drawing.Point(114, 87);
            this.cboDateSource.Name = "cboDateSource";
            this.cboDateSource.Size = new System.Drawing.Size(248, 21);
            this.cboDateSource.TabIndex = 2;
            this.cboDateSource.SelectedIndexChanged += new System.EventHandler(this.cboDateSource_SelectedIndexChanged);
            // 
            // tabFileSource
            // 
            this.tabFileSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabFileSource.Controls.Add(this.tabPage2);
            this.tabFileSource.Controls.Add(this.tabPage1);
            this.tabFileSource.Controls.Add(this.tabPage3);
            this.tabFileSource.Location = new System.Drawing.Point(6, 19);
            this.tabFileSource.Name = "tabFileSource";
            this.tabFileSource.SelectedIndex = 0;
            this.tabFileSource.Size = new System.Drawing.Size(737, 62);
            this.tabFileSource.TabIndex = 0;
            this.tabFileSource.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabFileSource_Selected);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblFileSourceSelect);
            this.tabPage2.Controls.Add(this.btnFileSourceSelectBrowse);
            this.tabPage2.Controls.Add(this.txtFileSourceSelectPath);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(729, 36);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Einzelne Dateien auswählen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblFileSourceSelect
            // 
            this.lblFileSourceSelect.AutoSize = true;
            this.lblFileSourceSelect.Location = new System.Drawing.Point(6, 11);
            this.lblFileSourceSelect.Name = "lblFileSourceSelect";
            this.lblFileSourceSelect.Size = new System.Drawing.Size(65, 13);
            this.lblFileSourceSelect.TabIndex = 0;
            this.lblFileSourceSelect.Text = "Suchordner:";
            // 
            // btnFileSourceSelectBrowse
            // 
            this.btnFileSourceSelectBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileSourceSelectBrowse.Image = global::OLKI.Programme.ReFiDa.Properties.Resources.Browse;
            this.btnFileSourceSelectBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileSourceSelectBrowse.Location = new System.Drawing.Point(563, 6);
            this.btnFileSourceSelectBrowse.Name = "btnFileSourceSelectBrowse";
            this.btnFileSourceSelectBrowse.Size = new System.Drawing.Size(160, 24);
            this.btnFileSourceSelectBrowse.TabIndex = 2;
            this.btnFileSourceSelectBrowse.Text = "Durchsuchen";
            this.btnFileSourceSelectBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileSourceSelectBrowse.UseVisualStyleBackColor = true;
            this.btnFileSourceSelectBrowse.Click += new System.EventHandler(this.btnFileSourceSelectBrowse_Click);
            // 
            // txtFileSourceSelectPath
            // 
            this.txtFileSourceSelectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileSourceSelectPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFileSourceSelectPath.Location = new System.Drawing.Point(77, 8);
            this.txtFileSourceSelectPath.Name = "txtFileSourceSelectPath";
            this.txtFileSourceSelectPath.Size = new System.Drawing.Size(480, 20);
            this.txtFileSourceSelectPath.TabIndex = 1;
            this.txtFileSourceSelectPath.TextChanged += new System.EventHandler(this.txtFileSourceSelectPath_TextChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnFileSourceDirectoryRefresh);
            this.tabPage1.Controls.Add(this.lblFileSourceDirectory);
            this.tabPage1.Controls.Add(this.txtFileSourceDirectoryPath);
            this.tabPage1.Controls.Add(this.btnFileSourceDirectoryBrowse);
            this.tabPage1.Controls.Add(this.chkFileSourceDirectorySub);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(729, 36);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Alle Dateien aus Ordner";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnFileSourceDirectoryRefresh
            // 
            this.btnFileSourceDirectoryRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileSourceDirectoryRefresh.Image = global::OLKI.Programme.ReFiDa.Properties.Resources._112_RefreshArrow_Blue_16x16_72;
            this.btnFileSourceDirectoryRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileSourceDirectoryRefresh.Location = new System.Drawing.Point(699, 6);
            this.btnFileSourceDirectoryRefresh.Name = "btnFileSourceDirectoryRefresh";
            this.btnFileSourceDirectoryRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnFileSourceDirectoryRefresh.TabIndex = 4;
            this.btnFileSourceDirectoryRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileSourceDirectoryRefresh.UseVisualStyleBackColor = false;
            this.btnFileSourceDirectoryRefresh.Click += new System.EventHandler(this.btnFileSourceDirectoryRefresh_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblFileSourceDragAndDrop);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(729, 36);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Drag & Drop";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblFileSourceDragAndDrop
            // 
            this.lblFileSourceDragAndDrop.AllowDrop = true;
            this.lblFileSourceDragAndDrop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileSourceDragAndDrop.Location = new System.Drawing.Point(3, 3);
            this.lblFileSourceDragAndDrop.Name = "lblFileSourceDragAndDrop";
            this.lblFileSourceDragAndDrop.Size = new System.Drawing.Size(723, 30);
            this.lblFileSourceDragAndDrop.TabIndex = 0;
            this.lblFileSourceDragAndDrop.Text = "Dateien hier hin oder in die Dateiliste ziehen";
            this.lblFileSourceDragAndDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFileSourceDragAndDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblFileSourceDragAndDrop_DragDrop);
            this.lblFileSourceDragAndDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblFileSourceDragAndDrop_DragEnter);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 568);
            this.Controls.Add(this.grbFiles);
            this.Controls.Add(this.grbExecute);
            this.Controls.Add(this.grbPrepare);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(790, 607);
            this.Name = "MainForm";
            this.Text = "{0} ";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MainForm_HelpButtonClicked);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.grbFiles.ResumeLayout(false);
            this.grbFiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShortenFilenamesLimit)).EndInit();
            this.grbExecute.ResumeLayout(false);
            this.grbExecute.PerformLayout();
            this.grbPrepare.ResumeLayout(false);
            this.grbPrepare.PerformLayout();
            this.grbDateSearchFormats.ResumeLayout(false);
            this.tabFileSource.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader cohFilesNote;
        private System.Windows.Forms.Label lblNewDateFormat;
        private System.Windows.Forms.ColumnHeader cohFilesNewFilename;
        private System.Windows.Forms.ColumnHeader cohFilesOldFilename;
        private OLKI.Toolbox.Widgets.SortListView lsvFiles;
        private System.Windows.Forms.GroupBox grbFiles;
        private System.Windows.Forms.Button btnExecutetConvert;
        private System.Windows.Forms.CheckBox chkFileSourceDirectorySub;
        private System.Windows.Forms.GroupBox grbExecute;
        private System.Windows.Forms.CheckBox chkInstantRename;
        private System.Windows.Forms.Label lblFileSourceDirectory;
        private System.Windows.Forms.Button btnFileSourceDirectoryBrowse;
        private System.Windows.Forms.TextBox txtFileSourceDirectoryPath;
        private System.Windows.Forms.GroupBox grbPrepare;
        private System.Windows.Forms.TabControl tabFileSource;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblFileSourceSelect;
        private System.Windows.Forms.Button btnFileSourceSelectBrowse;
        private System.Windows.Forms.TextBox txtFileSourceSelectPath;
        private System.Windows.Forms.ComboBox cboDateSource;
        private System.Windows.Forms.Label lblDateSource;
        private System.Windows.Forms.Button btnDateSearchFormatAdd;
        private System.Windows.Forms.GroupBox grbDateSearchFormats;
        private System.Windows.Forms.Button btnDateSearchFormaRemove;
        private System.Windows.Forms.TextBox txtFilenamePreview;
        private OLKI.Toolbox.Widgets.SortListView lsvDateSearchFormats;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.CheckBox chkQuitAfterRename;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblFileSourceDragAndDrop;
        private src.Forms.uscDateFormatEditor uscNewDate;
        private src.Forms.uscDateFormatEditor uscSearchDate;
        private System.Windows.Forms.Button btnFileSourceDirectoryRefresh;
        private System.Windows.Forms.CheckBox chkCheckForAlreadyInTargetFormat;
        private System.Windows.Forms.Button btnRefreshFileList;
        private System.Windows.Forms.LinkLabel lblFormatHelp;
        private System.Windows.Forms.CheckBox chkSelectAllRenameableFiles;
        private System.Windows.Forms.ColumnHeader cohFilesDirectory;
        private System.Windows.Forms.CheckBox chkShortenFilenames;
        private System.Windows.Forms.NumericUpDown nudShortenFilenamesLimit;
        private System.Windows.Forms.LinkLabel lblFormatOutlook;
    }
}