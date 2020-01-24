using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Xml.Linq;

namespace Daily
{
    public sealed class AppSettings
    {
        private static AppSettings instance = new AppSettings();


        public static AppSettings GetInstance()
        {
            return instance;
        }
        private AppSettings() { }

        public static string Read(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings[key];
            }
            catch (ConfigurationErrorsException)
            {
                throw new Exception();
            }
        }
    };

}
