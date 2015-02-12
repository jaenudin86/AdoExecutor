using System;
using System.Data;
using AdoExecutor.Configuration;
using AdoExecutor.Query;
using AdoExecutor.QueryFactory;

namespace AdoExecutor.TestApp
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      IAdoExecutorConfiguration configuration = new AdoExecutorConfigurationFactory().CreateDefaultConfiguration("test");
      var queryFactory = new AdoExecutorQueryFactory(configuration);

      IAdoExecutorQuery query = queryFactory.CreateQuery();

      var result = query.Select<DataTable>("select Id from dbo.TestGuid where id = @id",
        new { Id = new Guid("E6AB0F59-9E8D-4A03-8DE6-158A8C88F74B")});
    }
  }
}