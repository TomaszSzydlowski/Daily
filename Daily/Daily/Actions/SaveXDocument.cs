﻿using Daily.Controller;
using Daily.Helpers;
using Daily.Helpers.Interfaces;
using Daily.Model;

namespace Daily.Actions
{

    public sealed class SaveXDocument : DailyFileProperty
    {
        private const string TASKS = "tasks";

        private static SaveXDocument instance = new SaveXDocument();

        private SaveXDocument()
        {

        }

        public static SaveXDocument GetInstance()
        {
            return instance;
        }

        public void Save(PostActionRepo postActionRepo)
        {

            if (postActionRepo.XDoc != null && postActionRepo.TaskRepos != null)
            {
                foreach (var task in postActionRepo.TaskRepos)
                {
                    task.Content = EncryptController.GetInstance().EncryptXDoc(task.Content);
                    postActionRepo.XDoc.Element(TASKS).Add(task.GetXElement());
                }

                postActionRepo.XDoc.Save(FilePath);

            }
        }
    }
}
