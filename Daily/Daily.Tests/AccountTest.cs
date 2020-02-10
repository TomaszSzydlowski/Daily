using Daily.Controller;
using Daily.Tests.Fake;
using NUnit.Framework;

namespace Daily.Tests
{
    [TestFixture]
    public class AccountTest
    {
        Account account;

        [SetUp]
        public void Setup()
        {
            account = Account.GetInstance();
        }

        [Test]
        public void GetCommand_AddTask_ReturnCorrectStringTable()
        {
            //Arange
            var addCommand = "add newTask";
            var console = new ConsoleFake(addCommand);
            string[] result = account.GetCommand(console);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(new[] { "add", "newTask" }));
        }

        [Test]
        public void GetCommand_AddTaskLongContent_ReturnCorrectStringTable()
        {
            //Arange
            var addCommandLong = "add \"Today i did a lot of thinks\"";
            var console = new ConsoleFake(addCommandLong);
            string[] result = account.GetCommand(console);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(new[] { "add", "Today i did a lot of thinks" }));
        }

        [Test]
        public void GetCommand_FindTodayTask_ReturnCorrectStringTable()
        {
            //Arange
            var findTodayCommand = "find -t";
            var console = new ConsoleFake(findTodayCommand);
            string[] result = account.GetCommand(console);


            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(new[] { "find", "-t" }));
        }

        [Test]
        public void GetCommand_FindByDate_ReturnCorrectStringTable()
        {
            //Arange
            var findByDateCommand = "find 28/02/2019";
            var console = new ConsoleFake(findByDateCommand);
            string[] result = account.GetCommand(console);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(new[] { "find", "28/02/2019" }));
        }
    }
}
