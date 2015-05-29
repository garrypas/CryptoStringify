using CryptoStringify;

namespace System.Security.Cryptography
{
    public static class Extensions
    {
        public static string Hash(this KeyedHashAlgorithm sha1, string toHash, string salt)
        {
            return HMACHashHelper.Hash(sha1, toHash, salt);
        }

        public static string Hash(this HashAlgorithm sha1, string toHash)
        {
            return HashHelper.Hash(sha1, toHash);
        }
    }
}
