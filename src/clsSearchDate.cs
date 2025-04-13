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
using static OLKI.Programme.ReFiDa.src.DateFormatProvider;
using Outlook = Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace OLKI.Programme.ReFiDa.src
{
    internal static class SearchDate
    {
        #region Constants
        /// <summary>
        /// Identify Date Line in EML-File
        /// </summary>
        private const string EML_DATE_PATTERN = "Date: ";
        /// <summary>
        /// Identify Line Break in EML-File
        /// </summary>
        private const string EML_LINE_BREAK = "\r\n";
        /// <summary>
        /// Posible date formats to finde a Date sinside a EML-File
        /// </summary>
        private static readonly List<string> EML_TIME_FORMAT = new List<string> { "ddd, d MMM yyyy HH:mm:ss zzz", "ddd, dd MMM yyyy HH:mm:ss zzz", "dd MMM yyyy HH:mm:ss zzz", "d MMM yyyy HH:mm:ss zzz" };
        /// <summary>
        /// Exif-Tag for Creation Date of an Image (PropertyTagExifDTOrig)
        /// </summary>
        private const int EXIF_DTORIG_TAG_ID = 0x9003;
        #endregion

        #region Enums
        /// <summary>
        /// Enum to set where Outlook Elemnts should been added to a date
        /// </summary>
        public enum OutlookAdd
        {
            NoAdd = 0,
            SenderUserBefore = 10,
            SenderUserAfter = 11,
            SenderAddressBefore = 20,
            SenderAdressAfter = 21,
            SenderHostBefore = 30,
            SenderHostAfter = 31
        }
        #endregion

        #region Fields
        /// <summary>
        /// Regex to replace ":" in the date string
        /// </summary>
        private static readonly Regex RegReplacer = new Regex(":");
        #endregion

        #region Methodes
        /// <summary>
        /// Build a new filename, depending of the format
        /// </summary>
        /// <param name="fileInfo">FileInfo of the original File</param>
        /// <param name="filePureName">Filename without extension</param>
        /// <param name="targetDate">Target date of the file</param>
        /// <param name="targetDateFormat">Format of the target Date and Filename</param>
        /// <param name="exception">Exception while create the Filename</param>
        /// <returns>FileInfo for new File with target name</returns>
        public static FileInfo CreateNewFileInfo(FileInfo fileInfo, string filePureName, DateTime targetDate, DateFormatProvider targetDateFormat, out Exception exception)
        {
            return CreateNewFileInfo(fileInfo, filePureName, targetDate, targetDateFormat, "", "", out exception);
        }
        /// <summary>
        /// Build a new filename, depending of the format
        /// </summary>
        /// <param name="fileInfo">FileInfo of the original File</param>
        /// <param name="filePureName">Filename without extension</param>
        /// <param name="targetDate">Target date of the file</param>
        /// <param name="targetDateFormat">Format of the target Date and Filename</param>
        /// <param name="textAfterDate">Text to add before the Date</param>
        /// <param name="textBeforeDate">Text to add after the Date</param>
        /// <param name="exception">Exception while create the Filename</param>
        /// <returns>FileInfo for new File with target name</returns>
        public static FileInfo CreateNewFileInfo(FileInfo fileInfo, string filePureName, DateTime targetDate, DateFormatProvider targetDateFormat, string textAfterDate, string textBeforeDate, out Exception exception)
        {
            exception = null;
            string NewPath;
            string TargetDate = targetDate.ToString(targetDateFormat.Preview.Format);
            try
            {
                switch (targetDateFormat.Format.Position)
                {
                    case DatePositionIndicator.AfterFilename:
                        if (!string.IsNullOrEmpty(textAfterDate)) textAfterDate = string.Format("{1}{0}", new object[] { textAfterDate, targetDateFormat.Format.Seperator });
                        if (!string.IsNullOrEmpty(textBeforeDate)) textBeforeDate = string.Format("{1}{0}", new object[] { textBeforeDate, targetDateFormat.Format.Seperator });
                        NewPath = string.Format(@"{0}\{2}{5}{1}{4}{3}", new object[] { fileInfo.DirectoryName, TargetDate, filePureName, fileInfo.Extension, textAfterDate, textBeforeDate });
                        break;
                    case DatePositionIndicator.BeforeFilename:
                        if (!string.IsNullOrEmpty(textAfterDate)) textAfterDate = string.Format("{0}{1}", new object[] { textAfterDate, targetDateFormat.Format.Seperator });
                        if (!string.IsNullOrEmpty(textBeforeDate)) textBeforeDate = string.Format("{0}{1}", new object[] { textBeforeDate, targetDateFormat.Format.Seperator });
                        NewPath = string.Format(@"{0}\{5}{1}{4}{2}{3}", new object[] { fileInfo.DirectoryName, TargetDate, filePureName, fileInfo.Extension, textAfterDate, textBeforeDate });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(targetDateFormat.Format.Position));
                }

                //Shorten filenames if required
                if (Properties.Settings.Default.ShortenFilenames)
                {
                    NewPath = Toolbox.DirectoryAndFile.File.ShortenFilenameToMaxPathLength(NewPath, Properties.Settings.Default.ShortenFilenames_Limit, out exception);
                }

                return new FileInfo(NewPath);
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
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
                fileInfoReamed = CreateNewFileInfo(fileInfo, filePureName, fileInfo.LastWriteTime, targetDateFormat, out exception);
                return fileInfoReamed != null;
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
                fileInfoReamed = CreateNewFileInfo(fileInfo, filePureName, fileInfo.CreationTime, targetDateFormat, out exception);
                return fileInfoReamed != null;
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
            string DateCandidat;
            string FileOnlyName;
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
                                fileInfoReamed = CreateNewFileInfo(fileInfo, filePureNameNoDate, FoundDateValue, targetDateFormat, out exception);
                                return fileInfoReamed != null;
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
                string TextAfter = ""; ;
                string TextBefore = ""; ;

                exception = null;
                fileInfoReamed = null;
                if (!fileInfo.Extension.ToLower().Contains(".msg")) return false;

                //Create temporary directory an file
                DirectoryInfo TempDirInfo = Directory.CreateDirectory(Path.GetTempPath() + Settings_AppConst.Default.TempDirectoryName);
                FileInfo TempFileInfo = new FileInfo(Path.GetTempFileName());
                TempFileInfo.MoveTo(TempDirInfo.FullName + TempFileInfo.Name + ".msg");
                fileInfo.CopyTo(TempFileInfo.FullName, true);

                //Open in Outlook
                Outlook.Application OutlookApp = new Outlook.Application();
                Outlook.MailItem MailItem = OutlookApp.Session.OpenSharedItem(TempFileInfo.FullName) as Outlook.MailItem;

                //TODO: Replace Special Fields
                if (MailItem.SenderEmailType.Equals("SMTP", StringComparison.InvariantCultureIgnoreCase))
                {
                    GetFromMsgFileTextAfterBefore(MailItem, out TextAfter, out TextBefore);
                }

                //Rename file
                fileInfoReamed = CreateNewFileInfo(fileInfo, filePureName, MailItem.ReceivedTime, targetDateFormat, TextAfter, TextBefore, out exception);
                MailItem.Close(Outlook.OlInspectorClose.olDiscard);

                return fileInfoReamed != null;
            }
            catch (Exception ex)
            {
                exception = ex;
                fileInfoReamed = null;
                return false;
            }
        }

        /// <summary>
        /// Get sender data from E-Mail element
        /// </summary>
        /// <param name="mail">E-Mail item</param>
        /// <param name="textAfter">Add text after date</param>
        /// <param name="textBefore">Add text before date</param>
        public static void GetFromMsgFileTextAfterBefore(Outlook.MailItem mail, out string textAfter, out string textBefore)
        {
            System.Net.Mail.MailAddress MailFrom = new System.Net.Mail.MailAddress(mail.SenderEmailAddress, mail.SenderName);
            GetFromMsgFileTextAfterBefore(MailFrom, out textAfter, out textBefore);
        }
        /// <summary>
        /// Get sender data from E-Mail element
        /// </summary>
        /// <param name="mailFrom">E-Mail from das MailAdress Object</param>
        /// <param name="textAfter">Add text after date</param>
        /// <param name="textBefore">Add text before date</param>
        public static void GetFromMsgFileTextAfterBefore(System.Net.Mail.MailAddress mailFrom, out string textAfter, out string textBefore)
        {
            try
            {
                textAfter = "";
                textBefore = "";

                switch ((OutlookAdd)Properties.Settings.Default.OutlookAdd)
                {
                    case OutlookAdd.NoAdd:
                        return;
                    case OutlookAdd.SenderUserBefore:
                        textBefore = mailFrom.User;
                        return;
                    case OutlookAdd.SenderUserAfter:
                        textAfter = mailFrom.User;
                        return;
                    case OutlookAdd.SenderAddressBefore:
                        textBefore = mailFrom.Address;
                        return;
                    case OutlookAdd.SenderAdressAfter:
                        textAfter = mailFrom.Address;
                        return;
                    case OutlookAdd.SenderHostBefore:
                        textBefore = mailFrom.Host;
                        return;
                    case OutlookAdd.SenderHostAfter:
                        textAfter = mailFrom.Host;
                        return;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }
            catch (Exception ex)
            {
                _ = ex;
                textAfter = "";
                textBefore = "";
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
                exception = null;
                fileInfoReamed = null;
                string MailFile = File.ReadAllText(fileInfo.FullName, System.Text.Encoding.UTF8);
                int DateStart = MailFile.IndexOf(EML_DATE_PATTERN, StringComparison.InvariantCultureIgnoreCase);
                int EndDate = MailFile.IndexOf(EML_LINE_BREAK, DateStart, StringComparison.InvariantCultureIgnoreCase);
                string DateFound = MailFile.Substring(DateStart + EML_DATE_PATTERN.Length, EndDate - DateStart - EML_DATE_PATTERN.Length);
                DateTime RecivedDate;

                if (DateTime.TryParseExact(DateFound, EML_TIME_FORMAT.ToArray(), CultureInfo.InvariantCulture, DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite, out RecivedDate))
                {
                    fileInfoReamed = CreateNewFileInfo(fileInfo, filePureName, RecivedDate, targetDateFormat, out exception);
                    return fileInfoReamed != null;
                }
                return false;
            }
            catch (Exception ex)
            {
                exception = ex;
                fileInfoReamed = null;
                return false;
            }
        }

        /// <summary>
        /// Get the new filrename, with date from the EXIF-Creationdate  of an image file
        /// </summary>
        /// <param name="fileInfo">Original file</param>
        /// <param name="filePureName">Filename without extension</param>
        /// <param name="fileInfoReamed">Renamed file</param>
        /// <param name="targetDateFormat">Format of the target date</param>
        /// <param name="exception">Exception while getting the new Filename</param>
        /// <returns>True if the new Filename was sucessfully created</returns>
        public static bool GetFromExifCreationDate(FileInfo fileInfo, string filePureName, out FileInfo fileInfoReamed, DateFormatProvider targetDateFormat, out Exception exception)
        {
            try
            {
                DateTime ExifDate;
                FileStream fs = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read);
                using (Image myImage = Image.FromStream(fs, false, false))
                {
                    PropertyItem propItem = myImage.GetPropertyItem(EXIF_DTORIG_TAG_ID);
                    ExifDate = DateTime.Parse(RegReplacer.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2));

                }
                _ = ExifDate;

                fileInfoReamed = CreateNewFileInfo(fileInfo, filePureName, ExifDate, targetDateFormat, out exception);
                return fileInfoReamed != null;
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
        #endregion
    }
}