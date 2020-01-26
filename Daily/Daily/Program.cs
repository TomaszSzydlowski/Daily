using Daily.Controller;
using Daily.Helpers;

namespace Daily
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup.GetInstance().Go(args);
        }
    }
}


