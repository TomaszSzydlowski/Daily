using Daily.Helpers.Interfaces;
using Daily.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Daily.Actions
{
    public class FindYesterdayTasks : IActionBase
    {
        private const string TASK = "task";
        private const string TIME = "time";

        private static FindYesterdayTasks instance = new FindYesterdayTasks();

        private FindYesterdayTasks() { }

        public static FindYesterdayTasks GetInstance()
        {
            return instance;
        }

        public PostActionRepo Exec(XDocument xDoc, string arg = null)
        {
            var time = DateTime.Now;
            time = time.AddDays(-1);
            string Time = time.ToString("d", CultureInfo.CreateSpecificCulture("fr-FR"));

            IEnumerable<XElement> XElementsFilterByTime =
                from el in xDoc.Descendants(TASK)
                from attr in el.Attributes()
                where attr.Name.ToString().Equals(TIME)
                where attr.Value.ToString().Contains(Time)
                select el;

            var taskRepos = XElementsFilterByTime.Select(n => new TaskRepo
            {
                Content = n.Value,
                DataTime = n.Attribute(TIME).Value
            }).ToList();

            var postActionRepo = new PostActionRepo()
            {
                TaskRepos = taskRepos
            };

            return postActionRepo;
        }


    }
}
