using System;
using System.Linq;
using AdoExecutor.Utilities.PrimitiveTypes.Infrastructure;

namespace AdoExecutor.Utilities.PrimitiveTypes
{
  public class SqlPrimitiveDataTypes : ISqlPrimitiveDataTypes
  {
    private static readonly Type[] PrimitiveDataTypes =
    {
      typeof (bool),
      typeof (bool?),
      typeof (byte),
      typeof (byte?),
      typeof (sbyte),
      typeof (sbyte?),
      typeof (byte[]),
      typeof (char),
      typeof (char?),
      typeof (char[]),
      typeof (string),
      typeof (short),
      typeof (short?),
      typeof (ushort),
      typeof (ushort?),
      typeof (int),
      typeof (int?),
      typeof (uint),
      typeof (uint?),
      typeof (long),
      typeof (long?),
      typeof (ulong),
      typeof (ulong?),
      typeof (float),
      typeof (float?),
      typeof (double),
      typeof (double?),
      typeof (decimal),
      typeof (decimal?),
      typeof (DateTime),
      typeof (DateTime?),
      typeof (DateTimeOffset),
      typeof (DateTimeOffset?),
      typeof (TimeSpan),
      typeof (TimeSpan?),
      typeof (Guid),
      typeof (Guid?)
    };

    public virtual bool IsSqlPrimitiveType(Type dataType)
    {
      return PrimitiveDataTypes.Contains(dataType);
    }

    public virtual Type[] GetAllSqlPrimitiveTypes()
    {
      return PrimitiveDataTypes.ToArray();
    }
  }
}