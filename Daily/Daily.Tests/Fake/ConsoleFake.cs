using Daily.Helpers;

namespace Daily.Tests.Fake
{
    public class ConsoleFake : IConsoleReadLine
    {
        private readonly string _output;

        public ConsoleFake(string output)
        {
            _output = output;
        }

        public string ReadLine()
        {
            return _output;
        }
    }
}
