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
    public class SHAExtensionTests
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
        public void SHA1HashesCorrectlyWithSalt()
        {
            var hasher1 = new HMACSHA1(_encoding.GetBytes(Salt));
            Assert.AreEqual(GetString(hasher1), new HMACSHA1(_encoding.GetBytes(Salt)).Hash(Input));
            Assert.AreEqual(GetString(hasher1), new HMACSHA1().Hash(Input, Salt));
        }

        [TestMethod]
        public void SHA256HashesCorrectlyWithSalt()
        {
            var hasher256 = new HMACSHA256(_encoding.GetBytes(Salt));
            Assert.AreEqual(GetString(hasher256), new HMACSHA256(_encoding.GetBytes(Salt)).Hash(Input));
            Assert.AreEqual(GetString(hasher256), new HMACSHA256().Hash(Input, Salt));
        }

        [TestMethod]
        public void SHA384HashesCorrectlyWithSalt()
        {
            var hasher384 = new HMACSHA384(_encoding.GetBytes(Salt));
            Assert.AreEqual(GetString(hasher384), new HMACSHA384(_encoding.GetBytes(Salt)).Hash(Input));
            Assert.AreEqual(GetString(hasher384), new HMACSHA384().Hash(Input, Salt));
        }

        [TestMethod]
        public void SHA512HashesCorrectlyWithSalt()
        {
            var hasher512 = new HMACSHA512(_encoding.GetBytes(Salt));
            Assert.AreEqual(GetString(hasher512), new HMACSHA512(_encoding.GetBytes(Salt)).Hash(Input));
            Assert.AreEqual(GetString(hasher512), new HMACSHA512().Hash(Input, Salt));
        }

        [TestMethod]
        public void SHA1HashesCorrectlyWithoutSalt()
        {
            var hasher1 = new SHA1CryptoServiceProvider();
            Assert.AreEqual(hasher1.Hash(Input), hasher1.Hash(Input));
        }

        [TestMethod]
        public void SHA256HashesCorrectlyWithoutSalt()
        {
            var hasher256 = new SHA256CryptoServiceProvider();
            Assert.AreEqual(hasher256.Hash(Input), hasher256.Hash(Input));
        }

        [TestMethod]
        public void SHA384HashesCorrectlyWithoutSalt()
        {
            var hasher384 = new SHA384CryptoServiceProvider();
            Assert.AreEqual(hasher384.Hash(Input), hasher384.Hash(Input));
        }

        [TestMethod]
        public void SHA512HashesCorrectlyWithoutSalt()
        {
            var hasher512 = new SHA512CryptoServiceProvider();
            Assert.AreEqual(hasher512.Hash(Input), hasher512.Hash(Input));
        }

        private string GetString(HashAlgorithm hasher1)
        {
            return new String(hasher1.ComputeHash(_encoding.GetBytes(Input)).SelectMany(b => b.ToString("x2")).ToArray());
        }
    }
}
