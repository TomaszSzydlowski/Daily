using Daily.Model;
using System;
using System.Collections.Generic;

namespace Daily.View
{
    public sealed class FindTasksView : ViewBase, IViewBase
    {
        private static FindTasksView instance = new FindTasksView();

        private FindTasksView()
        {

        }

        public static FindTasksView GetInstance()
        {
            return instance;
        }
    }
}
