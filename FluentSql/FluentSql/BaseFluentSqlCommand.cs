using System;
using System.Collections.Generic;
using System.Data;

namespace FluentSql
{
    public abstract class BaseFluentSqlCommand
    {
        public BaseFluentSqlCommand()
        {
            IsolationLevel = IsolationLevel.ReadCommitted;
            CommandType = CommandType.StoredProcedure;
            SerializeParameters = new List<Action<IDalSqlCommand>>();
        }

        public string Command { get; set; }

        public CommandType CommandType { get; set; }

        public IDalSqlConnection Connection { get; set; }

        public IFluentSqlTransaction Transaction { get; set; }

        public IsolationLevel IsolationLevel { get; set; }

        public List<Action<IDalSqlCommand>> SerializeParameters { get; set; }

        protected void SetCommandImpl(string iCommand)
        {
            Command = iCommand;
        }

        protected void SetCommandTypeImpl(CommandType iCommandType)
        {
            CommandType = iCommandType;
        }

        protected void SetConnectionImpl(IDalSqlConnection iConnection)
        {
            Connection = iConnection;
        }

        protected void SetTransactionImpl(IFluentSqlTransaction iTransaction)
        {
            Transaction = iTransaction;
        }

        protected void SetIsolationLevelImpl(IsolationLevel iIsolationLevel)
        {
            IsolationLevel = iIsolationLevel;
        }

        protected void SetParametersImpl(Action<IDalSqlCommand> iSerializeParameters)
        {
            SerializeParameters.Add(iSerializeParameters);
        }

        protected void ExecuteSerializeParametersImpl(IDalSqlCommand command)
        {
            for (int i = 0; i < SerializeParameters.Count; i++)
            {
                SerializeParameters[i](command);
            }
        }
    }
}
