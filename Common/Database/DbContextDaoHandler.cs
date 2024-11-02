using System.Data;
using System.Data.Common;

namespace Common.Database
{
    public class DbContextDaoHandler
    {
        #region prop
        protected readonly AbstractDbContextDao AbstractDbContextDao;
        #endregion

        #region ctor
        public DbContextDaoHandler() { }

        public DbContextDaoHandler(DbContextDaoType dbContextDaoType)
        {
            AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoType);
        }

        public DbContextDaoHandler(DbContextDaoType dbContextDaoType, string connectionString)
        {
            AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoType, connectionString);
        }

        public DbContextDaoHandler(DbContextDaoType dbContextDaoType, IConnectionStringProvider connectionStringProvider)
        {
            AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoType, connectionStringProvider);
        }

        public DbContextDaoHandler(string dbContextDaoTypeString)
        {
            AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoTypeString);
        }

        public DbContextDaoHandler(string dbContextDaoTypeString, string connectionString)
        {
            AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoTypeString, connectionString);
        }

        public DbContextDaoHandler(string dbContextDaoTypeString, IConnectionStringProvider connectionStringProvider)
        {
            AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoTypeString, connectionStringProvider);
        }
        #endregion

        #region public
        public T ExecuteScalar<T>(string sql, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            return AbstractDbContextDao.ExecuteScalar<T>(sql, dbParameters, commandType, commandTimeout);
        }

        public T ExecuteScalar<T>(string sql, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            return AbstractDbContextDao.ExecuteScalar<T>(sql, dbParameters, commandType, commandTimeout);
        }

        public IList<T> ExecuteReader<T>(string sql, Func<IDataReader, IList<T>> func, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            return AbstractDbContextDao.ExecuteReader(sql, func, dbParameters, commandType, commandTimeout);
        }

        public IList<T> ExecuteReader<T>(string sql, Func<IDataReader, IList<T>> func, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            return AbstractDbContextDao.ExecuteReader(sql, func, dbParameters, commandType, commandTimeout);
        }

        public int ExecuteNonQuery(string sql, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            return AbstractDbContextDao.ExecuteNonQuery(sql, dbParameters, commandType, commandTimeout);
        }

        public int ExecuteNonQuery(string sql, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            return AbstractDbContextDao.ExecuteNonQuery(sql, dbParameters, commandType, commandTimeout);
        }

        public DbCommand CreateCommand(DbConnection dbConnection, string sql, CommandType commandType, int commandTimeout)
        {
            return AbstractDbContextDao.CreateCommand(dbConnection, sql, commandType, commandTimeout);
        }

        public DbParameter CreateParameter(string name, object value, DbType dbType = DbType.String, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return AbstractDbContextDao.CreateParameter(name, value, dbType, parameterDirection);
        }

        public string FormatParameterName(string name)
        {
            return AbstractDbContextDao.FormatParameterName(name);
        }
        #endregion
    }
}
