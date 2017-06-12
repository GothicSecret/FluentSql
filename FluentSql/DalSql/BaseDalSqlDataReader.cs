using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace FluentSql
{
    public abstract class BaseDalSqlDataReader : IDalSqlDataReader
    {
        public BaseDalSqlDataReader(SqlDataReader iReader)
        {
            Reader = iReader;
        }

        public int Depth { get { return Reader.Depth; } }

        public int FieldCount { get { return Reader.FieldCount; } }

        public bool HasRows { get { return Reader.HasRows; } }

        public bool IsClosed { get { return Reader.IsClosed; } }

        public int RecordsAffected { get { return Reader.RecordsAffected; } }

        public int VisibleFieldCount { get { return Reader.VisibleFieldCount; } }

        public object this[int i]
        {
            get
            {
                return Reader[i];
            }
        }

        public void Close()
        {
            Reader.Close();
        }

        public void Dispose()
        {
            Reader.Dispose();
        }

        public abstract bool GetBoolean(string column);

        public abstract byte GetByte(string column);

        public abstract long GetBytes(string column, long dataIndex, byte[] buffer, int bufferIndex, int length);

        public abstract byte[] GetAllBytes(string column);

        public abstract char GetChar(string column);

        public abstract long GetChars(string column, long dataIndex, char[] buffer, int bufferIndex, int length);

        public abstract string GetDataTypeName(string column);

        public abstract DateTime GetDateTime(string column);

        public abstract DateTimeOffset GetDateTimeOffset(string column);

        public abstract decimal GetDecimal(string column);

        public abstract double GetDouble(string column);

        public IEnumerator GetEnumerator()
        {
            return Reader.GetEnumerator();
        }

        public abstract Type GetFieldType(string column);

        public abstract T GetFieldValue<T>(string column);

        public abstract Task<T> GetFieldValueAsync<T>(string column, CancellationToken cancellationToken);

        public abstract float GetFloat(string column);

        public abstract Guid GetGuid(string column);

        public abstract short GetInt16(string column);

        public abstract int GetInt32(string column);

        public abstract long GetInt64(string column);

        public abstract string GetName(string column);

        public abstract int GetOrdinal(string name);

        public abstract Type GetProviderSpecificFieldType(string column);

        public abstract object GetProviderSpecificValue(string column);

        public abstract int GetProviderSpecificValues(object[] values);

        public DataTable GetSchemaTable()
        {
            return Reader.GetSchemaTable();
        }

        public abstract SqlBinary GetSqlBinary(string column);

        public abstract SqlBoolean GetSqlBoolean(string column);

        public abstract SqlByte GetSqlByte(string column);

        public abstract SqlBytes GetSqlBytes(string column);

        public abstract SqlChars GetSqlChars(string column);

        public abstract SqlDateTime GetSqlDateTime(string column);

        public abstract SqlDecimal GetSqlDecimal(string column);

        public abstract SqlDouble GetSqlDouble(string column);

        public abstract SqlGuid GetSqlGuid(string column);

        public abstract SqlInt16 GetSqlInt16(string column);

        public abstract SqlInt32 GetSqlInt32(string column);

        public abstract SqlInt64 GetSqlInt64(string column);

        public abstract SqlMoney GetSqlMoney(string column);

        public abstract SqlSingle GetSqlSingle(string column);

        public abstract SqlString GetSqlString(string column);

        public abstract object GetSqlValue(string column);

        public int GetSqlValues(object[] values)
        {
            return Reader.GetSqlValues(values);
        }

        public abstract SqlXml GetSqlXml(string column);

        public abstract Stream GetStream(string column);

        public abstract string GetString(string column);

        public abstract TextReader GetTextReader(string column);

        public abstract TimeSpan GetTimeSpan(string column);

        public abstract object GetValue(string column);

        public int GetValues(object[] values)
        {
            return Reader.GetValues(values);
        }

        public abstract XmlReader GetXmlReader(string column);

        public abstract bool IsDBNull(string column);

        public abstract Task<bool> IsDBNullAsync(string column, CancellationToken cancellationToken);

        public virtual bool NextResult()
        {
            return Reader.NextResult();
        }

        public virtual async Task<bool> NextResultAsync(CancellationToken cancellationToken)
        {
            return await Reader.NextResultAsync(cancellationToken);
        }

        public bool Read()
        {
            return Reader.Read();
        }

        public async Task<bool> ReadAsync(CancellationToken cancellationToken)
        {
            return await Reader.ReadAsync(cancellationToken);
        }

        public abstract byte[] GetBinaryNullable(string column);

        public abstract bool? GetBooleanNullable(string column);

        public abstract byte? GetByteNullable(string column);

        public abstract byte[] GetBytesNullable(string column);

        public abstract char[] GetCharsNullable(string column);

        public abstract DateTime? GetDateTimeNullable(string column);

        public abstract decimal? GetDecimalNullable(string column);

        public abstract double? GetDoubleNullable(string column);

        public abstract Guid? GetGuidNullable(string column);

        public abstract short? GetInt16Nullable(string column);

        public abstract int? GetInt32Nullable(string column);

        public abstract long? GetInt64Nullable(string column);

        public abstract decimal? GetMoneyNullable(string column);
 
        public abstract float? GetSingleNullable(string column);

        public abstract string GetStringNullable(string column);

        public abstract string GetXmlNullable(string column);

        protected SqlDataReader Reader;
    }
}
