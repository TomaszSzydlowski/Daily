using Daily.Helpers.Interfaces;
using Daily.Model;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Daily.Actions
{

    public sealed class AddTask : IActionBase
    {
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
            var postActionRepo = new PostActionRepo()
            {
                XDoc = xDoc,
                TaskRepos = new List<TaskRepo>()
                {
                    new TaskRepo()
                    {
                        Content=arg
                    }
                }
            };

            return postActionRepo;
        }
    }
}
