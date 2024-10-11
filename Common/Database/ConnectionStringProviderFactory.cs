using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{
    public enum ConnectionStringProviderType { XML, JSON };

    public static class ConnectionStringProviderFactory
    {
        public static IConnectionStringProvider GetConnectionStringProvider(ConnectionStringProviderType connectionStringProviderType) 
        { 
            IConnectionStringProvider connectionStringProvider = null;

            switch (connectionStringProviderType)
            {
                case ConnectionStringProviderType.XML:
                    connectionStringProvider = new XMLConnectionStringProvider();
                    break;
                case ConnectionStringProviderType.JSON:
                    connectionStringProvider = new JsonConnectionStringProvider();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return connectionStringProvider;
        }
    }
}
