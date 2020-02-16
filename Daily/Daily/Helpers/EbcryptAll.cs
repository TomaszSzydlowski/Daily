using Daily.Actions;
using Daily.Controller;
using Daily.Helpers.Interfaces;
using Daily.View;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Daily.Helpers
{
    public class EbcryptAll
    {
        protected static string FilePath => AppSettings.GetInstance().Read("FileDirectory");
        private const string TASKS = "tasks";
        private const string TASK = "task";
        private const string TIME = "time";

        private static IConsoleReadKey _consoleKey;
        private static IConsoleReadLine _consoleLine;
        private static IEncryptController _encryptController;
        private static IGetXDocument _xDocument;
        private static IActionBase _actionBase;

        private static EbcryptAll instance = new EbcryptAll();

        private EbcryptAll() { }

        public static EbcryptAll GetInstance(IConsoleReadKey consoleKey, IConsoleReadLine consoleLine, IEncryptController encryptController, IGetXDocument xDocument, IActionBase actionBase)
        {
            _consoleKey = consoleKey;
            _consoleLine = consoleLine;
            _encryptController = encryptController;
            _xDocument = xDocument;
            _actionBase = actionBase;

            return instance;
        }

        public static void Exec()
        {
            var xDocToEncrypt = _xDocument.Get();
            var postActionRepo = _actionBase.Exec(xDocToEncrypt, "/");
            postActionRepo.XDoc = xDocToEncrypt;
            postActionRepo.XDoc.Descendants(TASK).Remove();

            _encryptController.SecureString = Account.GetInstance(_consoleKey, _consoleLine, _encryptController, _xDocument, _actionBase).GetPassword();

            for (int i = 0; i < postActionRepo.TaskRepos.Count; i++)
            {
                var task = postActionRepo.TaskRepos[i];
                task.Content = _encryptController.EncryptXDoc(task.Content);

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
