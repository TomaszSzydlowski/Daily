using Daily.Actions;
using Daily.Helpers;

namespace Daily.Controller
{
    public sealed class ActionController
    {
        private static ActionController instance = new ActionController();



        private ActionController()
        {

        }
        public static ActionController GetInstance()
        {
            return instance;
        }

        public IActionBase CreateAction(EActionMethod selectedAction)
        {
            IActionBase action;
            var factory = new ActionFactory();
            action = factory.CreateAction(selectedAction);


            return action;
        }
    }
}
