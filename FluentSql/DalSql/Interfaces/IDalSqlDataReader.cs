using System;
using System.Collections;
using System.Data;
using System.Data.SqlTypes;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace FluentSql
{
    public interface IDalSqlDataReader : IDisposable
    {
        #region Public Properties

        int Depth { get; }

        int FieldCount { get; }

        bool HasRows { get; }

        bool IsClosed { get; }

        int RecordsAffected { get; }

        int VisibleFieldCount { get; }

        #endregion Public Properties

        #region Public Methods

        void Close();

        bool GetBoolean(string column);

        byte GetByte(string column);

        long GetBytes(string column, long dataIndex, byte[] buffer, int bufferIndex, int length);

        byte[] GetAllBytes(string column);

        char GetChar(string column);

        long GetChars(string column, long dataIndex, char[] buffer, int bufferIndex, int length);

        string GetDataTypeName(string column);

        DateTime GetDateTime(string column);

        DateTimeOffset GetDateTimeOffset(string column);

        decimal GetDecimal(string column);

        double GetDouble(string column);

        IEnumerator GetEnumerator();

        Type GetFieldType(string column);

        T GetFieldValue<T>(string column);

        Task<T> GetFieldValueAsync<T>(string column, CancellationToken cancellationToken);

        float GetFloat(string column);

        Guid GetGuid(string column);

        short GetInt16(string column);

        int GetInt32(string column);

        long GetInt64(string column);

        string GetName(string column);

        int GetOrdinal(string name);

        Type GetProviderSpecificFieldType(string column);

        object GetProviderSpecificValue(string column);

        int GetProviderSpecificValues(object[] values);

        DataTable GetSchemaTable();

        SqlBinary GetSqlBinary(string column);

        SqlBoolean GetSqlBoolean(string column);

        SqlByte GetSqlByte(string column);

        SqlBytes GetSqlBytes(string column);

        SqlChars GetSqlChars(string column);

        SqlDateTime GetSqlDateTime(string column);

        SqlDecimal GetSqlDecimal(string column);

        SqlDouble GetSqlDouble(string column);

        SqlGuid GetSqlGuid(string column);

        SqlInt16 GetSqlInt16(string column);

        SqlInt32 GetSqlInt32(string column);

        SqlInt64 GetSqlInt64(string column);

        SqlMoney GetSqlMoney(string column);

        SqlSingle GetSqlSingle(string column);

        SqlString GetSqlString(string column);

        object GetSqlValue(string column);

        int GetSqlValues(object[] values);

        SqlXml GetSqlXml(string column);

        Stream GetStream(string column);

        string GetString(string column);

        TextReader GetTextReader(string column);

        TimeSpan GetTimeSpan(string column);

        object GetValue(string column);

        int GetValues(object[] values);

        XmlReader GetXmlReader(string column);

        bool IsDBNull(string column);

        Task<bool> IsDBNullAsync(string column, CancellationToken cancellationToken);

        bool NextResult();

        Task<bool> NextResultAsync(CancellationToken cancellationToken);

        bool Read();

        Task<bool> ReadAsync(CancellationToken cancellationToken);

        byte[] GetBinaryNullable(string column);

        bool? GetBooleanNullable(string column);

        byte? GetByteNullable(string column);

        byte[] GetBytesNullable(string column);

        char[] GetCharsNullable(string column);

        DateTime? GetDateTimeNullable(string column);

        decimal? GetDecimalNullable(string column);

        double? GetDoubleNullable(string column);

        Guid? GetGuidNullable(string column);

        short? GetInt16Nullable(string column);

        int? GetInt32Nullable(string column);

        long? GetInt64Nullable(string column);

        decimal? GetMoneyNullable(string column);

        float? GetSingleNullable(string column);

        string GetStringNullable(string column);

        string GetXmlNullable(string column);

        #endregion Public Methods
    }
}
