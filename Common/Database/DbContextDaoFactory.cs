using Common.Database.Oracle;
using Common.Database.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{
    public enum DbContextDaoType { Sql, Oracle, MySql, Postgres }

    public static class DbContextDaoFactory
    {
        public static DbContextDao GetDbContextDao(DbContextDaoType dbContextDaoType, string connectionString) 
        {
            DbContextDao dbContextDao = null;

            switch (dbContextDaoType) 
            { 
                case DbContextDaoType.Sql:
                    dbContextDao = new SqlDbContextDao(connectionString); 
                    break;
                case DbContextDaoType.Oracle:
                    dbContextDao = new OracleDbContextDao(connectionString);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return dbContextDao;
        }

        public static DbContextDao GetDbContextDao(DbContextDaoType dbContextDaoType, IConnectionStringProvider connectionStringProvider)
        {
            DbContextDao dbContextDao = null;

            switch (dbContextDaoType)
            {
                case DbContextDaoType.Sql:
                    dbContextDao = new SqlDbContextDao(connectionStringProvider);
                    break;
                case DbContextDaoType.Oracle:
                    dbContextDao = new OracleDbContextDao(connectionStringProvider);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return dbContextDao;
        }
    }
}
