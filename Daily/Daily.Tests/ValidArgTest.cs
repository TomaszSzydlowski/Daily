using Daily.Helpers;
using NUnit.Framework;

namespace Daily.Tests
{
    [TestFixture]
    public class ValidArgTest
    {
        private ValidArg validArg;


        private const string ADD = "Add";
        private const string FIND = "Find";
        private const string FINDYESTERDAY = "-y";
        private const string FINDTODAY = "-t";

        private const string CONTENT = "content";

        [SetUp]
        public void Setup()
        {

        }


        [Test]
        public void CheckCorrectReturn_AddTask()
        {
            var userArg = new[] { ADD, CONTENT };

            validArg = ValidArg.Run(userArg);

            Assert.AreEqual(validArg.Action, EActionMethod.ADD);
        }

        [Test]
        public void CheckCorrectReturn_AddFind()
        {
            var userArg = new[] { FIND, CONTENT };

            validArg = ValidArg.Run(userArg);

            Assert.AreEqual(validArg.Action, EActionMethod.FIND);
        }

        [Test]
        public void CheckCorrectReturn_AddFindYesterday()
        {
            var userArg = new[] { FIND, FINDYESTERDAY, CONTENT };
            validArg = ValidArg.Run(userArg);

            Assert.AreEqual(validArg.Action, EActionMethod.FINDYESTERDAY);
        }

        [Test]
        public void CheckCorrectReturn_AddFindToday()
        {
            var userArg = new[] { FIND, FINDTODAY, CONTENT };
            validArg = ValidArg.Run(userArg);

            Assert.AreEqual(validArg.Action, EActionMethod.FINDTODAY);
        }
    }
}
