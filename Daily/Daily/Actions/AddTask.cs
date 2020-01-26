using Daily.Actions;
using Daily.Model;
using System;
using System.Xml.Linq;

namespace Daily
{

    public sealed class AddTask:IActionBase
    {
        private static AddTask instance = new AddTask();

        public XDocument XDoc { get; set; }

        private AddTask()
        {

        }

        public static AddTask GetInstance()
        {
            return instance;
        }

        public void Exec(XDocument xDoc, string arg)
        {
            var task = new XTaskRepo
            {
                Content = arg
            };

            xDoc.Element("tasks").Add(task.GetXElement());

            XDoc = xDoc;
        }

        //TODO:Do wezla tasks dodac dzien dd/mm/yyyy i zawsze dodawac ten wezel jesli jeszcze nie istnieje

    }
}
