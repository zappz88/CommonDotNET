using Common.Database;
using Common.Model;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;

namespace Common.Dao
{
    public class UserDao : Dao
    {
        public UserDao() : base() { }

        public UserDao(DbContextDaoType dbContextDaoType) : base(dbContextDaoType) { }

        public UserDao(DbContextDaoType dbContextDaoType, string connectionString) : base(dbContextDaoType, connectionString) { }

        public UserDao(DbContextDaoType dbContextDaoType, IConnectionStringProvider connectionStringProvider) : base (dbContextDaoType, connectionStringProvider) { }

        public UserDao(string dbContextDaoTypeString) : base(dbContextDaoTypeString) { }

        public UserDao(string dbContextDaoTypeString, string connectionString) : base (dbContextDaoTypeString, connectionString){ }

        public UserDao(string dbContextDaoTypeString, IConnectionStringProvider connectionStringProvider) : base(dbContextDaoTypeString, connectionStringProvider){ }

        public int InsertUser(string firstName, string middleName, string lastName, int age) 
        {
            string sql = "INSERT INTO BETATEST.DBO.USERS (FIRST_NAME, MIDDLE_NAME, LAST_NAME, AGE) " +
                         "VALUES " +
                            "(" +
                                $@"{FormatParameterName("FIRST_NAME")}, " +
                                $@"{FormatParameterName("MIDDLE_NAME")}, " +
                                $@"{FormatParameterName("LAST_NAME")}, " +
                                $@"{FormatParameterName("AGE")} " +
                            ");";
            IList<DbParameter> dbParameters = new List<DbParameter>()
            {
                CreateParameter("FIRST_NAME", firstName),
                CreateParameter("MIDDLE_NAME", middleName),
                CreateParameter("LAST_NAME", lastName),
                CreateParameter("AGE", age),
            };
            return ExecuteNonQuery(sql, dbParameters);
        }

        public User GetUserById(int userId)
        {
            string sql = $@"SELECT * FROM BETATEST.DBO.USERS WHERE USER_ID = {this.AbstractDbContextDao.FormatParameterName("ID")};";
            IList<DbParameter> dbParameters = new List<DbParameter>()
            {
                CreateParameter("ID", userId),
            };
            return ExecuteScalar<User>(sql, dbParameters);
        }

        public int UpdateUserById(int userId, string firstName = "", string middleName = "", string lastName = "", int age = 0)
        {
            User user = this.GetUserById(userId);
            if (user == null) 
            {
                throw new Exception("User not found.");
            }

            firstName = string.IsNullOrEmpty(firstName) ? user.FirstName : firstName;
            middleName = string.IsNullOrEmpty(middleName) ? user.MiddleName : middleName;
            lastName = string.IsNullOrEmpty(lastName) ? user.FirstName : lastName;
            age = age == 0 ? user.Age : age;   

            string sql = "UPDATE BETATEST.DBO.USERS " +
                            $@"SET FIRST_NAME = {FormatParameterName("FIRST_NAME")} " +
                            $@"SET MIDDLE_NAME = {FormatParameterName("MIDDLE_NAME")} " +
                            $@"SET LAST_NAME = {FormatParameterName("LAST_NAME")} " +
                            $@"SET AGE = {FormatParameterName("AGE")} " +
                                $@"WHERE USER_ID = {FormatParameterName("ID")};";
            IList<DbParameter> dbParameters = new List<DbParameter>()
            {
                CreateParameter("FIRST_NAME", firstName),
                CreateParameter("MIDDLE_NAME", middleName),
                CreateParameter("LAST_NAME", lastName),
                CreateParameter("AGE", age),
                CreateParameter("ID", userId),
            };
            return ExecuteNonQuery(sql, dbParameters);
        }

        public int DeleteUserById(int userId)
        {
            string sql = $@"DELETE FROM BETATEST.DBO.USERS WHERE USER_ID = {FormatParameterName("ID")};";
            IList<DbParameter> dbParameters = new List<DbParameter>()
            {
                CreateParameter("ID", userId),
            };
            return ExecuteNonQuery(sql, dbParameters);
        }
    }
}
