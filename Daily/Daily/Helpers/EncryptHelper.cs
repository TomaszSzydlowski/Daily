using Daily.Actions;
using Daily.Controller;
using Daily.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            EncryptController.GetInstance().SecureString = Account.GetInstance().GetPassword();

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
            ClearCurrentConsoleLine();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine($"Encrypted {i}/{count}");
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }


    }
}
