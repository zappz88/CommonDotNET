using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;
using Microsoft.Extensions.Logging;

namespace Common.Database.Sql
{
    public class SqlDbContextDao : DbContextDao
    {
        public SqlDbContextDao(string connectionString) : base(connectionString) { }

        public SqlDbContextDao(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) { }

        public override T ExecuteScalar<T>(string sql, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            SqlParameter[] sqlParameters = (SqlParameter[])dbParameters; 

            T result = default;

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = (SqlCommand)this.CreateCommand(sql, commandType, commandTimeout);
                    if (sqlParameters != null)
                    {
                        sqlCommand.Parameters.AddRange(sqlParameters);
                    }
                    result = (T)sqlCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    sqlConnection.Close();
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
            SqlParameter[] sqlParameters = (SqlParameter[])dbParameters;

            IList<T> result = default;

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = (SqlCommand)this.CreateCommand(sql, commandType, commandTimeout);
                    if (sqlParameters != null)
                    {
                        sqlCommand.Parameters.AddRange(sqlParameters);
                    }
                    result = func(sqlCommand.ExecuteReader());
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    sqlConnection.Close();
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
            SqlParameter[] sqlParameters = (SqlParameter[])dbParameters;

            int result = 0;

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = (SqlCommand)this.CreateCommand(sql, commandType, commandTimeout);
                    if (sqlParameters != null)
                    {
                        sqlCommand.Parameters.AddRange(sqlParameters);
                    }
                    result = sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    sqlConnection.Close();
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
            SqlParameter sqlParameter = new SqlParameter(name, value);
            sqlParameter.SqlDbType = (SqlDbType)dbType;
            sqlParameter.Direction = parameterDirection;
            return sqlParameter;
        }

        public override DbCommand CreateCommand(string sql, CommandType commandType, int commandTimeout)
        {
            SqlCommand sqlCommand = new SqlCommand(sql);
            sqlCommand.CommandType = commandType;
            sqlCommand.CommandTimeout = commandTimeout;
            return sqlCommand;
        }
    }
}
