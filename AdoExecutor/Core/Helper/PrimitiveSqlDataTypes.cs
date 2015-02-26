using System;
using System.Linq;

namespace AdoExecutor.Core.Helper
{
  public class PrimitiveSqlDataTypes
  {
    private static readonly Type[] PrimitiveDataTypes =
    {
      typeof (bool),
      typeof (byte),
      typeof (sbyte),
      typeof (byte[]),
      typeof (char),
      typeof (char[]),
      typeof (string),
      typeof (short),
      typeof (ushort),
      typeof (int),
      typeof (uint),
      typeof (long),
      typeof (ulong),
      typeof (float),
      typeof (double),
      typeof (decimal),
      typeof (DateTime),
      typeof (DateTimeOffset),
      typeof (TimeSpan),
      typeof (Guid)
    };

    public bool IsSqlPrimitiveType(Type dataType)
    {
      var dataTypeToCheck = Nullable.GetUnderlyingType(dataType) ?? dataType;

      return PrimitiveDataTypes.Contains(dataTypeToCheck);
    }
  }
}