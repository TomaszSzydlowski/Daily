using System;

namespace Daily.View
{
    public class ViewBase
    {
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
    }
}
