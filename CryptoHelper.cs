using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ponyville_School
{
    public static class CryptoHelper
    {
        public static string Encrypt(string plainText)
        {
            byte[] data = Encoding.UTF8.GetBytes(plainText);

            byte[] encrypted =
                ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] data = Convert.FromBase64String(encryptedText);

            byte[] decrypted =
                ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            Logger.Write("Программа расшифровала данные: " + encryptedText);
            return Encoding.UTF8.GetString(decrypted);
        }
    }
}
