using System.Data;
using AdoExecutor.Core.Query.Infrastructure;
using AdoExecutor.Core.QueryFactory;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData;
using AdoExecutor.Shared.Core.Entities;
using AdoExecutor.Shared.Core.ObjectBuilder;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Select
{
  [TestFixture(Category = "Integration")]
  public class MultipleResultSetTests
  {
    private IQuery _query;

    [SetUp]
    public void SetUp()
    {
      var queryFactory = new SqlQueryFactory("AdoExecutorTestDb");
      _query = queryFactory.CreateQuery();
    }

    [TearDown]
    public void TearDown()
    {
      _query.Dispose();
    }

    [Test]
    public void TesT()
    {
      var x = typeof (DataTable);
      //ARRANGE
      const string queryText = @"select *
                                 from dbo.TestDbType 
                                 where id = @id1 or id = @id2;

                                select *
                                from dbo.TestDbType 
                                where id = @id1 or id = @id2
                                order by id asc;

                                select NVarchar50 
                                from dbo.TestDbType
                                where id = @id1";

      //ACT
      var rowObject1 = TestDbTypeTable.Row1;
      var rowObject2 = TestDbTypeTable.Row2;
      var result = _query.Select<DataSet>(queryText,
        new {id1 = rowObject1.Id, id2 = rowObject2.Id});

      var x1 =
        ObjectBuilderExtensions.BuildFromDataSet<MultipleResultSet<DataTable, TestDbTypeTableRowDefiniedType[], string>>(result);
    }
  }
}