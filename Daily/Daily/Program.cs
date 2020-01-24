using System.Xml.Linq;
using System;


namespace Daily
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileDirectory = AppSettings.Read("FileDirectory");

            var xDoc = XDocument.Load(fileDirectory);

            if (args[0].Contains("s"))
            {
                var time = DateTime.Now.ToString("g");
                var content = args[1];

                var task = new XElement("Task", new XAttribute("DateTime", time), content);

                xDoc.Element("Root").Element("Tasks").Add(task);

            }

            xDoc.Save(fileDirectory);
        }
    }
}


