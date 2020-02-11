using Daily.Controller;
using Daily.Helpers;
using Daily.View;
using System;

namespace Daily
{
    class Program
    {
        private static ConsoleKey key;

        static void Main(string[] args)
        {
            ViewBase.ShowWelcome();
            var consoleService = new ConsoleWrapper();

            var logIn = Account.GetInstance().LogIn(consoleService);

            do
            {
                if (logIn)
                {
                    var commands = Account.GetInstance().GetCommand(consoleService);

                    MainController.GetInstance().Start(commands);
                }
                else
                {
                    logIn = Account.GetInstance().LogIn(consoleService);
                }

                ViewBase.ShowMessageAfterLogIn(logIn);

                key = Console.ReadKey(true).Key;
                ViewBase.ClearLine();

            } while (key == ConsoleKey.Enter);

            ViewBase.LogOutSuccess();
        }
    }
}


