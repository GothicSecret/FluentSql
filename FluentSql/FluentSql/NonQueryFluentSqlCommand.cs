using System;
using System.Data;

namespace FluentSql
{
    public class NonQueryFluentSqlCommand : BaseFluentSqlCommand, INonQueryFluentSqlCommand
    {
        #region Public Methods

        public int ExecuteNonQuery()
        {
            if (Connection.KeepAlive)
            {
                return ExecuteNonQueryImpl();
            }
            else
            {
                using (Connection)
                {
                    Connection.Open();
                    return ExecuteNonQueryImpl();
                }
            }
        }

        private int ExecuteNonQueryImpl()
        {
            if (Transaction == null)
            {
                using (var transaction = Connection.BeginTransaction(IsolationLevel))
                {
                    int result = 0;
                    using (var command = transaction.CreateCommand(CommandType, Command))
                    {
                        SerializeParameters?.Invoke(command);
                        result = command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    return result;
                }
            }
            else
            {
                int result = 0;
                using (var command = Transaction.CreateCommand(CommandType, Command))
                {
                    SerializeParameters?.Invoke(command);
                    result = command.ExecuteNonQuery();
                }
                return result;
            }
        }

        public INonQueryFluentSqlCommand SetCommand(string iCommand)
        {
            SetCommandImpl(iCommand);
            return this;
        }

        public INonQueryFluentSqlCommand SetCommandType(CommandType iCommandType)
        {
            SetCommandTypeImpl(iCommandType);
            return this;
        }

        public INonQueryFluentSqlCommand SetConnection(IDalSqlConnection iConnection)
        {
            SetConnectionImpl(iConnection);
            return this;
        }

        public INonQueryFluentSqlCommand SetTransaction(IFluentSqlTransaction iTransaction)
        {
            SetTransactionImpl(iTransaction);
            return this;
        }

        public INonQueryFluentSqlCommand SetIsolationLevel(IsolationLevel iIsolationLevel)
        {
            SetIsolationLevelImpl(iIsolationLevel);
            return this;
        }

        public INonQueryFluentSqlCommand SetParameters(Action<IDalSqlCommand> iSerializeParameters)
        {
            SetParametersImpl(iSerializeParameters);
            return this;
        }

        #endregion Public Methods
    }
}
