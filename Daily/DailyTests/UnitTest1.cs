using NUnit.Framework;

namespace DailyTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var FindTask = new FindTask();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}