namespace Daily.Helpers
{
    public class ValidArg : IValidArg
    {
        public string Content { get; private set; }
        public string Action { get; private set; }

        public ValidArg(string[] args)
        {
            Action = args[0];
            Content = args[1];
        }
    }
}
