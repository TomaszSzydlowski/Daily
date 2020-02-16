using Daily.Helpers.Interfaces;
using System;

namespace Daily.Helpers
{
    public class ConsoleReadKey : IConsoleReadKey
    {
        private static ConsoleReadKey instance = new ConsoleReadKey();

        private ConsoleReadKey()
        {

        }

        public static ConsoleReadKey GetInstance()
        {
            return instance;
        }

        public ConsoleKeyInfo ReadKey(bool b)
        {
            return Console.ReadKey(b);
        }
    }
}
