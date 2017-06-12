using System;
using System.Collections.Generic;
using System.Data;

namespace FluentSql
{
    public class ReaderFluentSqlCommand<T> : BaseFluentSqlCommand, IReaderFluentSqlCommand<T>
    {
        public ReaderFluentSqlCommand()
        {
            Behavior = CommandBehavior.Default;
            Caching = CachingMode.Standard;
        }

        public CommandBehavior Behavior { get; set; }

        public CachingMode Caching { get; set; }

        public Func<T> InitResult { get; set; }

        public T ExecuteReader(params Action<IDalSqlDataReader, T>[] iDeserialize)
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

        public T ExecuteReaderImpl(params Action<IDalSqlDataReader, T>[] iDeserialize)
        {
            if (Transaction == null)
            {
                using (var transaction = Connection.BeginTransaction(IsolationLevel))
                {
                    T result = InitResult();
                    using (var command = transaction.CreateCommand(CommandType, Command))
                    {
                        SerializeParameters?.Invoke(command);
                        using (var reader = command.ExecuteReader(Behavior, Caching))
                        {
                            var i = 0;
                            var serialize = iDeserialize[i];
                            while (reader.Read())
                            {
                                serialize(reader, result);
                            }
                            while (reader.NextResult())
                            {
                                i++;
                                serialize = iDeserialize[i];
                                while (reader.Read())
                                {
                                    serialize(reader, result);
                                }
                            }
                        }
                    }
                    transaction.Commit();
                    return result;
                }
            }
            else
            {
                T result = InitResult();
                using (var command = Transaction.CreateCommand(CommandType, Command))
                {
                    SerializeParameters?.Invoke(command);
                    using (var reader = command.ExecuteReader(Behavior, Caching))
                    {
                        var i = 0;
                        var serialize = iDeserialize[i];
                        while (reader.Read())
                        {
                            serialize(reader, result);
                        }
                        while (reader.NextResult())
                        {
                            i++;
                            serialize = iDeserialize[i];
                            while (reader.Read())
                            {
                                serialize(reader, result);
                            }
                        }
                    }
                }
                return result;
            }
        }

        public IEnumerable<T> ExecuteReaderYield(params Func<IDalSqlDataReader, T, T>[] iDeserialize)
        {
            if (Connection.KeepAlive)
            {
                return ExecuteReaderYieldImpl(iDeserialize);
            }
            else
            {
                using (Connection)
                {
                    return ExecuteReaderYieldImpl(iDeserialize);
                }
            }
        }

        public IEnumerable<T> ExecuteReaderYieldImpl(params Func<IDalSqlDataReader, T, T>[] iDeserialize)
        {
            if (Transaction == null)
            {
                using (var transaction = Connection.BeginTransaction(IsolationLevel))
                {
                    T result = InitResult();
                    using (var command = transaction.CreateCommand(CommandType, Command))
                    {
                        SerializeParameters(command);
                        using (var reader = command.ExecuteReader(Behavior, Caching))
                        {
                            var i = 0;
                            var serialize = iDeserialize[i];
                            while (reader.Read())
                            {
                                yield return serialize(reader, result);
                            }
                            while (reader.NextResult())
                            {
                                i++;
                                serialize = iDeserialize[i];
                                while (reader.Read())
                                {
                                    yield return serialize(reader, result);
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
            }
            else
            {
                T result = InitResult();
                using (var command = Transaction.CreateCommand(CommandType, Command))
                {
                    SerializeParameters(command);
                    using (var reader = command.ExecuteReader(Behavior, Caching))
                    {
                        var i = 0;
                        var serialize = iDeserialize[i];
                        while (reader.Read())
                        {
                            yield return serialize(reader, result);
                        }
                        while (reader.NextResult())
                        {
                            i++;
                            serialize = iDeserialize[i];
                            while (reader.Read())
                            {
                                yield return serialize(reader, result);
                            }
                        }
                    }
                }
            }
        }

        public IReaderFluentSqlCommand<T> SetCachingMode(CachingMode iCachingMode)
        {
            Caching = iCachingMode;
            return this;
        }

        public IReaderFluentSqlCommand<T> SetBehavior(CommandBehavior iBehavior)
        {
            Behavior = iBehavior;
            return this;
        }

        public IReaderFluentSqlCommand<T> SetInitResult(Func<T> iInitResult)
        {
            InitResult = iInitResult;
            return this;
        }

        public IReaderFluentSqlCommand<T> SetCommand(string iCommand)
        {
            SetCommandImpl(iCommand);
            return this;
        }

        public IReaderFluentSqlCommand<T> SetCommandType(CommandType iCommandType)
        {
            SetCommandTypeImpl(iCommandType);
            return this;
        }

        public IReaderFluentSqlCommand<T> SetConnection(IDalSqlConnection iConnection)
        {
            SetConnectionImpl(iConnection);
            return this;
        }

        public IReaderFluentSqlCommand<T> SetTransaction(IFluentSqlTransaction iTransaction)
        {
            SetTransactionImpl(iTransaction);
            return this;
        }

        public IReaderFluentSqlCommand<T> SetIsolationLevel(IsolationLevel iIsolationLevel)
        {
            SetIsolationLevelImpl(iIsolationLevel);
            return this;
        }

        public IReaderFluentSqlCommand<T> SetParameters(Action<IDalSqlCommand> iSerializeParameters)
        {
            SetParametersImpl(iSerializeParameters);
            return this;
        }
    }
}
