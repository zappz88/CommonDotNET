using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Encryption
{
    public class Base64BasicEncryptor : IEncryptor
    {
        private string Key = "ADMIN"; 

        public Base64BasicEncryptor() { }

        public Base64BasicEncryptor(string key) 
        { 
            this.Key = key;
        }

        public string Encrypt(string val) 
        {
            IEncryptor encryptor = new Encryptor(this.Key);
            IEncryptor base64Encryptor = new Base64BasicEncryptor();

            string base64EncryptedString = base64Encryptor.Encrypt(val);
            string encryptedString = encryptor.Encrypt(base64EncryptedString);
            
            return encryptedString;
        }

        public string Decrypt(string val)
        {
            IEncryptor encryptor = new Encryptor(this.Key);
            IEncryptor base64Encryptor = new Base64BasicEncryptor();

            if (!IsBasicEncrypted(val))
            {
                return val;
            }

            string decryptedString = encryptor.Decrypt(val);
            string base64DecryptedString = base64Encryptor.Decrypt(decryptedString);
            return decryptedString;
        }

        private bool IsBase64Encrypted(string val)
        {
            return Regex.IsMatch(val, RegexPattern.Base64Encryption);
        }

        private bool IsBasicEncrypted(string val)
        {
            return Regex.IsMatch(val, RegexPattern.BaseEncryption);
        }
    }
}
