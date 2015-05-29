using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoStringify
{
    internal static class HMACHashHelper
    {
        private static readonly UTF8Encoding Encoding;

        static HMACHashHelper()
        {
            Encoding = new UTF8Encoding();
        }

        public static string Hash(KeyedHashAlgorithm keyedHashAlgorithm, string toHash, string salt)
        {
            keyedHashAlgorithm.Key = Encoding.GetBytes(salt);
            return HashHelper.Hash(keyedHashAlgorithm, toHash);
        }
    }
}
