using Daily.Actions;
using Daily.Controller;
using Daily.Helpers;
using System;
using System.Xml.Linq;

namespace Daily
{
    public class Startup
    {
        private static Startup instance = new Startup();
        private XDocument XDoc { get => GetXDocument.GetInstance().Get(); }

        private Startup()
        {

        }

        public static Startup GetInstance()
        {
            return instance;
        }

        public void Go(string[] args)
        {
            var validArg = new ValidArg(args);

            Action(validArg);
            View(validArg);

        }

        private void View(IValidArg validArg)
        {
            var view = ViewController.GetInstance().CreateView(validArg.Action);
            view.Show();
        }

        private void Action(IValidArg validArg)
        {
            var action = ActionController.GetInstance().CreateAction(validArg.Action);

            action.Exec(XDoc, validArg.Content);

            if (action.XDoc != null)
            {
                SaveXDocument.GetInstance().Save(action.XDoc);
            }
        }
    }
}
