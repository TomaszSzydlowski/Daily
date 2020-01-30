using System;

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

        public void Show()
        {
            Console.WriteLine("[ADDED]");
        }
    }
}