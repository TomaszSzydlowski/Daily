using Daily.Actions;
using Daily.Controller;
using Daily.Cryptography;
using Daily.View;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Daily.Helpers
{
    public class EncryptHelper
    {
        protected static string FilePath => AppSettings.GetInstance().Read("FileDirectory");
        private const string TASKS = "tasks";
        private const string TASK = "task";
        private const string TIME = "time";

        public static void EncryptAll()
        {
            var xDocToEncrypt = GetXDocument.GetInstance().Get();
            var postActionRepo = FindTasks.GetInstance().Exec(xDocToEncrypt, "/");
            postActionRepo.XDoc = xDocToEncrypt;
            postActionRepo.XDoc.Descendants(TASK).Remove();

            var consoleService = new ConsoleWrapper();
            EncryptController.GetInstance().SecureString = Account.GetInstance().GetPassword(consoleService);

            for (int i = 0; i < postActionRepo.TaskRepos.Count; i++)
            {
                var task = postActionRepo.TaskRepos[i];
                task.Content = EncryptController.GetInstance().EncryptXDoc(task.Content);

                postActionRepo.XDoc.Element(TASKS).Add(new XElement(TASK, new XAttribute(TIME, task.DataTime), task.Content));

                ShowProgress(i,postActionRepo.TaskRepos.Count);
            }
            postActionRepo.XDoc.Save(FilePath);
        }

        private static void ShowProgress(int i, int count)
        {
            ViewBase.ClearLine();
            Console.Write($"Encrypted {i}/{count}. Please wait...");
        }



    }
}
