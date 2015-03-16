using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Core.QueryFactory.Infrastructure;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Transaction
{
  [TestFixture(Category = "Integration")]
  public class InvokeInTransactionTests
  {
    private IQueryFactory _queryFactory;

    [SetUp]
    public void SetUp()
    {
      _queryFactory = new SqlQueryFactory("AdoExecutorTestDb");
    }

    [Test]
    public void InvokeInTransaction_ShouldSaveData_WhenCommitTransaction()
    {
      //ARRANGE
      var query = _queryFactory.CreateQuery();
      
      //ACT
      query.BeginTransaction();
      query.Execute("create table #temp(id int)");
      query.Execute("insert into #temp(id) values(1)");
      query.CommitTransaction();
      
      //ASSERT
      int? id = query.Select<int?>("select id from #temp");
      Assert.AreEqual(1, id);

      query.Dispose();
    }

    [Test]
    public void InvokeInTransaction_ShouldRollbackSaveData_WhenRollbackTransaction()
    {
      //ARRANGE
      var query = _queryFactory.CreateQuery();
      
      //ACT
      query.BeginTransaction();
      query.Execute("create table #temp(id int)");
      query.Execute("insert into #temp(id) values(1)");
      query.RollbackTransaction();
      
      //ASSERT
      int? id = query.Select<int?>("select object_id('tempdb..#temp')");
      Assert.IsNull(id);

      query.Dispose();
    }
  }
}