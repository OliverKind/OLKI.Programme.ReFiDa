namespace OLKI.Programme.ReFiDa.src.Forms
{
    partial class uscDateFormatEditor
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSeperatorBefore = new System.Windows.Forms.TextBox();
            this.txtSeperatorAfter = new System.Windows.Forms.TextBox();
            this.radDateBefore = new System.Windows.Forms.RadioButton();
            this.radDateAfter = new System.Windows.Forms.RadioButton();
            this.txtDateFormat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSeperatorBefore
            // 
            this.txtSeperatorBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeperatorBefore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSeperatorBefore.Location = new System.Drawing.Point(398, 0);
            this.txtSeperatorBefore.Name = "txtSeperatorBefore";
            this.txtSeperatorBefore.Size = new System.Drawing.Size(20, 20);
            this.txtSeperatorBefore.TabIndex = 13;
            this.txtSeperatorBefore.EnabledChanged += new System.EventHandler(this.txtSeperatorBefore_EnabledChanged);
            this.txtSeperatorBefore.TextChanged += new System.EventHandler(this.txtSeperatorBefore_TextChanged);
            // 
            // txtSeperatorAfter
            // 
            this.txtSeperatorAfter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSeperatorAfter.Location = new System.Drawing.Point(85, 0);
            this.txtSeperatorAfter.Name = "txtSeperatorAfter";
            this.txtSeperatorAfter.Size = new System.Drawing.Size(20, 20);
            this.txtSeperatorAfter.TabIndex = 11;
            this.txtSeperatorAfter.EnabledChanged += new System.EventHandler(this.txtSeperatorAfter_EnabledChanged);
            this.txtSeperatorAfter.TextChanged += new System.EventHandler(this.txtSeperatorAfter_TextChanged);
            // 
            // radDateBefore
            // 
            this.radDateBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radDateBefore.AutoSize = true;
            this.radDateBefore.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radDateBefore.Location = new System.Drawing.Point(424, 3);
            this.radDateBefore.Name = "radDateBefore";
            this.radDateBefore.Size = new System.Drawing.Size(76, 17);
            this.radDateBefore.TabIndex = 14;
            this.radDateBefore.TabStop = true;
            this.radDateBefore.Text = "Dateiname";
            this.radDateBefore.UseVisualStyleBackColor = true;
            this.radDateBefore.CheckedChanged += new System.EventHandler(this.radDateBefore_CheckedChanged);
            // 
            // radDateAfter
            // 
            this.radDateAfter.AutoSize = true;
            this.radDateAfter.Location = new System.Drawing.Point(3, 3);
            this.radDateAfter.Name = "radDateAfter";
            this.radDateAfter.Size = new System.Drawing.Size(76, 17);
            this.radDateAfter.TabIndex = 10;
            this.radDateAfter.TabStop = true;
            this.radDateAfter.Text = "Dateiname";
            this.radDateAfter.UseVisualStyleBackColor = true;
            this.radDateAfter.CheckedChanged += new System.EventHandler(this.radDateAfter_CheckedChanged);
            // 
            // txtDateFormat
            // 
            this.txtDateFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDateFormat.Location = new System.Drawing.Point(111, 0);
            this.txtDateFormat.Name = "txtDateFormat";
            this.txtDateFormat.Size = new System.Drawing.Size(281, 20);
            this.txtDateFormat.TabIndex = 12;
            this.txtDateFormat.TextChanged += new System.EventHandler(this.txtDateFormat_TextChanged);
            // 
            // uscDateFormatEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSeperatorBefore);
            this.Controls.Add(this.txtSeperatorAfter);
            this.Controls.Add(this.radDateBefore);
            this.Controls.Add(this.radDateAfter);
            this.Controls.Add(this.txtDateFormat);
            this.Name = "uscDateFormatEditor";
            this.Size = new System.Drawing.Size(500, 20);
            this.EnabledChanged += new System.EventHandler(this.uscDateFormatEditor_EnabledChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSeperatorBefore;
        private System.Windows.Forms.TextBox txtSeperatorAfter;
        private System.Windows.Forms.RadioButton radDateBefore;
        private System.Windows.Forms.RadioButton radDateAfter;
        private System.Windows.Forms.TextBox txtDateFormat;
    }
}
