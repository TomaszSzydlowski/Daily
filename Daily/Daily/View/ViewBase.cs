using Daily.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Daily.View
{
    public class ViewBase
    {

        private const string FOUND = "FOUND";
        private const string NOTFOUND = "NOT FOUND";
        private const string SUCCESS = "SUCCESS";
        private const string LOGGEDIN = "You are logged in.";
        private const string PRESS_ENTER_TO_CONTINUE = "Press enter to continue";
        private const string PRESS_ENTER_TO_TRY_AGAIN = "Press enter to try again.";
        private const string WELCOME = "Welcome to the Daily program!";

        private const string LOGGEDOUT = "Successfully logged out. Bye!";
        private const string INVALID_PASSWORD = "The password given is incorrect. Try again.";
        private const string ERROR = "ERROR";
        private const string SOMETHING_WENT_WRONG_TRY_AGAIN = "Something went wrong. Try again..";

        public static void ConsoleWriteLineWithColor(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void ConsoleWriteWithColorAndBrackets(string message, ConsoleColor consoleColor)
        {
            Console.Write("[");
            ConsoleWriteWithColor(message, consoleColor);
            Console.Write("]");
        }

        public static void LogInFailed()
        {
            ConsoleTab();
            ConsoleWriteWithColorAndBrackets(ERROR, ConsoleColor.Red);
            Console.WriteLine();
            Console.WriteLine(INVALID_PASSWORD);

        }

        public static void ConsoleWriteLineWithColorAndBrackets(string message, ConsoleColor consoleColor)
        {
            Console.Write("[");
            ConsoleWriteWithColor(message, consoleColor);
            Console.WriteLine("]");
        }

        internal static void SomethingWentWrong()
        {
            ConsoleTab();
            ConsoleWriteWithColorAndBrackets(ERROR, ConsoleColor.Red);
            Console.WriteLine();
            Console.WriteLine(SOMETHING_WENT_WRONG_TRY_AGAIN);
        }

        public static void LogInSuccess()
        {
            ConsoleTab();
            ConsoleWriteWithColorAndBrackets(SUCCESS, ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine(LOGGEDIN);
            Console.WriteLine();
        }

        public static void LogOutSuccess()
        {
            ConsoleWriteWithColorAndBrackets(SUCCESS, ConsoleColor.Green);
            ConsoleTab();
            Console.WriteLine(LOGGEDOUT);
        }

        public static void ConsoleWriteWithColor(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(message);
            Console.ResetColor();
        }

        public static void ConsoleTab()
        {
            Console.Write("\t");
        }

        public static void ConsoleDash()
        {
            Console.Write("-");
        }

        public static void ConsoleSpace()
        {
            Console.Write(" ");
        }

        public virtual void Show(List<TaskRepo> taskRepos)
        {
            if (!taskRepos.Any())
            {
                ConsoleWriteLineWithColorAndBrackets(NOTFOUND, ConsoleColor.Red);
            }

            foreach (var taskRepo in taskRepos)
            {
                ConsoleWriteWithColorAndBrackets(FOUND, ConsoleColor.Green);
                ConsoleTab();

                Console.Write(taskRepo.DataTime);
                ConsoleSpace();
                ConsoleDash();
                ConsoleSpace();
                Console.WriteLine(taskRepo.Content);
            }
        }

        public static void ShowMessageAfterLogIn(bool logIn)
        {
            if (logIn)
            {
                Console.WriteLine();
                Console.Write(PRESS_ENTER_TO_CONTINUE);
            }
            else
            {
                Console.WriteLine();
                Console.Write(PRESS_ENTER_TO_TRY_AGAIN);
            }
        }

        public static void ClearLine()
        {
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.CursorTop--;
        }

        public static void ShowWelcome()
        {
            Console.WriteLine(WELCOME);
            Console.WriteLine();
        }
    }
}
