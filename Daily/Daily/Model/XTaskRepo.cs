
using System.Xml.Linq;

namespace Daily.Model
{
    public class XTaskRepo
    {
        private const string Task = "task";
        private const string Time = "time";

        public string DateTime => System.DateTime.Now.ToString("g");

        public string Content { get; set; }

        public XElement GetXElement()
        {
            return new XElement(Task, new XAttribute(Time, DateTime), Content);
        }

    }
}
