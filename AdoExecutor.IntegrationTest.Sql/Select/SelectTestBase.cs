using AdoExecutor.Core.Query.Infrastructure;
using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Core.QueryFactory.Infrastructure;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Select
{
  [TestFixture(Category = "Integration")]
  public abstract class SelectTestBase
  {
    [SetUp]
    public void SetUp()
    {
      QueryFactory = new SqlQueryFactory("AdoExecutorTestDb");
      Query = QueryFactory.CreateQuery();
    }

    [TearDown]
    public void TearDown()
    {
      Query.Dispose();
    }

    protected IQueryFactory QueryFactory { get; private set; }
    protected IQuery Query { get; private set; }
  }
}