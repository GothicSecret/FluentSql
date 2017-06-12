namespace FluentSql
{
    public class FluentSqlRepository<T> : FluentSqlRepository
    {
        public readonly T Serializer;

        public FluentSqlRepository(IDalSqlConnectionFactory iConnectionFactory, IFluentCommandFactory iCommandFactory, T iSerializer)
            : base(iConnectionFactory, iCommandFactory)
        {
            Serializer = iSerializer;
        }

        public FluentSqlRepository(IDalSqlConnectionFactory iConnectionFactory, IFluentCommandFactory iCommandFactory, IFluentSqlTransactionFactory iTransactionFactory, T iSerializer)
            : base(iConnectionFactory, iCommandFactory, iTransactionFactory)
        {
            Serializer = iSerializer;
        }
    }

    public class FluentSqlRepository
    {
        public readonly IFluentCommandFactory CommandFactory;
        public readonly IDalSqlConnectionFactory ConnectionFactory;
        public readonly IFluentSqlTransactionFactory TransactionFactory;

        public FluentSqlRepository(IDalSqlConnectionFactory iConnectionFactory, IFluentCommandFactory iCommandFactory,
            IFluentSqlTransactionFactory iTransactionFactory = null)
        {
            ConnectionFactory = iConnectionFactory;
            CommandFactory = iCommandFactory;
            TransactionFactory = iTransactionFactory;
        }
    }
}
