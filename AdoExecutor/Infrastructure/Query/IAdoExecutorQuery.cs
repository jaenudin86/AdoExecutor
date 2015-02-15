using System.Data;

namespace AdoExecutor.Infrastructure.Query
{
  public interface IAdoExecutorQuery
  {
    IDbConnection Connection { get; }
    int Execute(string query, object parameters = null);
    T Select<T>(string query, object parameters = null);
  }
}