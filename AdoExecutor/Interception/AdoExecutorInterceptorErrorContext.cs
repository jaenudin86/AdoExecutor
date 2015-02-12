using System;
using System.Data;
using AdoExecutor.Configuration;
using AdoExecutor.Context;

namespace AdoExecutor.Interception
{
  public class AdoExecutorInterceptorErrorContext : AdoExecutorContext,
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