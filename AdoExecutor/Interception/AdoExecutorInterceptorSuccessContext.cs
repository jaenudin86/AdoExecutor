using System.Data;
using AdoExecutor.Configuration;

namespace AdoExecutor.Interception
{
  public class AdoExecutorInterceptorSuccessContext : AdoExecutorInterceptorContextBase,
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