using System.Data;
using AdoExecutor.Configuration;

namespace AdoExecutor.Interception
{
  public interface IAdoExecutorInterceptorContext
  {
    string Query { get; }
    object Parameters { get; }
    IDbConnection Connection { get; }
    IDbCommand Command { get; }
    IAdoExecutorConfiguration Configuration { get; }
  }
}