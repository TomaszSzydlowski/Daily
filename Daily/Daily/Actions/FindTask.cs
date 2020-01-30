using Daily.Model;
using Daily.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Daily.Actions
{
    public sealed class FindTask : IActionBase
    {
        private const string Task = "task";
        private const string Time = "time";
        private static FindTask instance = new FindTask();

        public List<TaskRepo> Result { get; private set; }
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

            Result = result.Select(n => new TaskRepo { Content = n.Value, DataTime = n.Attribute(Time).ToString() }).ToList();
        }
    }
}
