﻿namespace Common.Encryption
{
    public static class RegexPattern
    {
        public static string Password = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";

        public static string Base64Encryption = "^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)?$";

        public static string BaseEncryption = "^(\\d+,{1})+(\\d+){1}$";
    }
}
