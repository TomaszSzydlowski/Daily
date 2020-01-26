using System;

namespace Daily.Helpers
{
    public partial class ValidArg : IValidArg
    {
        public string Content { get; private set; }
        public EActionMethod Action { get ; private set; }


        private const string Add = "Add";
        private const string Find = "Find";

        public ValidArg(string[] args)
        {
            Action = GetSelectedAction(args[0]);
            Content = args[1];
        }

        public EActionMethod GetSelectedAction(string arg)
        {
            if(arg.Equals(Add, StringComparison.OrdinalIgnoreCase))
            {
                return EActionMethod.ADD;
            }
            else if(arg.Equals(Find, StringComparison.OrdinalIgnoreCase))
            {
                return EActionMethod.FIND;
            }
            else
            {
                throw new ArgumentException(String.Format("{0} this argument is not supported. Use \" - help\" to list all arguments", arg));
            }
        }
    }
}
