using System.Security.Cryptography;
using System.Text;

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
