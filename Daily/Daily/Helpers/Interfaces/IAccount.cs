using System.Security;

namespace Daily.Helpers.Interfaces
{
    public interface IAccount
    {
        string[] GetCommand();
        SecureString GetPassword();
        bool LogIn();
    }
}