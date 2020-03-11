using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SpeekIO.Common.Extensions
{
    public static class StringExtensions
    {
        public static string Encrypt(this string input)
        {
            Encoding encoding = Encoding.UTF8;
            Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }

            return sbBytes.ToString();

            string EncryptionKey = "ce8ca83f-584f-41c3-a0d9-f8ac25c5616c";
            byte[] clearBytes = Encoding.Unicode.GetBytes(input);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    input = Convert.ToBase64String(ms.ToArray());
                    input = input.Replace(" ", "+");
                }
            }
            return input;
        }

        public static string Decrypt(this string input)
        {
            Encoding encoding = Encoding.UTF8;
            int numberChars = input.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(input.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);

            string EncryptionKey = "ce8ca83f-584f-41c3-a0d9-f8ac25c5616c";
            input = input.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(input);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    input = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return input;
        }

        public static byte[] GetByteArrayFromBase64(this string input)
        {
            return Convert.FromBase64String(input.Split(',')[1]);
        }
		public static bool IsNullOrEmpty(this string input)
		{
			return string.IsNullOrEmpty(input);
		}
		public static string GetTypeFromBase64(this string input)
		{
			return input.Substring(5, 5);
		}
	}
}
