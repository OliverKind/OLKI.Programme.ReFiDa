using OLKI.Programme.ReFiDa.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLKI.Programme.ReFiDa
{
    public partial class MainForm : Form
    {
        private readonly FileHandling _fileHandling = new FileHandling();


        public MainForm()
        {
            InitializeComponent();
            //this.lsvFiles.Items.AddRange()
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
                List<FileInfo> FileList = this._fileHandling.GetFilesToConvert(new System.IO.DirectoryInfo(this.txtDirectoryPath.Text), this.chkSubDirectory.Checked, this.chkCheckDouble.Checked, (this.chkStart.Checked && this.chkStart8.Checked), (this.chkStart.Checked && this.chkStart12.Checked), (this.chkEnd.Checked && this.chkEnd8.Checked), (this.chkEnd.Checked && this.chkEnd12.Checked));

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
                string FileName = string.Empty;

                for (int i = 0; i < this.lsvFiles.Items.Count; i++)
                {

                    this.lsvFiles.Items[i].ForeColor = Color.Black;
                    this.lsvFiles.Items[i].SubItems[3].Text = "";

                    if (this.lsvFiles.Items[i].Checked)
                    {
                        File = (FileInfo)this.lsvFiles.Items[i].Tag;
                        FileName = FileHandling.GetFileNameWithoudExtension(File);

                        // Convert Datum start
                        if (this.chkStart12.Checked && FileCheck.FilterStartWith(FileName, 12))
                        {
                            this._fileHandling.ConvertSrartWith(File, FileName, 12, this.txtNewFormat.Text, this.chkSimulateRenaming.Checked, this.lsvFiles.Items[i]);
                        }
                        else if (this.chkStart8.Checked && FileCheck.FilterStartWith(FileName, 8))
                        {
                            this._fileHandling.ConvertSrartWith(File, FileName, 8, this.txtNewFormat.Text, this.chkSimulateRenaming.Checked, this.lsvFiles.Items[i]);
                        }
                        // Convert Datum end
                        else if (this.chkEnd12.Checked && FileCheck.FilterEndWith(FileName, 12))
                        {
                            this._fileHandling.ConvertEndWith(File, FileName, 12, this.txtNewFormat.Text, this.chkSimulateRenaming.Checked, this.lsvFiles.Items[i]);
                        }
                        else if (this.chkEnd8.Checked && FileCheck.FilterEndWith(FileName, 8))
                        {
                            this._fileHandling.ConvertEndWith(File, FileName, 8, this.txtNewFormat.Text, this.chkSimulateRenaming.Checked, this.lsvFiles.Items[i]);
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
    }
}