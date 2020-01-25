using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Daily.Actions
{
    public class FindTask : BaseAction
    {
        private static FindTask instance = new FindTask();

        private FindTask()
        {

        }

        public static FindTask GetInstance()
        {
            return instance;
        }

        public override void Exec(string arg)
        {
            var xDoc = XDocument.Load(FilePath);

            string[] searchCriteria = new string[] { "25/01/2020 13:06", "25/01/2020 13:09", "25/01/2020 13:08", "25/01/2020 13:19" , "25/01/2020 19:38" , "38"};

            foreach (var item in searchCriteria)
            {
                DateTime startTime = DateTime.Now;

                XElement root = XElement.Load(FilePath);
                IEnumerable<XElement> tests =
                    from el in root.Elements("task")
                    where (string)el.Attribute("time") == item
                    select el;
                foreach (XElement el in tests)
                    Console.WriteLine(el.Value);



                DateTime stopTime = DateTime.Now;
                TimeSpan roznica = stopTime - startTime;
                Console.WriteLine("Czas pracy:" + roznica.TotalMilliseconds);
            }
            
            Console.ReadLine();

        }
    }
}
