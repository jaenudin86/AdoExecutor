using System.Data;
using AdoExecutor.Configuration;

namespace AdoExecutor.Interception
{
  public class AdoExecutorInterceptorEntryContext : AdoExecutorInterceptorContextBase, IAdoExecutorInterceptorEntryContext
  {
    public AdoExecutorInterceptorEntryContext(
      string query, 
      object parameters, 
      IDbConnection connection,
      IDbCommand command, 
      IAdoExecutorConfiguration configuration)
      : base(query, parameters, connection, command, configuration)
    {
    }
  }
}