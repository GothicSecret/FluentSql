using System;
using System.Data;

namespace FluentSql
{
    public class FluentSqlCommandFactory : IFluentSqlCommandFactory
    {
        public CommandBehavior DefaultBehavior { get; protected set; }

        public CachingMode DefaultCachingMode { get; protected set; }

        public CommandType DefaultCommandType { get; protected set; }

        public IsolationLevel DefaultIsolationLevel { get; protected set; }

        public Func<IDalSqlConnection> DefaultConnection { get; protected set; }

        public Func<IFluentSqlTransaction> DefaultTransaction { get; protected set; }

        public IFluentSqlCommandFactory SetDefaultConnection(Func<IDalSqlConnection> iConnection)
        {
            DefaultConnection = iConnection;
            return this;
        }

        public IFluentSqlCommandFactory SetDefaultTransaction(Func<IFluentSqlTransaction> iTransaction)
        {
            DefaultTransaction = iTransaction;
            return this;
        }

        public IFluentSqlCommandFactory SetDefaultCachingMode(CachingMode iCachingMode)
        {
            DefaultCachingMode = iCachingMode;
            return this;
        }

        public IFluentSqlCommandFactory SetDefaultBehavior(CommandBehavior iBehavior)
        {
            DefaultBehavior = iBehavior;
            return this;
        }

        public IFluentSqlCommandFactory SetDefaultCommandType(CommandType iCommandType)
        {
            DefaultCommandType = iCommandType;
            return this;
        }

        public IFluentSqlCommandFactory SetDefaultIsolationLevel(IsolationLevel iIsolationLevel)
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
                Connection = DefaultConnection?.Invoke(),
                Transaction = DefaultTransaction?.Invoke()
            };
        }

        public IScalarFluentSqlCommand Scalar()
        {
            return new ScalarFluentSqlCommand()
            {
                CommandType = DefaultCommandType,
                IsolationLevel = DefaultIsolationLevel,
                Connection = DefaultConnection?.Invoke(),
                Transaction = DefaultTransaction?.Invoke()
            };
        }

        public IReaderFluentSqlCommand<T> Reader<T>()
        {
            return new ReaderFluentSqlCommand<T>()
            {
                CommandType = DefaultCommandType,
                IsolationLevel = DefaultIsolationLevel,
                Connection = DefaultConnection?.Invoke(),
                Transaction = DefaultTransaction?.Invoke(),
                Behavior = DefaultBehavior,
                Caching = DefaultCachingMode
            };
        }

        public ISingleReaderFluentSqlCommand<T> SingleReader<T>()
        {
            return new SingleReaderFluentSqlCommand<T>()
            {
                CommandType = DefaultCommandType,
                IsolationLevel = DefaultIsolationLevel,
                Connection = DefaultConnection?.Invoke(),
                Transaction = DefaultTransaction?.Invoke()
            };
        }
    }
}
