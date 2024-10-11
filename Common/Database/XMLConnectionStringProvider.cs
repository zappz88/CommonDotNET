using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.Database
{
    public class XMLConnectionStringProvider : ConnectionStringProvider
    {
        public XMLConnectionStringProvider() : base() { }

        public XMLConnectionStringProvider(string path) : base(path) { }

        public string GetConnectionString() 
        {
            return "";
        }
    }
}
