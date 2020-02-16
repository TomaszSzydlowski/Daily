using Daily.Helpers.Interfaces;
using Encryptor;
using NUnit.Framework;

namespace Daily.Tests
{
    [TestFixture]
    public class EncryptionTests
    {
        private string _fakeInput;
        private byte[] _fakeIV;
        private byte[] _fakeSalt;
        private byte[] _fakeKey;
        private string _fakePassword;

        private IEncryption _encryption;


        [SetUp]
        public void Setup()
        {
            _encryption = Encryption.GetInstance();

            _fakePassword = "password";
            _fakeIV = _encryption.GenerateIV();
            _fakeSalt = _encryption.GenerateSalt();
            _fakeKey = _encryption.CreateKey(_fakePassword, _fakeSalt);
        }

        [Test]
        public void EncryptString()
        {
            //Arange
            _fakeInput = "abc";
            //Act
            var resultEncrypt = _encryption.EncryptString(_fakeInput, _fakeKey, _fakeIV);
            var resultDecrypt = _encryption.DecryptString(resultEncrypt, _fakeKey, _fakeIV);

            //Assert
            Assert.IsNotNull(resultEncrypt);
            Assert.That(resultEncrypt.Length, Is.GreaterThan(0));
            Assert.IsNotNull(resultDecrypt);
            Assert.That(resultDecrypt.Length, Is.GreaterThan(0));
            Assert.That(resultDecrypt, Is.EqualTo(_fakeInput));
        }
    }
}
