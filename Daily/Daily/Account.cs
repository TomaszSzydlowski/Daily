using Daily.Helpers.Interfaces;
using Daily.View;
using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;

namespace Daily.Controller
{
    public class Account : IAccount
    {
        private static IConsoleReadKey _consoleKey;
        private static IConsoleReadLine _consoleLine;
        private static IEncryptController _encryptController;
        private static IGetXDocument _xDocument;
        private static IActionBase _actionBase;

        private static Account instance = new Account();

        private Account() { }

        public static Account GetInstance(IConsoleReadKey consoleKey, IConsoleReadLine consoleLine, IEncryptController encryptController, IGetXDocument xDocument, IActionBase actionBase)
        {
            _consoleKey = consoleKey;
            _consoleLine = consoleLine;
            _encryptController = encryptController;
            _xDocument = xDocument;
            _actionBase = actionBase;

            return instance;
        }

        public bool LogIn()
        {
            try
            {
                _encryptController.SecureString = GetPassword();

                var xDoc = _xDocument.Get();
                var postActionRepo = _actionBase.Exec(xDoc);

                _encryptController.DecryptXDoc(postActionRepo.TaskRepos);

                ViewBase.LogInSuccess();
                return true;
            }
            catch (CryptographicException)
            {
                ViewBase.LogInFailed();
                return false;
            }
            catch (Exception ex)
            {
                ViewBase.SomethingWentWrong();
                Console.WriteLine(ex);
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
                key = _consoleKey.ReadKey(true);

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
            List<string> result = new List<string>();

            Console.Write("Command: ");
            var command = _consoleLine.ReadLine();
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
