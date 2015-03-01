using System;
using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;

namespace AdoExecutor.Core.Interception.Infrastructure
{
  public class InterceptorErrorContext : Context.Infrastructure.Context
  {
    public InterceptorErrorContext(
      string query, 
      object parameters, 
      Type resultType, 
      InvokeMethod invokeMethod, 
      IDbConnection connection, 
      IDbCommand command, 
      IConfiguration configuration, 
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