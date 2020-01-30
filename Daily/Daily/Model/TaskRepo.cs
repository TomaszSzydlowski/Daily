
using System.Xml.Linq;

namespace Daily.Model
{
    public class TaskRepo
    {
        private const string Task = "task";
        private const string Time = "time";

        public string CurrentDateTime { get => System.DateTime.Now.ToString("g"); }

        public string Content { get; set; }
        public string DataTime { get; set; }

        public XElement GetXElement()
        {
            return new XElement(Task, new XAttribute(Time, CurrentDateTime), Content);
        }

    }
}
