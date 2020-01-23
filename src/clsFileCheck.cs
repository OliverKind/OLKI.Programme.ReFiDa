using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OLKI.Programme.ReFiDa
{
    public static class FileCheck
    {

        public static bool IsFileToConvert(FileInfo file, bool avoidDoubleConvert, bool start8, bool start12, bool end8, bool end12)
        {
            string FileName =   FileHandling.GetFileNameWithoudExtension(file);

            if (avoidDoubleConvert && FileIsReformated(FileName)) return false;

            return FileInFilter(FileName, start8, start12, end8, end12);
        }

        public static bool FileInFilter(string fileName,  bool start8, bool start12, bool end8, bool end12)
        {
            // Check the beginning of a file name
            if (start8 || start12)
            {
                if (start8 && FilterStartWith(fileName, 8)) return true;
                if (start12 && FilterStartWith(fileName, 12)) return true;
            }

            // Check the end of a file name
            if (end8 || end12)
            {
                if (end8 && FilterEndWith(fileName, 8)) return true;
                if (end12 && FilterEndWith(fileName, 12)) return true;
            }

            return false;
        }

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

        public static bool FilterEndWith(string fileName, int length)
        {
            string Pattern = "[0-9]{" + length.ToString() + "}$";
            return Regex.Match(fileName, Pattern).Success;
        }

        public static bool FilterStartWith(string fileName, int length)
        {
            string Pattern = "^[0-9]{" + length.ToString() + "}";
            return Regex.Match(fileName, Pattern).Success;
        }
    }
}
