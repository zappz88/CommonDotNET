using Common.EnumUtil;

namespace Common.Encryption
{
    public enum EncryptorType { Basic, Base64 }

    public static class EncryptorFactory
    {
        #region
        public static IEncryptor GetEncryptor(EncryptorType encryptorType)
        {
            IEncryptor encryptor = null;

            switch (encryptorType)
            {
                case EncryptorType.Basic:
                    encryptor = new Encryptor();
                    break;
                case EncryptorType.Base64:
                    encryptor = new Base64Encryptor();
                    break;
                default:
                    throw new NotImplementedException();
            }
            return encryptor;
        }

        public static IEncryptor GetEncryptor(string encryptorTypeString)
        {
            EncryptorType encryptorType = EnumHelper.TryParse<EncryptorType>(encryptorTypeString);
            return GetEncryptor(encryptorType);
        }
        #endregion
    }
}
