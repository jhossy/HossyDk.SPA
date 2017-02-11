using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HossyDk.Library.Utils
{
    public static class PathUtilities
    {
        private static List<string> ValidFileExtensions = new List<string>
        {
            ".jpg", ".jpeg", ".png", ".gif" , ".bmp"
        };

        public static string RemoveIllegalPathCharacters(string fileName)
        {
            foreach(char c in System.IO.Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c.ToString(), string.Empty);
            }
            return fileName.Trim();
        }

        public static bool IsLegalFileExtension(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName);

            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(fileExtension))
            {
                return false;
            }

            return ValidFileExtensions.Contains(fileExtension.ToLower());
        }
    }
}
