using System.Data;
using AdoExecutor.Configuration;

namespace AdoExecutor.Context
{
  public interface IAdoExecutorContext
  {
    string Query { get; }
    object Parameters { get; }
    IDbConnection Connection { get; }
    IDbCommand Command { get; }
    IAdoExecutorConfiguration Configuration { get; }  
  }
}