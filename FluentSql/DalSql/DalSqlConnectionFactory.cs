namespace FluentSql
{
    public class DalSqlConnectionFactory : IDalSqlConnectionFactory
    {
        private readonly string ConnectionString;
        private readonly bool KeepAlive;

        public DalSqlConnectionFactory(string iConnectionString, bool iKeepAlive = false)
        {
            ConnectionString = iConnectionString;
            KeepAlive = iKeepAlive;
        }

        public DalSqlConnection Create()
        {
            return new DalSqlConnection(ConnectionString, KeepAlive);
        }
    }
}
