using Daily.Model;
using System;
using System.Collections.Generic;

namespace Daily.View
{
    public sealed class AddTaskView: ViewBase, IViewBase
    {
        private const string ADDED = "ADDED";
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
            foreach (var taskRepo in taskRepos)
            {
                ConsoleWriteWithColorAndBrackets(ADDED, ConsoleColor.Green);
                ConsoleTab();

                Console.Write(taskRepo.CurrentDateTime);
                ConsoleSpace();
                ConsoleDash();
                ConsoleSpace();
                Console.WriteLine(taskRepo.Content);
            }
        }
    }
}