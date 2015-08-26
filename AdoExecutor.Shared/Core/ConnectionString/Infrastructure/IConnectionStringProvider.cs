namespace AdoExecutor.Core.ConnectionString.Infrastructure
{
  public interface IConnectionStringProvider
  {
    string ConnectionString { get; }
  }
}