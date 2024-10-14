namespace Common.Database
{
    public class DbContext
    {
        public string ConnectionString { get; set; }

        public DbContext() { }

        public DbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public DbContext(IConnectionStringProvider connectionStringProvider)
        {
            this.ConnectionString = connectionStringProvider.GetConnectionString();
        }

        public DbContext SetConnectionString(string connectionString) 
        {
            this.ConnectionString = connectionString;
            return this;
        }

        public DbContext SetConnectionString(IConnectionStringProvider connectionStringProvider) 
        {
            this.ConnectionString = connectionStringProvider.GetConnectionString();
            return this;
        }
    }
}
