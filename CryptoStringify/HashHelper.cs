using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CryptoStringify
{
    internal static class HashHelper
    {
        private static readonly UTF8Encoding Encoding;

        static HashHelper()
        {
            Encoding = new UTF8Encoding();
        }

        public static string Hash(HashAlgorithm hashAlgorithm, string toHash)
        {
            return HashWithoutSalt(hashAlgorithm, toHash);
        }

        private static string HashWithoutSalt(HashAlgorithm hashAlgorithm, string toHash)
        {
            var messageBytes = Encoding.GetBytes(toHash);
            var hash = hashAlgorithm.ComputeHash(messageBytes);
            return new String(hash.SelectMany(h => h.ToString("x2")).ToArray());
        }
    }
}
