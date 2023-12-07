/*
 * ReFiDa - Reformating File names that contains a Date
 * 
 * Copyright:   Oliver Kind - 2023
 * License:     LGPL
 * 
 * Desctiption:
 * Class with tools to rename a Item and search for dates
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
using System.Globalization;
using System.IO;
using static OLKI.Programme.ReFiDa.src.DateFormatProvider;

namespace OLKI.Programme.ReFiDa.src
{
    internal static class SearchDate
    {
        /// <summary>
        /// Bould a new filename, depending of the format
        /// </summary>
        /// <param name="filePureName">Filename without extension</param>
        /// <param name="fileExtension">Fileextension of the file</param>
        /// <param name="targetDate">Target date of the file</param>
        /// <param name="targetDateFormat">Format of the target Date and Filename</param>
        /// <param name="exception">Exception while create the Filename</param>
        /// <returns>A string with the final Filename</returns>
        private static string FileNameBuilder(string filePureName, string fileExtension, DateTime targetDate, DateFormatProvider targetDateFormat, out Exception exception)
        {
            exception = null;
            try
            {
                switch (targetDateFormat.Format.Position)
                {
                    case DatePositionIndicator.AfterFilename:
                        return string.Format("{1}{0}{2}", new object[] { targetDate.ToString(targetDateFormat.Preview.Format), filePureName, fileExtension });
                    case DatePositionIndicator.BeforeFilename:
                        return string.Format("{0}{1}{2}", new object[] { targetDate.ToString(targetDateFormat.Preview.Format), filePureName, fileExtension });
                    default:
                        throw new ArgumentOutOfRangeException(nameof(targetDateFormat.Format.Position));
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                return string.Empty;
            }
        }

        /// <summary>
        /// Get the new filrename, with date from Fileproperty Last Write Time.
        /// </summary>
        /// <param name="fileInfo">Original file</param>
        /// <param name="filePureName">Filename without extension</param>
        /// <param name="fileInfoReamed">Renamed file</param>
        /// <param name="targetDateFormat">Format of the target date</param>
        /// <param name="exception">Exception while getting the new Filename</param>
        /// <returns>True if the new Filename was sucessfully created</returns>
        public static bool GetFromFilePropertyLastWriteTime(FileInfo fileInfo, string filePureName, out FileInfo fileInfoReamed, DateFormatProvider targetDateFormat, out Exception exception)
        {
            try
            {
                string FileRenamed = FileNameBuilder(filePureName, fileInfo.Extension, fileInfo.LastWriteTime, targetDateFormat, out exception);
                fileInfoReamed = new FileInfo(string.Format(@"{0}\{1}", new object[] { fileInfo.DirectoryName, FileRenamed }));
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                fileInfoReamed = null;
                return false;
            }
        }

        /// <summary>
        /// Get the new filrename, with date from Fileproperty Creation Time.
        /// </summary>
        /// <param name="fileInfo">Original file</param>
        /// <param name="filePureName">Filename without extension</param>
        /// <param name="fileInfoReamed">Renamed file</param>
        /// <param name="targetDateFormat">Format of the target date</param>
        /// <param name="exception">Exception while getting the new Filename</param>
        /// <returns>True if the new Filename was sucessfully created</returns>
        public static bool GetFromFilePropertyCreationTime(FileInfo fileInfo, string filePureName, out FileInfo fileInfoReamed, DateFormatProvider targetDateFormat, out Exception exception)
        {
            try
            {
                string FileRenamed = FileNameBuilder(filePureName, fileInfo.Extension, fileInfo.CreationTime, targetDateFormat, out exception);
                fileInfoReamed = new FileInfo(string.Format(@"{0}\{1}", new object[] { fileInfo.DirectoryName, FileRenamed }));
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                fileInfoReamed = null;
                return false;
            }
        }

        /// <summary>
        /// Get the new filrename, with date from the original Filename
        /// </summary>
        /// <param name="fileInfo">Original file</param>
        /// <param name="filePureName">Filename without extension</param>
        /// <param name="fileInfoReamed">Renamed file</param>
        /// <param name="targetDateFormat">Format of the target date</param>
        /// <param name="searchDateFormatList">List with search pattern, to search inside the Filename</param>
        /// <param name="exception">Exception while getting the new Filename</param>
        /// <returns>True if the new Filename was sucessfully created</returns>
        public static bool GetFromFileName(FileInfo fileInfo, string filePureName, out string filePureNameNoDate, out FileInfo fileInfoReamed, DateFormatProvider targetDateFormat, DateFormatProvider[] searchDateFormatList, out Exception exception)
        {
            exception = null;
            fileInfoReamed = null;
            filePureNameNoDate = string.Empty;
            string DateCandidat = string.Empty;
            string FileOnlyName = string.Empty;
            DatePositionIndicator DatePosition;
            try
            {
                DateTime FoundDateValue = new DateTime();
                for (int d = 0; d < searchDateFormatList.Length; d++)
                {
                    for (int l = 0; l < searchDateFormatList[d].FormatLength.Length; l++)
                    {
                        DatePosition = searchDateFormatList[d].Format.Position;
                        switch (DatePosition)
                        {
                            case DatePositionIndicator.AfterFilename:
                                DateCandidat = Substring(filePureName, filePureName.Length - searchDateFormatList[d].FormatLength[l], searchDateFormatList[d].FormatLength[l]);
                                FileOnlyName = Substring(filePureName, 0, filePureName.Length - searchDateFormatList[d].FormatLength[l]);
                                filePureNameNoDate = FileOnlyName;
                                break;
                            case DatePositionIndicator.BeforeFilename:
                                DateCandidat = Substring(filePureName, 0, searchDateFormatList[d].FormatLength[l]);
                                FileOnlyName = Substring(filePureName, searchDateFormatList[d].FormatLength[l], filePureName.Length - searchDateFormatList[d].FormatLength[l]);
                                filePureNameNoDate = FileOnlyName;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(DatePosition));
                        }
                        if (DateCandidat.Length > 0)
                        {
                            if (DateTime.TryParseExact(DateCandidat, searchDateFormatList[d].Preview.Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out FoundDateValue))
                            {
                                string FileRenamed = FileNameBuilder(filePureNameNoDate, fileInfo.Extension, fileInfo.CreationTime, targetDateFormat, out exception);
                                fileInfoReamed = new FileInfo(string.Format(@"{0}\{1}", new object[] { fileInfo.DirectoryName, FileRenamed }));
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        /// <summary>
        /// Get the new filrename, with date from the recived Date of an Outlook E-Mail
        /// </summary>
        /// <param name="fileInfo">Original file</param>
        /// <param name="filePureName">Filename without extension</param>
        /// <param name="fileInfoReamed">Renamed file</param>
        /// <param name="targetDateFormat">Format of the target date</param>
        /// <param name="exception">Exception while getting the new Filename</param>
        /// <returns>True if the new Filename was sucessfully created</returns>
        public static bool GetFromMsgFile(FileInfo fileInfo, string filePureName, out FileInfo fileInfoReamed, DateFormatProvider targetDateFormat, out Exception exception)
        {
            try
            {
                exception = null;
                fileInfoReamed = null;
                if (string.Compare(fileInfo.Extension, ".msg", StringComparison.OrdinalIgnoreCase) != 0) return false;

                //Create temporary directory an file
                DirectoryInfo TempDirInfo = Directory.CreateDirectory(Path.GetTempPath() + Settings_AppConst.Default.TempDirectoryName);
                FileInfo TempFileInfo = new FileInfo(Path.GetTempFileName());
                TempFileInfo.MoveTo(TempDirInfo.FullName + TempFileInfo.Name + ".msg");
                fileInfo.CopyTo(TempFileInfo.FullName, true);

                //Open in Outlook
                Microsoft.Office.Interop.Outlook.Application OutlookApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem MailItem = OutlookApp.Session.OpenSharedItem(TempFileInfo.FullName) as Microsoft.Office.Interop.Outlook.MailItem;

                //Rename file
                string FileRenamed = FileNameBuilder(filePureName, fileInfo.Extension, MailItem.ReceivedTime, targetDateFormat, out exception);
                fileInfoReamed = new FileInfo(string.Format(@"{0}\{1}", new object[] { fileInfo.DirectoryName, FileRenamed }));
                MailItem.Close(Microsoft.Office.Interop.Outlook.OlInspectorClose.olDiscard);

                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                fileInfoReamed = null;
                return false;
            }
        }

        /// <summary>
        /// Get the new filrename, with date from the recived Date of an Thunderbird E-Mail
        /// </summary>
        /// <param name="fileInfo">Original file</param>
        /// <param name="filePureName">Filename without extension</param>
        /// <param name="fileInfoReamed">Renamed file</param>
        /// <param name="targetDateFormat">Format of the target date</param>
        /// <param name="exception">Exception while getting the new Filename</param>
        /// <returns>True if the new Filename was sucessfully created</returns>
        public static bool GetFromEmlFile(FileInfo fileInfo, string filePureName, out FileInfo fileInfoReamed, DateFormatProvider targetDateFormat, out Exception exception)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                exception = ex;
                fileInfoReamed = null;
                return false;
            }
        }

        /// <summary>
        /// Retrieves a substring from this instance.
        /// </summary>
        /// <param name="s">String to create a Substring from</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>A string that is equivalent to the substring of length length that begins at startIndex in this instance, or Empty if startIndex is equal to the length of this instance and length is zero</returns>
        private static string Substring(string s, int startIndex, int length)
        {
            try
            {
                if (startIndex > s.Length) return string.Empty;
                if (startIndex < 0) return string.Empty;
                if (length < 0) return string.Empty;
                if (startIndex + length > s.Length) return string.Empty;
                return s.Substring(startIndex, length);
            }
            catch (Exception ex)
            {
                _ = ex;
                return string.Empty;
            }
        }
    }
}