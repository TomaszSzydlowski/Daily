using Daily.Model;
using NUnit.Framework;
using System;
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
            var postAction = addTask.Exec(_xDoc, content);
            var xDocAfter = postAction.XDoc.Descendants(Task).Count();


            Assert.That(xDocBefore, Is.Not.EqualTo(xDocAfter));
        }

        [Test]
        public void AddNewTask_Random_XDocNewCount()
        {
            var rnd = new Random();
            int length = rnd.Next(1, 10);

            var postAction = new PostActionRepo()
            {
                XDoc = _xDoc
            };
            for (int i = 0; i < length; i++)
            {
                postAction = addTask.Exec(postAction.XDoc, content);
            }

            var xDocAfter = postAction.XDoc.Descendants(Task).Count();
            var numberOfExistingTasks = 2;
            Assert.That(xDocAfter, Is.EqualTo(length + numberOfExistingTasks));
        }
    }
}
