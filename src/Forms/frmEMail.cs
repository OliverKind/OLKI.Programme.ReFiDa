/*
 * ReFiDa - Reformating File names that contains a Date
 * 
 * Copyright:   Oliver Kind - 2023
 * License:     LGPL
 * 
 * Desctiption:
 * Form to change settings to Add E-Mail sender Informations, for Outlook E-Mails
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

using OLKI.Programme.ReFiDa.src;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OLKI.Programme.ReFiDa
{
    internal partial class EMailForm : Form
    {
        #region Events
        public event EventHandler Changed;
        #endregion

        #region Methodes
        public EMailForm(SearchDate.OutlookAdd initialOutlookAdd)
        {
            InitializeComponent();
            foreach (RadioButton radioButton in this.tabLayoutPanel.Controls.OfType<RadioButton>())
            {
                radioButton.CheckedChanged += new EventHandler(this.RadioButton_CheckedChanged);

                if ((SearchDate.OutlookAdd)Convert.ToInt32(radioButton.Tag) == initialOutlookAdd)
                {
                    radioButton.Checked = true;
                }
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Properties.Settings.Default.OutlookAdd = Convert.ToInt32(((RadioButton)sender).Tag);
                Properties.Settings.Default.Save();
            }
            this.Changed?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}