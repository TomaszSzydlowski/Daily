using Daily.Helpers;
using Daily.Model;
using System;
using System.Xml.Linq;

namespace Daily
{

    public sealed class SaveXDocument : DailyFileProperty
    {
        private static SaveXDocument instance = new SaveXDocument();


        private SaveXDocument()
        {

        }

        public static SaveXDocument GetInstance()
        {
            return instance;
        }

        public void Save(XDocument xDoc)
        {
            xDoc.Save(FilePath);
        }
    }
}
