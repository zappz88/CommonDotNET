using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace Common.Database.MySql
{
    public class MySqlDbContextDao : AbstractDbContextDao
    {
        public MySqlDbContextDao() : base() { }

        public MySqlDbContextDao(string connectionString) : base(connectionString) { }

        public MySqlDbContextDao(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) { }

        public override T ExecuteScalar<T>(string sql, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            MySqlParameter[] mySqlParameters = (MySqlParameter[])dbParameters;

            T result = default;

            using (MySqlConnection mysqlConnection = new MySqlConnection(this.ConnectionString))
            {
                try
                {
                    mysqlConnection.Open();
                    MySqlCommand mySqlCommand = (MySqlCommand)this.CreateCommand(mysqlConnection, sql, commandType, commandTimeout);
                    if (mySqlParameters != null)
                    {
                        mySqlCommand.Parameters.AddRange(mySqlParameters);
                    }
                    result = (T)mySqlCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    mysqlConnection.Close();
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
            MySqlParameter[] mySqlParameters = (MySqlParameter[])dbParameters;

            IList<T> result = default;

            using (MySqlConnection mysqlConnection = new MySqlConnection(this.ConnectionString))
            {
                try
                {
                    mysqlConnection.Open();
                    MySqlCommand mySqlCommand = (MySqlCommand)this.CreateCommand(mysqlConnection, sql, commandType, commandTimeout);
                    if (mySqlParameters != null)
                    {
                        mySqlCommand.Parameters.AddRange(mySqlParameters);
                    }
                    result = func(mySqlCommand.ExecuteReader());
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    mysqlConnection.Close();
                }
            }

            return result;
        }

        public override IList<T> ExecuteReader<T>(string sql, Func<IDataReader, IList<T>> func, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            DbParameter[] dbParameterArray = dbParameters.ToArray();
            return ExecuteReader<T>(sql, func, dbParameterArray, commandType, commandTimeout);
        }

        public override int ExecuteNonQuery(string sql, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            MySqlParameter[] mySqlParameters = (MySqlParameter[])dbParameters;

            int result = 0;

            using (MySqlConnection mysqlConnection = new MySqlConnection(this.ConnectionString))
            {
                try
                {
                    mysqlConnection.Open();
                    MySqlCommand mySqlCommand = (MySqlCommand)this.CreateCommand(mysqlConnection, sql, commandType, commandTimeout);
                    if (mySqlParameters != null)
                    {
                        mySqlCommand.Parameters.AddRange(mySqlParameters);
                    }
                    result = mySqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    mysqlConnection.Close();
                }
            }

            return result;
        }

        public override int ExecuteNonQuery(string sql, IList<DbParameter> dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            DbParameter[] dbParameterArray = dbParameters.ToArray();
            return ExecuteNonQuery(sql, dbParameterArray, commandType, commandTimeout);
        }

        public override DbCommand CreateCommand(DbConnection dbConnection, string sql, CommandType commandType, int commandTimeout)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql, (MySqlConnection)dbConnection);
            mySqlCommand.CommandType = commandType;
            mySqlCommand.CommandTimeout = commandTimeout;
            return mySqlCommand;

            
        }

        public override DbParameter CreateParameter(string name, object value, DbType dbType = DbType.String, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            string mysqlParameterName = this.FormatParameterName(name);
            MySqlParameter mysSqlParameter = new MySqlParameter(mysqlParameterName, value);
            mysSqlParameter.MySqlDbType = (MySqlDbType)dbType;
            mysSqlParameter.Direction = parameterDirection;
            return mysSqlParameter;
        }

        public override string FormatParameterName(string name)
        {
            return $@":{name}";
        }
    }
}
