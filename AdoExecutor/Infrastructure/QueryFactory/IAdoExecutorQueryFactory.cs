using AdoExecutor.Infrastructure.Query;

namespace AdoExecutor.Infrastructure.QueryFactory
{
  public interface IAdoExecutorQueryFactory
  {
    IAdoExecutorQuery CreateQuery();
  }
}