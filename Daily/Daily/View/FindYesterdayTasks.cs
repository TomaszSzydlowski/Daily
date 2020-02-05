using Daily.Model;
using System;
using System.Collections.Generic;

namespace Daily.View
{
    public sealed class FindYesterdayTasks : ViewBase, IViewBase
    {
        private const string FOUND = "FOUND";
        private static FindYesterdayTasks instance = new FindYesterdayTasks();

        private FindYesterdayTasks()
        {

        }

        public static FindYesterdayTasks GetInstance()
        {
            return instance;
        }

        public void Show(List<TaskRepo> taskRepos)
        {
            foreach (var taskRepo in taskRepos)
            {
                ConsoleWriteWithColorAndBrackets(FOUND, ConsoleColor.Green);
                ConsoleTab();

                Console.Write(taskRepo.DataTime);
                ConsoleSpace();
                ConsoleDash();
                ConsoleSpace();
                Console.WriteLine(taskRepo.Content);
            }
        }
    }
}
