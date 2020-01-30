using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Daily.Actions
{
    public class FindTask : IActionBase
    {
        private const string Task = "task";
        private const string Time = "time";
        private static FindTask instance = new FindTask();

        public List<string> Result { get; private set; }
        public XDocument XDoc { get; set; }

        private FindTask()
        {

        }

        public static FindTask GetInstance()
        {
            return instance;
        }

        public void Exec(XDocument xDoc, string time)
        {
            IEnumerable<XElement> result =
                from el in xDoc.Descendants(Task)
                from attr in el.Attributes()
                where attr.Name.ToString().Equals(Time)
                where attr.Value.ToString().Contains(time)
                select el;

            Result = result.Select(n => n.Value).ToList();
        }
    }
}
