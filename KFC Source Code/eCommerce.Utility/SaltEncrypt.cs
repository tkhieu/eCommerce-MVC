using System;
using System.Security.Cryptography;
using System.Text;

namespace Utility
{
    public class SaltEncrypt
    {
        public static string HashCodeSHA1(string input)
        {
            string result = "";
            const string salt = "!@#$%^&*$%^&*";
            input = input + salt;
            try
            {
                SHA1 hash = SHA1.Create();
                var encoder = new ASCIIEncoding();
                byte[] combined = encoder.GetBytes(input);
                hash.ComputeHash(combined);
                result = Convert.ToBase64String(hash.Hash);
            }
            catch (Exception ex)
            {
                string strerr = "Error in HashCode : " + ex.Message;
            }
            return result;
        }
    }
}
