using System.Collections.Generic;
using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Core.QueryFactory.Infrastructure;
using AdoExecutor.IntegrationTest.Sql.Helper.TestDbTypeTable;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.PassParameter
{
  [TestFixture(Category = "Integration")]
  public class DictionaryPassParameter : PassParameterBase
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
      var parameters = new Dictionary<string, object>();
      parameters.Add("BigInt", TestDbTypeTable.Row1.BigInt);
      parameters.Add("Binary50", TestDbTypeTable.Row1.Binary50);
      parameters.Add("Bit", TestDbTypeTable.Row1.Bit);
      parameters.Add("Char10", TestDbTypeTable.Row1.Char10);
      parameters.Add("Date", TestDbTypeTable.Row1.Date);
      parameters.Add("DateTime", TestDbTypeTable.Row1.DateTime);
      parameters.Add("DateTime2", TestDbTypeTable.Row1.DateTime2);
      parameters.Add("DateTimeOffset", TestDbTypeTable.Row1.DateTimeOffset);
      parameters.Add("Decimal", TestDbTypeTable.Row1.Decimal);
      parameters.Add("Float", TestDbTypeTable.Row1.Float);
      parameters.Add("Image", TestDbTypeTable.Row1.Image);
      parameters.Add("Int", TestDbTypeTable.Row1.Int);
      parameters.Add("Money", TestDbTypeTable.Row1.Money);
      parameters.Add("NChar10", TestDbTypeTable.Row1.NChar10);
      parameters.Add("NText", TestDbTypeTable.Row1.NText);
      parameters.Add("Numeric", TestDbTypeTable.Row1.Numeric);
      parameters.Add("NVarchar50", TestDbTypeTable.Row1.NVarchar50);
      parameters.Add("Real", TestDbTypeTable.Row1.Real);
      parameters.Add("SmallDateTime", TestDbTypeTable.Row1.SmallDateTime);
      parameters.Add("SmallInt", TestDbTypeTable.Row1.SmallInt);
      parameters.Add("SmallMoney", TestDbTypeTable.Row1.SmallMoney);
      parameters.Add("Text", TestDbTypeTable.Row1.Text);
      parameters.Add("Time", TestDbTypeTable.Row1.Time);
      parameters.Add("TinyInt", TestDbTypeTable.Row1.TinyInt);
      parameters.Add("Uniqueidentifier", TestDbTypeTable.Row1.Uniqueidentifier);
      parameters.Add("Varbinary50", TestDbTypeTable.Row1.Varbinary50);
      parameters.Add("Varchar50", TestDbTypeTable.Row1.Varchar50);
      parameters.Add("Xml", TestDbTypeTable.Row1.Xml);

      var query = _queryFactory.CreateQuery();
      
      //ACT
      var result = query.Select<dynamic>(ExecuteProcQuery, parameters);

      //ASSERT
      AssertSingleDynamicObjectWithSingleRow(TestDbTypeTable.Row1, result);
    }
  }
}
