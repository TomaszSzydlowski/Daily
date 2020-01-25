namespace Daily.Helpers
{
    public class ArgValidator
    {
        public string Content { get; private set; }
        public string Action { get; private set; }

        public ArgValidator(string[] args)
        {
            Action = args[0];
            Content = args[1];
        }
    }
}
