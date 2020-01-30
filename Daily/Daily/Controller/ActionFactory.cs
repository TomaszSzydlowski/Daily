using Daily.Actions;
using Daily.Helpers;

namespace Daily.Controller
{
    public class ActionFactory
    {
        public virtual IActionBase CreateAction(EActionMethod method)
        {
            IActionBase view = null;
            switch (method)
            {
                case EActionMethod.ADD:
                    view = AddTask.GetInstance();
                    break;
                case EActionMethod.FIND:
                    view = FindTask.GetInstance();
                    break;
                default:
                    break;
            }
            return view;
        }
    }
}
