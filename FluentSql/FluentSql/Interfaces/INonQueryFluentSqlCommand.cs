using System;
using System.Data;

namespace FluentSql
{
    public interface INonQueryFluentSqlCommand : IFluentSqlCommand
    {
        int ExecuteNonQuery();

        INonQueryFluentSqlCommand SetCommand(string iCommand);

        INonQueryFluentSqlCommand SetCommandType(CommandType iCommandType);

        INonQueryFluentSqlCommand SetConnection(IDalSqlConnection iConnection);

        INonQueryFluentSqlCommand SetTransaction(IFluentSqlTransaction iTransaction);

        INonQueryFluentSqlCommand SetIsolationLevel(IsolationLevel iIsolationLevel);

        INonQueryFluentSqlCommand SetParameters(Action<IDalSqlCommand> iSerializeParameters);
    }
}
