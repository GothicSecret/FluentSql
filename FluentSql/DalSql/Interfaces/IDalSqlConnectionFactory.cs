namespace FluentSql
{
    public interface IDalSqlConnectionFactory
    {
        #region Public Methods

        DalSqlConnection Create();

        #endregion Public Methods
    }
}
