using System.Data;

namespace FluentSql
{
    public interface IFluentCommandFactory
    {
        IDalSqlConnection DefaultConnection { get; }

        CommandBehavior DefaultBehavior { get; }

        CachingMode DefaultCachingMode { get; }

        CommandType DefaultCommandType { get; }

        IsolationLevel DefaultIsolationLevel { get; }

        INonQueryFluentSqlCommand NonQuery();

        IReaderFluentSqlCommand<T> Reader<T>();

        IScalarFluentSqlCommand Scalar();

        IFluentCommandFactory SetDefaultCachingMode(CachingMode iCachingMode);

        IFluentCommandFactory SetDefaultBehavior(CommandBehavior iBehavior);

        IFluentCommandFactory SetDefaultCommandType(CommandType iCommandType);

        IFluentCommandFactory SetDefaultConnection(IDalSqlConnection iConnection);

        IFluentCommandFactory SetDefaultTransaction(IFluentSqlTransaction iTransaction);

        IFluentCommandFactory SetDefaultIsolationLevel(IsolationLevel iIsolationLevel);
    }
}
