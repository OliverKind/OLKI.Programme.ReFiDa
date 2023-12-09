/*
 * ReFiDa - QuickBackupCreator
 * 
 * Copyright:   Oliver Kind - 2023
 * License:     LGPL
 * 
 * Desctiption:
 * The MainForm of the application
 * 
 * 
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the LGPL General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * LGPL General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not check the GitHub-Repository.
 * 
 * */

using OLKI.Programme.ReFiDa.Properties;
using OLKI.Programme.ReFiDa.src;
using OLKI.Toolbox.Widgets.AboutForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OLKI.Programme.ReFiDa
{
    /// <summary>
    /// The MainForm of the application
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields
        /// <summary>
        /// Object to show the About Form
        /// </summary>
        private AboutForm _aboutForm;

        /// <summary>
        /// A list with Searchpatterns to search for Dates in a flename
        /// </summary>
        private List<DateFormatProvider> _searchFormatList = new List<DateFormatProvider>();

        /// <summary>
        /// Changes are system intern
        /// </summary>
        private bool _systemChanged = false;

        /// <summary>
        /// Target Date Format
        /// </summary>
        private readonly DateFormatProvider _targetDateFormat = new DateFormatProvider();
        #endregion

        #region Methodes
        /// <summary>
        /// Initial a new Apllication MainForm
        /// </summary>
        /// <param name="args">Startup arguments</param>
        public MainForm(string[] args)
        {
            InitializeComponent();

            Assembly Assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Image AppImage = Resources.ProgSym_256;
            this._aboutForm = new AboutForm(Assembly, AppImage, null)
            {
                Credits = Resources.Credits,
                LicenseDirectory = Path.GetDirectoryName(Assembly.Location) + @"\Licenses\",
                UpdateOnStartup = Settings.Default.AppUpdate_CheckAtStartUp,
                ShowUpdateControles = true
            };
            this._aboutForm.UpdateOnStartupChanged += new EventHandler(this.AboudForm_UpdateCheckChanged);
            this._aboutForm.CheckForUpdate += new LinkLabelLinkClickedEventHandler(this.AboudForm_UpdateClicked);

            this.Size = Settings_AppVar.Default.MainForm_Size;
            this.Text = string.Format(this.Text, new object[] { this._aboutForm.AssemblyTitle });

            OLKI.Toolbox.Widgets.Tools.ComboBox.AutoDropDownWidth(this.cboDateSource);
            this.cboDateSource.Items.RemoveAt(this.cboDateSource.Items.Count - 1);  //Remove last combobox item (Reading Thunderbird i)
            this.cboDateSource.SelectedIndex = Settings.Default.SearchDate_Source;
            Toolbox.Widgets.Tools.ComboBox.AutoDropDownWidth(this.cboDateSource);
            this.chkCheckForAlreadyInTargetFormat.Checked = Settings.Default.CheckForAlreadyInTargetFormat;
            this.chkFileSourceDirectorySub.Checked = Settings.Default.FileSourceDirectorySub;
            this.chkQuitAfterRename.Checked = Settings.Default.QuitAfterRename;
            this.chkInstantRename.Checked = Settings.Default.InstantRename;
            this.chkSelectAllRenameableFiles.Checked = Settings.Default.SelectAllRenameableFiles;

            this._systemChanged = true;
            string[] DateFormatList = new string[Settings.Default.SearchDate_List.Count];
            DateFormatProvider NewDateFormatProvider;
            ListViewItem NewListViewItem;
            Settings.Default.SearchDate_List.CopyTo(DateFormatList, 0);
            for (int i = 0; i < DateFormatList.Length; i++)
            {
                NewDateFormatProvider = new DateFormatProvider(false, DateFormatList[i]);
                NewDateFormatProvider.UpdateFormatLengthList();
                NewDateFormatProvider.AutoUpdateLengthList = true;
                this._searchFormatList.Add(NewDateFormatProvider);

                NewListViewItem = new ListViewItem();
                NewListViewItem.Tag = NewDateFormatProvider;
                NewListViewItem.Text = NewDateFormatProvider.Preview.FormatNoTextOrDummy;
                NewListViewItem.ToolTipText = NewDateFormatProvider.Preview.FinalDummyFilename;
                this.lsvDateSearchFormats.Items.Add(NewListViewItem);
            }

            this.tabFileSource.SelectedIndex = Settings_AppVar.Default.SelectedTabPage;
            this.txtFileSourceSelectPath.Text = Settings.Default.FileSourceSelectPath;
            this.txtFileSourceDirectoryPath.Text = Settings.Default.FileSourceDirectoryPath;

            DateFormatProvider NewDateFormat = new DateFormatProvider(false, Settings.Default.NewDate_Format);
            this.uscNewDate.DateFormat = NewDateFormat.Format.Date;
            this.uscNewDate.DatePosition = NewDateFormat.Format.Position;
            this.uscNewDate.Seperator = NewDateFormat.Format.Seperator;
            this._systemChanged = false;

            this.uscNewDate_Changed(this, new EventArgs());
            this.uscSearchDate_Changed(this, new EventArgs());

            this.lsvDateSearchFormats_SelectedIndexChanged(this, new EventArgs());
            FileLoader.LoadFilesToListview(args, this.lsvFiles, this);
            this.lsvFiles_SelectedIndexChanged(this, new EventArgs());
            this.UpdateRenameItem();
            this.AutoInstantRename();
        }

        /// <summary>
        /// Check for automatic renaming and renames all items if requested
        /// </summary>
        private void AutoInstantRename()
        {
            if (!this.chkInstantRename.Checked) return;
            if (this.lsvFiles.Items.Count == 0) return;

            this.UpdateRenameItem();
            this.RenameItems(false);
        }

        /// <summary>
        /// Rename listed items. All or only the selected
        /// </summary>
        /// <param name="renameOnlySelected">Set to true if only selected items sould renamed</param>
        private void RenameItems(bool renameOnlySelected)
        {
            try
            {
                bool Exceptions = false;
                this.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;

                for (int i = 0; i < this.lsvFiles.Items.Count; i++)
                {
                    if (renameOnlySelected && !this.lsvFiles.Items[i].Selected) continue;
                    RenameItem RenameItem = (RenameItem)this.lsvFiles.Items[i].Tag;
                    if (RenameItem.State != RenameItem.RenameState.ToRename) continue;

                    RenameItem.Rename();
                    this.lsvFiles.Items[i].BackColor = RenameItem.StateColor;
                    this.lsvFiles.Items[i].SubItems[3].Text = RenameItem.Exception != null ? RenameItem.Exception.Message : string.Empty;
                    if (RenameItem.Exception != null) Exceptions = true;
                }
                if (this.chkQuitAfterRename.Checked && !Exceptions)
                {
                    this.Close();
                    Application.Exit();
                    Application.ExitThread();
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(Stringtable._0x0003m, new object[] { ex.Message }), Stringtable._0x0003c, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                for (int i = 0; i < this.lsvFiles.Items.Count; i++)
                {
                    this.lsvFiles.Items[i].Selected = false;
                }
                Cursor.Current = Cursors.Default;
                this.Enabled = true;
            }
        }

        /// <summary>
        /// Save the List with searchpattern
        /// </summary>
        private void SafeSearchList()
        {
            System.Collections.Specialized.StringCollection DateFormatList = new System.Collections.Specialized.StringCollection();
            DateFormatProvider SearchFormat = new DateFormatProvider(false);
            this._searchFormatList.Clear();
            for (int i = 0; i < this.lsvDateSearchFormats.Items.Count; i++)
            {
                this._searchFormatList.Add((DateFormatProvider)this.lsvDateSearchFormats.Items[i].Tag);
                DateFormatList.Add(this._searchFormatList[this._searchFormatList.Count - 1].JSONencode);

            }
            Settings.Default.SearchDate_List = DateFormatList;
            Settings.Default.Save();
        }

        /// <summary>
        /// Upate all items in the ListView
        /// </summary>
        private void UpdateRenameItem()
        {
            this.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            for (int i = 0; i < this.lsvFiles.Items.Count; i++)
            {
                this.UpdateRenameItem(i);
            }
            Cursor.Current = Cursors.Default;
            this.Enabled = true;
        }
        /// <summary>
        /// Upate a rename items in the ListView
        /// </summary>
        /// <param name="index">Index of the ListItem to update</param>
        private void UpdateRenameItem(int index)
        {
            RenameItem RenameItem = (RenameItem)this.lsvFiles.Items[index].Tag;
            RenameItem.UpateRenameData((RenameItem.DateSearchMode)this.cboDateSource.SelectedIndex, this.chkCheckForAlreadyInTargetFormat.Checked, this._searchFormatList.ToArray(), this._targetDateFormat);
            this.lsvFiles.Items[index].BackColor = RenameItem.StateColor;
            this.lsvFiles.Items[index].SubItems[1].Text = RenameItem.FileInfoReamed != null ? RenameItem.FileInfoReamed.Name : string.Empty;
            this.lsvFiles.Items[index].SubItems[3].Text = RenameItem.Exception != null ? RenameItem.Exception.Message : string.Empty;

            if (this.chkSelectAllRenameableFiles.Checked && RenameItem.State == RenameItem.RenameState.ToRename)
            {
                this.lsvFiles.Items[index].Selected = true;
            }
            else
            {
                this.lsvFiles.Items[index].Selected = false;
            }
        }

        #region Form events
        private void AboudForm_UpdateCheckChanged(object sender, EventArgs e)
        {
            Settings.Default.AppUpdate_CheckAtStartUp = this._aboutForm.UpdateOnStartup;
            Settings.Default.Save();
        }

        private void AboudForm_UpdateClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Check for Updates for the Apllication
            Program.CheckForUpdate(this, false);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings_AppVar.Default.MainForm_Size = this.Size;
            Settings_AppVar.Default.Save();
            try
            {
                DirectoryInfo tempDirectory = Directory.CreateDirectory(Path.GetTempPath() + Settings_AppConst.Default.TempDirectoryName);
                tempDirectory.Delete(true);
            }
            catch (Exception ex)
            {
                _ = ex;
            }
        }

        private void MainForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this._aboutForm.ShowDialog(this);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Check for Updates for the Apllication
            if (Settings.Default.AppUpdate_CheckAtStartUp) Program.CheckForUpdate(this, true);
        }

        private void btnFileSourceDirectoryBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialog = new FolderBrowserDialog()
            {
                Description = Stringtable._0x0001,
                SelectedPath = this.txtFileSourceDirectoryPath.Text,
                ShowNewFolderButton = false
            };
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtFileSourceDirectoryPath.Text = FolderBrowserDialog.SelectedPath;
                this.btnFileSourceDirectoryRefresh_Click(sender, e);
            }
        }

        private void btnFileSourceDirectoryRefresh_Click(object sender, EventArgs e)
        {
            FileLoader.LoadFilesToListview(FileLoader.GetFilesFromDirectory(this.txtFileSourceDirectoryPath.Text, this.chkFileSourceDirectorySub.Checked), this.lsvFiles, this);
            this.UpdateRenameItem();
            this.AutoInstantRename();
        }

        private void btnDateSearchFormatAdd_Click(object sender, EventArgs e)
        {
            DateFormatProvider NewDateFormatProvider = new DateFormatProvider();

            ListViewItem NewListViewItem = new ListViewItem
            {
                Tag = NewDateFormatProvider,
                Text = NewDateFormatProvider.Preview.FormatNoText,
                ToolTipText = NewDateFormatProvider.Preview.FormatNoText
            };
            this.lsvDateSearchFormats.Items.Add(NewListViewItem);
            this.lsvDateSearchFormats.Items[this.lsvDateSearchFormats.Items.Count - 1].Selected = true;
            this.lsvDateSearchFormats.Items[this.lsvDateSearchFormats.Items.Count - 1].EnsureVisible();

            this.SafeSearchList();
            this.UpdateRenameItem();
        }

        private void btnDateSearchFormaRemove_Click(object sender, EventArgs e)
        {
            if (this.lsvDateSearchFormats.SelectedItems.Count != 1) return;
            this.lsvDateSearchFormats.SelectedItems[0].Remove();

            this.SafeSearchList();
            this.UpdateRenameItem();
        }

        private void btnExecutetConvert_Click(object sender, EventArgs e)
        {
            this.RenameItems(true);
        }

        private void btnFileSourceSelectBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog
            {
                InitialDirectory = this.txtFileSourceSelectPath.Text,
                Multiselect = true
            };
            if (OpenFileDialog.ShowDialog() == DialogResult.OK && OpenFileDialog.FileNames.Length > 0)
            {
                FileInfo FileInfo = new FileInfo(OpenFileDialog.FileNames[0]);
                this.txtFileSourceSelectPath.Text = FileInfo.DirectoryName;
                FileLoader.LoadFilesToListview(OpenFileDialog.FileNames, this.lsvFiles, this);
                this.UpdateRenameItem();
                this.AutoInstantRename();
            }
        }

        private void btnRefreshFileList_Click(object sender, EventArgs e)
        {
            this.UpdateRenameItem();
        }

        private void cboDateSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.SearchDate_Source = this.cboDateSource.SelectedIndex;
            Settings.Default.Save();

            this.grbDateSearchFormats.Enabled = (this.cboDateSource.SelectedIndex == 2);
            this.UpdateRenameItem();
        }

        private void chkCheckForAlreadyInTargetFormat_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.CheckForAlreadyInTargetFormat = this.chkCheckForAlreadyInTargetFormat.Checked;
            Settings.Default.Save();
            this.UpdateRenameItem();
        }

        private void chkFileSourceDirectorySub_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.FileSourceDirectorySub = chkFileSourceDirectorySub.Checked;
            Settings.Default.Save();
        }

        private void chkInstantRename_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.InstantRename = chkInstantRename.Checked;
            Settings.Default.Save();
        }

        private void chkQuitAfterRename_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.QuitAfterRename = chkQuitAfterRename.Checked;
            Settings.Default.Save();
        }

        private void chkSelectAllRenameableFiles_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.SelectAllRenameableFiles = chkSelectAllRenameableFiles.Checked;
            Settings.Default.Save();
        }

        private void grbDateSearchFormats_EnabledChanged(object sender, EventArgs e)
        {
            this.grbDateSearchFormats.Visible = this.grbDateSearchFormats.Enabled;
            this.lsvDateSearchFormats_SelectedIndexChanged(this, new EventArgs());
        }

        private void lblFileSourceDragAndDrop_DragDrop(object sender, DragEventArgs e)
        {
            FileLoader.LoadFilesToListview((string[])e.Data.GetData(DataFormats.FileDrop, false), this.lsvFiles, this);
            this.UpdateRenameItem();
            this.AutoInstantRename();
        }

        private void lblFileSourceDragAndDrop_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void lblFormatHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Settings_AppConst.Default.FormatHelpLink);
        }

        private void lsvFilesPreview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control && e.Shift)
            {
                this.lsvFiles.MultiSelect = true;
                foreach (ListViewItem item in this.lsvFiles.Items)
                {
                    item.Selected = false;
                }
            }
            else if (e.KeyCode == Keys.A && e.Control)
            {
                this.lsvFiles.MultiSelect = true;
                foreach (ListViewItem item in this.lsvFiles.Items)
                {
                    item.Selected = true;
                }
            }
        }

        private void lsvDateSearchFormats_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.SafeSearchList();
            this.UpdateRenameItem();
        }

        private void lsvDateSearchFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lsvDateSearchFormats.SelectedItems.Count == 1)
            {
                this._systemChanged = true;
                this.uscSearchDate.Enabled = true;
                this.btnDateSearchFormaRemove.Enabled = true;

                DateFormatProvider SelectedDateFormat = (DateFormatProvider)this.lsvDateSearchFormats.SelectedItems[0].Tag;

                this.uscSearchDate.DateFormat = SelectedDateFormat.Format.Date;
                this.uscSearchDate.DatePosition = SelectedDateFormat.Format.Position;
                this.uscSearchDate.Seperator = SelectedDateFormat.Format.Seperator;
                this._systemChanged = false;
            }
            else
            {
                this.uscSearchDate.Enabled = false;
                this.btnDateSearchFormaRemove.Enabled = false;
                this.uscSearchDate.DateFormat = string.Empty;
            }
        }

        private void lsvFiles_DragDrop(object sender, DragEventArgs e)
        {
            this.lblFileSourceDragAndDrop_DragDrop(sender, e);
        }

        private void lsvFiles_DragEnter(object sender, DragEventArgs e)
        {
            this.lblFileSourceDragAndDrop_DragEnter(sender, e);
        }

        private void lsvFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsvFiles.SelectedItems.Count == 1)
            {
                RenameItem RenameItem = (RenameItem)this.lsvFiles.SelectedItems[0].Tag;
                if (RenameItem.State == RenameItem.RenameState.Renamed)
                {
                    System.Diagnostics.Process.Start("explorer.exe", "/e,/select," + RenameItem.FileInfoReamed.FullName);
                }
                else
                {
                    System.Diagnostics.Process.Start("explorer.exe", "/e,/select," + RenameItem.FileInfo.FullName);
                }
            }
        }

        private void lsvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnExecutetConvert.Enabled = this.lsvFiles.SelectedItems.Count > 0;
        }

        private void tabFileSource_Selected(object sender, TabControlEventArgs e)
        {
            Settings_AppVar.Default.SelectedTabPage = e.TabPageIndex;
            Settings_AppVar.Default.Save();
        }

        private void txtFileSourceSelectPath_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.FileSourceSelectPath = this.txtFileSourceSelectPath.Text;
            Settings.Default.Save();
        }

        private void txtFileSourceDirectoryPath_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.FileSourceDirectoryPath = this.txtFileSourceDirectoryPath.Text;
            Settings.Default.Save();
        }

        private void uscNewDate_Changed(object sender, EventArgs e)
        {
            if (this._systemChanged) return;

            this._targetDateFormat.AutoUpdateLengthList = false;
            this._targetDateFormat.Format.Date = this.uscNewDate.DateFormat;
            this._targetDateFormat.Format.Position = this.uscNewDate.DatePosition;
            this._targetDateFormat.Format.Seperator = this.uscNewDate.Seperator;
            this._targetDateFormat.AutoUpdateLengthList = true;
            this._targetDateFormat.UpdateFormatLengthList();
            this.txtFilenamePreview.Text = this._targetDateFormat.Preview.FinalDummyFilename;

            Settings.Default.NewDate_Format = this._targetDateFormat.JSONencode;
            Settings.Default.Save();
            this.UpdateRenameItem();
        }

        private void uscSearchDate_Changed(object sender, EventArgs e)
        {
            if (this.lsvDateSearchFormats.SelectedItems.Count != 1 || this._systemChanged) return;

            DateFormatProvider SelectedDateFormat = (DateFormatProvider)this.lsvDateSearchFormats.SelectedItems[0].Tag;

            SelectedDateFormat.AutoUpdateLengthList = false;
            SelectedDateFormat.Format.Date = this.uscSearchDate.DateFormat;
            SelectedDateFormat.Format.Position = this.uscSearchDate.DatePosition;
            SelectedDateFormat.Format.Seperator = this.uscSearchDate.Seperator;
            SelectedDateFormat.AutoUpdateLengthList = true;
            SelectedDateFormat.UpdateFormatLengthList();

            this.lsvDateSearchFormats.SelectedItems[0].Text = SelectedDateFormat.Preview.FormatNoTextOrDummy;
            this.lsvDateSearchFormats.SelectedItems[0].ToolTipText = SelectedDateFormat.Preview.FinalDummyFilename;

            this.SafeSearchList();
            this.UpdateRenameItem();
        }
        #endregion
        #endregion
    }
}