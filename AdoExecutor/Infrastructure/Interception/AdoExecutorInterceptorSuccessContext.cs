using System;
using System.Data;
using AdoExecutor.Infrastructure.Configuration;
using AdoExecutor.Infrastructure.Context;

namespace AdoExecutor.Infrastructure.Interception
{
  public class AdoExecutorInterceptorSuccessContext : AdoExecutorContext
  {
    public AdoExecutorInterceptorSuccessContext(
      string query, 
      object parameters, 
      Type resultType, 
      AdoExecutorInvokeMethod invokeMethod, 
      IDbConnection connection, 
      IDbCommand command, 
      IAdoExecutorConfiguration configuration, 
      object result) 
      : base(query, parameters, resultType, invokeMethod, connection, command, configuration)
    {
      Result = result;
    }

    public object Result { get; private set; }
  }
}