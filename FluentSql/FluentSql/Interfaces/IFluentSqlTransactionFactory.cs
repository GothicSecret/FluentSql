using System.Data;

namespace FluentSql
{
    public interface IFluentSqlTransactionFactory
    {
        IDalSqlConnection DefaultConnection { get; }

        IsolationLevel DefaultIsolationLevel { get; }

        IFluentSqlTransactionFactory SetDefaultConnection(IDalSqlConnection iConnection);

        IFluentSqlTransactionFactory SetDefaultIsolationLevel(IsolationLevel iIsolationLevel);

        IFluentSqlTransaction Create();
    }
}
