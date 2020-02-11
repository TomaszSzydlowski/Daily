using Daily.Actions;
using Daily.Cryptography;
using Daily.Helpers.Interfaces;
using Daily.View;
using System;
using System.Collections.Generic;
using System.Security;

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

        public bool LogIn(IConsoleReadKey consoleReadKey)
        {
            try
            {
                EncryptController.GetInstance().SecureString = GetPassword(consoleReadKey);

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
        public SecureString GetPassword(IConsoleReadKey consoleReadKey)
        {
            SecureString securePwd = new SecureString();
            ConsoleKeyInfo key;

            Console.Write("Enter password: ");
            do
            {
                key = consoleReadKey.ReadKey(true);

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

        public string[] GetCommand(IConsoleReadLine console)
        {
            List<string> result = new List<string>();

            Console.Write("Command: ");
            var command = console.ReadLine();
            var content = GetStringBetweenChars(command);
            var commandAction = RemoveStringBetweenChars(command);
            Console.WriteLine();

            if (!string.IsNullOrEmpty(command))
            {
                if (string.IsNullOrEmpty(commandAction))
                {
                    commandAction = command;
                }

                var commandActionResult = commandAction.Trim().Split(' ');
                result.AddRange(commandActionResult);

                if (!string.IsNullOrEmpty(content))
                {
                    result.Add(content);
                }
            }


            return result.ToArray();
        }

        private string GetStringBetweenChars(string str)
        {
            if (str.Contains('"'))
            {
                int pFrom = str.IndexOf('"') + 1;
                int pTo = str.LastIndexOf('"');

                return str.Substring(pFrom, pTo - pFrom);
            }
            return null;
        }

        private string RemoveStringBetweenChars(string str)
        {
            if (str.Contains('"'))
            {
                int pFrom = str.IndexOf('"');
                int pTo = str.LastIndexOf('"') + 1;

                return str.Remove(pFrom, pTo - pFrom);
            }
            return null;
        }
    }
}
