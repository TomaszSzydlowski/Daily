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
        private FindTask findTask;
        private const string DateTimePerformance = "25/01/2020 19:36";
        private const string Criteria = "25/01/2020 13:05";

        public string DateTime => System.DateTime.Now.ToString("g");

        [SetUp]
        public void Setup()
        {
            findTask = FindTask.GetInstance();
        }

        private XDocument GetBigXML()
        {
            TextReader tr = new StringReader("<tasks>Content</tasks>");
            XDocument xDoc = XDocument.Load(tr);

            for (int i = 0; i < 15000; i++)
            {
                xDoc.Element("tasks").Add(new XElement(Task, new XAttribute(Time, DateTime), "Content"));
            }

            xDoc.Element("tasks").Add(new XElement(Task, new XAttribute(Time, DateTime), DateTimePerformance));

            for (int i = 0; i < 15000; i++)
            {
                xDoc.Element("tasks").Add(new XElement(Task, new XAttribute(Time, DateTime), "Content"));
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
        public void GetFindByAllDateTime_ReturnAllEqualValuesToCriteria()
        {
            findTask.Exec(_xDoc, Criteria);

            Assert.That(findTask.Result, Is.Not.Empty);
            Assert.That(findTask.Result.Count, Is.EqualTo(1));
        }

        [Test]
        public void FindPerformance_Pin()
        {
            Assert.That(GetBigXML().Descendants(Task).Count(), Is.EqualTo(30001));
            Assert.That(Period(() => findTask.Exec(GetBigXML(), DateTimePerformance)), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(0.1)));
        }
    }
}