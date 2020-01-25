using Daily.Model;
using System;
using System.Xml.Linq;

namespace Daily
{

    public sealed class AddTask
    {
        private static AddTask instance = new AddTask();

        private AddTask()
        {

        }

        public static AddTask GetInstance()
        {
            return instance;
        }

        public XDocument Add(XDocument xDoc, string arg)
        {
            var task = new XTaskRepo
            {
                Content = arg
            };

            xDoc.Element("tasks").Add(task.GetXElement());

            return xDoc;
        }

        //TODO:Do wezla tasks dodac dzien dd/mm/yyyy i zawsze dodawac ten wezel jesli jeszcze nie istnieje

    }
}
