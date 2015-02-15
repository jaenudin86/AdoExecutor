using System;
using AdoExecutor.Core.Query;
using AdoExecutor.Infrastructure.Configuration;
using AdoExecutor.Infrastructure.Query;
using AdoExecutor.Infrastructure.QueryFactory;

namespace AdoExecutor.Core.QueryFactory
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