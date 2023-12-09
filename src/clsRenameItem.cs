/*
 * ReFiDa - Reformating File names that contains a Date
 * 
 * Copyright:   Oliver Kind - 2023
 * License:     LGPL
 * 
 * Desctiption:
 * Class to provide datea and tools to rename a file
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
using System.Drawing;
using System.Globalization;
using System.IO;
using static OLKI.Programme.ReFiDa.src.DateFormatProvider;

namespace OLKI.Programme.ReFiDa.src
{
    /// <summary>
    /// Class to provide datea and tools to rename a file
    /// </summary>
    internal class RenameItem
    {
        #region Enums
        /// <summary>
        /// Where to search for the new date
        /// </summary>
        public enum DateSearchMode
        {
            /// <summary>
            /// Use the file property Last write time
            /// </summary>
            FilePropertyLastWriteTime,
            /// <summary>
            /// Use the file property Creation time
            /// </summary>
            FilePropertyCreationTime,
            /// <summary>
            /// Search inside the filename for a date
            /// </summary>
            Filename,
            /// <summary>
            /// Use the recived Date of an Outlook E-Mail file
            /// </summary>
            EMailOutlook,
            /// <summary>
            /// Use the recived Date of an Thunderbird E-Mail file
            /// </summary>
            EMailThunderbird
        }

        /// <summary>
        /// State of the rename object
        /// </summary>
        public enum RenameState
        {
            /// <summary>
            /// Not an File to rename
            /// </summary>
            NoRename,
            /// <summary>
            /// Is a File to rename
            /// </summary>
            ToRename,
            /// <summary>
            /// File is renamed
            /// </summary>
            Renamed,
            /// <summary>
            /// Exception while searching for a date or rename the file
            /// </summary>
            Exception
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the exception while searching for a date or renaming the file
        /// </summary>
        public Exception Exception { get; private set; } = null;

        /// <summary>
        /// FileInfo of the original File
        /// </summary>
        public FileInfo FileInfo { get; private set; } = null;

        /// <summary>
        /// FileInfo of the renamed File
        /// </summary>
        public FileInfo FileInfoReamed { get; private set; } = null;

        /// <summary>
        /// Original Filename without extension
        /// </summary>
        public string FilePureName { get; private set; } = string.Empty;


        /// <summary>
        /// Original Filename without extension and without date (if filename contains date)
        /// </summary>
        public string FilePureNameNoDate { get; private set; } = string.Empty;

        /// <summary>
        /// State of the renaming Item
        /// </summary>
        public RenameState State { get; private set; } = RenameState.NoRename;

        /// <summary>
        /// Color for the ListView, depending of the state
        /// </summary>
        public Color StateColor
        {
            get
            {
                switch (State)
                {
                    case RenameState.NoRename: return new Color();
                    case RenameState.ToRename: return Settings_AppConst.Default.FormatColor_ToRename;
                    case RenameState.Renamed: return Settings_AppConst.Default.FormatColor_Renamed;
                    case RenameState.Exception: return Settings_AppConst.Default.FormatColor_Exception;
                    default: return new Color();
                }
            }
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Create a new RenameItem
        /// </summary>
        /// <param name="file">File to rename</param>
        public RenameItem(FileInfo file)
        {
            this.FileInfo = file;
            this.FilePureName = FileInfo.Name.Substring(0, FileInfo.Name.Length - FileInfo.Extension.Length);
            this.FilePureNameNoDate = this.FilePureName;
        }

        /// <summary>
        /// Get if the file is already in final format
        /// </summary>
        /// <param name="filePureName">Filename without extension</param>
        /// <param name="targetDateFormat">Final date format</param>
        /// <returns>Returns true if the file is in final format</returns>
        private bool IsInFirnalFormat(string filePureName, DateFormatProvider targetDateFormat)
        {
            for (int l = 0; l < targetDateFormat.FormatLength.Length; l++)
            {
                if (filePureName.Length >= targetDateFormat.FormatLength[l])
                {
                    DatePositionIndicator DatePosition = targetDateFormat.Format.Position;
                    string SearchPartOfName;
                    switch (DatePosition)
                    {
                        case DatePositionIndicator.AfterFilename:
                            SearchPartOfName = filePureName.Substring(filePureName.Length - targetDateFormat.FormatLength[l], targetDateFormat.FormatLength[l]);
                            break;
                        case DatePositionIndicator.BeforeFilename:
                            SearchPartOfName = filePureName.Substring(0, targetDateFormat.FormatLength[l]);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(DatePosition));
                    }
                    if (DateTime.TryParseExact(SearchPartOfName, targetDateFormat.Preview.Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _)) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Rename the file an set the state and exception
        /// </summary>
        /// <returns>Return if renaming was sucessfull</returns>
        public bool Rename()
        {
            try
            {
                this.Exception = null;
                this.FileInfo.MoveTo(this.FileInfoReamed.FullName);
                this.State = RenameState.Renamed;
                return true;
            }
            catch (Exception ex)
            {
                this.Exception = ex;
                this.State = RenameState.Exception;
                return false;
            }
        }

        /// <summary>
        /// Update the rename Item: Renamed File, Status etc.
        /// </summary>
        /// <param name="dateSource">Source to search for the date</param>
        /// <param name="checkForAlreadyInTargetFormat">Check if the file is already in final format</param>
        /// <param name="searchDateFormatList">List with date Patterns to search inside the file name</param>
        /// <param name="targetDateFormat">Format of the final date and file name</param>
        public void UpateRenameData(DateSearchMode dateSource, bool checkForAlreadyInTargetFormat, DateFormatProvider[] searchDateFormatList, DateFormatProvider targetDateFormat)
        {
            try
            {
                bool GetDateResult;
                this.Exception = null;
                this.FileInfoReamed = null;
                this.State = RenameState.NoRename;

                FileInfo FileInfoReamed = null;
                Exception Exception = null;

                // No rename needet
                if (checkForAlreadyInTargetFormat && this.IsInFirnalFormat(this.FilePureName, targetDateFormat)) return;

                //Check for new date
                switch (dateSource)
                {
                    case DateSearchMode.FilePropertyLastWriteTime:
                        GetDateResult = SearchDate.GetFromFilePropertyLastWriteTime(this.FileInfo, this.FilePureName, out FileInfoReamed, targetDateFormat, out Exception);
                        this.State = GetDateResult ? RenameState.ToRename : RenameState.Exception;
                        break;
                    case DateSearchMode.FilePropertyCreationTime:
                        GetDateResult = SearchDate.GetFromFilePropertyCreationTime(this.FileInfo, this.FilePureName, out FileInfoReamed, targetDateFormat, out Exception);
                        this.State = GetDateResult ? RenameState.ToRename : RenameState.Exception;
                        break;
                    case DateSearchMode.Filename:
                        string FilePureNameNoDate = this.FilePureName;
                        GetDateResult = SearchDate.GetFromFileName(this.FileInfo, this.FilePureName, out FilePureNameNoDate, fileInfoReamed: out FileInfoReamed, targetDateFormat: targetDateFormat, searchDateFormatList: searchDateFormatList, exception: out Exception);
                        this.State = this.UpdateState(GetDateResult, Exception);
                        this.FilePureNameNoDate = FilePureNameNoDate;
                        break;
                    case DateSearchMode.EMailOutlook:
                        GetDateResult = SearchDate.GetFromMsgFile(this.FileInfo, this.FilePureName, out FileInfoReamed, targetDateFormat, out Exception);
                        this.State = this.UpdateState(GetDateResult, Exception);
                        break;
                    case DateSearchMode.EMailThunderbird:
                        GetDateResult = SearchDate.GetFromEmlFile(this.FileInfo, this.FilePureName, out FileInfoReamed, targetDateFormat, out Exception);
                        this.State = this.UpdateState(GetDateResult, Exception);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(dateSource));
                }
                this.Exception = Exception;
                this.FileInfoReamed = FileInfoReamed;
            }
            catch (Exception ex)
            {
                this.Exception = ex;
                this.State = RenameState.Exception;
            }
        }

        /// <summary>
        /// Update the State
        /// </summary>
        /// <param name="setToRename">Should the state be renamed</param>
        /// <param name="exception">Exception of the Item</param>
        /// <returns>Set to Rename, if set, or NoRename if no exception has thrown, otherwise set to exception</returns>
        private RenameState UpdateState(bool setToRename, Exception exception)
        {
            if (setToRename)
            {
                return RenameState.ToRename;
            }
            else
            {
                return exception == null ? RenameState.NoRename : RenameState.Exception;
            }
        }
        #endregion
    }
}