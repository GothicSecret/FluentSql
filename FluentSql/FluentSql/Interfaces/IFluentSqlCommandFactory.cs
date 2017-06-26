using System;
using System.Data;

namespace FluentSql
{
    public interface IFluentSqlCommandFactory
    {
        Func<IDalSqlConnection> DefaultConnection { get; }

        Func<IFluentSqlTransaction> DefaultTransaction { get; }

        CommandBehavior DefaultBehavior { get; }

        CachingMode DefaultCachingMode { get; }

        CommandType DefaultCommandType { get; }

        IsolationLevel DefaultIsolationLevel { get; }

        INonQueryFluentSqlCommand NonQuery();

        IReaderFluentSqlCommand<T> Reader<T>();

        ISingleReaderFluentSqlCommand<T> SingleReader<T>();

        IScalarFluentSqlCommand Scalar();

        IFluentSqlCommandFactory SetDefaultCachingMode(CachingMode iCachingMode);

        IFluentSqlCommandFactory SetDefaultBehavior(CommandBehavior iBehavior);

        IFluentSqlCommandFactory SetDefaultCommandType(CommandType iCommandType);

        IFluentSqlCommandFactory SetDefaultConnection(Func<IDalSqlConnection> iConnection);

        IFluentSqlCommandFactory SetDefaultTransaction(Func<IFluentSqlTransaction> iTransaction);

        IFluentSqlCommandFactory SetDefaultIsolationLevel(IsolationLevel iIsolationLevel);
    }
}
