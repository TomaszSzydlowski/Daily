using Daily.Actions;
using Daily.Helpers;

namespace Daily.Controller
{
    public class ActionFactory
    {
        public virtual IActionBase CreateAction(EActionMethod method)
        {
            IActionBase action = null;
            switch (method)
            {
                case EActionMethod.ADD:
                    action = AddTask.GetInstance();
                    break;
                case EActionMethod.FIND:
                    action = FindTask.GetInstance();
                    break;
                default:
                    break;
            }
            return action;
        }
    }
}
