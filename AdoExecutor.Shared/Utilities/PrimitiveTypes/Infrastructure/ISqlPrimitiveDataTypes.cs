using System;
using System.Data;

namespace AdoExecutor.Utilities.PrimitiveTypes.Infrastructure
{
  public interface ISqlPrimitiveDataTypes
  {
    bool IsSqlPrimitiveType(Type dataType);
    Type[] GetAllSqlPrimitiveTypes();
    bool IsNull(object value);
    DbType ConvertTypeToDbType(Type type);
  }
}