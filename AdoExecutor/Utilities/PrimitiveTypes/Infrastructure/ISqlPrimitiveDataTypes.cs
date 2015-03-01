using System;

namespace AdoExecutor.Utilities.PrimitiveTypes.Infrastructure
{
  public interface ISqlPrimitiveDataTypes
  {
    bool IsSqlPrimitiveType(Type dataType);
    Type[] GetAllSqlPrimitiveTypes();
  }
}