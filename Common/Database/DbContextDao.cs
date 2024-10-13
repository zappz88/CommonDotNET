using System.Data.Common;
using System.Data;

namespace Common.Database
{
    public abstract class DbContextDao : DbContext
    { 
        public DbContextDao(string connectionString) : base(connectionString) { }

        public DbContextDao(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) { }

        public abstract T ExecuteScalar<T>(string sql, DbParameter[] dbParameters, CommandType commandType, int commandTimeout);

        public abstract T ExecuteScalar<T>(string sql, IList<DbParameter> dbParameters, CommandType commandType, int commandTimeout);

        public abstract IList<T> ExecuteReader<T>(string sql, Func<IDataReader, IList<T>> func, DbParameter[] dbParameters, CommandType commandType, int commandTimeout);

        public abstract IList<T> ExecuteReader<T>(string sql, Func<IDataReader, IList<T>> func, IList<DbParameter> dbParameters, CommandType commandType, int commandTimeout);

        public abstract int ExecuteNonQuery(string sql, DbParameter[] dbParameters, CommandType commandType, int commandTimeout);

        public abstract int ExecuteNonQuery(string sql, IList<DbParameter> dbParameters, CommandType commandType, int commandTimeout);

        public abstract DbParameter CreateParameter(string name, object value, DbType dbType, ParameterDirection parameterDirection);

        public abstract DbCommand CreateCommand(string sql, CommandType commandType, int commandTimeout);
    }
}
