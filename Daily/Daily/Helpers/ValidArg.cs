using System;

namespace Daily.Helpers
{
    public partial class ValidArg : IValidArg
    {
        public string Content { get; private set; }
        public EActionMethod Action { get; private set; }

        private const string Add = "Add";
        private const string Find = "Find";
        private const string FindYesterday = "-y";

        public ValidArg(string[] args)
        {
            try
            {
                Action = GetSelectedAction(args);
                Content = GetContent(args[args.Length - 1]);
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("There aren't enough arguments. Give more arguments or use \" - help\" to list all supported arguments");
            }
        }

        public EActionMethod GetSelectedAction(string[] arg)
        {
            var firstArg = arg[0];
            var secondArg = arg[1];

            if (firstArg.Equals(Add, StringComparison.OrdinalIgnoreCase))
            {
                return EActionMethod.ADD;
            }
            else if (firstArg.Equals(Find, StringComparison.OrdinalIgnoreCase))
            {
                if (secondArg.Equals(FindYesterday, StringComparison.OrdinalIgnoreCase))
                {
                    return EActionMethod.FINDYESTERDAY;
                }
                return EActionMethod.FIND;
            }
            else
            {
                throw new ArgumentException(String.Format("{0} this argument is not supported. Use \" - help\" to list all supported arguments", arg));
            }
        }

        private string GetContent(string lastArg)
        {
            return lastArg.Contains('-') ? null : lastArg;
        }
    }
}
