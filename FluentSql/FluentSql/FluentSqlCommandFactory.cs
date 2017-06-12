using System.Data;

namespace FluentSql
{
    public class FluentSqlCommandFactory : IFluentCommandFactory
    {
        public CommandBehavior DefaultBehavior { get; protected set; }

        public CachingMode DefaultCachingMode { get; protected set; }

        public CommandType DefaultCommandType { get; protected set; }

        public IsolationLevel DefaultIsolationLevel { get; protected set; }

        public IDalSqlConnection DefaultConnection { get; protected set; }

        public IFluentSqlTransaction DefaultTransaction { get; protected set; }

        public IFluentCommandFactory SetDefaultConnection(IDalSqlConnection iConnection)
        {
            DefaultConnection = iConnection;
            return this;
        }

        public IFluentCommandFactory SetDefaultTransaction(IFluentSqlTransaction iTransaction)
        {
            DefaultTransaction = iTransaction;
            return this;
        }

        public IFluentCommandFactory SetDefaultCachingMode(CachingMode iCachingMode)
        {
            DefaultCachingMode = iCachingMode;
            return this;
        }

        public IFluentCommandFactory SetDefaultBehavior(CommandBehavior iBehavior)
        {
            DefaultBehavior = iBehavior;
            return this;
        }

        public IFluentCommandFactory SetDefaultCommandType(CommandType iCommandType)
        {
            DefaultCommandType = iCommandType;
            return this;
        }

        public IFluentCommandFactory SetDefaultIsolationLevel(IsolationLevel iIsolationLevel)
        {
            DefaultIsolationLevel = iIsolationLevel;
            return this;
        }

        public INonQueryFluentSqlCommand NonQuery()
        {
            return new NonQueryFluentSqlCommand()
            {
                CommandType = DefaultCommandType,
                IsolationLevel = DefaultIsolationLevel,
                Connection = DefaultConnection,
                Transaction = DefaultTransaction
            };
        }

        public IScalarFluentSqlCommand Scalar()
        {
            return new ScalarFluentSqlCommand()
            {
                CommandType = DefaultCommandType,
                IsolationLevel = DefaultIsolationLevel,
                Connection = DefaultConnection,
                Transaction = DefaultTransaction
            };
        }

        public IReaderFluentSqlCommand<T> Reader<T>()
        {
            return new ReaderFluentSqlCommand<T>()
            {
                CommandType = DefaultCommandType,
                IsolationLevel = DefaultIsolationLevel,
                Connection = DefaultConnection,
                Transaction = DefaultTransaction,
                Behavior = DefaultBehavior,
                Caching = DefaultCachingMode
            };
        }
    }
}
