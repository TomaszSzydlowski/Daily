using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Daily.Actions
{
    public class FindTask:IActionBase
    {
        private static FindTask instance = new FindTask();

        public List<string> Result { get; private set; }

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
                from el in xDoc.Descendants("task")
                where (string)el.Attribute("time") == time
                select el;

           Result= result.Select(n => n.Value).ToList();
        }
    }
}
