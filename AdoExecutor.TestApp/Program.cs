using System;
using System.Data;
using System.Dynamic;
using AdoExecutor.Core.Configuration;
using AdoExecutor.Core.Interception;
using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Infrastructure.Configuration;
using AdoExecutor.Infrastructure.Query;

namespace AdoExecutor.TestApp
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      IAdoExecutorConfiguration configuration = new AdoExecutorConfigurationFactory().CreateDefaultSqlConfiguration("test");
      configuration.Interceptors.Add(new ConsoleLoggerAdoExecutorInterceptor());
      var queryFactory = new AdoExecutorQueryFactory(configuration);

      IAdoExecutorQuery query = queryFactory.CreateQuery();

      dynamic obj = new ExpandoObject();
      obj.Id = Guid.NewGuid();

      var result = query.Select<Person[]>("select Id from dbo.TestGuid");
    }

    public class Person
    {
      public Guid Id { get; set; }
    }
  }
}