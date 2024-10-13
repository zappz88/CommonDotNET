namespace Common.Database
{
    public class DbContext
    {
        public string ConnectionString { get; set; }

        public DbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public DbContext(IConnectionStringProvider connectionStringProvider)
        {
            this.ConnectionString = connectionStringProvider.GetConnectionString();
        }
    }
}
