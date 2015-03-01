using System;
using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;

namespace AdoExecutor.Core.Interception.Infrastructure
{
  public class InterceptorExitContext : Context.Infrastructure.Context
  {
    public InterceptorExitContext(
      string query, 
      object parameters, 
      Type resultType, 
      InvokeMethod invokeMethod, 
      IDbConnection connection, 
      IDbCommand command, 
      IConfiguration configuration, 
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