using System;
using System.Data;
using System.Data.SqlClient;

namespace FluentSql
{
    public interface IDalSqlTransaction : IDisposable
    {
        #region Public Properties

        DalSqlConnection Connection { get; }

        SqlTransaction Transaction { get; }

        #endregion Public Properties

        #region Public Methods

        void Commit();

        void Rollback();

        void Rollback(string name);

        void Save(string name);

        DalSqlCommand CreateCommand(string iCommandText);

        DalSqlCommand CreateCommand(CommandType iCommandType, string iCommandText);

        #endregion Public Methods
    }
}
