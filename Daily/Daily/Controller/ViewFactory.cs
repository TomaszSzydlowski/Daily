using Daily.Helpers;
using Daily.View;

namespace Daily.Controller
{
    public class ViewFactory
    {
        public virtual IViewBase CreateView(EActionMethod method)
        {
            IViewBase view = null;
            switch (method)
            {
                case EActionMethod.ADD:
                    view = AddTaskView.GetInstance();
                    break;
                case EActionMethod.FIND:
                    view = FindTasksView.GetInstance();
                    break;
                case EActionMethod.FINDYESTERDAY:
                    view = FindYesterdayTasks.GetInstance();
                    break;
                default:
                    break;
            }
            return view;
        }
    }
}
