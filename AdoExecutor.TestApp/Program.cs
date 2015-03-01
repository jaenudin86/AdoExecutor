using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using AdoExecutor.Core.Query.Infrastructure;
using AdoExecutor.Core.QueryFactory;

namespace AdoExecutor.TestApp
{
  internal class Program
  {
    public class Account
    {
      public Guid Id { get; set; }
      public string Login { get; set; }
      public string PasswordHash { get; set; }
      public bool? IsBlocked { get; set; }
      public DateTime? Created { get; set; }
      public int FailedLoginCount { get; set; }
    }

    private static void Main(string[] args)
    {
      var adoExecutorQueryFactory = new SqlQueryFactory("test");
      IQuery query = adoExecutorQueryFactory.CreateQuery();

      var queryText = @"select Id, Login, PasswordHash, IsBlocked, Created, FailedLoginCount 
                       from dbo.Account";

      var result = query.Select<object[]>(queryText);
    }


  }
}