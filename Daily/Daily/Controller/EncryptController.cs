using Daily.Model;
using Encryptor;
using System;
using System.Collections.Generic;
using System.Security;
using Daily.Helpers;
using Daily.Helpers.Interfaces;

namespace Daily.Controller
{
    public sealed class EncryptController : IEncryptController
    {
        private static EncryptController instance = new EncryptController();

        private readonly byte[] IV = Convert.FromBase64String(AppSettings.GetInstance().Read("IV"));
        private readonly byte[] Salt = Convert.FromBase64String(AppSettings.GetInstance().Read("Salt"));

        public SecureString SecureString { private get; set; }

        private EncryptController()
        {

        }

        public static EncryptController GetInstance()
        {
            return instance;
        }

        public string EncryptXDoc(string content)
        {
            var key = GetKey();
            return Encryption.EncryptString(content, key, IV);
        }

        private byte[] GetKey()
        {
            var password = new System.Net.NetworkCredential(string.Empty, SecureString).Password;
            var key = Encryption.CreateKey(password, Salt);
            return key;
        }

        public void DecryptXDoc(List<TaskRepo> taskRepos)
        {
            var key = GetKey();
            foreach (var taskRepo in taskRepos)
            {
                taskRepo.Content = Encryption.DecryptString(taskRepo.Content, key, IV);
            }
        }
    }
}
