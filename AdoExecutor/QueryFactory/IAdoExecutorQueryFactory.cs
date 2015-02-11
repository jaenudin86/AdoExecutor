using AdoExecutor.Query;

namespace AdoExecutor.QueryFactory
{
  public interface IAdoExecutorQueryFactory
  {
    IAdoExecutorQuery CreateQuery();
  }
}