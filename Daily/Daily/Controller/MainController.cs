using Daily.Actions;
using Daily.Helpers;

namespace Daily.Controller
{
    public sealed class MainController
    {
        private static MainController instance = new MainController();



        private MainController()
        {

        }
        public static MainController GetInstance()
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
