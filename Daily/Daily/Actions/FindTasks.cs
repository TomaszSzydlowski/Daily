using Daily.Helpers.Interfaces;
using Daily.Model;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Daily.Actions
{
    public sealed class FindTasks : IActionBase
    {
        private const string TASK = "task";
        private const string TIME = "time";

        private static FindTasks instance = new FindTasks();

        private FindTasks()
        {

        }

        public static FindTasks GetInstance()
        {
            return instance;
        }

        public PostActionRepo Exec(XDocument xDoc, string time)
        {
            IEnumerable<XElement> XElementsFilterByTime =
                from el in xDoc.Descendants(TASK)
                from attr in el.Attributes()
                where attr.Name.ToString().Equals(TIME)
                where attr.Value.ToString().Contains(time)
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
