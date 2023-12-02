/*
 * ReFiDa - QuickBackupCreator
 * 
 * Copyright:   Oliver Kind - 2023
 * License:     LGPL
 * 
 * Desctiption:
 * Provide Controles to edit the Date format
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

using System;
using System.Windows.Forms;

namespace OLKI.Programme.ReFiDa.src.Forms
{
    /// <summary>
    /// Provide Controles to edit the Date format
    /// </summary>
    public partial class uscDateFormatgEditor : UserControl
    {
        #region Events
        /// <summary>
        /// Raised if the format was changed
        /// </summary>
        public event EventHandler Changed;
        #endregion

        #region Properties
        /// <summary>
        /// Date format settings
        /// </summary>
        private string _dateFormat;
        /// <summary>
        /// Get or set the Date format setting
        /// </summary>
        public string DateFormat
        {
            get
            {
                return this._dateFormat;
            }
            set
            {
                this._dateFormat = value;
                this.txtDateFormat.Text = value;
                this.Changed?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// The Position of the date
        /// </summary>
        private DateFormatProvider.DatePositionIndicator _datePosition;
        /// <summary>
        /// Get or set the Position of the date
        /// </summary>
        public DateFormatProvider.DatePositionIndicator DatePosition
        {
            get
            {
                return this._datePosition;
            }
            set
            {
                this._datePosition = value;
                switch (value)
                {
                    case DateFormatProvider.DatePositionIndicator.AfterFilename:
                        this.radDateAfter.Checked = true;
                        break;
                    case DateFormatProvider.DatePositionIndicator.BeforeFilename:
                        this.radDateBefore.Checked = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(DatePosition));
                }
                this.Changed?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// The seperator between date and original filename
        /// </summary>
        private string _seperator;
        /// <summary>
        /// Get or set the seperator between date and original filename
        /// </summary>
        public string Seperator
        {
            get
            {
                return this._seperator;
            }
            set
            {
                this._seperator = value;
                this.txtSeperatorBefore.Text = value;
                this.Changed?.Invoke(this, new EventArgs());
            }
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Inital a new Date Format Editr
        /// </summary>
        public uscDateFormatgEditor()
        {
            InitializeComponent();
        }

        private void radDateAfter_CheckedChanged(object sender, EventArgs e)
        {
            this.txtSeperatorAfter.Enabled = this.radDateAfter.Checked;
            this.txtSeperatorBefore.Enabled = !this.txtSeperatorAfter.Enabled;
            if (this.radDateAfter.Checked) this.DatePosition = DateFormatProvider.DatePositionIndicator.AfterFilename;
        }

        private void radDateBefore_CheckedChanged(object sender, EventArgs e)
        {
            this.txtSeperatorBefore.Enabled = this.radDateBefore.Checked;
            this.txtSeperatorAfter.Enabled = !this.txtSeperatorBefore.Enabled;
            if (this.radDateBefore.Checked) this.DatePosition = DateFormatProvider.DatePositionIndicator.BeforeFilename;
        }

        private void txtDateFormat_TextChanged(object sender, EventArgs e)
        {
            this.DateFormat = this.txtDateFormat.Text;
        }

        private void txtSeperatorAfter_EnabledChanged(object sender, EventArgs e)
        {
            this.txtSeperatorAfter.Visible = this.txtSeperatorAfter.Enabled;
        }

        private void txtSeperatorAfter_TextChanged(object sender, EventArgs e)
        {
            this.txtSeperatorBefore.Text = this.txtSeperatorAfter.Text;
            this.Seperator = this.txtSeperatorAfter.Text;
        }

        private void txtSeperatorBefore_EnabledChanged(object sender, EventArgs e)
        {
            this.txtSeperatorBefore.Visible = this.txtSeperatorBefore.Enabled;
        }

        private void txtSeperatorBefore_TextChanged(object sender, EventArgs e)
        {
            this.txtSeperatorAfter.Text = this.txtSeperatorBefore.Text;
            this.Seperator = this.txtSeperatorBefore.Text;
        }
        #endregion
    }
}