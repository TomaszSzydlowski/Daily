using Daily.Actions;
using NUnit.Framework;
using System;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

namespace Daily.Tests
{
    class FindYesterdayTasksTests : TestBase
    {
        private FindYesterdayTasks findYesterdayTask;
        private const string TASKS = "tasks";
        public readonly string Content = "TaskFromYesterDayTest";
        public string Time;


        [SetUp]
        public void Setup()
        {
            findYesterdayTask = FindYesterdayTasks.GetInstance();
            Time = GetDateTimeWithFormat(-1);
        }

        private string GetDateTimeWithFormat(int days)
        {
            var time = DateTime.Now;
            time = time.AddDays(days);
            return time.ToString("d", CultureInfo.CreateSpecificCulture("fr-FR"));
        }

        [Test]
        public void GetTasksFromYesterday_ReturnOneTask()
        {
            var postActionRepo = findYesterdayTask.Exec(PrepareData());
            Assert.That(postActionRepo.TaskRepos.Count, Is.EqualTo(1));
        }

        private XDocument PrepareData()
        {

            var rnd = new Random();
            int length = rnd.Next(1, 10);

            TextReader tr = new StringReader("<tasks>Content</tasks>");
            XDocument xDoc = XDocument.Load(tr);

            for (int i = 0; i < length; i++)
            {
                var days = -i - 1;
                var time = GetDateTimeWithFormat(days);
                xDoc.Element(TASKS).Add(new XElement(Task, new XAttribute(TIME, time), Content+i));
            }

            return xDoc;
        }

        [Test]
        public void GetTasksFromYesterday_AttributeIsCorrect()
        {
            var postActionRepo = findYesterdayTask.Exec(PrepareData());
            Assert.That(postActionRepo.TaskRepos[0].DataTime, Is.EqualTo(Time));
        }

        [Test]
        public void GetTasksFromYesterday_ContentIsCorrect()
        {
            var postActionRepo = findYesterdayTask.Exec(PrepareData());
            var content = Content + 0;
            Assert.That(postActionRepo.TaskRepos[0].Content, Is.EqualTo(content));
        }
    }
}
