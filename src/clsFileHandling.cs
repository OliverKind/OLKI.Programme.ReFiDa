/*
 * ReFiDa - Reformating File names that contains a Date
 * 
 * Copyright:   Oliver Kind - 2020
 * License:     LGPL
 * 
 * Desctiption:
 * Class to handle files: tools, search and rename
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

using OLKI.Tools.CommonTools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OLKI.Programme.ReFiDa
{
    /// <summary>
    /// Class to handle files: tools, search and rename
    /// </summary>
    class FileHandling
    {
        /// <summary>
        /// Seach for file they are valid to reformat the filanem
        /// </summary>
        /// <param name="searchDirectroy">Directory to search for files</param>
        /// <param name="searchSubDirectroys">Search sub directroys</param>
        /// <param name="avoidDoubleFormat">Check if file is already formated</param>
        /// <param name="start8">Search file files starting with 8 digits</param>
        /// <param name="start12">Search file files starting with 12 digits</param>
        /// <param name="end8">Search file files ending with 8 digits</param>
        /// <param name="end12">Search file files ending with 12 digits</param>
        /// <returns>List with files to reformat</returns>
        public List<FileInfo> GetFilesToReformat(DirectoryInfo searchDirectroy, bool searchSubDirectroys, bool avoidDoubleFormat, bool start8, bool start12, bool end8, bool end12)
        {
            List<FileInfo> FileList = new List<FileInfo> { };

            foreach (FileInfo File in searchDirectroy.GetFiles())
            {
                if (FileCheck.IsFileToConvert(File, avoidDoubleFormat, start8, start12, end8, end12)) FileList.Add(File);
            }

            // Search in sub directories
            if (searchSubDirectroys)
            {
                foreach (DirectoryInfo Directory in searchDirectroy.GetDirectories())
                {
                    FileList.AddRange(this.GetFilesToReformat(Directory, searchSubDirectroys, avoidDoubleFormat, start8, start12, end8, end12));
                }
            }

            return FileList;
        }

        /// <summary>
        /// Get the filename of the file withoud path and extension
        /// </summary>
        /// <param name="file">File to geht the pure file name</param>
        /// <returns>The filename of the file withoud path and extension</returns>
        public static string GetPureFileName(FileInfo file)
        {
            return file.Name.Substring(0, file.Name.Length - file.Extension.Length);
        }

        /// <summary>
        /// Reformat filenames starting with numbers
        /// </summary>
        /// <param name="file">File to reformat the filename</param>
        /// <param name="pureFileName">pure filename withoud path and extension</param>
        /// <param name="length">Length of the numbers to reformat</param>
        /// <param name="format">New format</param>
        /// <param name="simulate">Simulate renaiming</param>
        /// <param name="listViewItem">Listview item of the file in main form</param>
        public void ReformatFileNameStartWithNumber(FileInfo file, string pureFileName, int length, string format, bool simulate, ListViewItem listViewItem)
        {
            try
            {
                string NewDate = string.Empty;
                Nullable<DateTime> NewDateTime = null;

                if (length == 12)
                {
                    NewDateTime = Converter.NumDateTimeToDateTime(pureFileName.Substring(0, length) + "00");
                    if (NewDateTime != null)
                    {
                        NewDate = ((DateTime)NewDateTime).ToString(format);
                    }
                }
                if (length == 8)
                {
                    NewDateTime = Converter.NumDateTimeToDateTime(pureFileName.Substring(0, length) + "000000");
                    if (NewDateTime != null)
                    {
                        NewDate = ((DateTime)NewDateTime).ToString(format);
                    }
                }

                if (NewDateTime != null && !string.IsNullOrEmpty(NewDate))
                {
                    string NewFileName = NewDate + "" + pureFileName.Substring(length) + file.Extension;
                    listViewItem.SubItems[1].Text = NewFileName;
                    listViewItem.BackColor = Color.LightGreen;

                    //Rename
                    string newPath = file.DirectoryName + @"\" + NewFileName;
                    if (!simulate) file.MoveTo(newPath);
                }
            }
            catch (Exception ex)
            {
                listViewItem.SubItems[3].Text = ex.Message;
                listViewItem.BackColor = Color.LightCoral;
            }
        }

        /// <summary>
        /// Reformat filenames ending with numbers
        /// </summary>
        /// <param name="file">File to reformat the filename</param>
        /// <param name="pureFileName">pure filename withoud path and extension</param>
        /// <param name="length">Length of the numbers to reformat</param>
        /// <param name="format">New format</param>
        /// <param name="simulate">Simulate renaiming</param>
        /// <param name="listViewItem">Listview item of the file in main form</param>
        public void ReformatFileNameEndWithNumber(FileInfo file, string pureFileName, int length, string format, bool simulate, ListViewItem listViewItem)
        {
            try
            {
                string NewDate = string.Empty;
                Nullable<DateTime> NewDateTime = null;

                if (length == 12)
                {
                    NewDateTime = OLKI.Tools.CommonTools.Converter.NumDateTimeToDateTime(pureFileName.Substring(pureFileName.Length - length, length) + "00");
                    if (NewDateTime != null)
                    {
                        NewDate = ((DateTime)NewDateTime).ToString(format);
                    }
                }
                if (length == 8)
                {
                    NewDateTime = OLKI.Tools.CommonTools.Converter.NumDateTimeToDateTime(pureFileName.Substring(pureFileName.Length - length, length) + "000000");
                    if (NewDateTime != null)
                    {
                        NewDate = ((DateTime)NewDateTime).ToString(format);
                    }
                }

                if (NewDateTime != null && !string.IsNullOrEmpty(NewDate))
                {
                    string NewFileName = pureFileName.Substring(0, pureFileName.Length - length) + NewDate + file.Extension;
                    listViewItem.SubItems[1].Text = NewFileName;
                    listViewItem.BackColor = Color.LightGreen;
                    //Rename
                    string np = file.DirectoryName + @"\" + NewFileName;
                    if (!simulate) file.MoveTo(np);
                }
            }
            catch (Exception ex)
            {
                listViewItem.SubItems[3].Text = ex.Message;
                listViewItem.BackColor = Color.LightCoral;
            }
        }
    }
}