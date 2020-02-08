using Daily.Actions;
using Daily.Cryptography;
using Daily.View;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Xml.Linq;

namespace Daily.Controller
{
    public class Account
    {
        private static Account instance = new Account();

        private Account() { }

        public static Account GetInstance()
        {
            return instance;
        }

        public bool LogIn()
        {
            try
            {
                EncryptController.GetInstance().SecureString = GetPassword();

                var xDoc = GetXDocument.GetInstance().Get();
                var postActionRepo = FindFirstTask.GetInstance().Exec(xDoc);

                EncryptController.GetInstance().DecryptXDoc(postActionRepo.TaskRepos);

                ViewBase.LogInSuccess();
                return true;
            }
            catch (Exception)
            {
                ViewBase.LogInFailed();
                return false;
            }
        }
        public SecureString GetPassword()
        {
            SecureString securePwd = new SecureString();
            ConsoleKeyInfo key;

            Console.Write("Enter password: ");
            do
            {
                key = Console.ReadKey(true);

                // Ignore any key out of range.
                if (((int)key.Key) >= 48 && ((int)key.Key <= 90))
                {
                    // Append the character to the password.
                    securePwd.AppendChar(key.KeyChar);
                    Console.Write("*");
                }
                // Exit if Enter key is pressed.
            } while (key.Key != ConsoleKey.Enter);
            return securePwd;
        }

        public string[] GetCommand()
        {
            Console.Write("Command: ");
            var commands = Console.ReadLine();
            Console.WriteLine();

            return commands.Split(' ');
        }
    }
}
