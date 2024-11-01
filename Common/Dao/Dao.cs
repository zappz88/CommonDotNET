using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Common.Database;

namespace Common.Dao
{
    public class Dao
    {
        protected readonly AbstractDbContextDao AbstractDbContextDao;

        public Dao() { }

        public Dao(DbContextDaoType dbContextDaoType)
        {
            this.AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoType);
        }

        public Dao(DbContextDaoType dbContextDaoType, string connectionString)
        {
            this.AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoType, connectionString);
        }

        public Dao(DbContextDaoType dbContextDaoType, IConnectionStringProvider connectionStringProvider)
        {
            this.AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoType, connectionStringProvider);
        }

        public Dao(string dbContextDaoTypeString)
        {
            this.AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoTypeString);
        }

        public Dao(string dbContextDaoTypeString, string connectionString)
        {
            this.AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoTypeString, connectionString);
        }

        public Dao(string dbContextDaoTypeString, IConnectionStringProvider connectionStringProvider)
        {
            this.AbstractDbContextDao = DbContextDaoFactory.GetDbContextDao(dbContextDaoTypeString, connectionStringProvider);
        }
    }
}
