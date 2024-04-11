using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CryptLibraryBGA
{
    public class BGAKeys
    {
        public string[] GenerateKeyPair(int keySize = 2048)
        {
            // Generar un par de claves RSA
            using (var rsa = new RSACryptoServiceProvider(keySize))
            {
                // Exportar la clave pública
                var publicKeyXml = rsa.ToXmlString(false);

                // Exportar la clave privada
                var privateKeyXml = rsa.ToXmlString(true);

                // Almacenar las claves en archivos
                return new[] {privateKeyXml, publicKeyXml};
            }
        }

        public string EncryptText(string plainText, string publicKeyXml)
        {
            var dataToEncrypt = Encoding.UTF8.GetBytes(plainText);

            // Importar la clave pública
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKeyXml);

                // Encriptar los datos
                var encryptedData = rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.OaepSHA1);
                return Convert.ToBase64String(encryptedData);
            }
        }

        public string DecryptText(string encryptedData, string privateKeyXml)
        {
            var dataToDecrypt = Convert.FromBase64String(encryptedData);

            // Importar la clave privada
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKeyXml);

                // Desencriptar los datos
                var decryptedData = rsa.Decrypt(dataToDecrypt, RSAEncryptionPadding.OaepSHA1);
                return Encoding.UTF8.GetString(decryptedData);
            }
        }
        
        public string Encrypt(String text, String JsonPath)
        {
            string textJson = File.ReadAllText(JsonPath);
            string encrypt = EncryptText(text, textJson);
            return encrypt;
        }

        public string Decrypt(String textCrypt, String JsonPath)
        {
            string textJson = File.ReadAllText(JsonPath);
            string decrypt = DecryptText(textCrypt, textJson);
            return decrypt;
        }
    }
}