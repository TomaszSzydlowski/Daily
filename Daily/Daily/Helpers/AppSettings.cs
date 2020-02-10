using System;
using System.Configuration;

namespace Daily.Helpers
{
    public sealed class AppSettings
    {
        private static AppSettings instance = new AppSettings();


        public static AppSettings GetInstance()
        {
            return instance;
        }
        private AppSettings() { }

        public string Read(string key)
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
