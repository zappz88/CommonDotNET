using Common.Database;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dao
{
    public class Dao : DbContextDaoHandler
    {
        #region ctor
        public Dao(DbContextDaoType dbContextDaoType, string connectionString) : base(dbContextDaoType, connectionString) { }

        public Dao(DbContextDaoType dbContextDaoType, IConnectionStringProvider connectionStringProvider) : base(dbContextDaoType, connectionStringProvider) { }

        public Dao(string dbContextDaoTypeString, string connectionString) : base(dbContextDaoTypeString, connectionString) { }

        public Dao(string dbContextDaoTypeString, IConnectionStringProvider connectionStringProvider) : base(dbContextDaoTypeString, connectionStringProvider) { }
        #endregion

        protected string ResolveStringIsNullOrWhiteSpace(string val, string replacement) 
        {
            return string.IsNullOrWhiteSpace(val) ? replacement : val;
        }

        protected int ResolveIntIsZero(int val, int replacement)
        {
            return val == 0 ? replacement : val;
        }
    }
}
