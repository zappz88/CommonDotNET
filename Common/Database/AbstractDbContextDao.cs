using System.Data.Common;
using System.Data;

namespace Common.Database
{
    public abstract class AbstractDbContextDao
    {
        public string ConnectionString { get; set; }

        public AbstractDbContextDao() { }

        public AbstractDbContextDao(string connectionString) 
        { 
            this.ConnectionString = connectionString;
        }

        public AbstractDbContextDao(IConnectionStringProvider connectionStringProvider) 
        { 
            this.ConnectionString = connectionStringProvider.GetConnectionString();
        }

        public abstract T ExecuteScalar<T>(string sql, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400);

        public abstract T ExecuteScalar<T>(string sql, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400);

        public abstract IList<T> ExecuteReader<T>(string sql, Func<IDataReader, IList<T>> func, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400);

        public abstract IList<T> ExecuteReader<T>(string sql, Func<IDataReader, IList<T>> func, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400);

        public abstract int ExecuteNonQuery(string sql, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400);

        public abstract int ExecuteNonQuery(string sql, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400);

        public abstract DbCommand CreateCommand(DbConnection dbConnection, string sql, CommandType commandType = CommandType.Text, int commandTimeout = 400);

        public abstract DbParameter CreateParameter(string name, object value, DbType dbType = DbType.AnsiString, ParameterDirection parameterDirection = ParameterDirection.Input);

        public abstract string FormatParameterName(string name);
    }
}
