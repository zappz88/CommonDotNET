using System.Data.Common;
using System.Data;

namespace Common.Database
{
    public abstract class DbContextDao : DbContext
    {
        public DbContextDao() { }

        public DbContextDao(string connectionString) : base(connectionString) { }

        public DbContextDao(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) { }

        public abstract T ExecuteScalar<T>(string sql, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400);

        public abstract T ExecuteScalar<T>(string sql, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400);

        public abstract IList<T> ExecuteReader<T>(string sql, Func<IDataReader, IList<T>> func, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400);

        public abstract IList<T> ExecuteReader<T>(string sql, Func<IDataReader, IList<T>> func, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400);

        public abstract int ExecuteNonQuery(string sql, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400);

        public abstract int ExecuteNonQuery(string sql, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400);

        public abstract DbParameter CreateParameter(string name, object value, DbType dbType, ParameterDirection parameterDirection = ParameterDirection.Input);

        public abstract DbCommand CreateCommand(string sql, CommandType commandType = CommandType.Text, int commandTimeout = 400);
    }
}
