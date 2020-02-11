using Daily.Helpers.Interfaces;

namespace Daily.Tests.Fake
{
    public class ConsoleReadLineFake : IConsoleReadLine
    {
        private readonly string _output;

        public ConsoleReadLineFake(string output)
        {
            _output = output;
        }

        public string ReadLine()
        {
            return _output;
        }
    }
}
