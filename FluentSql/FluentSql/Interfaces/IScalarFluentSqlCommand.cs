using System;
using System.Data;

namespace FluentSql
{
    public interface IScalarFluentSqlCommand : IFluentSqlCommand
    {
        T ExecuteScalar<T>();

        IScalarFluentSqlCommand SetCommand(string iCommand);

        IScalarFluentSqlCommand SetCommandType(CommandType iCommandType);

        IScalarFluentSqlCommand SetConnection(IDalSqlConnection iConnection);

        IScalarFluentSqlCommand SetTransaction(IFluentSqlTransaction iTransaction);

        IScalarFluentSqlCommand SetIsolationLevel(IsolationLevel iIsolationLevel);

        IScalarFluentSqlCommand SetParameters(Action<IDalSqlCommand> iSerializeParameters);
    }
}
