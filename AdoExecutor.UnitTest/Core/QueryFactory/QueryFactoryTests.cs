using System;
using AdoExecutor.Core.QueryFactory;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.QueryFactory
{
  [TestFixture(Category = "Unit")]
  public class QueryFactoryTests
  {
    private SqlQueryFactory _sqlQueryFactory;

    [SetUp]
    public void SetUp()
    {
      _sqlQueryFactory = new SqlQueryFactory("test");
    }

    [Test]
    public void Constructor_ShouldThrownArgumentNullException_WhenAnyParameterIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(() => new SqlQueryFactory(null));
    }

    [Test]
    public void CreateQuery_ShouldReturnConfiguredQuery()
    {
      //ACT
      var query = _sqlQueryFactory.CreateQuery();

      //ASSET
      Assert.IsInstanceOf<AdoExecutor.Core.Query.Query> (query);

    }
  }
}