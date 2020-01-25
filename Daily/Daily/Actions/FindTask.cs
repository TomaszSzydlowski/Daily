using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Daily.Actions
{
    public class FindTask
    {
        private static FindTask instance = new FindTask();

        private FindTask()
        {

        }

        public static FindTask GetInstance()
        {
            return instance;
        }

        public List<string> Find(XDocument xDoc, string time)
        {
            IEnumerable<XElement> result =
                from el in xDoc.Descendants("task")
                where (string)el.Attribute("time") == time
                select el;

            return result.Select(n => n.Value).ToList();

        }


    }
}
