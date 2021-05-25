using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAPS.SJK.Logic
{
    public class ConfigReader
    {
        public static string filePath { get { return Get("filePath"); } }
        public static string DOMAIN { get { return Get("Domain"); } }
        public static bool Debug { get { return Get("Debug").ToLower() == true.ToString().ToLower(); } }
        public static string SendGrid_API_Key { get { return Get("SendGrid_API_Key"); } }
        private static string Get(string key)
        {
            string result = "";
            try
            {
                result = System.Configuration.ConfigurationManager.AppSettings[key];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
