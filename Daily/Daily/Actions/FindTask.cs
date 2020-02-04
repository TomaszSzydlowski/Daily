using Daily.Model;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Daily.Actions
{
    public sealed class FindTask : IActionBase
    {
        private const string Task = "task";
        private const string Time = "time";

        private static FindTask instance = new FindTask();

        private FindTask()
        {

        }

        public static FindTask GetInstance()
        {
            return instance;
        }

        public PostActionRepo Exec(XDocument xDoc, string time)
        {
            IEnumerable<XElement> XElementsFilterByTime =
                from el in xDoc.Descendants(Task)
                from attr in el.Attributes()
                where attr.Name.ToString().Equals(Time)
                where attr.Value.ToString().Contains(time)
                select el;

            var taskRepos = XElementsFilterByTime.Select(n => new TaskRepo 
            { 
                Content = n.Value, 
                DataTime = n.Attribute(Time).Value
            }).ToList();

            var postActionRepo = new PostActionRepo()
            {
                TaskRepos = taskRepos
            };

            return postActionRepo;
        }
    }
}
