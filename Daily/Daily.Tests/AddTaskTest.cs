using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace Daily.Tests
{
    [TestFixture]
    public class AddTaskTest : TestBase
    {
        private AddTask addTask;
        private const string content = "test arg !@#";

        [SetUp]
        public void Setup()
        {
            addTask = AddTask.GetInstance();
        }

        [Test]
        public void AddNewTask_XDocNewIsBigger()
        {
            var xDocBefore = _xDoc.Descendants(Task).Count();
            addTask.Exec(_xDoc, content);
            var xDocAfter = addTask.XDoc.Descendants(Task).Count();

            Assert.That(xDocBefore, Is.Not.EqualTo(xDocAfter));
        }

        [Test]
        public void AddNewTask_Random_XDocNewCount()
        {
            var xDocNew = _xDoc;
            var rnd = new Random();
            int length = rnd.Next(1, 10);
            for (int i = 0; i < length; i++)
            {
                addTask.Exec(xDocNew, content);
            }
            var xDocAfter = addTask.XDoc.Descendants(Task).Count();

            Assert.That(xDocAfter, Is.EqualTo(length+1));
        }
    }
}
