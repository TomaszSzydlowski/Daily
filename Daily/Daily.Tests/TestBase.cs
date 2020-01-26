using System.IO;
using System.Xml.Linq;

namespace Daily.Tests
{
    public class TestBase
    {
        private const string xmlString = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?><tasks><task time =\"25/01/2020 13:05\">content</task></tasks>";

        protected XDocument _xDoc
        {
            get
            {
                var tr = new StringReader(xmlString);
                return XDocument.Load(tr);
            }
        }

        protected const string Task = "task";
        protected const string Time = "time";
    }
}