namespace OLKI.Programme.ReFiDa.src.Forms
{
    partial class EMailForm
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
            this.lblSenderAdress = new System.Windows.Forms.Label();
            this.lblSenderUser = new System.Windows.Forms.Label();
            this.lblSenderHost = new System.Windows.Forms.Label();
            this.radSenderUserBefore = new System.Windows.Forms.RadioButton();
            this.radSenderAddressBefore = new System.Windows.Forms.RadioButton();
            this.radSenderHostBefore = new System.Windows.Forms.RadioButton();
            this.radSenderHostAfter = new System.Windows.Forms.RadioButton();
            this.radSenderAdressAfter = new System.Windows.Forms.RadioButton();
            this.radSenderUserAfter = new System.Windows.Forms.RadioButton();
            this.tabLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.radNoAdd = new System.Windows.Forms.RadioButton();
            this.lblAfterDate = new System.Windows.Forms.Label();
            this.lblBeforeDate = new System.Windows.Forms.Label();
            this.tabLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSenderAdress
            // 
            this.lblSenderAdress.AutoSize = true;
            this.lblSenderAdress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSenderAdress.Location = new System.Drawing.Point(78, 45);
            this.lblSenderAdress.Name = "lblSenderAdress";
            this.lblSenderAdress.Size = new System.Drawing.Size(244, 20);
            this.lblSenderAdress.TabIndex = 7;
            this.lblSenderAdress.Text = "Abesnder: Komplett";
            this.lblSenderAdress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSenderUser
            // 
            this.lblSenderUser.AutoSize = true;
            this.lblSenderUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSenderUser.Location = new System.Drawing.Point(78, 25);
            this.lblSenderUser.Name = "lblSenderUser";
            this.lblSenderUser.Size = new System.Drawing.Size(244, 20);
            this.lblSenderUser.TabIndex = 4;
            this.lblSenderUser.Text = "Abesnder: Alias";
            this.lblSenderUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSenderHost
            // 
            this.lblSenderHost.AutoSize = true;
            this.lblSenderHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSenderHost.Location = new System.Drawing.Point(78, 65);
            this.lblSenderHost.Name = "lblSenderHost";
            this.lblSenderHost.Size = new System.Drawing.Size(244, 20);
            this.lblSenderHost.TabIndex = 10;
            this.lblSenderHost.Text = "Abesnder: Domain (Mit Top-Level-Domain)";
            this.lblSenderHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radSenderUserBefore
            // 
            this.radSenderUserBefore.AutoSize = true;
            this.radSenderUserBefore.Dock = System.Windows.Forms.DockStyle.Left;
            this.radSenderUserBefore.Location = new System.Drawing.Point(3, 28);
            this.radSenderUserBefore.Name = "radSenderUserBefore";
            this.radSenderUserBefore.Size = new System.Drawing.Size(14, 14);
            this.radSenderUserBefore.TabIndex = 3;
            this.radSenderUserBefore.TabStop = true;
            this.radSenderUserBefore.Tag = "10";
            this.radSenderUserBefore.UseVisualStyleBackColor = true;
            // 
            // radSenderAddressBefore
            // 
            this.radSenderAddressBefore.AutoSize = true;
            this.radSenderAddressBefore.Dock = System.Windows.Forms.DockStyle.Left;
            this.radSenderAddressBefore.Location = new System.Drawing.Point(3, 48);
            this.radSenderAddressBefore.Name = "radSenderAddressBefore";
            this.radSenderAddressBefore.Size = new System.Drawing.Size(14, 14);
            this.radSenderAddressBefore.TabIndex = 6;
            this.radSenderAddressBefore.TabStop = true;
            this.radSenderAddressBefore.Tag = "20";
            this.radSenderAddressBefore.UseVisualStyleBackColor = true;
            // 
            // radSenderHostBefore
            // 
            this.radSenderHostBefore.AutoSize = true;
            this.radSenderHostBefore.Dock = System.Windows.Forms.DockStyle.Left;
            this.radSenderHostBefore.Location = new System.Drawing.Point(3, 68);
            this.radSenderHostBefore.Name = "radSenderHostBefore";
            this.radSenderHostBefore.Size = new System.Drawing.Size(14, 14);
            this.radSenderHostBefore.TabIndex = 9;
            this.radSenderHostBefore.TabStop = true;
            this.radSenderHostBefore.Tag = "30";
            this.radSenderHostBefore.UseVisualStyleBackColor = true;
            // 
            // radSenderHostAfter
            // 
            this.radSenderHostAfter.AutoSize = true;
            this.radSenderHostAfter.Dock = System.Windows.Forms.DockStyle.Right;
            this.radSenderHostAfter.Location = new System.Drawing.Point(383, 68);
            this.radSenderHostAfter.Name = "radSenderHostAfter";
            this.radSenderHostAfter.Size = new System.Drawing.Size(14, 14);
            this.radSenderHostAfter.TabIndex = 11;
            this.radSenderHostAfter.TabStop = true;
            this.radSenderHostAfter.Tag = "31";
            this.radSenderHostAfter.UseVisualStyleBackColor = true;
            // 
            // radSenderAdressAfter
            // 
            this.radSenderAdressAfter.AutoSize = true;
            this.radSenderAdressAfter.Dock = System.Windows.Forms.DockStyle.Right;
            this.radSenderAdressAfter.Location = new System.Drawing.Point(383, 48);
            this.radSenderAdressAfter.Name = "radSenderAdressAfter";
            this.radSenderAdressAfter.Size = new System.Drawing.Size(14, 14);
            this.radSenderAdressAfter.TabIndex = 8;
            this.radSenderAdressAfter.TabStop = true;
            this.radSenderAdressAfter.Tag = "21";
            this.radSenderAdressAfter.UseVisualStyleBackColor = true;
            // 
            // radSenderUserAfter
            // 
            this.radSenderUserAfter.AutoSize = true;
            this.radSenderUserAfter.Dock = System.Windows.Forms.DockStyle.Right;
            this.radSenderUserAfter.Location = new System.Drawing.Point(383, 28);
            this.radSenderUserAfter.Name = "radSenderUserAfter";
            this.radSenderUserAfter.Size = new System.Drawing.Size(14, 14);
            this.radSenderUserAfter.TabIndex = 5;
            this.radSenderUserAfter.Tag = "11";
            this.radSenderUserAfter.UseVisualStyleBackColor = true;
            // 
            // tabLayoutPanel
            // 
            this.tabLayoutPanel.ColumnCount = 3;
            this.tabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tabLayoutPanel.Controls.Add(this.radNoAdd, 1, 0);
            this.tabLayoutPanel.Controls.Add(this.lblAfterDate, 2, 0);
            this.tabLayoutPanel.Controls.Add(this.lblBeforeDate, 0, 0);
            this.tabLayoutPanel.Controls.Add(this.radSenderUserBefore, 0, 1);
            this.tabLayoutPanel.Controls.Add(this.radSenderAddressBefore, 0, 2);
            this.tabLayoutPanel.Controls.Add(this.radSenderHostAfter, 2, 3);
            this.tabLayoutPanel.Controls.Add(this.radSenderHostBefore, 0, 3);
            this.tabLayoutPanel.Controls.Add(this.radSenderAdressAfter, 2, 2);
            this.tabLayoutPanel.Controls.Add(this.radSenderUserAfter, 2, 1);
            this.tabLayoutPanel.Controls.Add(this.lblSenderUser, 1, 1);
            this.tabLayoutPanel.Controls.Add(this.lblSenderHost, 1, 3);
            this.tabLayoutPanel.Controls.Add(this.lblSenderAdress, 1, 2);
            this.tabLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.tabLayoutPanel.Name = "tabLayoutPanel";
            this.tabLayoutPanel.RowCount = 4;
            this.tabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabLayoutPanel.Size = new System.Drawing.Size(400, 85);
            this.tabLayoutPanel.TabIndex = 0;
            // 
            // radNoAdd
            // 
            this.radNoAdd.AutoSize = true;
            this.radNoAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.radNoAdd.Location = new System.Drawing.Point(78, 3);
            this.radNoAdd.Name = "radNoAdd";
            this.radNoAdd.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.radNoAdd.Size = new System.Drawing.Size(160, 19);
            this.radNoAdd.TabIndex = 1;
            this.radNoAdd.TabStop = true;
            this.radNoAdd.Tag = "0";
            this.radNoAdd.Text = "Nichts hinzufügen";
            this.radNoAdd.UseVisualStyleBackColor = true;
            // 
            // lblAfterDate
            // 
            this.lblAfterDate.AutoSize = true;
            this.lblAfterDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAfterDate.Location = new System.Drawing.Point(328, 0);
            this.lblAfterDate.Name = "lblAfterDate";
            this.lblAfterDate.Size = new System.Drawing.Size(69, 25);
            this.lblAfterDate.TabIndex = 2;
            this.lblAfterDate.Text = "Nach Datum";
            this.lblAfterDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBeforeDate
            // 
            this.lblBeforeDate.AutoSize = true;
            this.lblBeforeDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBeforeDate.Location = new System.Drawing.Point(3, 0);
            this.lblBeforeDate.Name = "lblBeforeDate";
            this.lblBeforeDate.Size = new System.Drawing.Size(69, 25);
            this.lblBeforeDate.TabIndex = 0;
            this.lblBeforeDate.Text = "Vor Datum";
            this.lblBeforeDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EMailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(424, 109);
            this.Controls.Add(this.tabLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EMailForm";
            this.Text = "E-Mail Eigenschaft dem Dateinamen hinzufügen";
            this.tabLayoutPanel.ResumeLayout(false);
            this.tabLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSenderAdress;
        private System.Windows.Forms.Label lblSenderUser;
        private System.Windows.Forms.Label lblSenderHost;
        private System.Windows.Forms.RadioButton radSenderUserBefore;
        private System.Windows.Forms.RadioButton radSenderAddressBefore;
        private System.Windows.Forms.RadioButton radSenderHostBefore;
        private System.Windows.Forms.RadioButton radSenderHostAfter;
        private System.Windows.Forms.RadioButton radSenderAdressAfter;
        private System.Windows.Forms.RadioButton radSenderUserAfter;
        private System.Windows.Forms.TableLayoutPanel tabLayoutPanel;
        private System.Windows.Forms.Label lblBeforeDate;
        private System.Windows.Forms.Label lblAfterDate;
        private System.Windows.Forms.RadioButton radNoAdd;
    }
}