using Daily.Helpers.Interfaces;
using System;

namespace Daily.Helpers
{
    public class ConsoleReadLine : IConsoleReadLine
    {
        private static ConsoleReadLine instance = new ConsoleReadLine();

        private ConsoleReadLine() { }

        public static ConsoleReadLine GetInstance()
        {
            return instance;
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
