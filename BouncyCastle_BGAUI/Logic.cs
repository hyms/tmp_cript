using System;
using System.IO;
using System.Text;
using CryptLibraryBGA;

namespace BouncyCastle_BGAUI
{
    class Logic
    {
        private string _publicKey;
        private string _privateKey;
        private string _publicNameFile;
        private string _privateNameFile;
        private BGAKeys _bgaKeys;

        public Logic()
        {
            _bgaKeys = new BGAKeys();
            string[] keys = _bgaKeys.GenerateKeyPair(2048);
            _privateKey = keys[0];
            _publicKey = keys[1];

            _publicNameFile = "publicKey.xml";
            _privateNameFile = "privateKey.xml";
        }

        public string GeneratePublic()
        {
            File.WriteAllText(_publicNameFile, _publicKey, Encoding.UTF8);
            string currentDirectory = Directory.GetCurrentDirectory();
            return Path.Combine(currentDirectory, _publicNameFile);
        }

        public string GeneratePrivate()
        {
            File.WriteAllText(_privateNameFile, _privateKey, Encoding.UTF8);
            string currentDirectory = Directory.GetCurrentDirectory();
            return Path.Combine(currentDirectory, _privateNameFile);
        }

        public string Encrypt(String text, String jsonPath)
        {
            string encrypt = _bgaKeys.Encrypt(text, jsonPath);
            return encrypt;
        }

        public string Decrypt(String textCrypt, String jsonPath)
        {
            string decrypt = _bgaKeys.Decrypt(textCrypt, jsonPath);
            return decrypt;
        }
    }
}