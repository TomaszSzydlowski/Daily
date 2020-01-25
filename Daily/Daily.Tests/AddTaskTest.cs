using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace Daily.Tests
{
    [TestFixture]
    public class AddTaskTest : TestBase
    {
        private const string content = "test arg !@#";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddNewTask_XDocNewIsBigger()
        {
            var xDocBefore = _xDoc.Descendants(Task).Count();
            var xDocNew = AddTask.GetInstance().Add(_xDoc, content);
            var xDocAfter = xDocNew.Descendants(Task).Count();

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
                xDocNew = AddTask.GetInstance().Add(xDocNew, content);
            }
            var xDocAfter = xDocNew.Descendants(Task).Count();

            Assert.That(xDocAfter, Is.EqualTo(length+1));
        }
    }
}
