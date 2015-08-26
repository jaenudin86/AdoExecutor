using System;
using System.Collections.Generic;
using System.Data;
using AdoExecutor.Utilities.PrimitiveTypes.Infrastructure;

namespace AdoExecutor.Utilities.PrimitiveTypes
{
  public class SqlPrimitiveDataTypes : ISqlPrimitiveDataTypes
  {
    private static readonly IDictionary<Type, DbType> PrimitiveDataTypes = new Dictionary<Type, DbType>
    {
      {typeof (bool), DbType.Boolean},
      {typeof (bool?), DbType.Boolean},
      {typeof (byte), DbType.Byte},
      {typeof (byte?), DbType.Byte},
      {typeof (sbyte), DbType.SByte},
      {typeof (sbyte?), DbType.SByte},
      {typeof (byte[]), DbType.Binary},
      {typeof (char), DbType.StringFixedLength},
      {typeof (char?), DbType.StringFixedLength},
      {typeof (char[]), DbType.String},
      {typeof (string), DbType.String},
      {typeof (short), DbType.Int16},
      {typeof (short?), DbType.Int16},
      {typeof (ushort), DbType.UInt16},
      {typeof (ushort?), DbType.UInt16},
      {typeof (int), DbType.Int32},
      {typeof (int?), DbType.Int32},
      {typeof (uint), DbType.UInt32},
      {typeof (uint?), DbType.UInt32},
      {typeof (long), DbType.Int64},
      {typeof (long?), DbType.Int64},
      {typeof (ulong), DbType.UInt64},
      {typeof (ulong?), DbType.UInt64},
      {typeof (float), DbType.Single},
      {typeof (float?), DbType.Single},
      {typeof (double), DbType.Double},
      {typeof (double?), DbType.Double},
      {typeof (decimal), DbType.Decimal},
      {typeof (decimal?), DbType.Decimal},
      {typeof (DateTime), DbType.DateTime},
      {typeof (DateTime?), DbType.DateTime},
      {typeof (DateTimeOffset), DbType.DateTimeOffset},
      {typeof (DateTimeOffset?), DbType.DateTimeOffset},
      {typeof (TimeSpan), DbType.Time},
      {typeof (TimeSpan?), DbType.Time},
      {typeof (Guid), DbType.Guid},
      {typeof (Guid?), DbType.Guid}
    };

    public virtual bool IsSqlPrimitiveType(Type dataType)
    {
      return PrimitiveDataTypes.Keys.Contains(dataType);
    }

    public virtual Type[] GetAllSqlPrimitiveTypes()
    {
      Type[] primitivesTypes = new Type[PrimitiveDataTypes.Count];

      PrimitiveDataTypes.Keys.CopyTo(primitivesTypes, 0);

      return primitivesTypes;
    }

    public bool IsNull(object value)
    {
      return value == null || Convert.IsDBNull(value);
    }

    public DbType ConvertTypeToDbType(Type type)
    {
      return PrimitiveDataTypes[type];
    }
  }
}