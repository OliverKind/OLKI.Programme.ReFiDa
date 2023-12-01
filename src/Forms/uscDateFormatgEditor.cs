using OLKI.Programme.ReFiDa.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLKI.Programme.ReFiDa.src.Forms
{
    public partial class uscDateFormatgEditor : UserControl
    {
        #region Events
        public event EventHandler Changed;
        #endregion

        #region Properties
        private string _dateFormat;
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

        private DateFormatProvider.DatePositionIndicator _datePosition;
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

        private string _seperator;
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