using Daily.Actions;
using Daily.Helpers;
using Daily.Helpers.Interfaces;

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
                    action = FindTasks.GetInstance();
                    break;
                case EActionMethod.FINDYESTERDAY:
                    action = FindYesterdayTasks.GetInstance();
                    break;
                case EActionMethod.FINDTODAY:
                    action = FindTodayTasks.GetInstance();
                    break;
                default:
                    break;
            }
            return action;
        }
    }
}
