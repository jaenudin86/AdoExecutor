using System;
using System.Data;
using AdoExecutor.Infrastructure.Configuration;
using AdoExecutor.Infrastructure.Context;

namespace AdoExecutor.Infrastructure.Interception
{
  public class AdoExecutorInterceptorExitContext : AdoExecutorContext
  {
    public AdoExecutorInterceptorExitContext(
      string query, 
      object parameters, 
      Type resultType, 
      AdoExecutorInvokeMethod invokeMethod, 
      IDbConnection connection, 
      IDbCommand command, 
      IAdoExecutorConfiguration configuration, 
      object result, 
      System.Exception exception) 
      : base(query, parameters, resultType, invokeMethod, connection, command, configuration)
    {
      Exception = exception;
      Result = result;
    }

    public object Result { get; private set; }
    public System.Exception Exception { get; private set; }
  }
}