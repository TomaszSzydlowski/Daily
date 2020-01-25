using Daily.Actions;
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

        public BaseAction ChooseAction(string arg)
        {
            if (arg.Equals(Add, StringComparison.OrdinalIgnoreCase))
            {
                return AddTask.GetInstance();
            }
            else if (arg.Equals(Find, StringComparison.OrdinalIgnoreCase))
            {
                return FindTask.GetInstance();
            }

            throw new ArgumentException(String.Format("{0} this argument is not supported. Use \" - help\" to list all arguments", arg));
        }
    }
}
