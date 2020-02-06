using Daily.Model;
using Encryptor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Daily.Cryptography
{
    public sealed class EncryptController
    {
        private static EncryptController instance = new EncryptController();

        private byte[] IV = Convert.FromBase64String(AppSettings.GetInstance().Read("IV"));
        private byte[] Key = Convert.FromBase64String(AppSettings.GetInstance().Read("Key"));

        private EncryptController()
        {

        }

        public static EncryptController GetInstance()
        {
            return instance;
        }

        public string EncryptXDoc(string content)
        {
            return Encryption.EncryptString(content, Key, IV);
        }

        public void DecryptXDoc(List<TaskRepo> taskRepos)
        {
            foreach (var taskRepo in taskRepos)
            {
                taskRepo.Content = Encryption.DecryptString(taskRepo.Content, Key, IV);
            }
        }
    }
}
