using System.Data;

namespace FluentSql
{
    public class FluentSqlTransactionFactory : IFluentSqlTransactionFactory
    {
        public IsolationLevel DefaultIsolationLevel { get; protected set; }

        public IDalSqlConnection DefaultConnection { get; protected set; }

        public IFluentSqlTransactionFactory SetDefaultConnection(IDalSqlConnection iConnection)
        {
            DefaultConnection = iConnection;
            return this;
        }

        public IFluentSqlTransactionFactory SetDefaultIsolationLevel(IsolationLevel iIsolationLevel)
        {
            DefaultIsolationLevel = iIsolationLevel;
            return this;
        }

        public IFluentSqlTransaction Create()
        {
            return new FluentSqlTransaction()
            {
                Connection = DefaultConnection,
                IsolationLevel = DefaultIsolationLevel
            };
        }
    }
}
