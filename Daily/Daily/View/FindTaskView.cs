using Daily.Actions;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void Show()
        {
            var findResults = FindTask.GetInstance().Result;

            foreach (var findResult in findResults)
            {
                Console.Write(findResult.DataTime);
                Console.Write("\t");
                Console.WriteLine(findResult.Content);
            }

            Console.ReadKey();
        }
    }
}
