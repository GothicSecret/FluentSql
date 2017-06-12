using System;
using System.Data;

namespace FluentSql
{
    public interface IFluentSqlCommand
    {
        string Command { get; set; }

        CommandType CommandType { get; set; }

        IDalSqlConnection Connection { get; set; }

        IsolationLevel IsolationLevel { get; set; }

        Action<IDalSqlCommand> SerializeParameters { get; set; }
    }
}
