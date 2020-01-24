/*
 * ReFiDa - Reformating File names that contains a Date
 * 
 * Copyright:   Oliver Kind - 2020
 * License:     LGPL
 * 
 * Desctiption:
 * Class to check if file is a file to convert
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

using System.IO;
using System.Text.RegularExpressions;

namespace OLKI.Programme.ReFiDa
{
    /// <summary>
    /// Class to check if file is a file to convert
    /// </summary>
    public static class FileCheck
    {
        /// <summary>
        /// Check file if it is an file to reformat the filename. If requestet only if the filename isn't already formated.
        /// </summary>
        /// <param name="file">File to check to reformat the filename</param>
        /// <param name="avoidDoubleFormat">If true check if filename is already formated. If yes, then return false.</param>
        /// <param name="start8">File can start with 8 digits</param>
        /// <param name="start12">File can start with 12 digits</param>
        /// <param name="end8">File can end with 8 digits</param>
        /// <param name="end12">File can start with 12 digits</param>
        /// <returns>Return true if the file is a valid file to reformat the filename</returns>
        public static bool IsFileToConvert(FileInfo file, bool avoidDoubleFormat, bool start8, bool start12, bool end8, bool end12)
        {
            string FileName = FileHandling.GetPureFileName(file);

            if (avoidDoubleFormat && FileIsReformated(FileName)) return false;

            // Check the beginning of a filename
            if (start8 || start12)
            {
                if (start8 && FilterStartWithDigits(FileName, 8)) return true;
                if (start12 && FilterStartWithDigits(FileName, 12)) return true;
            }

            // Check the end of a filename
            if (end8 || end12)
            {
                if (end8 && FilterEndWithDigits(FileName, 8)) return true;
                if (end12 && FilterEndWithDigits(FileName, 12)) return true;
            }

            return false;
        }

        /// <summary>
        /// Check if the filename is already refomated
        /// </summary>
        /// <param name="fileName">Filename to check if it is already formated</param>
        /// <returns>True if the filename is already formated</returns>
        public static bool FileIsReformated(string fileName)
        {
            // Check for long format
            string StartPatternLong = @"^\d{4}(-\d{2}){2}__\d{2}-\d{2}";
            string EndPatternLong = @"\d{4}(-\d{2}){2}__\d{2}-\d{2}$";
            if (Regex.Match(fileName, StartPatternLong).Success || Regex.Match(fileName, EndPatternLong).Success)
            {
                return true;
            }

            // Check for short format
            string StartPatternShort = @"^\d{4}(-\d{2}){2}";
            string EndPatternShort = @"\d{4}(-\d{2}){2}$";
            if (Regex.Match(fileName, StartPatternShort).Success || Regex.Match(fileName, EndPatternShort).Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if the filanme start with digits
        /// </summary>
        /// <param name="fileName">Filename to check</param>
        /// <param name="length">Number of the requested digits</param>
        /// <returns>True if the filename start with digits</returns>
        public static bool FilterEndWithDigits(string fileName, int length)
        {
            string Pattern = "[0-9]{" + length.ToString() + "}$";
            return Regex.Match(fileName, Pattern).Success;
        }

        /// <summary>
        /// Check if the filanme ends with digits
        /// </summary>
        /// <param name="fileName">Filename to check</param>
        /// <param name="length">Number of the requested digits</param>
        /// <returns>True if the filename ends with digits</returns>
        public static bool FilterStartWithDigits(string fileName, int length)
        {
            string Pattern = "^[0-9]{" + length.ToString() + "}";
            return Regex.Match(fileName, Pattern).Success;
        }
    }
}