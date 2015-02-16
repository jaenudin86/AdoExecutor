using System;
using System.Diagnostics;
using System.Dynamic;
using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Infrastructure.Query;

namespace AdoExecutor.TestApp
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var adoExecutorQueryFactory = new SqlAdoExecutorQueryFactory("test");

      IAdoExecutorQuery query = adoExecutorQueryFactory.CreateQuery();

      dynamic obj = new ExpandoObject();
      obj.Id = Guid.NewGuid();

      var sw = Stopwatch.StartNew();
      var result = query.Select<Person[]>("select * from dbo.Account");
      sw.Stop();
    }

    public class Person
    {
      public Guid Id { get; set; }
      public string Login { get; set; }
      public string PasswordHash { get; set; }
      public bool? IsBlocked { get; set; }
      public DateTime? Created { get; set; }
      public int FailedLoginCount { get; set; }
    }
  }
}