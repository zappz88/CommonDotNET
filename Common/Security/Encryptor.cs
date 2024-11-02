using System.Text;

namespace Common.Security
{
    public class Encryptor : IEncryptor
    {
        private string Key = "ADMIN";

        public Encryptor() { }

        public string Encrypt(string val)
        {
            string[] result = new string[val.Length];
            for (int i = 0, j = 0; i < Key.Length && j < val.Length; i++, j++)
            {
                if (i == Key.Length || j < val.Length)
                {
                    i = 0;
                }
                int keyCharCode = Encoding.UTF8.GetBytes(Key[i].ToString())[0];
                int valCharCode = Encoding.UTF8.GetBytes(val[j].ToString())[0];
                int encrypted = (valCharCode * keyCharCode);
                result[j] = encrypted.ToString();
            }
            return string.Join(',', result);
        }

        public string Decrypt(string val)
        {
            byte[] result = new byte[val.Length];
            string[] valArray = val.Split(',');
            for (int i = 0, j = 0; i < Key.Length && j < valArray.Length; i++, j++)
            {
                if (i == Key.Length || j < valArray.Length)
                {
                    i = 0;
                }
                int keyCharCode = Encoding.UTF8.GetBytes(Key[i].ToString())[0];
                int valCharCode = Int32.Parse(valArray[j]);
                int decrypted = (valCharCode / keyCharCode);
                result[j] = (byte)decrypted;
            }
            return Encoding.UTF8.GetString(result);
        }
    }
}
