using Daily.Controller;
using Daily.Actions;
using Daily.Helpers;
using Daily.View;
using System;
using Daily.Helpers.Interfaces;

namespace Daily
{
    class Program
    {
        private static IConsoleReadLine consoleLine = ConsoleReadLine.GetInstance();
        private static IConsoleReadKey consoleKey = ConsoleReadKey.GetInstance();
        private static IGetXDocument getXDocument = GetXDocument.GetInstance();
        private static IEncryptController encryptController = EncryptController.GetInstance();
        private static IActionBase actionBase = FindFirstTask.GetInstance();
        private static IMainController mainController = MainController.GetInstance();
        private static IAccount account = Account.GetInstance(consoleKey, consoleLine, encryptController, getXDocument, actionBase);
        private static ConsoleKey key;

        static void Main(string[] args)
        {
            ViewBase.ShowWelcome();

            var logIn = account.LogIn();

            do
            {
                if (logIn)
                {
                    var commands = account.GetCommand();

                    mainController.Start(commands);
                }
                else
                {
                    logIn = account.LogIn();
                }

                ViewBase.ShowMessageAfterLogIn(logIn);

                key = consoleKey.ReadKey(true).Key;
                ViewBase.ClearLine();

            } while (key == ConsoleKey.Enter);

            ViewBase.LogOutSuccess();
        }
    }
}


