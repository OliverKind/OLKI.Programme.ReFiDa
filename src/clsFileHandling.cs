using OLKI.Tools.CommonTools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLKI.Programme.ReFiDa
{
    class FileHandling
    {
        public List<FileInfo> GetFilesToConvert(DirectoryInfo searchDirectroy, bool searchSubDirectroys, bool avoidDoubleConvert, bool start8, bool start12, bool end8, bool end12)
        {
            List<FileInfo> FileList = new List<FileInfo> { };

            foreach (FileInfo File in searchDirectroy.GetFiles())
            {
                if (FileCheck.IsFileToConvert(File, avoidDoubleConvert, start8, start12, end8, end12)) FileList.Add(File);
            }

            // Search in sub directories
            if (searchSubDirectroys)
            {
                foreach (DirectoryInfo Directory in searchDirectroy.GetDirectories())
                {
                    FileList.AddRange(this.GetFilesToConvert(Directory, searchSubDirectroys, avoidDoubleConvert, start8, start12, end8, end12));
                }
            }

            return FileList;
        }

        public static string GetFileNameWithoudExtension(FileInfo file)
        {
            return file.Name.Substring(0, file.Name.Length - file.Extension.Length);
        }

        public void ConvertSrartWith(FileInfo file, string fileName, int length, string format, bool simulate, ListViewItem listViewItem)
        {
            try
            {
                string NewDate = string.Empty;
                Nullable<DateTime> NewDateTime = null;

                if (length == 12)
                {
                    NewDateTime = Converter.NumDateTimeToDateTime(fileName.Substring(0, length) + "00");
                    if (NewDateTime != null)
                    {
                        NewDate = ((DateTime)NewDateTime).ToString(format);
                    }
                }
                if (length == 8)
                {
                    NewDateTime = Converter.NumDateTimeToDateTime(fileName.Substring(0, length) + "000000");
                    if (NewDateTime != null)
                    {
                        NewDate = ((DateTime)NewDateTime).ToString(format);
                    }
                }

                if (NewDateTime != null && !string.IsNullOrEmpty(NewDate))
                {
                    string NewFileName = NewDate + "" + fileName.Substring(length) + file.Extension;
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

        public void ConvertEndWith(FileInfo file, string fileName, int length, string format, bool simulate, ListViewItem listViewItem)
        {
            try
            {
                string NewDate = string.Empty;
                Nullable<DateTime> NewDateTime = null;

                if (length == 12)
                {
                    NewDateTime = OLKI.Tools.CommonTools.Converter.NumDateTimeToDateTime(fileName.Substring(fileName.Length - length, length) + "00");
                    if (NewDateTime != null)
                    {
                        NewDate = ((DateTime)NewDateTime).ToString(format);
                    }
                }
                if (length == 8)
                {
                    NewDateTime = OLKI.Tools.CommonTools.Converter.NumDateTimeToDateTime(fileName.Substring(fileName.Length - length, length) + "000000");
                    if (NewDateTime != null)
                    {
                        NewDate = ((DateTime)NewDateTime).ToString(format);
                    }
                }

                if (NewDateTime != null && !string.IsNullOrEmpty(NewDate))
                {
                    string NewFileName = fileName.Substring(0, fileName.Length - length) + NewDate + file.Extension;
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



        //public bool IsFileToConvert(FileInfo file, bool avoidDoubleConvert, bool start8, bool start12, bool end8, bool end12)
        //{
        //    return true;
        //}
        //private bool FileInFilter(string fileName, bool FilterIfconverted, bool start8, bool start12, bool end8, bool end12)
        //{
        //    if (FilterIfconverted && this.FileIsReformated(fileName)) return false;

        //    // Check the beginning of a file name
        //    if (start8 || start12)
        //    {
        //        if (start8 && this.FilterStartWith(fileName, 8)) return true;
        //        if (start12 && this.FilterStartWith(fileName, 12)) return true;
        //    }

        //    // Check the end of a file name
        //    if (end8 ||end12)
        //    {
        //        if (end8&& this.FilterEndWith(fileName, 8)) return true;
        //        if (end12&& this.FilterEndWith(fileName, 12)) return true;
        //    }

        //    return false;
        //}


        //private bool FileIsReformated(string fileName)
        //{
        //    // Check file has format
        //    string StartPatternLong = @"^\d{4}(-\d{2}){2}__\d{2}-\d{2}";
        //    string EndPatternLong = @"\d{4}(-\d{2}){2}__\d{2}-\d{2}$";
        //    if (Regex.Match(fileName, StartPatternLong).Success || Regex.Match(fileName, EndPatternLong).Success)
        //    {
        //        return true;
        //    }

        //    string StartPatternShort = @"^\d{4}(-\d{2}){2}";
        //    string EndPatternShort = @"\d{4}(-\d{2}){2}$";
        //    if (Regex.Match(fileName, StartPatternShort).Success || Regex.Match(fileName, EndPatternShort).Success)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //private bool FilterEndWith(string fileName, int length)
        //{
        //    string Pattern = "[0-9]{" + length.ToString() + "}$";
        //    return Regex.Match(fileName, Pattern).Success;
        //}

        //private bool FilterStartWith(string fileName, int length)
        //{
        //    string Pattern = "^[0-9]{" + length.ToString() + "}";
        //    return Regex.Match(fileName, Pattern).Success;
        //}
    }
}