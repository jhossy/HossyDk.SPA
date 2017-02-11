using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HossyDk.Library.Utils
{
    public static class ConfigurationUtils
    {
        public static string GetAppSetting(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return string.Empty;
            }

            return ConfigurationManager.AppSettings[key];
        }
    }
}
