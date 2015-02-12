using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AdoExecutor.Exception;

namespace AdoExecutor.Helper
{
  public class DotNetToSqlBridge : IDotNetToSqlBridge
  {
    readonly IDictionary<Type, DbType> _typeMap = new Dictionary<Type, DbType>();

    public DotNetToSqlBridge()
    {
      //get from dapper
      _typeMap[typeof(byte)] = DbType.Byte;
      _typeMap[typeof(sbyte)] = DbType.SByte;
      _typeMap[typeof(short)] = DbType.Int16;
      _typeMap[typeof(ushort)] = DbType.UInt16;
      _typeMap[typeof(int)] = DbType.Int32;
      _typeMap[typeof(uint)] = DbType.UInt32;
      _typeMap[typeof(long)] = DbType.Int64;
      _typeMap[typeof(ulong)] = DbType.UInt64;
      _typeMap[typeof(float)] = DbType.Single;
      _typeMap[typeof(double)] = DbType.Double;
      _typeMap[typeof(decimal)] = DbType.Decimal;
      _typeMap[typeof(bool)] = DbType.Boolean;
      _typeMap[typeof(string)] = DbType.String;
      _typeMap[typeof(char)] = DbType.StringFixedLength;
      _typeMap[typeof(Guid)] = DbType.Guid;
      _typeMap[typeof(DateTime)] = DbType.DateTime;
      _typeMap[typeof(DateTimeOffset)] = DbType.DateTimeOffset;
      _typeMap[typeof(byte[])] = DbType.Binary;
      _typeMap[typeof(byte?)] = DbType.Byte;
      _typeMap[typeof(sbyte?)] = DbType.SByte;
      _typeMap[typeof(short?)] = DbType.Int16;
      _typeMap[typeof(ushort?)] = DbType.UInt16;
      _typeMap[typeof(int?)] = DbType.Int32;
      _typeMap[typeof(uint?)] = DbType.UInt32;
      _typeMap[typeof(long?)] = DbType.Int64;
      _typeMap[typeof(ulong?)] = DbType.UInt64;
      _typeMap[typeof(float?)] = DbType.Single;
      _typeMap[typeof(double?)] = DbType.Double;
      _typeMap[typeof(decimal?)] = DbType.Decimal;
      _typeMap[typeof(bool?)] = DbType.Boolean;
      _typeMap[typeof(char?)] = DbType.StringFixedLength;
      _typeMap[typeof(Guid?)] = DbType.Guid;
      _typeMap[typeof(DateTime?)] = DbType.DateTime;
      _typeMap[typeof(DateTimeOffset?)] = DbType.DateTimeOffset;
    }


    public Type[] GetSupportedDotNetTypes()
    {
      return _typeMap.Keys.ToArray();
    }

    public bool IsSupportedDotNetType(Type type)
    {
      return _typeMap.ContainsKey(type);
    }

    public DbType GetDbTypeFromDotNetType(Type netType)
    {
      DbType dbType;

      if (_typeMap.TryGetValue(netType, out dbType))
        return dbType;

      throw new AdoExecutorException("Not found mapping");
    }
  }
}
