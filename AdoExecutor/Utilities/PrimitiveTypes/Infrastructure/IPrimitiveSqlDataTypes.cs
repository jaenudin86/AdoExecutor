using System;

namespace AdoExecutor.Utilities.PrimitiveTypes.Infrastructure
{
  public interface IPrimitiveSqlDataTypes
  {
    bool IsSqlPrimitiveType(Type dataType);
    Type[] GetAllSqlPrimitiveTypes();
  }
}