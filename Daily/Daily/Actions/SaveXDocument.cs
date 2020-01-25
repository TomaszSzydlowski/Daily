using Daily.Model;
using System;
using System.Xml.Linq;

namespace Daily
{

    public sealed class SaveXDocument
    {
        private static SaveXDocument instance = new SaveXDocument();

        private string FilePath => AppSettings.GetInstance().Read("FileDirectory");


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
