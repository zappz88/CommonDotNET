using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Database
{
    public class JsonConnectionStringProvider : ConnectionStringProvider
    {
        public JsonConnectionStringProvider() : base() { }

        public JsonConnectionStringProvider(string path) : base(path) { }

        public string GetConnectionString() 
        {
            return "";
        }
    }
}
