using System;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Infrastructure.Query;

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
      var adoExecutorQueryFactory = new SqlAdoExecutorQueryFactory("test");
      IAdoExecutorQuery query = adoExecutorQueryFactory.CreateQuery();

      var queryText = @"select Id, Login, PasswordHash, IsBlocked, Created, FailedLoginCount 
                       from dbo.Account
                       where id = @id";

      var queryParameter = new {Id = new Guid("8F45FE85-7D79-47CC-82D6-CD433B3D10BB")};
    }


  }
}