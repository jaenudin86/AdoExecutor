using System;
using System.Data;

namespace AdoExecutor.Helper
{
  public interface IDotNetToSqlBridge
  {
    Type[] GetSupportedDotNetTypes();
    bool IsSupportedDotNetType(Type type);
    DbType GetDbTypeFromDotNetType(Type netType);
  }
}