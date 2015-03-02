using System;
using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;

namespace AdoExecutor.Core.Interception.Infrastructure
{
  public class InterceptorSuccessContext : Context.Infrastructure.AdoExecutorContext
  {
    public InterceptorSuccessContext(
      string query, 
      object parameters, 
      Type resultType, 
      InvokeMethod invokeMethod, 
      IDbConnection connection, 
      IDbCommand command, 
      IConfiguration configuration, 
      object result) 
      : base(query, parameters, resultType, invokeMethod, connection, command, configuration)
    {
      Result = result;
    }

    public object Result { get; private set; }
  }
}