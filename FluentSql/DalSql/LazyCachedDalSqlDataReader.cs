using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace FluentSql
{
    public class LazyCachedDalSqlDataReader : BaseDalSqlDataReader
    {
        public LazyCachedDalSqlDataReader(SqlDataReader iReader)
            : base(iReader)
        {
            Keys = new SortedDictionary<string, int>();
        }

        public object this[string name]
        {
            get
            {
                return Reader[GetKey(name)];
            }
        }

        public override bool GetBoolean(string column)
        {
            return Reader.GetBoolean(GetKey(column));
        }

        public override byte GetByte(string column)
        {
            return Reader.GetByte(GetKey(column));
        }

        public override long GetBytes(string column, long dataIndex, byte[] buffer, int bufferIndex, int length)
        {
            return Reader.GetBytes(GetKey(column), dataIndex, buffer, bufferIndex, length);
        }

        public override byte[] GetAllBytes(string column)
        {
            return (byte[])Reader[GetKey(column)];
        }

        public override char GetChar(string column)
        {
            return Reader.GetChar(GetKey(column));
        }

        public override long GetChars(string column, long dataIndex, char[] buffer, int bufferIndex, int length)
        {
            return Reader.GetChars(GetKey(column), dataIndex, buffer, bufferIndex, length);
        }

        public override string GetDataTypeName(string column)
        {
            return Reader.GetDataTypeName(GetKey(column));
        }

        public override DateTime GetDateTime(string column)
        {
            return Reader.GetDateTime(GetKey(column));
        }

        public override DateTimeOffset GetDateTimeOffset(string column)
        {
            return Reader.GetDateTimeOffset(GetKey(column));
        }

        public override decimal GetDecimal(string column)
        {
            return Reader.GetDecimal(GetKey(column));
        }

        public override double GetDouble(string column)
        {
            return Reader.GetDouble(GetKey(column));
        }

        public override Type GetFieldType(string column)
        {
            return Reader.GetFieldType(GetKey(column));
        }

        public override T GetFieldValue<T>(string column)
        {
            return Reader.GetFieldValue<T>(GetKey(column));
        }

        public override async Task<T> GetFieldValueAsync<T>(string column, CancellationToken cancellationToken)
        {
            return await Reader.GetFieldValueAsync<T>(GetKey(column));
        }

        public override float GetSingle(string column)
        {
            return Reader.GetFloat(GetKey(column));
        }

        public override Guid GetGuid(string column)
        {
            return Reader.GetGuid(GetKey(column));
        }

        public override short GetInt16(string column)
        {
            return Reader.GetInt16(GetKey(column));
        }

        public override int GetInt32(string column)
        {
            return Reader.GetInt32(GetKey(column));
        }

        public override long GetInt64(string column)
        {
            return Reader.GetInt64(GetKey(column));
        }

        public override string GetName(string column)
        {
            return Reader.GetName(GetKey(column));
        }

        public override int GetOrdinal(string name)
        {
            return Reader.GetOrdinal(name);
        }

        public override Type GetProviderSpecificFieldType(string column)
        {
            return Reader.GetProviderSpecificFieldType(GetKey(column));
        }

        public override object GetProviderSpecificValue(string column)
        {
            return Reader.GetProviderSpecificValue(GetKey(column));
        }

        public override int GetProviderSpecificValues(object[] values)
        {
            return Reader.GetProviderSpecificValues(values);
        }

        public override SqlBinary GetSqlBinary(string column)
        {
            return Reader.GetSqlBinary(GetKey(column));
        }

        public override SqlBoolean GetSqlBoolean(string column)
        {
            return Reader.GetSqlBoolean(GetKey(column));
        }

        public override SqlByte GetSqlByte(string column)
        {
            return Reader.GetSqlByte(GetKey(column));
        }

        public override SqlBytes GetSqlBytes(string column)
        {
            return Reader.GetSqlBytes(GetKey(column));
        }

        public override SqlChars GetSqlChars(string column)
        {
            return Reader.GetSqlChars(GetKey(column));
        }

        public override SqlDateTime GetSqlDateTime(string column)
        {
            return Reader.GetSqlDateTime(GetKey(column));
        }

        public override SqlDecimal GetSqlDecimal(string column)
        {
            return Reader.GetSqlDecimal(GetKey(column));
        }

        public override SqlDouble GetSqlDouble(string column)
        {
            return Reader.GetSqlDouble(GetKey(column));
        }

        public override SqlGuid GetSqlGuid(string column)
        {
            return Reader.GetSqlGuid(GetKey(column));
        }

        public override SqlInt16 GetSqlInt16(string column)
        {
            return Reader.GetSqlInt16(GetKey(column));
        }

        public override SqlInt32 GetSqlInt32(string column)
        {
            return Reader.GetSqlInt32(GetKey(column));
        }

        public override SqlInt64 GetSqlInt64(string column)
        {
            return Reader.GetSqlInt64(GetKey(column));
        }

        public override SqlMoney GetSqlMoney(string column)
        {
            return Reader.GetSqlMoney(GetKey(column));
        }

        public override SqlSingle GetSqlSingle(string column)
        {
            return Reader.GetSqlSingle(GetKey(column));
        }

        public override SqlString GetSqlString(string column)
        {
            return Reader.GetSqlString(GetKey(column));
        }

        public override object GetSqlValue(string column)
        {
            return Reader.GetSqlBoolean(GetKey(column));
        }

        public override SqlXml GetSqlXml(string column)
        {
            return Reader.GetSqlXml(GetKey(column));
        }

        public override Stream GetStream(string column)
        {
            return Reader.GetStream(GetKey(column));
        }

        public override string GetString(string column)
        {
            return Reader.GetString(GetKey(column));
        }

        public override TextReader GetTextReader(string column)
        {
            return Reader.GetTextReader(GetKey(column));
        }

        public override TimeSpan GetTimeSpan(string column)
        {
            return Reader.GetTimeSpan(GetKey(column));
        }

        public override object GetValue(string column)
        {
            return Reader.GetValue(GetKey(column));
        }

        public override XmlReader GetXmlReader(string column)
        {
            return Reader.GetXmlReader(GetKey(column));
        }

        public override bool IsDBNull(string column)
        {
            return Reader.IsDBNull(GetKey(column));
        }

        public override async Task<bool> IsDBNullAsync(string column, CancellationToken cancellationToken)
        {
            return await Reader.IsDBNullAsync(GetKey(column), cancellationToken);
        }

        public override bool NextResult()
        {
            var result = Reader.NextResult();
            Keys.Clear();
            return result;
        }

        public override async Task<bool> NextResultAsync(CancellationToken cancellationToken)
        {
            var result = await Reader.NextResultAsync(cancellationToken);
            Keys.Clear();
            return result;
        }

        public override byte[] GetBinaryNullable(string column)
        {
            var result = Reader.GetSqlBinary(GetKey(column));
            return result.IsNull ? null : result.Value;
        }

        public override bool? GetBooleanNullable(string column)
        {
            var result = Reader.GetSqlBoolean(GetKey(column));
            return result.IsNull ? (bool?)null : result.Value;
        }

        public override byte? GetByteNullable(string column)
        {
            var result = Reader.GetSqlByte(GetKey(column));
            return result.IsNull ? (byte?)null : result.Value;
        }

        public override byte[] GetBytesNullable(string column)
        {
            var result = Reader.GetSqlBytes(GetKey(column));
            return result.IsNull ? null : result.Value;
        }

        public override char[] GetCharsNullable(string column)
        {
            var result = Reader.GetSqlChars(GetKey(column));
            return result.IsNull ? null : result.Value;
        }

        public override DateTime? GetDateTimeNullable(string column)
        {
            var result = Reader.GetSqlDateTime(GetKey(column));
            return result.IsNull ? (DateTime?)null : result.Value;
        }

        public override decimal? GetDecimalNullable(string column)
        {
            var result = Reader.GetSqlDecimal(GetKey(column));
            return result.IsNull ? (decimal?)null : result.Value;
        }

        public override double? GetDoubleNullable(string column)
        {
            var result = Reader.GetSqlDouble(GetKey(column));
            return result.IsNull ? (double?)null : result.Value;
        }

        public override Guid? GetGuidNullable(string column)
        {
            var result = Reader.GetSqlGuid(GetKey(column));
            return result.IsNull ? (Guid?)null : result.Value;
        }

        public override short? GetInt16Nullable(string column)
        {
            var result = Reader.GetSqlInt16(GetKey(column));
            return result.IsNull ? (short?)null : result.Value;
        }

        public override int? GetInt32Nullable(string column)
        {
            var result = Reader.GetSqlInt32(GetKey(column));
            return result.IsNull ? (int?)null : result.Value;
        }

        public override long? GetInt64Nullable(string column)
        {
            var result = Reader.GetSqlInt64(GetKey(column));
            return result.IsNull ? (long?)null : result.Value;
        }

        public override decimal? GetMoneyNullable(string column)
        {
            var result = Reader.GetSqlMoney(GetKey(column));
            return result.IsNull ? (decimal?)null : result.Value;
        }

        public override float? GetSingleNullable(string column)
        {
            var result = Reader.GetSqlSingle(GetKey(column));
            return result.IsNull ? (float?)null : result.Value;
        }

        public override string GetStringNullable(string column)
        {
            var result = Reader.GetSqlString(GetKey(column));
            return result.IsNull ? null : result.Value;
        }

        public override string GetXmlNullable(string column)
        {
            var result = Reader.GetSqlXml(GetKey(column));
            return result.IsNull ? null : result.Value;
        }

        private SortedDictionary<string, int> Keys;

        private int GetKey(string name)
        {
            int value;
            if (Keys.TryGetValue(name, out value))
            {
                return value;
            }
            else
            {
                value = Reader.GetOrdinal(name);
                Keys.Add(name, Reader.GetOrdinal(name));
                return value;
            }
        }
    }
}
