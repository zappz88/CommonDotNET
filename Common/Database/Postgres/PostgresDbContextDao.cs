using System.Data.Common;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace Common.Database.Postgres
{
    public class PostgresDbContextDao : DbContextDao
    {
        public PostgresDbContextDao(string connectionString) : base(connectionString) { }

        public PostgresDbContextDao(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) { }

        public override T ExecuteScalar<T>(string sql, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            NpgsqlParameter[] npgsqlParameters = (NpgsqlParameter[])dbParameters;

            T result = default;

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(this.ConnectionString))
            {
                try
                {
                    npgsqlConnection.Open();
                    NpgsqlCommand npgsqlCommand = (NpgsqlCommand)this.CreateCommand(sql, commandType, commandTimeout);
                    if (npgsqlParameters != null)
                    {
                        npgsqlCommand.Parameters.AddRange(npgsqlParameters);
                    }
                    result = (T)npgsqlCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    npgsqlConnection.Close();
                }
            }


            return result;
        }

        public override T ExecuteScalar<T>(string sql, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            DbParameter[] dbParameterArray = dbParameters.ToArray();
            return ExecuteScalar<T>(sql, dbParameterArray, commandType, commandTimeout);
        }

        public override IList<T> ExecuteReader<T>(string sql, Func<IDataReader, IList<T>> func, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            NpgsqlParameter[] npgsqlParameters = (NpgsqlParameter[])dbParameters;

            IList<T> result = default;

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(this.ConnectionString))
            {
                try
                {
                    npgsqlConnection.Open();
                    NpgsqlCommand npgsqlCommand = (NpgsqlCommand)this.CreateCommand(sql, commandType, commandTimeout);
                    if (npgsqlParameters != null)
                    {
                        npgsqlCommand.Parameters.AddRange(npgsqlParameters);
                    }
                    result = func(npgsqlCommand.ExecuteReader());
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    npgsqlConnection.Close();
                }
            }

            return result;
        }

        public override IList<T> ExecuteReader<T>(string sql, Func<IDataReader, IList<T>> func, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            DbParameter[] dbParameterArray = dbParameters.ToArray();
            return ExecuteReader(sql, func, dbParameterArray, commandType, commandTimeout);
        }

        public override int ExecuteNonQuery(string sql, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            NpgsqlParameter[] npgsqlParameters = (NpgsqlParameter[])dbParameters;

            int result = 0;

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(this.ConnectionString))
            {
                try
                {
                    npgsqlConnection.Open();
                    NpgsqlCommand npgsqlCommand = (NpgsqlCommand)this.CreateCommand(sql, commandType, commandTimeout);
                    if (npgsqlParameters != null)
                    {
                        npgsqlCommand.Parameters.AddRange(npgsqlParameters);
                    }
                    result = npgsqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    npgsqlConnection.Close();
                }
            }

            return result;
        }

        public override int ExecuteNonQuery(string sql, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            DbParameter[] dbParameterArray = dbParameters.ToArray();
            return ExecuteNonQuery(sql, dbParameterArray, commandType, commandTimeout);
        }

        public override DbParameter CreateParameter(string name, object value, DbType dbType = DbType.String, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            NpgsqlParameter npgsqlParameter = new NpgsqlParameter(name, value);
            npgsqlParameter.NpgsqlDbType = (NpgsqlDbType)dbType;
            npgsqlParameter.Direction = parameterDirection;
            return npgsqlParameter;
        }

        public override DbCommand CreateCommand(string sql, CommandType commandType, int commandTimeout)
        {
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sql);
            npgsqlCommand.CommandType = commandType;
            npgsqlCommand.CommandTimeout = commandTimeout;
            return npgsqlCommand;
        }
    }
}
