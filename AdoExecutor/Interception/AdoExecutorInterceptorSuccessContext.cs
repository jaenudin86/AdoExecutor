using System.Data;
using AdoExecutor.Configuration;
using AdoExecutor.Context;

namespace AdoExecutor.Interception
{
  public class AdoExecutorInterceptorSuccessContext : AdoExecutorContext,
    IAdoExecutorInterceptorSuccessContext
  {
    public AdoExecutorInterceptorSuccessContext(
      string query,
      object parameters,
      IDbConnection connection,
      IDbCommand command,
      IAdoExecutorConfiguration configuration, object result)
      : base(query, parameters, connection, command, configuration)
    {
      Result = result;
    }

    public object Result { get; private set; }
  }
}