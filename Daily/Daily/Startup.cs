﻿using Daily.Controller;
using Daily.Helpers;
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

        internal void Go(string[] args)
        {
            var validArg = new ValidArg(args);
            var action = MainController.GetInstance().MakeAction(validArg.Action);

            action.Exec(XDoc, validArg.Content);
        }
    }
}
