using Daily.Model;
using System;
using System.Xml.Linq;

namespace Daily
{

    public sealed class AddTask : BaseAction
    {
        private static AddTask instance = new AddTask();

        private AddTask()
        {

        }

        public static AddTask GetInstance()
        {
            return instance;
        }

        public override void Exec(string arg)
        {
            var xDoc = XDocument.Load(FilePath);

            var task = new XTaskRepo
            {
                Content = arg 
            };

            xDoc.Element("tasks").Add(task.GetXElement());
            xDoc.Save(FilePath);
        }

        //TODO:Do wezla tasks dodac dzien dd/mm/yyyy i zawsze dodawac ten wezel jesli jeszcze nie istnieje

    }
}
