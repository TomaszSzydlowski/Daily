using Daily.Controller;
using Daily.Tests.Fake;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security;

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
            //Arrange
            var addCommand = "add newTask";
            var console = new ConsoleReadLineFake(addCommand);
            string[] result = account.GetCommand(console);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(new[] { "add", "newTask" }));
        }

        [Test]
        public void GetCommand_AddTaskLongContent_ReturnCorrectStringTable()
        {
            //Arrange
            var addCommandLong = "add \"Today i did a lot of thinks\"";
            var console = new ConsoleReadLineFake(addCommandLong);
            string[] result = account.GetCommand(console);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(new[] { "add", "Today i did a lot of thinks" }));
        }

        [Test]
        public void GetCommand_FindTodayTask_ReturnCorrectStringTable()
        {
            //Arrange
            var findTodayCommand = "find -t";
            var console = new ConsoleReadLineFake(findTodayCommand);
            string[] result = account.GetCommand(console);


            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(new[] { "find", "-t" }));
        }

        [Test]
        public void GetCommand_FindByDate_ReturnCorrectStringTable()
        {
            //Arrange
            var findByDateCommand = "find 28/02/2019";
            var console = new ConsoleReadLineFake(findByDateCommand);
            string[] result = account.GetCommand(console);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(new[] { "find", "28/02/2019" }));
        }

        [Test]
        public void GetPassword_ReturnCorrectStringLength()
        {
            //Arrange
            ConsoleReadKeyFake console = ArrangeConsoleReadKeyOutput();

            SecureString result = account.GetPassword(console);
            var password = new System.Net.NetworkCredential(string.Empty, result).Password;

            //Assert
            Assert.That(password, Is.Not.Null);
            Assert.That(password.Length, Is.EqualTo(2));
            Assert.That(password, Is.EqualTo("AB"));
        }

        private ConsoleReadKeyFake ArrangeConsoleReadKeyOutput()
        {
            ConsoleKeyInfo a = new ConsoleKeyInfo('A', ConsoleKey.A, false, false, false);
            ConsoleKeyInfo b = new ConsoleKeyInfo('B', ConsoleKey.B, false, false, false);
            ConsoleKeyInfo enter = new ConsoleKeyInfo((char)ConsoleKey.Enter, ConsoleKey.Enter, false, false, false);

            var consoleKeyInfoList = new List<ConsoleKeyInfo>();
            consoleKeyInfoList.Add(a);
            consoleKeyInfoList.Add(b);
            consoleKeyInfoList.Add(enter);

            var console = new ConsoleReadKeyFake(consoleKeyInfoList.ToArray());
            return console;
        }

        [Test]
        public void LogIn_ReturnFalse()
        {
            //Arrange
            ConsoleReadKeyFake console = ArrangeConsoleReadKeyOutput();
            //Act
            var result = account.LogIn(console);

            //Assert
            Assert.That(result, Is.False);
        }
    }
}
