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
    public class FindTaskTest:TestBase
    {
        private const string DateTimePerformance = "25/01/2020 19:36";
        private const string Criteria = "25/01/2020 13:05";

        public string DateTime => System.DateTime.Now.ToString("g");

        [SetUp]
        public void Setup()
        {

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
            var founds = FindTask.GetInstance().Find(_xDoc, Criteria);

            Assert.That(founds, Is.Not.Empty);
            Assert.That(founds.Count, Is.EqualTo(1));
        }

        [Test]
        public void FindPerformance_Pin()
        {
            Assert.That(GetBigXML().Descendants(Task).Count(), Is.EqualTo(30001));
            Assert.That(Period(() => FindTask.GetInstance().Find(GetBigXML(), DateTimePerformance)), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(0.1)));
        }
    }
}