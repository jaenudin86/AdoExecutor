using AdoExecutor.Core.Query.Infrastructure;

namespace AdoExecutor.Core.QueryFactory.Infrastructure
{
  public interface IQueryFactory
  {
    IQuery CreateQuery();
  }
}