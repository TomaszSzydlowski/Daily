using NUnit.Framework;
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
        public void AddNewTask_postActionHaveNewTaskRepo()
        {
            var postAction = addTask.Exec(_xDoc, content);

            Assert.That(postAction.TaskRepos, Is.Not.Null);
            Assert.That(postAction.TaskRepos.Count, Is.EqualTo(1));
            Assert.That(postAction.XDoc, Is.Not.Null);
        }
    }
}
