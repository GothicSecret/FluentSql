using System;
using System.Data;

namespace FluentSql
{
    public interface IFluentSqlTransaction : IDisposable
    {
        IDalSqlTransaction Transaction { get; }

        IDalSqlConnection Connection { get; set; }

        IsolationLevel IsolationLevel { get; set; }

        IDalSqlCommand CreateCommand(string iCommandText);

        IDalSqlCommand CreateCommand(CommandType iCommandType, string iCommandText);

        IFluentSqlTransaction SetConnection(DalSqlConnection iConnection);

        IFluentSqlTransaction SetIsolationLevel(IsolationLevel iIsolationLevel);

        void Begin();

        void Commit();

        IFluentSqlTransaction Save(string name);

        IFluentSqlTransaction Rollback(string name);

        IFluentSqlTransaction Rollback();
    }
}
