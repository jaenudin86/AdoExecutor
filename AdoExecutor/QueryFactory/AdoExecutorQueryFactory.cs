using System;
using AdoExecutor.Configuration;
using AdoExecutor.Query;

namespace AdoExecutor.QueryFactory
{
  public class AdoExecutorQueryFactory : IAdoExecutorQueryFactory
  {
    private readonly IAdoExecutorConfiguration _configuration;

    public AdoExecutorQueryFactory(IAdoExecutorConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException("configuration");

      _configuration = configuration;
    }

    public IAdoExecutorQuery CreateQuery()
    {
      return new AdoExecutorQuery(_configuration);
    }
  }
}