using Daily.Controller;
using Daily.Helpers;

namespace Daily
{
    class Program
    {
        static void Main(string[] args)
        {
            var validArgs = new ArgValidator(args);

            var action = MainController.GetInstance().ChooseAction(validArgs.Action);
            action.Exec(validArgs.Content);
        }
    }
}


