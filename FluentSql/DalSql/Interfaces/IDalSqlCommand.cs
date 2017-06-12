using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FluentSql
{
    public interface IDalSqlCommand : IDisposable
    {
        #region Public Properties

        CommandType CommandType { get; set; }

        #endregion Public Properties

        #region Public Methods

        SqlParameter AddWithValue(string name, object value);

        int ExecuteNonQuery();

        Task<int> ExecuteNonQueryAsync();

        IDalSqlDataReader ExecuteReader();

        IDalSqlDataReader ExecuteReader(CommandBehavior iBehavior);

        IDalSqlDataReader ExecuteReader(CommandBehavior iBehavior, CachingMode iCaching);

        Task<IDalSqlDataReader> ExecuteReaderAsync();

        object ExecuteScalar();

        Task<object> ExecuteScalarAsync();

        #endregion Public Methods
    }
}
