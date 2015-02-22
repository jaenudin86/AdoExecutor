using System;
using System.Data;

namespace AdoExecutor.Infrastructure.Query
{
  public interface IAdoExecutorQuery : IDisposable
  {
    IDbConnection Connection { get; }
    int Execute(string query, object parameters = null, AdoExecutorQueryOptions options = null);
    T Select<T>(string query, object parameters = null, AdoExecutorQueryOptions options = null);
  }
}