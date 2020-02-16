using Daily.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace Encryptor
{
    public sealed class Encryption : IEncryption
    {
        private static Encryption instance = new Encryption();

        private Encryption()
        {

        }

        public static Encryption GetInstance()
        {
            return instance;
        }

        public string EncryptString(string input, byte[] key, byte[] IV)
        {
            using (RijndaelManaged RMCrypto = new RijndaelManaged())
            {
                RMCrypto.Key = key;
                RMCrypto.IV = IV;
                var encryptor = RMCrypto.CreateEncryptor(RMCrypto.Key, RMCrypto.IV);
                var msEncrypt = new MemoryStream();
                var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(input);
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }

        public string DecryptString(string input, byte[] key, byte[] IV)
        {
            using (RijndaelManaged RMCrypto = new RijndaelManaged())
            {
                string text;
                RMCrypto.Key = key;
                RMCrypto.IV = IV;
                var decryptor = RMCrypto.CreateDecryptor(RMCrypto.Key, RMCrypto.IV);
                var cipher = Convert.FromBase64String(input);
                var msDecrypt = new MemoryStream(cipher);
                var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using (var srDecrypt = new StreamReader(csDecrypt))
                {
                    text = srDecrypt.ReadToEnd();
                }
                return text;
            }
        }

        public byte[] GenerateSalt()
        {
            List<byte> Salt = new List<byte>();
            Random rnd = new Random();
            for (int i = 1; i <= 256; i++)
            {
                Salt.Add(Convert.ToByte(rnd.Next(1, 128)));
            }
            return Salt.ToArray();
        }

        public byte[] GenerateIV()
        {
            List<byte> IV = new List<byte>();
            Random rnd = new Random();
            for (int i = 1; i <= 16; i++)
            {
                IV.Add(Convert.ToByte(rnd.Next(0, 128)));
            }
            return IV.ToArray();
        }

        public byte[] CreateKey(string InputKey, byte[] saltBytes)
        {
            using (var key = new Rfc2898DeriveBytes(InputKey, saltBytes, 1200000))
            {
                return key.GetBytes(32);
            }
        }
    }
}