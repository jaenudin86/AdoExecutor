using System;
using System.Data;
using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Core.QueryFactory.Infrastructure;
using AdoExecutor.IntegrationTest.Sql.Helper.TestDbTypeTable;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Select
{
  [TestFixture(Category = "Integration")]
  public class SelectToDataTableTests : DataTableRowAssertBase
  {
    private IQueryFactory _queryFactory;

    [SetUp]
    public void SetUp()
    {
      _queryFactory = new SqlQueryFactory("AdoExecutorTestDb");
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId()
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id";
      var query = _queryFactory.CreateQuery();
      var rowObject1 = TestDbTypeTable.Row1;

      //ACT
      var result = query.Select<DataTable>(queryText, new { id = rowObject1.Id });
      
      
      //ASSERT
      Assert.AreEqual(1, result.Rows.Count);
      AssertSingleDynamicObjectWithSingleRow(rowObject1, result.Rows[0]);

      query.Dispose();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds()
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id1 or id = @id2
                                 order by id asc";

      var query = _queryFactory.CreateQuery();
      var rowObject1 = TestDbTypeTable.Row1;
      var rowObject2 = TestDbTypeTable.Row2;

      //ACT
      var result = query.Select<DataTable>(queryText, new { id1 = rowObject1.Id, id2 = rowObject2.Id });

      //ASSERT
      Assert.AreEqual(2, result.Rows.Count);

      AssertSingleDynamicObjectWithSingleRow(rowObject1, result.Rows[0]);
      AssertSingleDynamicObjectWithSingleRow(rowObject2, result.Rows[1]);

      query.Dispose();
    }
  }
}