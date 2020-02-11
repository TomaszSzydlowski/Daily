using System;
using Daily.Helpers.Interfaces;

namespace Daily.Helpers
{
    public sealed class ValidArg : IValidArg
    {
        public string Content { get; private set; }
        public EActionMethod Action { get; private set; }

        private const string ADD = "Add";
        private const string FIND = "Find";
        private const string FINDYESTERDAY = "-y";
        private const string FINDTODAY = "-t";

        private ValidArg() { }

        private static ValidArg instance = new ValidArg();


        public static ValidArg GetInstance()
        {
            return instance;
        }

        public static ValidArg Run(string[] args)
        {
            var validArg = GetInstance();

            try
            {
                validArg.Action = GetSelectedAction(args);
                validArg.Content = GetContent(args[args.Length - 1]);
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("There aren't enough arguments. Give more arguments or use \" - help\" to list all supported arguments");
            }

            return validArg;
        }

        private static EActionMethod GetSelectedAction(string[] arg)
        {
            var firstArg = arg[0];
            var secondArg = arg[1];

            if (firstArg.Equals(ADD, StringComparison.OrdinalIgnoreCase))
            {
                return EActionMethod.ADD;
            }
            else if (firstArg.Equals(FIND, StringComparison.OrdinalIgnoreCase))
            {
                if (secondArg.Equals(FINDYESTERDAY, StringComparison.OrdinalIgnoreCase))
                {
                    return EActionMethod.FINDYESTERDAY;
                }
                if (secondArg.Equals(FINDTODAY, StringComparison.OrdinalIgnoreCase))
                {
                    return EActionMethod.FINDTODAY;
                }
                return EActionMethod.FIND;
            }
            else
            {
                throw new ArgumentException(String.Format("{0} this argument is not supported. Use \" - help\" to list all supported arguments", arg));
            }
        }

        private static string GetContent(string lastArg)
        {
            return lastArg.Contains('-') ? null : lastArg;
        }
    }
}
