using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FluentSql
{
    public class DalSqlCommand : IDisposable, IDalSqlCommand
    {
        private SqlCommand command;
        private IDalSqlTransaction _transaction;
        private IDalSqlConnection _connection;

        public DalSqlCommand(string iCommandText, IDalSqlConnection iConnection)
        {
            _connection = iConnection;
            command = new SqlCommand(iCommandText, iConnection.Connection);
        }

        public DalSqlCommand(string iCommandText, IDalSqlConnection iConnection, IDalSqlTransaction iTransaction)
            : this(iCommandText, iConnection)
        {
            _connection = iConnection;
            _transaction = iTransaction;
            command.Transaction = iTransaction.Transaction;
        }

        public DalSqlCommand(CommandType iCommandType, string iCommandText, IDalSqlConnection iConnection, IDalSqlTransaction iTransaction)
            : this(iCommandText, iConnection, iTransaction)
        {
            _connection = iConnection;
            _transaction = iTransaction;
            command.CommandType = iCommandType;
        }

        public DalSqlCommand(CommandType iCommandType, string iCommandText, IDalSqlConnection iConnection)
            : this(iCommandText, iConnection)
        {
            _connection = iConnection;
            command.CommandType = iCommandType;
        }

        public CommandType CommandType
        {
            get { return command.CommandType; }
            set { command.CommandType = value; }
        }

        public SqlParameter AddWithValue(string name, object value)
        {
            return command.Parameters.AddWithValue(name, value != null ? value : DBNull.Value);
        }

        public void Dispose()
        {
            command.Dispose();
        }

        public int ExecuteNonQuery()
        {
            return command.ExecuteNonQuery();
        }

        public IDalSqlTransaction Transaction
        {
            get
            {
                return _transaction;
            }
            set
            {
                _transaction = value;
                command.Transaction = value.Transaction;
            }
        }

        public IDalSqlConnection Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
                command.Connection = value.Connection;
            }
        }

        public async Task<int> ExecuteNonQueryAsync()
        {
            return await command.ExecuteNonQueryAsync();
        }

        public IDalSqlDataReader ExecuteReader()
        {
            return new NonCachedDalSqlDataReader(command.ExecuteReader());
        }

        public IDalSqlDataReader ExecuteReader(CommandBehavior iBehavior)
        {
            return new NonCachedDalSqlDataReader(command.ExecuteReader(iBehavior));
        }

        public IDalSqlDataReader ExecuteReader(CommandBehavior iBehavior, CachingMode iCaching)
        {
            switch (iCaching)
            {
                case CachingMode.Disabled:
                    return new NonCachedDalSqlDataReader(command.ExecuteReader(iBehavior));

                case CachingMode.Standard:
                    return new CachedDalSqlDataReader(command.ExecuteReader(iBehavior));

                case CachingMode.Lazy:
                    return new LazyCachedDalSqlDataReader(command.ExecuteReader(iBehavior));

                default:
                    //Stub
                    return new NonCachedDalSqlDataReader(command.ExecuteReader(iBehavior));
            }
        }

        public async Task<IDalSqlDataReader> ExecuteReaderAsync()
        {
            return new NonCachedDalSqlDataReader(await command.ExecuteReaderAsync());
        }

        public async Task<IDalSqlDataReader> ExecuteReaderAsync(CommandBehavior iBehavior, CachingMode iCaching)
        {
            switch (iCaching)
            {
                case CachingMode.Disabled:
                    return new NonCachedDalSqlDataReader(await command.ExecuteReaderAsync(iBehavior));

                case CachingMode.Standard:
                    return new CachedDalSqlDataReader(await command.ExecuteReaderAsync(iBehavior));

                case CachingMode.Lazy:
                    return new LazyCachedDalSqlDataReader(await command.ExecuteReaderAsync(iBehavior));

                default:
                    //Stub
                    return new NonCachedDalSqlDataReader(await command.ExecuteReaderAsync(iBehavior));
            }
        }

        public object ExecuteScalar()
        {
            return command.ExecuteScalar();
        }

        public Task<object> ExecuteScalarAsync()
        {
            return command.ExecuteScalarAsync();
        }
    }
}
