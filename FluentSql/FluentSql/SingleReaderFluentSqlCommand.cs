using System;
using System.Data;

namespace FluentSql
{
    public class SingleReaderFluentSqlCommand<T> : BaseFluentSqlCommand, ISingleReaderFluentSqlCommand<T>
    {
        public SingleReaderFluentSqlCommand()
        {
            Behavior = CommandBehavior.SingleRow;
            Caching = CachingMode.Disabled;
        }

        public CommandBehavior Behavior { get; }

        public CachingMode Caching { get; }

        public T ExecuteReader(Func<IDalSqlDataReader, T> iDeserialize)
        {
            if (Connection.KeepAlive)
            {
                return ExecuteReaderImpl(iDeserialize);
            }
            else
            {
                using (Connection)
                {
                    Connection.Open();
                    return ExecuteReaderImpl(iDeserialize);
                }
            }
        }

        public T ExecuteReaderImpl(Func<IDalSqlDataReader, T> iDeserialize)
        {
            if (Transaction == null)
            {
                T result;
                using (var transaction = Connection.BeginTransaction(IsolationLevel))
                {
                    using (var command = transaction.CreateCommand(CommandType, Command))
                    {
                        ExecuteSerializeParametersImpl(command);
                        using (var reader = command.ExecuteReader(Behavior, Caching))
                        {
                            var i = 0;
                            if (reader.Read())
                            {
                                result = iDeserialize(reader);
                            }
                            else
                            {
                                result = default(T);
                            }
                        }
                    }
                    transaction.Commit();
                }
                return result;
            }
            else
            {
                T result;
                using (var command = Transaction.CreateCommand(CommandType, Command))
                {
                    ExecuteSerializeParametersImpl(command);
                    using (var reader = command.ExecuteReader(Behavior, Caching))
                    {
                        var i = 0;
                        if (reader.Read())
                        {
                            result = iDeserialize(reader);
                        }
                        else
                        {
                            result = default(T);
                        }
                    }
                }
                return result;
            }
        }

        public ISingleReaderFluentSqlCommand<T> SetCommand(string iCommand)
        {
            SetCommandImpl(iCommand);
            return this;
        }

        public ISingleReaderFluentSqlCommand<T> SetCommandType(CommandType iCommandType)
        {
            SetCommandTypeImpl(iCommandType);
            return this;
        }

        public ISingleReaderFluentSqlCommand<T> SetConnection(IDalSqlConnection iConnection)
        {
            SetConnectionImpl(iConnection);
            return this;
        }

        public ISingleReaderFluentSqlCommand<T> SetTransaction(IFluentSqlTransaction iTransaction)
        {
            SetTransactionImpl(iTransaction);
            return this;
        }

        public ISingleReaderFluentSqlCommand<T> SetIsolationLevel(IsolationLevel iIsolationLevel)
        {
            SetIsolationLevelImpl(iIsolationLevel);
            return this;
        }

        public ISingleReaderFluentSqlCommand<T> SetParameters(Action<IDalSqlCommand> iSerializeParameters)
        {
            SetParametersImpl(iSerializeParameters);
            return this;
        }
    }
}
