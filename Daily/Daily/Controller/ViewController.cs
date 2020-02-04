using Daily.Actions;
using Daily.Helpers;
using Daily.View;

namespace Daily.Controller
{
    public sealed class ViewController
    {
        private static ViewController instance = new ViewController();



        private ViewController()
        {

        }
        public static ViewController GetInstance()
        {
            return instance;
        }

        public IViewBase CreateView(EActionMethod selectedAction)
        {
            IViewBase view;
            var factory = new ViewFactory();
            view = factory.CreateView(selectedAction);


            return view;
        }
    }
}
