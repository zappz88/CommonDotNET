namespace Common.Database
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public string Path { get; set; }

        public string Key { get; } = "ConnectionString";

        public ConnectionStringProvider()
        {
            
        }

        public ConnectionStringProvider(string path)
        {
            this.Path = path;
        }

        public string GetConnectionString() 
        { 
            throw new NotImplementedException();
        }
    }
}
