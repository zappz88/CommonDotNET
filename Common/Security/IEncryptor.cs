﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Security
{
    public interface IEncryptor
    {
        string Encrypt(string val);

        string Decrypt(string val);
    }
}
