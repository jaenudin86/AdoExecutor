using System;
using System.Data;
using AdoExecutor.Infrastructure.Configuration;
using AdoExecutor.Infrastructure.Context;

namespace AdoExecutor.Infrastructure.Interception
{
  public class AdoExecutorInterceptorErrorContext : AdoExecutorContext
  {
    public AdoExecutorInterceptorErrorContext(
      string query, 
      object parameters, 
      Type resultType, 
      AdoExecutorInvokeMethod invokeMethod, 
      IDbConnection connection, 
      IDbCommand command, 
      IAdoExecutorConfiguration configuration, 
      System.Exception exception) 
      : base(query, parameters, resultType, invokeMethod, connection, command, configuration)
    {
      if (exception == null)
        throw new ArgumentNullException("exception");

      Exception = exception;
    }

    public System.Exception Exception { get; private set; }
  }
}