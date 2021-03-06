﻿using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xClient.Core.Encryption;
using xClient.Core.Helper;

namespace xClient.Tests.Core.Encryption
{
    [TestClass]
    public class AESTests
    {
        [TestMethod]
        public void EncryptAndDecryptStringTest()
        {
            var input = Helper.GetRandomName(100);
            var password = Helper.GetRandomName(50);
            var encrypted = AES.Encrypt(input, password);

            Assert.IsNotNull(encrypted);
            Assert.AreNotEqual(encrypted, input);

            var decrypted = AES.Decrypt(encrypted, password);

            Assert.AreEqual(input, decrypted);
        }

        [TestMethod]
        public void EncryptAndDecryptByteArrayTest()
        {
            var input = Helper.GetRandomName(100);
            var inputByte = Encoding.UTF8.GetBytes(input);

            var passwordByte = Encoding.UTF8.GetBytes(Helper.GetRandomName(50));
            var encryptedByte = AES.Encrypt(inputByte, passwordByte);

            Assert.IsNotNull(encryptedByte);
            CollectionAssert.AllItemsAreNotNull(encryptedByte);
            CollectionAssert.AreNotEqual(encryptedByte, inputByte);

            var decryptedByte = AES.Decrypt(encryptedByte, passwordByte);

            CollectionAssert.AreEqual(inputByte, decryptedByte);
        }
    }
}