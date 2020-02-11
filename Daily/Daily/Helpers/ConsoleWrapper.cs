using Daily.Helpers.Interfaces;
using System;

namespace Daily.Helpers
{
    public class ConsoleWrapper : IConsoleReadLine, IConsoleReadKey
    {
        public ConsoleKeyInfo ReadKey(bool b)
        {
            return Console.ReadKey(b);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
