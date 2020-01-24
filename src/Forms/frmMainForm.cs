/*
 * ReFiDa - QuickBackupCreator
 * 
 * Copyright:   Oliver Kind - 2020
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
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * LGPL General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not check the GitHub-Repository.
 * 
 * */

using OLKI.Programme.ReFiDa.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OLKI.Programme.ReFiDa
{
    /// <summary>
    /// The MainForm of the application
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields
        /// <summary>
        /// Class to handle files: tools, search and rename
        /// </summary>
        private readonly FileHandling _fileHandling = new FileHandling();
        #endregion

        #region Methodes
        public MainForm()
        {
            InitializeComponent();
        }

        #region Form events
        private void MainForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            AboutForm AboutForm = new AboutForm();
            AboutForm.ShowDialog();
        }

        private void btnDirectoryBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowser = new FolderBrowserDialog()
            {
                Description = Stringtable._0x0001,
                SelectedPath = this.txtDirectoryPath.Text,
                ShowNewFolderButton = false
            };
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                this.txtDirectoryPath.Text = FolderBrowser.SelectedPath;
            }
        }

        private void btnDirectoryListFiles_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                List<FileInfo> FileList = this._fileHandling.GetFilesToReformat(new System.IO.DirectoryInfo(this.txtDirectoryPath.Text), this.chkSubDirectory.Checked, this.chkCheckDouble.Checked, (this.chkStart.Checked && this.chkStart8.Checked), (this.chkStart.Checked && this.chkStart12.Checked), (this.chkEnd.Checked && this.chkEnd8.Checked), (this.chkEnd.Checked && this.chkEnd12.Checked));

                // List files
                this.lsvFiles.Items.Clear();
                if (FileList.Count == 0) return;
                foreach (FileInfo File in FileList)
                {
                    ListViewItem NewItem = new ListViewItem
                    {
                        Text = File.Name
                    };
                    NewItem.SubItems.Add("");
                    NewItem.SubItems.Add(File.Directory.FullName);
                    NewItem.SubItems.Add("");
                    NewItem.Checked = true;
                    NewItem.Tag = File;

                    this.lsvFiles.Items.Add(NewItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(Stringtable._0x0002m, new object[] { ex.Message }), Stringtable._0x0002c, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void btnStartConvert_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;

                FileInfo File = null;
                string PureFileName = string.Empty;

                for (int i = 0; i < this.lsvFiles.Items.Count; i++)
                {

                    this.lsvFiles.Items[i].ForeColor = Color.Black;
                    this.lsvFiles.Items[i].SubItems[3].Text = "";

                    if (this.lsvFiles.Items[i].Checked)
                    {
                        File = (FileInfo)this.lsvFiles.Items[i].Tag;
                        PureFileName = FileHandling.GetPureFileName(File);

                        // Convert Datum start
                        if (this.chkStart12.Checked && FileCheck.FilterStartWithDigits(PureFileName, 12))
                        {
                            this._fileHandling.ReformatFileNameStartWithNumber(File, PureFileName, 12, this.txtNewFormat.Text, this.chkSimulateRenaming.Checked, this.lsvFiles.Items[i]);
                        }
                        else if (this.chkStart8.Checked && FileCheck.FilterStartWithDigits(PureFileName, 8))
                        {
                            this._fileHandling.ReformatFileNameStartWithNumber(File, PureFileName, 8, this.txtNewFormat.Text, this.chkSimulateRenaming.Checked, this.lsvFiles.Items[i]);
                        }
                        // Convert Datum end
                        else if (this.chkEnd12.Checked && FileCheck.FilterEndWithDigits(PureFileName, 12))
                        {
                            this._fileHandling.ReformatFileNameEndWithNumber(File, PureFileName, 12, this.txtNewFormat.Text, this.chkSimulateRenaming.Checked, this.lsvFiles.Items[i]);
                        }
                        else if (this.chkEnd8.Checked && FileCheck.FilterEndWithDigits(PureFileName, 8))
                        {
                            this._fileHandling.ReformatFileNameEndWithNumber(File, PureFileName, 8, this.txtNewFormat.Text, this.chkSimulateRenaming.Checked, this.lsvFiles.Items[i]);
                        }
                        else
                        {
                            this.lsvFiles.Items[i].SubItems[3].Text = Stringtable._0x0004;
                            this.lsvFiles.Items[i].BackColor = Color.Yellow;
                        }
                        if (this.chkSimulateRenaming.Checked)
                        {
                            this.lsvFiles.Items[i].SubItems[3].Text = this.lsvFiles.Items[i].SubItems[3].Text + Stringtable._0x0005; ;
                            this.lsvFiles.Items[i].ForeColor = Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(Stringtable._0x0003m, new object[] { ex.Message }), Stringtable._0x0003c, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void chkEnd_CheckedChanged(object sender, EventArgs e)
        {
            this.chkEnd12.Enabled = this.chkEnd.Checked;
            this.chkEnd8.Enabled = this.chkEnd.Checked;
        }

        private void chkStart_CheckedChanged(object sender, EventArgs e)
        {
            this.chkStart12.Enabled = this.chkStart.Checked;
            this.chkStart8.Enabled = this.chkStart.Checked;
        }

        private void lsvFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/e,/select," + ((FileInfo)this.lsvFiles.SelectedItems[0].Tag).FullName);
        }
        #endregion
        #endregion
    }
}