using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace FluentSql
{
    public class NonCachedDalSqlDataReader : BaseDalSqlDataReader
    {
        public NonCachedDalSqlDataReader(SqlDataReader iReader)
            : base(iReader)
        {
        }

        public object this[string name]
        {
            get
            {
                return Reader[name];
            }
        }

        public override bool GetBoolean(string column)
        {
            return Reader.GetBoolean(Reader.GetOrdinal(column));
        }

        public override byte GetByte(string column)
        {
            return Reader.GetByte(Reader.GetOrdinal(column));
        }

        public override long GetBytes(string column, long dataIndex, byte[] buffer, int bufferIndex, int length)
        {
            return Reader.GetBytes(Reader.GetOrdinal(column), dataIndex, buffer, bufferIndex, length);
        }

        public override byte[] GetAllBytes(string column)
        {
            return (byte[])Reader[Reader.GetOrdinal(column)];
        }

        public override char GetChar(string column)
        {
            return Reader.GetChar(Reader.GetOrdinal(column));
        }

        public override long GetChars(string column, long dataIndex, char[] buffer, int bufferIndex, int length)
        {
            return Reader.GetChars(Reader.GetOrdinal(column), dataIndex, buffer, bufferIndex, length);
        }

        public override string GetDataTypeName(string column)
        {
            return Reader.GetDataTypeName(Reader.GetOrdinal(column));
        }

        public override DateTime GetDateTime(string column)
        {
            return Reader.GetDateTime(Reader.GetOrdinal(column));
        }

        public override DateTimeOffset GetDateTimeOffset(string column)
        {
            return Reader.GetDateTimeOffset(Reader.GetOrdinal(column));
        }

        public override decimal GetDecimal(string column)
        {
            return Reader.GetDecimal(Reader.GetOrdinal(column));
        }

        public override double GetDouble(string column)
        {
            return Reader.GetDouble(Reader.GetOrdinal(column));
        }

        public override Type GetFieldType(string column)
        {
            return Reader.GetFieldType(Reader.GetOrdinal(column));
        }

        public override T GetFieldValue<T>(string column)
        {
            return Reader.GetFieldValue<T>(Reader.GetOrdinal(column));
        }

        public override async Task<T> GetFieldValueAsync<T>(string column, CancellationToken cancellationToken)
        {
            return await Reader.GetFieldValueAsync<T>(Reader.GetOrdinal(column));
        }

        public override float GetSingle(string column)
        {
            return Reader.GetFloat(Reader.GetOrdinal(column));
        }

        public override Guid GetGuid(string column)
        {
            return Reader.GetGuid(Reader.GetOrdinal(column));
        }

        public override short GetInt16(string column)
        {
            return Reader.GetInt16(Reader.GetOrdinal(column));
        }

        public override int GetInt32(string column)
        {
            return Reader.GetInt32(Reader.GetOrdinal(column));
        }

        public override long GetInt64(string column)
        {
            return Reader.GetInt64(Reader.GetOrdinal(column));
        }

        public override string GetName(string column)
        {
            return Reader.GetName(Reader.GetOrdinal(column));
        }

        public override int GetOrdinal(string name)
        {
            return Reader.GetOrdinal(name);
        }

        public override Type GetProviderSpecificFieldType(string column)
        {
            return Reader.GetProviderSpecificFieldType(Reader.GetOrdinal(column));
        }

        public override object GetProviderSpecificValue(string column)
        {
            return Reader.GetProviderSpecificValue(Reader.GetOrdinal(column));
        }

        public override int GetProviderSpecificValues(object[] values)
        {
            return Reader.GetProviderSpecificValues(values);
        }

        public override SqlBinary GetSqlBinary(string column)
        {
            return Reader.GetSqlBinary(Reader.GetOrdinal(column));
        }

        public override SqlBoolean GetSqlBoolean(string column)
        {
            return Reader.GetSqlBoolean(Reader.GetOrdinal(column));
        }

        public override SqlByte GetSqlByte(string column)
        {
            return Reader.GetSqlByte(Reader.GetOrdinal(column));
        }

        public override SqlBytes GetSqlBytes(string column)
        {
            return Reader.GetSqlBytes(Reader.GetOrdinal(column));
        }

        public override SqlChars GetSqlChars(string column)
        {
            return Reader.GetSqlChars(Reader.GetOrdinal(column));
        }

        public override SqlDateTime GetSqlDateTime(string column)
        {
            return Reader.GetSqlDateTime(Reader.GetOrdinal(column));
        }

        public override SqlDecimal GetSqlDecimal(string column)
        {
            return Reader.GetSqlDecimal(Reader.GetOrdinal(column));
        }

        public override SqlDouble GetSqlDouble(string column)
        {
            return Reader.GetSqlDouble(Reader.GetOrdinal(column));
        }

        public override SqlGuid GetSqlGuid(string column)
        {
            return Reader.GetSqlGuid(Reader.GetOrdinal(column));
        }

        public override SqlInt16 GetSqlInt16(string column)
        {
            return Reader.GetSqlInt16(Reader.GetOrdinal(column));
        }

        public override SqlInt32 GetSqlInt32(string column)
        {
            return Reader.GetSqlInt32(Reader.GetOrdinal(column));
        }

        public override SqlInt64 GetSqlInt64(string column)
        {
            return Reader.GetSqlInt64(Reader.GetOrdinal(column));
        }

        public override SqlMoney GetSqlMoney(string column)
        {
            return Reader.GetSqlMoney(Reader.GetOrdinal(column));
        }

        public override SqlSingle GetSqlSingle(string column)
        {
            return Reader.GetSqlSingle(Reader.GetOrdinal(column));
        }

        public override SqlString GetSqlString(string column)
        {
            return Reader.GetSqlString(Reader.GetOrdinal(column));
        }

        public override object GetSqlValue(string column)
        {
            return Reader.GetSqlBoolean(Reader.GetOrdinal(column));
        }

        public override SqlXml GetSqlXml(string column)
        {
            return Reader.GetSqlXml(Reader.GetOrdinal(column));
        }

        public override Stream GetStream(string column)
        {
            return Reader.GetStream(Reader.GetOrdinal(column));
        }

        public override string GetString(string column)
        {
            return Reader.GetString(Reader.GetOrdinal(column));
        }

        public override TextReader GetTextReader(string column)
        {
            return Reader.GetTextReader(Reader.GetOrdinal(column));
        }

        public override TimeSpan GetTimeSpan(string column)
        {
            return Reader.GetTimeSpan(Reader.GetOrdinal(column));
        }

        public override object GetValue(string column)
        {
            return Reader.GetValue(Reader.GetOrdinal(column));
        }

        public override XmlReader GetXmlReader(string column)
        {
            return Reader.GetXmlReader(Reader.GetOrdinal(column));
        }

        public override bool IsDBNull(string column)
        {
            return Reader.IsDBNull(Reader.GetOrdinal(column));
        }

        public override async Task<bool> IsDBNullAsync(string column, CancellationToken cancellationToken)
        {
            return await Reader.IsDBNullAsync(Reader.GetOrdinal(column), cancellationToken);
        }

        public override byte[] GetBinaryNullable(string column)
        {
            var result = Reader.GetSqlBinary(Reader.GetOrdinal(column));
            return result.IsNull ? null : result.Value;
        }

        public override bool? GetBooleanNullable(string column)
        {
            var result = Reader.GetSqlBoolean(Reader.GetOrdinal(column));
            return result.IsNull ? (bool?)null : result.Value;
        }

        public override byte? GetByteNullable(string column)
        {
            var result = Reader.GetSqlByte(Reader.GetOrdinal(column));
            return result.IsNull ? (byte?)null : result.Value;
        }

        public override byte[] GetBytesNullable(string column)
        {
            var result = Reader.GetSqlBytes(Reader.GetOrdinal(column));
            return result.IsNull ? null : result.Value;
        }

        public override char[] GetCharsNullable(string column)
        {
            var result = Reader.GetSqlChars(Reader.GetOrdinal(column));
            return result.IsNull ? null : result.Value;
        }

        public override DateTime? GetDateTimeNullable(string column)
        {
            var result = Reader.GetSqlDateTime(Reader.GetOrdinal(column));
            return result.IsNull ? (DateTime?)null : result.Value;
        }

        public override decimal? GetDecimalNullable(string column)
        {
            var result = Reader.GetSqlDecimal(Reader.GetOrdinal(column));
            return result.IsNull ? (decimal?)null : result.Value;
        }

        public override double? GetDoubleNullable(string column)
        {
            var result = Reader.GetSqlDouble(Reader.GetOrdinal(column));
            return result.IsNull ? (double?)null : result.Value;
        }

        public override Guid? GetGuidNullable(string column)
        {
            var result = Reader.GetSqlGuid(Reader.GetOrdinal(column));
            return result.IsNull ? (Guid?)null : result.Value;
        }

        public override short? GetInt16Nullable(string column)
        {
            var result = Reader.GetSqlInt16(Reader.GetOrdinal(column));
            return result.IsNull ? (short?)null : result.Value;
        }

        public override int? GetInt32Nullable(string column)
        {
            var result = Reader.GetSqlInt32(Reader.GetOrdinal(column));
            return result.IsNull ? (int?)null : result.Value;
        }

        public override long? GetInt64Nullable(string column)
        {
            var result = Reader.GetSqlInt64(Reader.GetOrdinal(column));
            return result.IsNull ? (long?)null : result.Value;
        }

        public override decimal? GetMoneyNullable(string column)
        {
            var result = Reader.GetSqlMoney(Reader.GetOrdinal(column));
            return result.IsNull ? (decimal?)null : result.Value;
        }

        public override float? GetSingleNullable(string column)
        {
            var result = Reader.GetSqlSingle(Reader.GetOrdinal(column));
            return result.IsNull ? (float?)null : result.Value;
        }

        public override string GetStringNullable(string column)
        {
            var result = Reader.GetSqlString(Reader.GetOrdinal(column));
            return result.IsNull ? null : result.Value;
        }

        public override string GetXmlNullable(string column)
        {
            var result = Reader.GetSqlXml(Reader.GetOrdinal(column));
            return result.IsNull ? null : result.Value;
        }
    }
}
