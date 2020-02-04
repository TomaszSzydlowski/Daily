using Daily.Actions;
using Daily.Model;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Daily
{

    public sealed class AddTask : IActionBase
    {
        private const string Tasks = "tasks";
        private static AddTask instance = new AddTask();

        private AddTask()
        {

        }

        public static AddTask GetInstance()
        {
            return instance;
        }

        public PostActionRepo Exec(XDocument xDoc, string arg)
        {
            var task = new TaskRepo
            {
                Content = arg
            };

            xDoc.Element(Tasks).Add(task.GetXElement());
            var taskRepos = new List<TaskRepo>() { task };

            var postActionRepo = new PostActionRepo()
            {
                XDoc = xDoc,
                TaskRepos = taskRepos
            };

            return postActionRepo;
        }
    }
}
