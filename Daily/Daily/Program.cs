using Daily.Controller;
using Daily.Helpers;

namespace Daily
{
    class Program
    {
        static void Main(string[] args)
        {
            var validArgs = new ValidArg(args);
            MainController.GetInstance().ChooseAction(validArgs);
        }
    }
}


