using Daily.Actions;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Daily.Tests
{
    [TestFixture]
    public class FindTaskTest : TestBase
    {
        private FindTasks findTask;
        private const string DateTimePerformance = "25/01/2020 19:36";
        private string Criteria = "25/01/2020 13:05";

        public string Time => DateTime.Now.ToString("g");

        [SetUp]
        public void Setup()
        {
            findTask = FindTasks.GetInstance();
        }

        private XDocument GetBigXML()
        {
            TextReader tr = new StringReader("<tasks>Content</tasks>");
            XDocument xDoc = XDocument.Load(tr);

            for (int i = 0; i < 15000; i++)
            {
                xDoc.Element("tasks").Add(new XElement(Task, new XAttribute(TIME, Time), "Content"));
            }

            xDoc.Element("tasks").Add(new XElement(Task, new XAttribute(TIME, Time), DateTimePerformance));

            for (int i = 0; i < 15000; i++)
            {
                xDoc.Element("tasks").Add(new XElement(Task, new XAttribute(TIME, Time), "Content"));
            }

            return xDoc;
        }
        private TimeSpan Period(Action toTime)
        {
            var timer = Stopwatch.StartNew();
            toTime();
            timer.Stop();
            return timer.Elapsed;
        }


        [Test]
        [TestCase("25")]
        [TestCase("12")]
        [TestCase("2019")]
        [TestCase("25/01")]
        [TestCase("1/2020")]
        [TestCase("25/01/2020 13:05")]
        public void GetTaskByDayMonthYear_ReturnAllEqualValuesToCriteria(string arg)
        {
            var postAction = findTask.Exec(_xDoc, Criteria);

            Assert.That(postAction.TaskRepos, Is.Not.Empty);
            Assert.That(postAction.TaskRepos.Count, Is.EqualTo(1));
        }

        [Test]
        public void FindPerformance_Pin()
        {
            Assert.That(GetBigXML().Descendants(Task).Count(), Is.EqualTo(30001));
            Assert.That(Period(() => findTask.Exec(GetBigXML(), DateTimePerformance)), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(0.15)));
        }
    }
}