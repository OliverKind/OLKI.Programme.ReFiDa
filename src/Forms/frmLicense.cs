/*
 * ReFiDa - QuickBackupCreator
 * 
 * Copyright:   Oliver Kind - 2020
 * License:     LGPL
 * 
 * Desctiption:
 * Form to show license information
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

using System;
using System.Windows.Forms;

namespace OLKI.Programme.ReFiDa
{
    /// <summary>
    /// A form to show license information
    /// </summary>
    public partial class License : Form
    {
        #region Constants
        /// <summary>
        /// Index for application main licence to set licence combobox at start up
        /// </summary>
        private const int INDEX_FOR_APPLICATION_MAIN_LICENCE = 1;
        #endregion

        #region Methods
        public License()
        {
            InitializeComponent();
            this.cboLicenseName.SelectedIndex = INDEX_FOR_APPLICATION_MAIN_LICENCE;
        }

        private void License_Shown(object sender, EventArgs e)
        {
            this.txtLicense.SelectionLength = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cboLicenseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch  (this.cboLicenseName.SelectedItem.ToString())
            {
                case "CC4.0-License":
                    this.txtLicense.Text = Properties.Resources.CC4_0_License;
                    break;
                case "LGPL-License":
                    this.txtLicense.Text = Properties.Resources.LGPL_License;
                    break;
                default:
                    this.txtLicense.Text = "";
                    break;
            }
        }
        #endregion
    }
}