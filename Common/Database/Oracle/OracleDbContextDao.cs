using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Common;

namespace Common.Database.Oracle
{
    public class OracleDbContextDao : AbstractDbContextDao
    {
        public OracleDbContextDao() : base() { }

        public OracleDbContextDao(string connectionString) : base(connectionString) { }

        public OracleDbContextDao(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider) { }

        public override T ExecuteScalar<T>(string sql, DbParameter[] dbParameters = null, CommandType commandType = CommandType.Text, int commandTimeout = 400)
        {
            OracleParameter[] oracleParameters = (OracleParameter[])dbParameters;

            T result = default;

            using (OracleConnection oracleConnection = new OracleConnection(ConnectionString))
            {
                try
                {
                    oracleConnection.Open();
                    OracleCommand oracleCommand = (OracleCommand)CreateCommand(sql, commandType, commandTimeout);
                    if (oracleParameters != null)
                    {
                        oracleCommand.Parameters.AddRange(oracleParameters);
                    }
                    result = (T)oracleCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    oracleConnection.Close();
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
            OracleParameter[] oracleParameters = (OracleParameter[])dbParameters;

            IList<T> result = default;

            using (OracleConnection oracleConnection = new OracleConnection(ConnectionString))
            {
                try
                {
                    oracleConnection.Open();
                    OracleCommand oracleCommand = (OracleCommand)CreateCommand(sql, commandType, commandTimeout);
                    if (oracleParameters != null)
                    {
                        oracleCommand.Parameters.AddRange(oracleParameters);
                    }
                    result = func(oracleCommand.ExecuteReader());
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    oracleConnection.Close();
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
            OracleParameter[] oracleParameters = (OracleParameter[])dbParameters;

            int result = 0;

            using (OracleConnection oracleConnection = new OracleConnection(ConnectionString))
            {
                try
                {
                    oracleConnection.Open();
                    OracleCommand oracleCommand = (OracleCommand)CreateCommand(sql, commandType, commandTimeout);
                    if (oracleParameters != null)
                    {
                        oracleCommand.Parameters.AddRange(oracleParameters);
                    }
                    result = oracleCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    oracleConnection.Close();
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
            string oracleParameterName = $@":{name}";
            OracleParameter oracleParameter = new OracleParameter(oracleParameterName, value);
            oracleParameter.OracleDbType = (OracleDbType)dbType;
            oracleParameter.Direction = parameterDirection;
            return oracleParameter;
        }

        public override DbCommand CreateCommand(string sql, CommandType commandType, int commandTimeout)
        {
            OracleCommand oracleCommand = new OracleCommand(sql);
            oracleCommand.CommandType = commandType;
            oracleCommand.CommandTimeout = commandTimeout;
            return oracleCommand;
        }
    }
}
