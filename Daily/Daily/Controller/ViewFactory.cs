using Daily.Helpers;
using Daily.View;

namespace Daily.Controller
{
    public class ViewFactory
    {
        public virtual IViewBase CreateView(EActionMethod method)
        {
            IViewBase action = null;
            switch (method)
            {
                case EActionMethod.ADD:
                    action = AddTaskView.GetInstance();
                    break;
                case EActionMethod.FIND:
                    action = FindTaskView.GetInstance();
                    break;
                default:
                    break;
            }
            return action;
        }
    }
}
