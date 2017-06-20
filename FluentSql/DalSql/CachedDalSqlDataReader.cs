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
    public class CachedDalSqlDataReader : BaseDalSqlDataReader
    {
        public CachedDalSqlDataReader(SqlDataReader iReader)
            : base(iReader)
        {
            Keys = new SortedDictionary<string, int>();
            InitKeys();
        }

        public object this[string name]
        {
            get
            {
                return Reader[Keys[name]];
            }
        }

        public override bool GetBoolean(string column)
        {
            return Reader.GetBoolean(Keys[column]);
        }

        public override byte GetByte(string column)
        {
            return Reader.GetByte(Keys[column]);
        }

        public override long GetBytes(string column, long dataIndex, byte[] buffer, int bufferIndex, int length)
        {
            return Reader.GetBytes(Keys[column], dataIndex, buffer, bufferIndex, length);
        }

        public override byte[] GetAllBytes(string column)
        {
            return (byte[])Reader[Keys[column]];
        }

        public override char GetChar(string column)
        {
            return Reader.GetChar(Keys[column]);
        }

        public override long GetChars(string column, long dataIndex, char[] buffer, int bufferIndex, int length)
        {
            return Reader.GetChars(Keys[column], dataIndex, buffer, bufferIndex, length);
        }

        public override string GetDataTypeName(string column)
        {
            return Reader.GetDataTypeName(Keys[column]);
        }

        public override DateTime GetDateTime(string column)
        {
            return Reader.GetDateTime(Keys[column]);
        }

        public override DateTimeOffset GetDateTimeOffset(string column)
        {
            return Reader.GetDateTimeOffset(Keys[column]);
        }

        public override decimal GetDecimal(string column)
        {
            return Reader.GetDecimal(Keys[column]);
        }

        public override double GetDouble(string column)
        {
            return Reader.GetDouble(Keys[column]);
        }

        public override Type GetFieldType(string column)
        {
            return Reader.GetFieldType(Keys[column]);
        }

        public override T GetFieldValue<T>(string column)
        {
            return Reader.GetFieldValue<T>(Keys[column]);
        }

        public override async Task<T> GetFieldValueAsync<T>(string column, CancellationToken cancellationToken)
        {
            return await Reader.GetFieldValueAsync<T>(Keys[column]);
        }

        public override float GetFloat(string column)
        {
            return Reader.GetFloat(Keys[column]);
        }

        public override Guid GetGuid(string column)
        {
            return Reader.GetGuid(Keys[column]);
        }

        public override short GetInt16(string column)
        {
            return Reader.GetInt16(Keys[column]);
        }

        public override int GetInt32(string column)
        {
            return Reader.GetInt32(Keys[column]);
        }

        public override long GetInt64(string column)
        {
            return Reader.GetInt64(Keys[column]);
        }

        public override string GetName(string column)
        {
            return Reader.GetName(Keys[column]);
        }

        public override int GetOrdinal(string name)
        {
            return Reader.GetOrdinal(name);
        }

        public override Type GetProviderSpecificFieldType(string column)
        {
            return Reader.GetProviderSpecificFieldType(Keys[column]);
        }

        public override object GetProviderSpecificValue(string column)
        {
            return Reader.GetProviderSpecificValue(Keys[column]);
        }

        public override int GetProviderSpecificValues(object[] values)
        {
            return Reader.GetProviderSpecificValues(values);
        }

        public override SqlBinary GetSqlBinary(string column)
        {
            return Reader.GetSqlBinary(Keys[column]);
        }

        public override SqlBoolean GetSqlBoolean(string column)
        {
            return Reader.GetSqlBoolean(Keys[column]);
        }

        public override SqlByte GetSqlByte(string column)
        {
            return Reader.GetSqlByte(Keys[column]);
        }

        public override SqlBytes GetSqlBytes(string column)
        {
            return Reader.GetSqlBytes(Keys[column]);
        }

        public override SqlChars GetSqlChars(string column)
        {
            return Reader.GetSqlChars(Keys[column]);
        }

        public override SqlDateTime GetSqlDateTime(string column)
        {
            return Reader.GetSqlDateTime(Keys[column]);
        }

        public override SqlDecimal GetSqlDecimal(string column)
        {
            return Reader.GetSqlDecimal(Keys[column]);
        }

        public override SqlDouble GetSqlDouble(string column)
        {
            return Reader.GetSqlDouble(Keys[column]);
        }

        public override SqlGuid GetSqlGuid(string column)
        {
            return Reader.GetSqlGuid(Keys[column]);
        }

        public override SqlInt16 GetSqlInt16(string column)
        {
            return Reader.GetSqlInt16(Keys[column]);
        }

        public override SqlInt32 GetSqlInt32(string column)
        {
            return Reader.GetSqlInt32(Keys[column]);
        }

        public override SqlInt64 GetSqlInt64(string column)
        {
            return Reader.GetSqlInt64(Keys[column]);
        }

        public override SqlMoney GetSqlMoney(string column)
        {
            return Reader.GetSqlMoney(Keys[column]);
        }

        public override SqlSingle GetSqlSingle(string column)
        {
            return Reader.GetSqlSingle(Keys[column]);
        }

        public override SqlString GetSqlString(string column)
        {
            return Reader.GetSqlString(Keys[column]);
        }

        public override object GetSqlValue(string column)
        {
            return Reader.GetSqlValue(Keys[column]);
        }

        public override SqlXml GetSqlXml(string column)
        {
            return Reader.GetSqlXml(Keys[column]);
        }

        public override Stream GetStream(string column)
        {
            return Reader.GetStream(Keys[column]);
        }

        public override string GetString(string column)
        {
            return Reader.GetString(Keys[column]);
        }

        public override TextReader GetTextReader(string column)
        {
            return Reader.GetTextReader(Keys[column]);
        }

        public override TimeSpan GetTimeSpan(string column)
        {
            return Reader.GetTimeSpan(Keys[column]);
        }

        public override object GetValue(string column)
        {
            return Reader.GetValue(Keys[column]);
        }

        public override XmlReader GetXmlReader(string column)
        {
            return Reader.GetXmlReader(Keys[column]);
        }

        public override bool IsDBNull(string column)
        {
            return Reader.IsDBNull(Keys[column]);
        }

        public override async Task<bool> IsDBNullAsync(string column, CancellationToken cancellationToken)
        {
            return await Reader.IsDBNullAsync(Keys[column], cancellationToken);
        }

        public override bool NextResult()
        {
            var result = Reader.NextResult();
            Keys.Clear();
            InitKeys();
            return result;
        }

        public override async Task<bool> NextResultAsync(CancellationToken cancellationToken)
        {
            var result = await Reader.NextResultAsync(cancellationToken);
            Keys.Clear();
            InitKeys();
            return result;
        }

        private SortedDictionary<string, int> Keys;

        private void InitKeys()
        {
            for (int i = 0; i < Reader.FieldCount; i++)
            {
                Keys.Add(Reader.GetName(i), i);
            }
        }

        public override byte[] GetBinaryNullable(string column)
        {
            var result = Reader.GetSqlBinary(Keys[column]);
            return result.IsNull ? null : result.Value;
        }

        public override bool? GetBooleanNullable(string column)
        {
            var result = Reader.GetSqlBoolean(Keys[column]);
            return result.IsNull ? (bool?)null : result.Value;
        }

        public override byte? GetByteNullable(string column)
        {
            var result = Reader.GetSqlByte(Keys[column]);
            return result.IsNull ? (byte?)null : result.Value;
        }

        public override byte[] GetBytesNullable(string column)
        {
            var result = Reader.GetSqlBytes(Keys[column]);
            return result.IsNull ? null : result.Value;
        }

        public override char[] GetCharsNullable(string column)
        {
            var result = Reader.GetSqlChars(Keys[column]);
            return result.IsNull ? null : result.Value;
        }

        public override DateTime? GetDateTimeNullable(string column)
        {
            var result = Reader.GetSqlDateTime(Keys[column]);
            return result.IsNull ? (DateTime?)null : result.Value;
        }

        public override decimal? GetDecimalNullable(string column)
        {
            var result = Reader.GetSqlDecimal(Keys[column]);
            return result.IsNull ? (decimal?)null : result.Value;
        }

        public override double? GetDoubleNullable(string column)
        {
            var result = Reader.GetSqlDouble(Keys[column]);
            return result.IsNull ? (double?)null : result.Value;
        }

        public override Guid? GetGuidNullable(string column)
        {
            var result = Reader.GetSqlGuid(Keys[column]);
            return result.IsNull ? (Guid?)null : result.Value;
        }

        public override short? GetInt16Nullable(string column)
        {
            var result = Reader.GetSqlInt16(Keys[column]);
            return result.IsNull ? (short?)null : result.Value;
        }

        public override int? GetInt32Nullable(string column)
        {
            var result = Reader.GetSqlInt32(Keys[column]);
            return result.IsNull ? (int?)null : result.Value;
        }

        public override long? GetInt64Nullable(string column)
        {
            var result = Reader.GetSqlInt64(Keys[column]);
            return result.IsNull ? (long?)null : result.Value;
        }

        public override decimal? GetMoneyNullable(string column)
        {
            var result = Reader.GetSqlMoney(Keys[column]);
            return result.IsNull ? (decimal?)null : result.Value;
        }

        public override float? GetSingleNullable(string column)
        {
            var result = Reader.GetSqlSingle(Keys[column]);
            return result.IsNull ? (float?)null : result.Value;
        }

        public override string GetStringNullable(string column)
        {
            var result = Reader.GetSqlString(Keys[column]);
            return result.IsNull ? null : result.Value;
        }

        public override string GetXmlNullable(string column)
        {
            var result = Reader.GetSqlXml(Keys[column]);
            return result.IsNull ? null : result.Value;
        }
    }
}
