using System;
using System.Data;

namespace FluentSql
{
    public interface ISingleReaderFluentSqlCommand<T> : IFluentSqlCommand
    {
        T ExecuteReader(Func<IDalSqlDataReader, T> iDeserialize);

        ISingleReaderFluentSqlCommand<T> SetCommand(string iCommand);

        ISingleReaderFluentSqlCommand<T> SetCommandType(CommandType iCommandType);

        ISingleReaderFluentSqlCommand<T> SetConnection(IDalSqlConnection iConnection);

        ISingleReaderFluentSqlCommand<T> SetTransaction(IFluentSqlTransaction iTransaction);

        ISingleReaderFluentSqlCommand<T> SetIsolationLevel(IsolationLevel iIsolationLevel);

        ISingleReaderFluentSqlCommand<T> SetParameters(Action<IDalSqlCommand> iSerializeParameters);
    }
}
