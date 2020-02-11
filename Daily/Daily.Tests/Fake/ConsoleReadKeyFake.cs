using Daily.Helpers.Interfaces;
using System;

namespace Daily.Tests.Fake
{
    public class ConsoleReadKeyFake : IConsoleReadKey
    {
        private static int count =0;
        private readonly ConsoleKeyInfo[] _input;

        public ConsoleReadKeyFake(ConsoleKeyInfo[] input)
        {
            _input = input;
        }

        public ConsoleKeyInfo ReadKey(bool b)
        {
            ConsoleKeyInfo output = _input[count];
            count++;

            return output;
        }
    }
}
