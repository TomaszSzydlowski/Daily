using Daily.Model;
using System.Collections.Generic;
using System.Security;

namespace Daily.Helpers.Interfaces
{
    public interface IEncryptController
    {
        SecureString SecureString { set; }

        void DecryptXDoc(List<TaskRepo> taskRepos);
        string EncryptXDoc(string content);
    }
}