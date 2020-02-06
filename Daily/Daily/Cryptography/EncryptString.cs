using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace Encryptor
{
    public class Encryption
    {
        public static string EncryptString(string input, byte[] key, byte[] IV)
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

        public static string DecryptString(string input, byte[] key, byte[] IV)
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

        public static byte[] GenerateSalt()
        {
            List<byte> Salt = new List<byte>();
            Random rnd = new Random();
            for (int i = 1; i <= 256; i++)
            {
                Salt.Add(Convert.ToByte(rnd.Next(1, 128)));
            }
            return Salt.ToArray();
        }

        public static byte[] GenerateIV()
        {
            List<byte> IV = new List<byte>();
            Random rnd = new Random();
            for (int i = 1; i <= 16; i++)
            {
                IV.Add(Convert.ToByte(rnd.Next(0, 128)));
            }
            return IV.ToArray();
        }

        public static byte[] CreateKey(string InputKey, byte[] saltBytes)
        {
            using (var key = new Rfc2898DeriveBytes(InputKey, saltBytes, 1200000))
            {
                return key.GetBytes(32);
            }
        }

        public static byte[] GetHMAC(byte[] hashdata, byte[] key)
        {
            HMACSHA512 hmac = new HMACSHA512();
            hmac.Key = key;
            return hmac.ComputeHash(hashdata);
        }
    }
}