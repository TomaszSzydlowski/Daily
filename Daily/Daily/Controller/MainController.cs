using Daily.Actions;
using Daily.Helpers;
using System;

namespace Daily.Controller
{
    public sealed class MainController
    {
        private static MainController instance = new MainController();

        private const string Add = "Add";
        private const string Find = "Find";

        private MainController()
        {

        }
        public static MainController GetInstance()
        {
            return instance;
        }

        public void ChooseAction(IValidArg validArg)
        {
            var xDoc = GetXDocument.GetInstance().Get();

            if (validArg.Action.Equals(Add, StringComparison.OrdinalIgnoreCase))
            {
                var changedXDoc = AddTask.GetInstance().Add(xDoc, validArg.Content);
                SaveXDocument.GetInstance().Save(changedXDoc);
            }
            else if (validArg.Action.Equals(Find, StringComparison.OrdinalIgnoreCase))
            {
                var founds = FindTask.GetInstance().Find(xDoc, validArg.Content);
            }
            else
            {
                throw new ArgumentException(String.Format("{0} this argument is not supported. Use \" - help\" to list all arguments", validArg.Action));
            }
        }
    }
}
