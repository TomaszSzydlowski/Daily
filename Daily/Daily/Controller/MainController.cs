using Daily.Controller;
using Daily.Helpers;
using Daily.Model;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Daily
{
    public class MainController
    {
        private static MainController instance = new MainController();
        private XDocument XDoc { get => GetXDocument.GetInstance().Get(); }

        private MainController()
        {

        }

        public static MainController GetInstance()
        {
            return instance;
        }

        public void Start(string[] args)
        {
            var validArg = new ValidArg(args);
            var postAction = Action(validArg);

            Save(postAction.XDoc);
            View(validArg,postAction.TaskRepos);
        }

        private void View(IValidArg validArg, List<TaskRepo> taskRepos)
        {
            var view = ViewController.GetInstance().CreateView(validArg.Action);
            view.Show(taskRepos);
        }

        private PostActionRepo Action(IValidArg validArg)
        {
            var action = ActionController.GetInstance().CreateAction(validArg.Action);

            var postAction = action.Exec(XDoc, validArg.Content);

            return postAction;
        }

        private void Save(XDocument xDoc)
        {
            SaveXDocument.GetInstance().Save(xDoc);
        }
    }
}
