using System;
using System.Data;
using AdoExecutor.Configuration;

namespace AdoExecutor.Interception
{
  public class AdoExecutorInterceptorErrorContext : AdoExecutorInterceptorContextBase,
    IAdoExecutorInterceptorErrorContext
  {
    public AdoExecutorInterceptorErrorContext(
      string query,
      object parameters,
      IDbConnection connection,
      IDbCommand command,
      IAdoExecutorConfiguration configuration,
      System.Exception exception)
      : base(query, parameters, connection, command, configuration)
    {
      if (exception == null)
        throw new ArgumentNullException("exception");

      Exception = exception;
    }

    public System.Exception Exception { get; private set; }
  }
}