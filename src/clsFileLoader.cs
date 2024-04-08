/*
 * ReFiDa - Reformating File names that contains a Date
 * 
 * Copyright:   Oliver Kind - 2023
 * License:     LGPL
 * 
 * Desctiption:
 * Class to provide tools to load files
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OLKI.Programme.ReFiDa.src
{
    /// <summary>
    /// Class to provide tools to load files
    /// </summary>
    internal static class FileLoader
    {
        #region Methodes
        /// <summary>
        /// Load all files of the defined directory and subdirectorys, if requested, to a List
        /// </summary>
        /// <param name="directory">Path of the directory to laod the files from</param>
        /// <param name="subDirectorys">Defines if the subdirectorys should also been loaded</param>
        /// <returns>List with files in the directory and subdirectorys, if requested, to a List</returns>
        public static FileInfo[] GetFilesFromDirectory(string directory, bool subDirectorys)
        {
            if (string.IsNullOrEmpty(directory)) return (new List<FileInfo>()).ToArray();
            return GetFilesFromDirectory(new DirectoryInfo(directory), subDirectorys);
        }
        /// <summary>
        /// Load all files of the defined directory and subdirectorys, if requested, to a List
        /// </summary>
        /// <param name="directoryInfo">Path of the directory to laod the files from</param>
        /// <param name="subDirectorys">Defines if the subdirectorys should also been loaded</param>
        /// <returns>List with files in the directory and subdirectorys, if requested, to a List</returns>
        public static FileInfo[] GetFilesFromDirectory(DirectoryInfo directoryInfo, bool subDirectorys)
        {
            List<FileInfo> FileList = new List<FileInfo>();
            FileList.AddRange(directoryInfo.GetFiles().OrderBy(o => o.Name));
            if (subDirectorys)
            {
                foreach (DirectoryInfo SubDirectoryPath in directoryInfo.GetDirectories().OrderBy(o => o.Name))
                {
                    FileList.AddRange(GetFilesFromDirectory(SubDirectoryPath, subDirectorys));
                }
            }
            return FileList.ToArray();
        }

        /// <summary>
        /// Write the defined Files to the file ListView
        /// </summary>
        /// <param name="files">Files to write to ListView</param>
        /// <param name="listView">ListView to write the files to</param>
        /// <param name="form">Parent form of the ListView</param>
        /// <param name="clearItems">Defines if the existing list should been cleared, before new items will be added</param>
        public static void LoadFilesToListview(string[] files, ListView listView, IWin32Window form, bool clearItems)
        {
            List<FileInfo> FileInfos = new List<FileInfo>();
            foreach (string FileItem in files)
            {
                FileInfos.Add(new FileInfo(FileItem));
            }
            LoadFilesToListview(FileInfos.ToArray(), listView, form, clearItems);
        }
        /// <summary>
        /// Write the defined Files to the file ListView
        /// </summary>
        /// <param name="files">Files to write to ListView</param>
        /// <param name="listView">ListView to write the files to</param>
        /// <param name="form">Parent form of the ListView</param>
        /// <param name="clearItems">Defines if the existing list should been cleared, before new items will be added</param>
        public static void LoadFilesToListview(FileInfo[] files, ListView listView, IWin32Window form, bool clearItems)
        {
            try
            {
                if (files.Length == 0) return;
                ((Form)form).Enabled = false;
                Cursor.Current = Cursors.WaitCursor;

                if (clearItems) listView.Items.Clear();
                listView.BeginUpdate();
                ListViewItem ListViewItem;
                RenameItem RenameItem;

                foreach (FileInfo FileItem in files)
                {
                    if (!clearItems && FileIsInList(listView, FileItem)) continue;

                    RenameItem = new RenameItem(FileItem);
                    ListViewItem = new ListViewItem
                    {
                        Text = RenameItem.FileInfo.Name
                    };
                    ListViewItem.SubItems.Add(string.Empty);
                    ListViewItem.SubItems.Add(RenameItem.FileInfo.DirectoryName);
                    ListViewItem.SubItems.Add(RenameItem.Exception != null ? RenameItem.Exception.Message : string.Empty);
                    ListViewItem.Tag = RenameItem;
                    listView.Items.Add(ListViewItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(form, string.Format(Stringtable._0x0002m, new object[] { ex.Message }), Stringtable._0x0002c, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                listView.EndUpdate();
                Cursor.Current = Cursors.Default;
                ((Form)form).Enabled = true;
            }
        }

        /// <summary>
        /// Check if the defined file ist already in list to rename
        /// </summary>
        /// <param name="listView">ListView to check for exisiting files</param>
        /// <param name="fileToCheck">File to check if it is already in list</param>
        /// <returns>True if the file is already in the list</returns>
        private static bool FileIsInList(ListView listView, FileInfo fileToCheck)
        {
            RenameItem CheckItem;
            foreach (ListViewItem ListViewItem in listView.Items)
            {
                try
                {
                    CheckItem = (RenameItem)ListViewItem.Tag;
                    if (CheckItem.FileInfo.FullName == fileToCheck.FullName) return true;
                }
                catch (Exception ex)
                {
                    _ = ex;
                }
            }
            return false;
        }
        #endregion
    }
}