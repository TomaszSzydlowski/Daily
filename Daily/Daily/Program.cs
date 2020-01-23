using System.Xml.Linq;

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


            xDoc.Save(@"C:\Home\Repo\01_Repository\31_Daily\Daily\Daily\Daily\XMLDoc.xml");
        }
    }


}
