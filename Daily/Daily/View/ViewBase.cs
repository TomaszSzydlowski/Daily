using Daily.Model;
using System;
using System.Collections.Generic;

namespace Daily.View
{
    public class ViewBase
    {

        private const string FOUND = "FOUND";

        protected void ConsoleWriteLineWithColor(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        protected void ConsoleWriteWithColorAndBrackets(string message, ConsoleColor consoleColor)
        {
            Console.Write("[");
            ConsoleWriteWithColor(message, consoleColor);
            Console.Write("]");
        }

        protected void ConsoleWriteWithColor(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(message);
            Console.ResetColor();
        }

        protected void ConsoleTab()
        {
            Console.Write("\t");
        }

        protected void ConsoleDash()
        {
            Console.Write("-");
        }

        protected void ConsoleSpace()
        {
            Console.Write(" ");
        }

        public virtual void Show(List<TaskRepo> taskRepos)
        {
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
    }
}
