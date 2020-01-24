namespace OLKI.Programme.ReFiDa
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkCheckDouble = new System.Windows.Forms.CheckBox();
            this.lblNewFormat = new System.Windows.Forms.Label();
            this.txtNewFormat = new System.Windows.Forms.TextBox();
            this.btnDirectoryListFiles = new System.Windows.Forms.Button();
            this.chkEnd8 = new System.Windows.Forms.CheckBox();
            this.chkEnd12 = new System.Windows.Forms.CheckBox();
            this.chkStart8 = new System.Windows.Forms.CheckBox();
            this.chkStart12 = new System.Windows.Forms.CheckBox();
            this.chkEnd = new System.Windows.Forms.CheckBox();
            this.chkStart = new System.Windows.Forms.CheckBox();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvFiles = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbFiles = new System.Windows.Forms.GroupBox();
            this.btnStartConvert = new System.Windows.Forms.Button();
            this.chkSubDirectory = new System.Windows.Forms.CheckBox();
            this.grbProceed = new System.Windows.Forms.GroupBox();
            this.chkSimulateRenaming = new System.Windows.Forms.CheckBox();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.btnDirectoryBrowse = new System.Windows.Forms.Button();
            this.txtDirectoryPath = new System.Windows.Forms.TextBox();
            this.grbPrepare = new System.Windows.Forms.GroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbFiles.SuspendLayout();
            this.grbProceed.SuspendLayout();
            this.grbPrepare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Hinweis";
            this.columnHeader4.Width = 100;
            // 
            // chkCheckDouble
            // 
            this.chkCheckDouble.Checked = true;
            this.chkCheckDouble.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCheckDouble.Location = new System.Drawing.Point(486, 48);
            this.chkCheckDouble.Name = "chkCheckDouble";
            this.chkCheckDouble.Size = new System.Drawing.Size(256, 24);
            this.chkCheckDouble.TabIndex = 13;
            this.chkCheckDouble.Text = "Prüfen auf doppelkonvertierung";
            this.chkCheckDouble.UseVisualStyleBackColor = true;
            // 
            // lblNewFormat
            // 
            this.lblNewFormat.Location = new System.Drawing.Point(6, 105);
            this.lblNewFormat.Name = "lblNewFormat";
            this.lblNewFormat.Size = new System.Drawing.Size(140, 23);
            this.lblNewFormat.TabIndex = 12;
            this.lblNewFormat.Text = "Neues Format für Datum:";
            // 
            // txtNewFormat
            // 
            this.txtNewFormat.Location = new System.Drawing.Point(152, 108);
            this.txtNewFormat.Name = "txtNewFormat";
            this.txtNewFormat.ReadOnly = true;
            this.txtNewFormat.Size = new System.Drawing.Size(145, 20);
            this.txtNewFormat.TabIndex = 11;
            this.txtNewFormat.Text = "yyyy-MM-dd__HH-mm";
            // 
            // btnDirectoryListFiles
            // 
            this.btnDirectoryListFiles.Image = ((System.Drawing.Image)(resources.GetObject("btnDirectoryListFiles.Image")));
            this.btnDirectoryListFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDirectoryListFiles.Location = new System.Drawing.Point(486, 74);
            this.btnDirectoryListFiles.Name = "btnDirectoryListFiles";
            this.btnDirectoryListFiles.Size = new System.Drawing.Size(256, 54);
            this.btnDirectoryListFiles.TabIndex = 10;
            this.btnDirectoryListFiles.Text = "Auflisten";
            this.btnDirectoryListFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDirectoryListFiles.UseVisualStyleBackColor = true;
            this.btnDirectoryListFiles.Click += new System.EventHandler(this.btnDirectoryListFiles_Click);
            // 
            // chkEnd8
            // 
            this.chkEnd8.Checked = true;
            this.chkEnd8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnd8.Location = new System.Drawing.Point(218, 78);
            this.chkEnd8.Name = "chkEnd8";
            this.chkEnd8.Size = new System.Drawing.Size(80, 24);
            this.chkEnd8.TabIndex = 9;
            this.chkEnd8.Text = "8 Stellig";
            this.chkEnd8.UseVisualStyleBackColor = true;
            // 
            // chkEnd12
            // 
            this.chkEnd12.Checked = true;
            this.chkEnd12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnd12.Location = new System.Drawing.Point(132, 78);
            this.chkEnd12.Name = "chkEnd12";
            this.chkEnd12.Size = new System.Drawing.Size(80, 24);
            this.chkEnd12.TabIndex = 8;
            this.chkEnd12.Text = "12 Stellig";
            this.chkEnd12.UseVisualStyleBackColor = true;
            // 
            // chkStart8
            // 
            this.chkStart8.Checked = true;
            this.chkStart8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStart8.Location = new System.Drawing.Point(218, 48);
            this.chkStart8.Name = "chkStart8";
            this.chkStart8.Size = new System.Drawing.Size(80, 24);
            this.chkStart8.TabIndex = 7;
            this.chkStart8.Text = "8 Stellig";
            this.chkStart8.UseVisualStyleBackColor = true;
            // 
            // chkStart12
            // 
            this.chkStart12.Checked = true;
            this.chkStart12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStart12.Location = new System.Drawing.Point(132, 48);
            this.chkStart12.Name = "chkStart12";
            this.chkStart12.Size = new System.Drawing.Size(80, 24);
            this.chkStart12.TabIndex = 6;
            this.chkStart12.Text = "12 Stellig";
            this.chkStart12.UseVisualStyleBackColor = true;
            // 
            // chkEnd
            // 
            this.chkEnd.Checked = true;
            this.chkEnd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnd.Location = new System.Drawing.Point(6, 78);
            this.chkEnd.Name = "chkEnd";
            this.chkEnd.Size = new System.Drawing.Size(120, 24);
            this.chkEnd.TabIndex = 5;
            this.chkEnd.Text = "Datum am Ende";
            this.chkEnd.UseVisualStyleBackColor = true;
            this.chkEnd.CheckedChanged += new System.EventHandler(this.chkEnd_CheckedChanged);
            // 
            // chkStart
            // 
            this.chkStart.Checked = true;
            this.chkStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStart.Location = new System.Drawing.Point(6, 48);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(120, 24);
            this.chkStart.TabIndex = 4;
            this.chkStart.Text = "Datum am Anfang";
            this.chkStart.UseVisualStyleBackColor = true;
            this.chkStart.CheckedChanged += new System.EventHandler(this.chkStart_CheckedChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dateiname neu";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Dateiname alt";
            this.columnHeader1.Width = 200;
            // 
            // lsvFiles
            // 
            this.lsvFiles.CheckBoxes = true;
            this.lsvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvFiles.FullRowSelect = true;
            this.lsvFiles.GridLines = true;
            this.lsvFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvFiles.HideSelection = false;
            this.lsvFiles.Location = new System.Drawing.Point(7, 19);
            this.lsvFiles.MultiSelect = false;
            this.lsvFiles.Name = "lsvFiles";
            this.lsvFiles.ShowItemToolTips = true;
            this.lsvFiles.Size = new System.Drawing.Size(729, 293);
            this.lsvFiles.TabIndex = 0;
            this.lsvFiles.UseCompatibleStateImageBehavior = false;
            this.lsvFiles.View = System.Windows.Forms.View.Details;
            this.lsvFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsvFiles_MouseDoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ordner";
            this.columnHeader3.Width = 200;
            // 
            // grbFiles
            // 
            this.grbFiles.Controls.Add(this.lsvFiles);
            this.grbFiles.Location = new System.Drawing.Point(13, 152);
            this.grbFiles.Name = "grbFiles";
            this.grbFiles.Size = new System.Drawing.Size(749, 318);
            this.grbFiles.TabIndex = 6;
            this.grbFiles.TabStop = false;
            this.grbFiles.Text = "Kontrolle";
            // 
            // btnStartConvert
            // 
            this.btnStartConvert.Image = ((System.Drawing.Image)(resources.GetObject("btnStartConvert.Image")));
            this.btnStartConvert.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartConvert.Location = new System.Drawing.Point(157, 19);
            this.btnStartConvert.Name = "btnStartConvert";
            this.btnStartConvert.Size = new System.Drawing.Size(585, 55);
            this.btnStartConvert.TabIndex = 0;
            this.btnStartConvert.Text = "Ausgewählte Dateiein umbenennen";
            this.btnStartConvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStartConvert.UseVisualStyleBackColor = true;
            this.btnStartConvert.Click += new System.EventHandler(this.btnStartConvert_Click);
            // 
            // chkSubDirectory
            // 
            this.chkSubDirectory.Checked = true;
            this.chkSubDirectory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSubDirectory.Location = new System.Drawing.Point(652, 19);
            this.chkSubDirectory.Name = "chkSubDirectory";
            this.chkSubDirectory.Size = new System.Drawing.Size(90, 24);
            this.chkSubDirectory.TabIndex = 3;
            this.chkSubDirectory.Text = "Unterordner";
            this.chkSubDirectory.UseVisualStyleBackColor = true;
            // 
            // grbProceed
            // 
            this.grbProceed.Controls.Add(this.chkSimulateRenaming);
            this.grbProceed.Controls.Add(this.btnStartConvert);
            this.grbProceed.Location = new System.Drawing.Point(13, 476);
            this.grbProceed.Name = "grbProceed";
            this.grbProceed.Size = new System.Drawing.Size(748, 80);
            this.grbProceed.TabIndex = 5;
            this.grbProceed.TabStop = false;
            this.grbProceed.Text = "Ausführen";
            // 
            // chkSimulateRenaming
            // 
            this.chkSimulateRenaming.AutoSize = true;
            this.chkSimulateRenaming.Location = new System.Drawing.Point(6, 39);
            this.chkSimulateRenaming.Name = "chkSimulateRenaming";
            this.chkSimulateRenaming.Size = new System.Drawing.Size(145, 17);
            this.chkSimulateRenaming.TabIndex = 14;
            this.chkSimulateRenaming.Text = "Umbenennung simulieren";
            this.chkSimulateRenaming.UseVisualStyleBackColor = true;
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(6, 24);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(65, 13);
            this.lblDirectory.TabIndex = 2;
            this.lblDirectory.Text = "Suchordner:";
            // 
            // btnDirectoryBrowse
            // 
            this.btnDirectoryBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnDirectoryBrowse.Image")));
            this.btnDirectoryBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDirectoryBrowse.Location = new System.Drawing.Point(486, 19);
            this.btnDirectoryBrowse.Name = "btnDirectoryBrowse";
            this.btnDirectoryBrowse.Size = new System.Drawing.Size(160, 23);
            this.btnDirectoryBrowse.TabIndex = 1;
            this.btnDirectoryBrowse.Text = "Durchsuchen";
            this.btnDirectoryBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDirectoryBrowse.UseVisualStyleBackColor = true;
            this.btnDirectoryBrowse.Click += new System.EventHandler(this.btnDirectoryBrowse_Click);
            // 
            // txtDirectoryPath
            // 
            this.txtDirectoryPath.Location = new System.Drawing.Point(77, 21);
            this.txtDirectoryPath.Name = "txtDirectoryPath";
            this.txtDirectoryPath.Size = new System.Drawing.Size(403, 20);
            this.txtDirectoryPath.TabIndex = 0;
            this.txtDirectoryPath.Text = "C:\\Users\\00grigri\\Desktop\\Neuer Ordner";
            // 
            // grbPrepare
            // 
            this.grbPrepare.Controls.Add(this.chkCheckDouble);
            this.grbPrepare.Controls.Add(this.lblNewFormat);
            this.grbPrepare.Controls.Add(this.txtNewFormat);
            this.grbPrepare.Controls.Add(this.btnDirectoryListFiles);
            this.grbPrepare.Controls.Add(this.chkEnd8);
            this.grbPrepare.Controls.Add(this.chkEnd12);
            this.grbPrepare.Controls.Add(this.chkStart8);
            this.grbPrepare.Controls.Add(this.chkStart12);
            this.grbPrepare.Controls.Add(this.chkEnd);
            this.grbPrepare.Controls.Add(this.chkStart);
            this.grbPrepare.Controls.Add(this.chkSubDirectory);
            this.grbPrepare.Controls.Add(this.lblDirectory);
            this.grbPrepare.Controls.Add(this.btnDirectoryBrowse);
            this.grbPrepare.Controls.Add(this.txtDirectoryPath);
            this.grbPrepare.Location = new System.Drawing.Point(13, 12);
            this.grbPrepare.Name = "grbPrepare";
            this.grbPrepare.Size = new System.Drawing.Size(749, 134);
            this.grbPrepare.TabIndex = 4;
            this.grbPrepare.TabStop = false;
            this.grbPrepare.Text = "Ordner und Optionen wählen";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 568);
            this.Controls.Add(this.grbFiles);
            this.Controls.Add(this.grbProceed);
            this.Controls.Add(this.grbPrepare);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "ConDate";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MainForm_HelpButtonClicked);
            this.grbFiles.ResumeLayout(false);
            this.grbProceed.ResumeLayout(false);
            this.grbProceed.PerformLayout();
            this.grbPrepare.ResumeLayout(false);
            this.grbPrepare.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.CheckBox chkCheckDouble;
        private System.Windows.Forms.Label lblNewFormat;
        private System.Windows.Forms.TextBox txtNewFormat;
        private System.Windows.Forms.Button btnDirectoryListFiles;
        private System.Windows.Forms.CheckBox chkEnd8;
        private System.Windows.Forms.CheckBox chkEnd12;
        private System.Windows.Forms.CheckBox chkStart8;
        private System.Windows.Forms.CheckBox chkStart12;
        private System.Windows.Forms.CheckBox chkEnd;
        private System.Windows.Forms.CheckBox chkStart;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lsvFiles;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox grbFiles;
        private System.Windows.Forms.Button btnStartConvert;
        private System.Windows.Forms.CheckBox chkSubDirectory;
        private System.Windows.Forms.GroupBox grbProceed;
        private System.Windows.Forms.CheckBox chkSimulateRenaming;
        private System.Windows.Forms.Label lblDirectory;
        private System.Windows.Forms.Button btnDirectoryBrowse;
        private System.Windows.Forms.TextBox txtDirectoryPath;
        private System.Windows.Forms.GroupBox grbPrepare;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

