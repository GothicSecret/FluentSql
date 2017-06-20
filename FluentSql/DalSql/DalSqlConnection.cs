using System;
using System.Data;
using System.Data.SqlClient;

namespace FluentSql
{
    public class DalSqlConnection : IDalSqlConnection
    {
        public DalSqlConnection(string iConnectionString, bool iKeepAlive = false)
        {
            Connection = new SqlConnection(iConnectionString);
            KeepAlive = iKeepAlive;
        }

        public SqlConnection Connection { get; private set; }

        public bool KeepAlive { get; set; }

        public ConnectionState State
        {
            get
            {
                return Connection.State;
            }
        }

        public DalSqlTransaction BeginTransaction(IsolationLevel level)
        {
            return new DalSqlTransaction(Connection.BeginTransaction(level), this);
        }

        public void Close()
        {
            Connection.Close();
        }

        public DalSqlCommand CreateCommand(string iCommandText)
        {
            return new DalSqlCommand(iCommandText, this);
        }

        public DalSqlCommand CreateCommand(CommandType iCommandTyype, string iCommandText)
        {
            return new DalSqlCommand(iCommandTyype, iCommandText, this);
        }

        public DalSqlCommand CreateCommand(string iCommandText, DalSqlTransaction iTransaction)
        {
            return new DalSqlCommand(iCommandText, this, iTransaction);
        }

        public DalSqlCommand CreateCommand(CommandType iCommandType, string iCommandText, DalSqlTransaction iTransaction)
        {
            return new DalSqlCommand(iCommandType, iCommandText, this, iTransaction);
        }

        public void Dispose()
        {
            Connection.Dispose();
        }

        public void Open()
        {
            Connection.Open();
        }
    }
}
