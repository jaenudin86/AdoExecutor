using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Core.QueryFactory.Infrastructure;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.PassParameter
{
  [TestFixture(Category = "Integration")]
  public class EnumerablePassParameterTests : PassParameterBase
  {
    private const string ExecuteProcQuery = @"
      EXECUTE [dbo].[spTestDbType] 
         @0
        ,@1
        ,@2
        ,@3
        ,@4
        ,@5
        ,@6
        ,@7
        ,@8
        ,@9
        ,@10
        ,@11
        ,@12
        ,@13
        ,@14
        ,@15
        ,@16
        ,@17
        ,@18
        ,@19
        ,@20
        ,@21
        ,@22
        ,@23
        ,@24
        ,@25
        ,@26
        ,@27";

    private IQueryFactory _queryFactory;

    [SetUp]
    public void SetUp()
    {
      _queryFactory = new SqlQueryFactory("AdoExecutorTestDb");
    }

    [Test]
    public void PassAllParameters()
    {
      //ARRANGE
      var rowObject1 = TestDbTypeTable.Row1;

      var parameters = new object[]
      {
        rowObject1.BigInt,
        rowObject1.Binary50,
        rowObject1.Bit,
        rowObject1.Char10,
        rowObject1.Date,
        rowObject1.DateTime,
        rowObject1.DateTime2,
        rowObject1.DateTimeOffset,
        rowObject1.Decimal,
        rowObject1.Float,
        rowObject1.Image,
        rowObject1.Int,
        rowObject1.Money,
        rowObject1.NChar10,
        rowObject1.NText,
        rowObject1.Numeric,
        rowObject1.NVarchar50,
        rowObject1.Real,
        rowObject1.SmallDateTime,
        rowObject1.SmallInt,
        rowObject1.SmallMoney,
        rowObject1.Text,
        rowObject1.Time,
        rowObject1.TinyInt,
        rowObject1.Uniqueidentifier,
        rowObject1.Varbinary50,
        rowObject1.Varchar50,
        rowObject1.Xml
      };

      var query = _queryFactory.CreateQuery();

      //ACT
      var result = query.Select<dynamic>(ExecuteProcQuery, parameters);

      //ASSERT
      AssertSingleDynamicObjectWithSingleRow(TestDbTypeTable.Row1, result);

      query.Dispose();
    }
  }
}