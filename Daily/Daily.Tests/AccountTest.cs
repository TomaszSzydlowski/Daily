using Daily.Controller;
using Daily.Helpers.Interfaces;
using Daily.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Daily.Tests
{
    [TestFixture]
    public class AccountTest
    {
        Mock<IConsoleReadKey> _fakeConsoleKey;
        Mock<IConsoleReadLine> _fakeConsoleLine;
        Mock<IGetXDocument> _fakeXDocument;
        Mock<IActionBase> _fakeActionBase;
        Mock<IEncryptController> _fakeEncryptController;

        Account account;

        [SetUp]
        public void Setup()
        {
            _fakeConsoleKey = new Mock<IConsoleReadKey>();
            _fakeConsoleLine = new Mock<IConsoleReadLine>();
            _fakeXDocument = new Mock<IGetXDocument>();
            _fakeActionBase = new Mock<IActionBase>();
            _fakeEncryptController = new Mock<IEncryptController>();
            account = Account.GetInstance(_fakeConsoleKey.Object,_fakeConsoleLine.Object, _fakeEncryptController.Object, _fakeXDocument.Object,_fakeActionBase.Object);
        }

        [Test]
        public void GetCommand_AddTask_ReturnCorrectStringTable()
        {
            //Arrange
            _fakeConsoleLine.Setup(x => x.ReadLine()).Returns("add newTask");
            string[] result = account.GetCommand();

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(new[] { "add", "newTask" }));
        }

        [Test]
        public void GetCommand_AddTaskLongContent_ReturnCorrectStringTable()
        {
            //Arrange
            _fakeConsoleLine.Setup(x => x.ReadLine()).Returns("add \"Today i did a lot of thinks\"");
            string[] result = account.GetCommand();

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(new[] { "add", "Today i did a lot of thinks" }));
        }

        [Test]
        public void GetCommand_FindTodayTask_ReturnCorrectStringTable()
        {
            //Arrange
            _fakeConsoleLine.Setup(x => x.ReadLine()).Returns("find -t");
            string[] result = account.GetCommand();


            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(new[] { "find", "-t" }));
        }

        [Test]
        public void GetCommand_FindByDate_ReturnCorrectStringTable()
        {
            //Arrange
            _fakeConsoleLine.Setup(x => x.ReadLine()).Returns("find 28/02/2019");
            string[] result = account.GetCommand();

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(new[] { "find", "28/02/2019" }));
        }

        [Test]
        public void GetPassword_ReturnCorrectStringLength()
        {
            //Arrange
            _fakeConsoleKey.SetupSequence(x => x.ReadKey(It.IsAny<bool>()))
                .Returns(new ConsoleKeyInfo('A', ConsoleKey.A, false, false, false))
                .Returns(new ConsoleKeyInfo('B', ConsoleKey.B, false, false, false))
                .Returns(new ConsoleKeyInfo((char)ConsoleKey.Enter, ConsoleKey.Enter, false, false, false));

            //Act
            SecureString result = account.GetPassword();
            var password = new System.Net.NetworkCredential(string.Empty, result).Password;

            //Assert
            Assert.That(password, Is.Not.Null);
            Assert.That(password.Length, Is.EqualTo(2));
            Assert.That(password, Is.EqualTo("AB"));
        }

        [Test]
        public void LogIn_WrongPassword_ReturnFalse()
        {
            //Arrange
            _fakeConsoleKey.Setup(x => x.ReadKey(It.IsAny<bool>()))
                .Returns(new ConsoleKeyInfo((char)ConsoleKey.Enter, ConsoleKey.Enter, false, false, false));
            _fakeEncryptController.Setup(x => x.DecryptXDoc(It.IsAny<List<TaskRepo>>()))
                .Throws(new CryptographicException());
            _fakeActionBase.Setup(x => x.Exec(It.IsAny<XDocument>(), It.IsAny<string>()))
                .Returns(new PostActionRepo
                {
                    TaskRepos = new List<TaskRepo>
                    {
                        new TaskRepo
                        {
                            Content="fake"
                        }
                    }
                });

            //Act
            var result = account.LogIn();

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void LogIn_SomethingWentWrong_ReturnFalse()
        {
            //Arrange
            _fakeConsoleKey.Setup(x => x.ReadKey(It.IsAny<bool>()))
                .Returns(new ConsoleKeyInfo((char)ConsoleKey.Enter, ConsoleKey.Enter, false, false, false));
            _fakeEncryptController.Setup(x => x.DecryptXDoc(It.IsAny<List<TaskRepo>>()))
                .Throws(new Exception());
            _fakeActionBase.Setup(x => x.Exec(It.IsAny<XDocument>(), It.IsAny<string>()))
                .Returns(new PostActionRepo
                {
                    TaskRepos = new List<TaskRepo>
                    {
                        new TaskRepo
                        {
                            Content="fake"
                        }
                    }
                });

            //Act
            var result = account.LogIn();

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void LogIn_CorrectPassword_ReturnTrue()
        {
            //Arrange
            _fakeConsoleKey.Setup(x => x.ReadKey(It.IsAny<bool>()))
                .Returns(new ConsoleKeyInfo((char)ConsoleKey.Enter, ConsoleKey.Enter, false, false, false));
            _fakeActionBase.Setup(x => x.Exec(It.IsAny<XDocument>(), It.IsAny<string>()))
                .Returns(new PostActionRepo
                {
                    TaskRepos = new List<TaskRepo>
                    {
                        new TaskRepo
                        {
                            Content="fake"
                        }
                    }
                });

            //Act
            var result = account.LogIn();

            //Assert
            Assert.That(result, Is.True);
        }
    }
}
