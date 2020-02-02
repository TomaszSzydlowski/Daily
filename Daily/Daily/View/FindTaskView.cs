using Daily.Actions;
using Daily.Model;
using System;
using System.Collections.Generic;

namespace Daily.View
{
    public sealed class FindTaskView : IViewBase
    {
        private static FindTaskView instance = new FindTaskView();

        private FindTaskView()
        {

        }

        public static FindTaskView GetInstance()
        {
            return instance;
        }

        public void Show(List<TaskRepo> taskRepos)
        {
            foreach (var taskRepo in taskRepos)
            {
                Console.Write(taskRepo.DataTime);
                Console.Write("\t");
                Console.WriteLine(taskRepo.Content);
            }

            Console.ReadKey();
        }
    }
}
