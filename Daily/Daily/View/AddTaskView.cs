using Daily.Model;
using System;
using System.Collections.Generic;

namespace Daily.View
{
    public sealed class AddTaskView: IViewBase
    {
        private static AddTaskView instance = new AddTaskView();

        private AddTaskView()
        {

        }

        public static AddTaskView GetInstance()
        {
            return instance;
        }

        public void Show(List<TaskRepo> taskRepos)
        {
            Console.WriteLine("[ADDED]");
        }
    }
}