using System.Data;

namespace FluentSql
{
    public class FluentSqlTransaction : IFluentSqlTransaction
    {
        public IDalSqlTransaction Transaction { get; private set; }

        public IDalSqlConnection Connection { get; set; }

        public IsolationLevel IsolationLevel { get; set; }

        public IDalSqlCommand CreateCommand(string iCommandText)
        {
            return new DalSqlCommand(iCommandText, Connection, this.Transaction);
        }

        public IDalSqlCommand CreateCommand(CommandType iCommandType, string iCommandText)
        {
            return new DalSqlCommand(iCommandType, iCommandText, Connection, this.Transaction);
        }

        public IFluentSqlTransaction SetConnection(DalSqlConnection iConnection)
        {
            Connection = iConnection;
            return this;
        }

        public IFluentSqlTransaction SetIsolationLevel(IsolationLevel iIsolationLevel)
        {
            IsolationLevel = iIsolationLevel;
            return this;
        }

        public void Begin()
        {
            Transaction = Connection.BeginTransaction(IsolationLevel);
        }

        public void Commit()
        {
            Transaction.Commit();
        }

        public IFluentSqlTransaction Save(string name)
        {
            Transaction.Save(name);
            return this;
        }

        public IFluentSqlTransaction Rollback(string name)
        {
            Transaction.Rollback(name);
            return this;
        }

        public IFluentSqlTransaction Rollback()
        {
            Transaction.Rollback();
            return this;
        }

        public void Dispose()
        {
            Transaction.Dispose();
            Connection.Dispose();
        }
    }
}
