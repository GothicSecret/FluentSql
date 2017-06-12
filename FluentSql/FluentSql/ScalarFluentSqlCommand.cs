using System;
using System.Data;

namespace FluentSql
{
    public class ScalarFluentSqlCommand : BaseFluentSqlCommand, IScalarFluentSqlCommand
    {
        public T ExecuteScalar<T>()
        {
            if (Connection.KeepAlive)
            {
                return ExecuteScalarImpl<T>();
            }
            else
            {
                using (Connection)
                {
                    Connection.Open();
                    return ExecuteScalarImpl<T>();
                }
            }
        }

        public IScalarFluentSqlCommand SetCommand(string iCommand)
        {
            SetCommandImpl(iCommand);
            return this;
        }

        public IScalarFluentSqlCommand SetCommandType(CommandType iCommandType)
        {
            SetCommandTypeImpl(iCommandType);
            return this;
        }

        public IScalarFluentSqlCommand SetConnection(IDalSqlConnection iConnection)
        {
            SetConnectionImpl(iConnection);
            return this;
        }

        public IScalarFluentSqlCommand SetTransaction(IFluentSqlTransaction iTransaction)
        {
            SetTransactionImpl(iTransaction);
            return this;
        }

        public IScalarFluentSqlCommand SetIsolationLevel(IsolationLevel iIsolationLevel)
        {
            SetIsolationLevelImpl(iIsolationLevel);
            return this;
        }

        public IScalarFluentSqlCommand SetParameters(Action<IDalSqlCommand> iSerializeParameters)
        {
            SetParametersImpl(iSerializeParameters);
            return this;
        }

        private T ExecuteScalarImpl<T>()
        {
            if (Transaction == null)
            {
                using (var transaction = Connection.BeginTransaction(IsolationLevel))
                {
                    object rawResult = null;
                    using (var command = transaction.CreateCommand(CommandType, Command))
                    {
                        SerializeParameters?.Invoke(command);
                        rawResult = command.ExecuteScalar();
                    }
                    transaction.Commit();
                    return (T)rawResult;
                }
            }
            else
            {
                object rawResult = null;
                using (var command = Transaction.CreateCommand(CommandType, Command))
                {
                    SerializeParameters?.Invoke(command);
                    rawResult = command.ExecuteScalar();
                }
                return (T)rawResult;
            }
        }
    }
}
