using Common.Database.MySql;
using Common.Database.Oracle;
using Common.Database.Postgres;
using Common.Database.Sql;
using Common.EnumUtil;

namespace Common.Database
{
    public enum DbContextDaoType { Sql, Oracle, MySql, Postgres }

    public static class DbContextDaoFactory
    {
        public static DbContextDao GetDbContextDao(DbContextDaoType dbContextDaoType)
        {
            DbContextDao dbContextDao = null;

            switch (dbContextDaoType)
            {
                case DbContextDaoType.Sql:
                    dbContextDao = new SqlDbContextDao();
                    break;
                case DbContextDaoType.Oracle:
                    dbContextDao = new OracleDbContextDao();
                    break;
                case DbContextDaoType.MySql:
                    dbContextDao = new MySqlDbContextDao();
                    break;
                case DbContextDaoType.Postgres:
                    dbContextDao = new PostgresDbContextDao();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return dbContextDao;
        }

        public static DbContextDao GetDbContextDao(string dbContextDaoTypeString)
        {
            DbContextDaoType dbContextDaoType = EnumHelper.TryParse<DbContextDaoType>(dbContextDaoTypeString);

            DbContextDao dbContextDao = null;

            switch (dbContextDaoType)
            {
                case DbContextDaoType.Sql:
                    dbContextDao = new SqlDbContextDao();
                    break;
                case DbContextDaoType.Oracle:
                    dbContextDao = new OracleDbContextDao();
                    break;
                case DbContextDaoType.MySql:
                    dbContextDao = new MySqlDbContextDao();
                    break;
                case DbContextDaoType.Postgres:
                    dbContextDao = new PostgresDbContextDao();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return dbContextDao;
        }

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
                case DbContextDaoType.MySql:
                    dbContextDao = new MySqlDbContextDao(connectionString);
                    break;
                case DbContextDaoType.Postgres:
                    dbContextDao = new PostgresDbContextDao(connectionString);
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
                case DbContextDaoType.MySql:
                    dbContextDao = new MySqlDbContextDao(connectionStringProvider);
                    break;
                case DbContextDaoType.Postgres:
                    dbContextDao = new PostgresDbContextDao(connectionStringProvider);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return dbContextDao;
        }
    }
}
