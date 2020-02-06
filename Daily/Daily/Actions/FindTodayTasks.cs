using Daily.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Daily.Actions
{
    public class FindTodayTasks : IActionBase
    {
        private const string TASK = "task";
        private const string TIME = "time";

        private static FindTodayTasks instance = new FindTodayTasks();

        private FindTodayTasks() { }

        public static FindTodayTasks GetInstance()
        {
            return instance;
        }

        public PostActionRepo Exec(XDocument xDoc, string arg = null)
        {
            var time = DateTime.Now;
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
