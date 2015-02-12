using System;
using System.Data;
using AdoExecutor.Configuration;
using AdoExecutor.Context;

namespace AdoExecutor.Interception
{
  public class AdoExecutorInterceptorExitContext : AdoExecutorContext, IAdoExecutorInterceptorExitContext
  {
    public AdoExecutorInterceptorExitContext(
      string query,
      object parameters,
      IDbConnection connection,
      IDbCommand command,
      IAdoExecutorConfiguration configuration,
      object result,
      System.Exception exception) : base(query, parameters, connection, command, configuration)
    {
      Exception = exception;
      Result = result;
    }

    public object Result { get; private set; }
    public System.Exception Exception { get; private set; }
  }
}