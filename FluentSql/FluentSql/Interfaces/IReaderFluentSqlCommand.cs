using System;
using System.Data;

namespace FluentSql
{
    public interface IReaderFluentSqlCommand<T> : IFluentSqlCommand
    {
        Func<T> InitResult { get; }

        CommandBehavior Behavior { get; }

        T ExecuteReader(params Action<IDalSqlDataReader, T>[] iDeserialize);

        IReaderFluentSqlCommand<T> SetInitResult(Func<T> iInitResult);

        IReaderFluentSqlCommand<T> SetCachingMode(CachingMode iCachingMode);

        IReaderFluentSqlCommand<T> SetBehavior(CommandBehavior iBehavior);

        IReaderFluentSqlCommand<T> SetCommand(string iCommand);

        IReaderFluentSqlCommand<T> SetCommandType(CommandType iCommandType);

        IReaderFluentSqlCommand<T> SetConnection(IDalSqlConnection iConnection);

        IReaderFluentSqlCommand<T> SetTransaction(IFluentSqlTransaction iTransaction);

        IReaderFluentSqlCommand<T> SetIsolationLevel(IsolationLevel iIsolationLevel);

        IReaderFluentSqlCommand<T> SetParameters(Action<IDalSqlCommand> iSerializeParameters);
    }
}
