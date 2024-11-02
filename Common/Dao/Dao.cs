using System.Data;
using System.Data.Common;
using Common.Database;

namespace Common.Dao
{
    public class Dao
    {
        protected readonly AbstractDbContextDao AbstractDbContextDao;

        public Dao() { }

        public Dao(DbContextDaoType dbContextDaoType)
        {
            this.AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoType);
        }

        public Dao(DbContextDaoType dbContextDaoType, string connectionString)
        {
            this.AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoType, connectionString);
        }

        public Dao(DbContextDaoType dbContextDaoType, IConnectionStringProvider connectionStringProvider)
        {
            this.AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoType, connectionStringProvider);
        }

        public Dao(string dbContextDaoTypeString)
        {
            this.AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoTypeString);
        }

        public Dao(string dbContextDaoTypeString, string connectionString)
        {
            this.AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoTypeString, connectionString);
        }

        public Dao(string dbContextDaoTypeString, IConnectionStringProvider connectionStringProvider)
        {
            this.AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoTypeString, connectionStringProvider);
        }

        public T ExecuteScalar<T>(string sql, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            return this.AbstractDbContextDao.ExecuteScalar<T>(sql, dbParameters, commandType, commandTimeout);
        }

        public T ExecuteScalar<T>(string sql, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            return this.AbstractDbContextDao.ExecuteScalar<T>(sql, dbParameters, commandType, commandTimeout);
        }

        public IList<T> ExecuteReader<T>(string sql, Func<IDataReader, IList<T>> func, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            return this.AbstractDbContextDao.ExecuteReader(sql, func, dbParameters, commandType, commandTimeout);
        }

        public IList<T> ExecuteReader<T>(string sql, Func<IDataReader, IList<T>> func, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            return this.AbstractDbContextDao.ExecuteReader(sql, func, dbParameters, commandType, commandTimeout);
        }

        public int ExecuteNonQuery(string sql, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            return this.AbstractDbContextDao.ExecuteNonQuery(sql, dbParameters, commandType, commandTimeout);
        }

        public int ExecuteNonQuery(string sql, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            return this.AbstractDbContextDao.ExecuteNonQuery(sql, dbParameters, commandType, commandTimeout);
        }

        public DbCommand CreateCommand(DbConnection dbConnection, string sql, CommandType commandType, int commandTimeout)
        {
            return this.AbstractDbContextDao.CreateCommand(dbConnection, sql, commandType, commandTimeout);
        }

        public DbParameter CreateParameter(string name, object value, DbType dbType = DbType.String, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return this.AbstractDbContextDao.CreateParameter(name, value, dbType, parameterDirection);
        }

        public string FormatParameterName(string name)
        {
            return this.AbstractDbContextDao.FormatParameterName(name);
        }
    }
}
