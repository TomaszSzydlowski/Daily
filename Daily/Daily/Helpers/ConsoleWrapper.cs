using System;

namespace Daily.Helpers
{
    public class ConsoleWrapper : IConsoleReadLine
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
