using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CryptoStringify;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoStringifyTests
{
    [TestClass]
    public class MD5ExtensionTests
    {
        private UTF8Encoding _encoding;
        private const string Input = "hello";
        private const string Salt = "salt";

        [TestInitialize]
        public void Setup()
        {
            _encoding = new UTF8Encoding();
        }

        [TestMethod]
        public void HashesCorrectlyWithoutSalt()
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            Assert.AreEqual(GetString(md5Hasher), md5Hasher.Hash(Input));

            var ripemd160Hasher = new RIPEMD160Managed();
            Assert.AreEqual(GetString(ripemd160Hasher), ripemd160Hasher.Hash(Input));
        }

        [TestMethod]
        public void HashesCorrectlyWithSalt()
        {
            var md5Hasher = new HMACMD5(_encoding.GetBytes(Salt));
            Assert.AreEqual(GetString(md5Hasher), md5Hasher.Hash(Input));
            Assert.AreEqual(GetString(md5Hasher), md5Hasher.Hash(Input, Salt));

            var ripemd160Hasher = new HMACRIPEMD160(_encoding.GetBytes(Salt));
            Assert.AreEqual(GetString(ripemd160Hasher), ripemd160Hasher.Hash(Input));
            Assert.AreEqual(GetString(ripemd160Hasher), ripemd160Hasher.Hash(Input, Salt));
        }

        private string GetString(HashAlgorithm hasher1)
        {
            return new String(hasher1.ComputeHash(_encoding.GetBytes(Input)).SelectMany(b => b.ToString("x2")).ToArray());
        }
    }
}
