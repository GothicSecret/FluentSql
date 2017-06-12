using System;
using System.Data;
using System.Data.SqlClient;

namespace FluentSql
{
    public interface IDalSqlConnection : IDisposable
    {
        #region Public Properties

        SqlConnection Connection { get; }

        bool KeepAlive { get; set; }

        #endregion Public Properties

        #region Public Methods

        DalSqlTransaction BeginTransaction(IsolationLevel level);

        void Close();

        DalSqlCommand CreateCommand(string iCommandText);

        DalSqlCommand CreateCommand(string iCommandText, DalSqlTransaction iTransaction);

        DalSqlCommand CreateCommand(CommandType iCommandTyype, string iCommandText);

        DalSqlCommand CreateCommand(CommandType iCommandType, string iCommandText, DalSqlTransaction iTransaction);

        void Open();

        ConnectionState State { get; }

        #endregion Public Methods
    }
}
