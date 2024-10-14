using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Common.Database
{
    public class Dao
    {
        public DbContextDao DbContextDao { get; set; }

        public Dao() { }

        public Dao(DbContextDao dbContextDao) 
        { 
            this.DbContextDao = dbContextDao;
        }

        public Dao(DbContextDaoType dbContextDaoType) 
        {
            this.DbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoType);
        }

        public int test(string integer) 
        {
            string sql = "testsql";
            int test = this.DbContextDao.ExecuteScalar<int>
            (
                sql, 
                [
                    this.DbContextDao.CreateParameter("INT", integer, DbType.String)
                ]
            );
            return test;
        }
    }
}
