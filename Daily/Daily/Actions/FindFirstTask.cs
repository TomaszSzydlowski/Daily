using Daily.Helpers.Interfaces;
using Daily.Model;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Daily.Actions
{
    public sealed class FindFirstTask : IActionBase
    {
        private const string TASK = "task";
        private const string TIME = "time";

        private static FindFirstTask instance = new FindFirstTask();

        private FindFirstTask()
        {

        }

        public static FindFirstTask GetInstance()
        {
            return instance;
        }

        public PostActionRepo Exec(XDocument xDoc, string criteria=null)
        {
            var firstElement = xDoc.Root.Descendants(TASK).First();


            var postActionRepo = new PostActionRepo()
            {
                TaskRepos = new List<TaskRepo>
                {
                    new TaskRepo()
                    {
                        Content = firstElement.Value,
                        DataTime = firstElement.Attribute(TIME).Value
                    }
                }
            };

            return postActionRepo;
        }
    }
}
