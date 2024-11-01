using Common.Database;
using Common.Model;
using System.Data.Common;

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
            string sql = "INSERT INTO DBO.BETATEST.USERS (FIRST_NAME, MIDDLE_NAME, lAST_NAME, AGE) VALUES (@FIRST_NAME, @MIDDLE_NAME, @LAST_NAME, @AGE);";
            IList<DbParameter> dbParameters = new List<DbParameter>()
            {
                this.AbstractDbContextDao.CreateParameter("@FIRST_NAME", firstName),
                this.AbstractDbContextDao.CreateParameter("@MIDDLE_NAME", middleName),
                this.AbstractDbContextDao.CreateParameter("@LAST_NAME", lastName),
                this.AbstractDbContextDao.CreateParameter("@AGE", age)
            };
            return this.AbstractDbContextDao.ExecuteNonQuery(sql, dbParameters);
        }

        public User GetUserById(int userId)
        {
            string sql = "SELECT * FROM DBO.BETATEST.USERS WHERE USER_ID = @ID;";
            IList<DbParameter> dbParameters = new List<DbParameter>()
            {
                this.AbstractDbContextDao.CreateParameter("@ID", userId),
            };
            return this.AbstractDbContextDao.ExecuteScalar<User>(sql, dbParameters);
        }

        public int UpdateUserById(int userId, string firstName, string middleName, string lastName, int age)
        {
            User user = this.GetUserById(userId);
            if (user == null) 
            {
                throw new Exception("User not found.");
            }

            firstName = string.IsNullOrEmpty(firstName) ? user.FirstName : firstName;
            middleName = string.IsNullOrEmpty(middleName) ? user.MiddleName : middleName;
            lastName = string.IsNullOrEmpty(lastName) ? user.FirstName : lastName;

            string sql = "UPDATE DBO.BETATEST.USERS SET FIRST_NAME =  WHERE USER_ID = @ID;";
            IList<DbParameter> dbParameters = new List<DbParameter>()
            {
                this.AbstractDbContextDao.CreateParameter("@ID", userId),
            };
            return this.AbstractDbContextDao.ExecuteNonQuery(sql, dbParameters);
        }

        public int DeleteUserById(int userId)
        {
            string sql = "DELETE FROM DBO.BETATEST.USERS WHERE USER_ID = @ID;";
            IList<DbParameter> dbParameters = new List<DbParameter>()
            {
                this.AbstractDbContextDao.CreateParameter("@ID", userId),
            };
            return this.AbstractDbContextDao.ExecuteNonQuery(sql, dbParameters);
        }
    }
}
