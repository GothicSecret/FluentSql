namespace FluentSql
{
    public class FluentSqlRepository<T> : FluentSqlRepository
    {
        public readonly T Serializer;

        public FluentSqlRepository(IDalSqlConnectionFactory iConnectionFactory, IFluentSqlCommandFactory iCommandFactory, T iSerializer)
            : base(iConnectionFactory, iCommandFactory)
        {
            Serializer = iSerializer;
        }

        public FluentSqlRepository(IDalSqlConnectionFactory iConnectionFactory, IFluentSqlCommandFactory iCommandFactory, IFluentSqlTransactionFactory iTransactionFactory, T iSerializer)
            : base(iConnectionFactory, iCommandFactory, iTransactionFactory)
        {
            Serializer = iSerializer;
        }
    }

    public class FluentSqlRepository
    {
        public readonly IFluentSqlCommandFactory CommandFactory;
        public readonly IDalSqlConnectionFactory ConnectionFactory;
        public readonly IFluentSqlTransactionFactory TransactionFactory;

        public FluentSqlRepository(IDalSqlConnectionFactory iConnectionFactory, IFluentSqlCommandFactory iCommandFactory,
            IFluentSqlTransactionFactory iTransactionFactory = null)
        {
            ConnectionFactory = iConnectionFactory;
            CommandFactory = iCommandFactory;
            TransactionFactory = iTransactionFactory;
        }
    }
}
