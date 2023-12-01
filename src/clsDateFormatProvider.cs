/*
 * ReFiDa - Reformating File names that contains a Date
 * 
 * Copyright:   Oliver Kind - 2023
 * License:     LGPL
 * 
 * Desctiption:
 * Class to provide tools to format dates and save format settings
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
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace OLKI.Programme.ReFiDa.src
{
    /// <summary>
    /// Class to provide tools to format dates and save format settings
    /// </summary>
    public class DateFormatProvider
    {
        #region Subclasses
        /// <summary>
        /// Basic format settings
        /// </summary>
        public class Settings
        {
            #region Events
            /// <summary>
            /// Raised if the settings has been changed
            /// </summary>
            public event EventHandler Changed;
            #endregion

            #region Properties
            /// <summary>
            /// Date format settings
            /// </summary>
            private string _date = Settings_AppConst.Default.DefaultDate_Format;
            /// <summary>
            /// Get or set the Date format setting
            /// </summary>
            public string Date
            {
                get
                {
                    return this._date;
                }
                set
                {
                    this._date = value;
                    this.Changed?.Invoke(this, new EventArgs());
                }
            }

            /// <summary>
            /// The Position of the date
            /// </summary>
            private DatePositionIndicator _position = (DatePositionIndicator)Settings_AppConst.Default.DefaultDate_Position;
            /// <summary>
            /// Get or set the Position of the date
            /// </summary>
            public DatePositionIndicator Position
            {
                get
                {
                    return this._position;
                }
                set
                {
                    this._position = value;
                    this.Changed?.Invoke(this, new EventArgs());
                }
            }

            /// <summary>
            /// The seperator between date and original filename
            /// </summary>
            public string _seperator = Settings_AppConst.Default.DefaultDate_Seperatur;
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
                    this.Changed?.Invoke(this, new EventArgs());
                }
            }
            #endregion
        }

        /// <summary>
        /// Provide tools to Preview of the definded date format
        /// </summary>
        public class Previews
        {
            #region Fields
            /// <summary>
            /// Settings of the date format
            /// </summary>
            private readonly Settings _format;
            #endregion

            #region Properteis
            /// <summary>
            /// Shows the formated dummy Date with Seperators with an dummy filename
            /// </summary>
            public string FinalDummyFilename
            {
                get
                {
                    try
                    {
                        switch (this._format.Position)
                        {
                            case DatePositionIndicator.AfterFilename:
                                return string.Format(Stringtable._0x0005a, new object[] { DateTime.Now.ToString(this._format.Date), this._format.Seperator });
                            case DatePositionIndicator.BeforeFilename:
                                return string.Format(Stringtable._0x0005b, new object[] { DateTime.Now.ToString(this._format.Date), this._format.Seperator });
                            default:
                                throw new ArgumentOutOfRangeException(nameof(this._format.Position));
                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }

            /// <summary>
            /// Shows the complete Format with Seperators
            /// </summary>
            public string Format
            {
                get
                {
                    try
                    {
                        switch (this._format.Position)
                        {
                            case DatePositionIndicator.AfterFilename:
                                return string.Format("{1}{0}", new object[] { this._format.Date, this._format.Seperator });
                            case DatePositionIndicator.BeforeFilename:
                                return string.Format("{0}{1}", new object[] { this._format.Date, this._format.Seperator });
                            default:
                                throw new ArgumentOutOfRangeException(nameof(this._format.Position));
                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }

            /// <summary>
            /// Shows the complete Format with Seperators or an Message if no format is set
            /// </summary>
            public string FormatNoText
            {
                get
                {
                    return string.IsNullOrEmpty(this.Format) ? Stringtable._0x0006 : this.Format;
                }
            }

            /// <summary>
            /// Shows the complete Format with Seperators with an dummy filename or an Message if no format is set
            /// </summary>
            public string FormatNoTextOrDummy
            {
                get
                {
                    try
                    {
                        if (string.IsNullOrEmpty(this.Format)) return Stringtable._0x0006;

                        switch (this._format.Position)
                        {
                            case DatePositionIndicator.AfterFilename:
                                return string.Format(Stringtable._0x0007a, new object[] { this._format.Date, this._format.Seperator });
                            case DatePositionIndicator.BeforeFilename:
                                return string.Format(Stringtable._0x0007b, new object[] { this._format.Date, this._format.Seperator });
                            default:
                                throw new ArgumentOutOfRangeException(nameof(this._format.Position));
                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }



                }
            }
            #endregion

            #region Methodes
            /// <summary>
            /// Create a new Preview object, with default formating
            /// </summary>
            public Previews() : this(new Settings()) { }
            /// <summary>
            /// Create a new Preview object with defined formating
            /// </summary>
            /// <param name="format">Format to show in preview</param>
            public Previews(Settings format)
            {
                this._format = format;
            }
            #endregion
        }
        #endregion

        #region Constants
        /// <summary>
        /// Dummy year to calculate format lenght
        /// </summary>
        private const int DUMMY_YEAR = 2000;
        #endregion

        #region Enums
        /// <summary>
        /// Indication of the position of the date
        /// </summary>
        public enum DatePositionIndicator
        {
            /// <summary>
            /// Date is after Filename, but befor the File Extension
            /// </summary>
            AfterFilename,
            /// <summary>
            /// Date is before Filename and File Extension
            /// </summary>
            BeforeFilename
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the format settings
        /// </summary>
        public Settings Format { get; private set; } = new Settings();

        /// <summary>
        /// Get the format preview
        /// </summary>
        public Previews Preview { get; private set; } = new Previews();

        /// <summary>
        /// JSON-Encode of the format settings
        /// </summary>
        public string JSONencode
        {
            get
            {
                return JsonSerializer.Serialize(this.Format);
            }
        }

        /// <summary>
        /// Get or set if the formath lengts List shold been updated if an setting was changed
        /// </summary>
        public bool AutoUpdateLengthList { get; set; } = false;

        /// <summary>
        /// A List with the posible lengths of the final formats, with Names for Days and Months, debending fo the fomrat settings
        /// </summary>
        public int[] FormatLength { get; private set; }
        #endregion

        #region Methodes
        /// <summary>
        /// Inital a new DateFormatProvider with no AutoUpdate and defaukt format settings
        /// </summary>
        public DateFormatProvider() : this(false) { }
        /// <summary>
        /// Inital a new DateFormatProvider with defaukt format settings
        /// </summary>
        /// <param name="autoUpdateLengthList">Set if the FormatLength should been automaticly updated if the format settings where changed</param>
        public DateFormatProvider(bool autoUpdateLengthList) : this(autoUpdateLengthList, string.Empty) { }
        /// <summary>
        /// Inital a new DateFormatProvider
        /// </summary>
        /// <param name="autoUpdateLengthList">Set if the FormatLength should been automaticly updated if the format settings where changed</param>
        /// <param name="jsonEncode">JSON-Encode of the format settings, will be saved to the sttings</param>
        public DateFormatProvider(bool autoUpdateLengthList, string jsonEncode)
        {
            this.Format = new Settings();
            this.Format.Changed += new EventHandler(this.Settings_Changed);
            this.AutoUpdateLengthList = autoUpdateLengthList;
            if (!string.IsNullOrEmpty(jsonEncode))
            {
                this.Format = JsonSerializer.Deserialize<Settings>(jsonEncode);
            }
            this.Preview = new Previews(this.Format);
            this.UpdateFormatLengthList();
        }

        /// <summary>
        /// Update the list of the format length
        /// </summary>
        public void UpdateFormatLengthList()
        {
            this.FormatLength = new int[0];
            DateTime CheckDateTime;
            List<int> FormatLengthList = new List<int>();
            int LengthValue;

            for (int m = 1; m <= 12; m++)
            {
                for (int d = 1; d <= 7; d++)
                {
                    LengthValue = 0;
                    try
                    {
                        CheckDateTime = new DateTime(DUMMY_YEAR, m, d);
                        switch (this.Format.Position)
                        {
                            case DatePositionIndicator.AfterFilename:
                                LengthValue = string.Format("{1}{0}", new object[] { CheckDateTime.ToString(this.Format.Date), this.Format.Seperator }).Length;
                                break;
                            case DatePositionIndicator.BeforeFilename:
                                LengthValue = string.Format("{0}{1}", new object[] { CheckDateTime.ToString(this.Format.Date), this.Format.Seperator }).Length;
                                break;
                            default:
                                LengthValue = 0;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        _ = ex;
                    }
                    if (!FormatLengthList.Contains(LengthValue) && LengthValue > 0) FormatLengthList.Add(LengthValue);
                }
            }

            FormatLengthList.Sort();
            FormatLengthList.Reverse();
            this.FormatLength = FormatLengthList.ToArray();
        }

        private void Settings_Changed(object sender, EventArgs e)
        {
            this.Preview = new Previews(this.Format);
            if (this.AutoUpdateLengthList) this.UpdateFormatLengthList();
        }

        #endregion
    }
}