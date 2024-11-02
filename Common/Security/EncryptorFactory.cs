using Common.EnumUtil;

namespace Common.Security
{
    public enum EncryptorType { Javascript }

    public static class EncryptorFactory
    {
        public static IEncryptor GetEncryptor(EncryptorType encryptorType) 
        {
            IEncryptor encryptor = null;

            switch (encryptorType) 
            { 
                case EncryptorType.Javascript:
                    encryptor = new JavascriptEncryptor();
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
    }
}
