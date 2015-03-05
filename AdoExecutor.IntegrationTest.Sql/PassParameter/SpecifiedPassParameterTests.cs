using System.Data;
using AdoExecutor.Core.Parameter;
using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Core.QueryFactory.Infrastructure;
using AdoExecutor.IntegrationTest.Sql.Helper.TestDbTypeTable;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.PassParameter
{
  [TestFixture(Category = "Integration")]
  public class SpecifiedPassParameterTests : PassParameterBase
  {
    private const string ExecuteProcQuery = @"
      EXECUTE [dbo].[spTestDbType] 
         @BigInt
        ,@Binary50
        ,@Bit
        ,@Char10
        ,@Date
        ,@DateTime
        ,@DateTime2
        ,@DateTimeOffset
        ,@Decimal
        ,@Float
        ,@Image
        ,@Int
        ,@Money
        ,@NChar10
        ,@NText
        ,@Numeric
        ,@NVarchar50
        ,@Real
        ,@SmallDateTime
        ,@SmallInt
        ,@SmallMoney
        ,@Text
        ,@Time
        ,@TinyInt
        ,@Uniqueidentifier
        ,@Varbinary50
        ,@Varchar50
        ,@Xml";

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

      var parameters = new[]
      {
        new SpecifiedParameter("BigInt", rowObject1.BigInt),
        new SpecifiedParameter("Binary50", rowObject1.Binary50),
        new SpecifiedParameter("Bit", rowObject1.Bit),
        new SpecifiedParameter("Char10", rowObject1.Char10),
        new SpecifiedParameter("Date", rowObject1.Date),
        new SpecifiedParameter("DateTime", rowObject1.DateTime),
        new SpecifiedParameter("DateTime2", rowObject1.DateTime2),
        new SpecifiedParameter("DateTimeOffset", rowObject1.DateTimeOffset),
        new SpecifiedParameter("Decimal", rowObject1.Decimal),
        new SpecifiedParameter("Float", rowObject1.Float),
        new SpecifiedParameter("Image", rowObject1.Image),
        new SpecifiedParameter("Int", rowObject1.Int),
        new SpecifiedParameter("Money", rowObject1.Money),
        new SpecifiedParameter("NChar10", rowObject1.NChar10),
        new SpecifiedParameter("NText", rowObject1.NText),
        new SpecifiedParameter("Numeric", rowObject1.Numeric),
        new SpecifiedParameter("NVarchar50", rowObject1.NVarchar50),
        new SpecifiedParameter("Real", rowObject1.Real),
        new SpecifiedParameter("SmallDateTime", rowObject1.SmallDateTime),
        new SpecifiedParameter("SmallInt", rowObject1.SmallInt),
        new SpecifiedParameter("SmallMoney", rowObject1.SmallMoney),
        new SpecifiedParameter("Text", rowObject1.Text),
        new SpecifiedParameter("Time", rowObject1.Time),
        new SpecifiedParameter("TinyInt", rowObject1.TinyInt),
        new SpecifiedParameter("Uniqueidentifier", rowObject1.Uniqueidentifier),
        new SpecifiedParameter("Varbinary50", rowObject1.Varbinary50),
        new SpecifiedParameter("Varchar50", rowObject1.Varchar50),
        new SpecifiedParameter("Xml", rowObject1.Xml)
      };

      var query = _queryFactory.CreateQuery();

      //ACT
      var result = query.Select<dynamic>(ExecuteProcQuery, parameters);

      //ASSERT
      AssertSingleDynamicObjectWithSingleRow(TestDbTypeTable.Row1, result);
    }

    [Test]
    public void GetValueFromOutputParameter()
    {
      //ARRANGE
      const string text = "testText";
      const string duplicateText = "testTexttestText";
      const string queryText = "exec dbo.spDuplicateString @text out";

      var parameter = new SpecifiedParameter("@text", text, direction:ParameterDirection.InputOutput, size: 128);

      var query = _queryFactory.CreateQuery();

      //ACT
      query.Execute(queryText, parameter);

      //ASSERT
      Assert.AreEqual(duplicateText, parameter.GetOutputValue<string>());
    }
  }
}