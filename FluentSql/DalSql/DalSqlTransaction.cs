using System.Data;
using System.Data.SqlClient;

namespace FluentSql
{
    public class DalSqlTransaction : IDalSqlTransaction
    {
        public DalSqlTransaction(SqlTransaction iTransaction, DalSqlConnection iConnection)
        {
            Transaction = iTransaction;
            Connection = iConnection;
        }

        public DalSqlConnection Connection { get; private set; }

        public SqlTransaction Transaction { get; private set; }

        public void Commit()
        {
            Transaction.Commit();
        }

        public void Rollback()
        {
            Transaction.Rollback();
        }

        public void Rollback(string name)
        {
            Transaction.Rollback(name);
        }

        public void Save(string name)
        {
            Transaction.Save(name);
        }

        public DalSqlCommand CreateCommand(string iCommandText)
        {
            return new DalSqlCommand(iCommandText, Connection, this);
        }

        public DalSqlCommand CreateCommand(CommandType iCommandType, string iCommandText)
        {
            return new DalSqlCommand(iCommandType, iCommandText, Connection, this);
        }

        public void Dispose()
        {
            Transaction.Dispose();
        }
    }
}
