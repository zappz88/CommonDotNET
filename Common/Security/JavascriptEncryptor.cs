using System.Text;
using System.Text.RegularExpressions;

namespace Common.Security
{
    public class JavascriptEncryptor : IEncryptor
    {
        #region ctor
        public JavascriptEncryptor() { }
        #endregion

        #region public
        //btoa encoding
        public string Encrypt(string val) 
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(val));
        }

        //atob decoding
        public string Decrypt(string val)
        {
            if (IsBase64Encrypted(val)) 
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(val));
            }
            return val;
        }
        #endregion

        #region private
        private bool IsBase64Encrypted(string val) 
        {
            return Regex.IsMatch(val, RegexPattern.Base64);
        }
        #endregion
    }
}
