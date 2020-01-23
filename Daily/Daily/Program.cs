using System.Xml.Linq;
using System;
using System.Configuration;


namespace Daily
{
    class Program
    {
        static void Main(string[] args)
        {

            XDocument xDoc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Root",
                    new XElement("Task",
                    new XAttribute("Data", "data"), "tresc zdania")
                    )
                    );

            static string ReadSetting(string key)
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

            var fileDirectory = ReadSetting("FileDirectory");


            xDoc.Save(fileDirectory);
        }
    }
}


