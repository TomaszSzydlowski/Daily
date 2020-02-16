using Daily.Actions;
using Daily.Helpers;
using Daily.Model;
using System.Collections.Generic;
using System.Xml.Linq;
using Daily.Helpers.Interfaces;
using Encryptor;

namespace Daily.Controller
{
    public class MainController : IMainController
    {
        private static MainController instance = new MainController();

        private IEncryptController _encryptController { get => EncryptController.GetInstance(); }
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
            var validArg = ValidArg.Run(args);
            var postAction = Action(validArg);

            Save(postAction);

            View(validArg, postAction.TaskRepos);
        }

        private void View(IValidArg validArg, List<TaskRepo> taskRepos)
        {
            _encryptController.DecryptXDoc(taskRepos);

            var view = ViewController.GetInstance().CreateView(validArg.Action);
            view.Show(taskRepos);
        }

        private PostActionRepo Action(IValidArg validArg)
        {
            var action = ActionController.GetInstance().CreateAction(validArg.Action);

            var postAction = action.Exec(XDoc, validArg.Content);

            return postAction;
        }

        private void Save(PostActionRepo postActionRepo)
        {
            SaveXDocument.GetInstance().Save(postActionRepo);
        }
    }
}
