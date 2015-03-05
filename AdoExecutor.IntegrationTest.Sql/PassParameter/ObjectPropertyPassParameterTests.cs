using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Core.QueryFactory.Infrastructure;
using AdoExecutor.IntegrationTest.Sql.Helper.TestDbTypeTable;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.PassParameter
{
  [TestFixture(Category = "Integration")]
  public class ObjectPropertyPassParameterTests : PassParameterBase
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
      var parameters = CreateDefiniedTypeFromRowObject(rowObject1);
      var query = _queryFactory.CreateQuery();

      //ACT
      var result = query.Select<dynamic>(ExecuteProcQuery, parameters);

      //ASSERT
      AssertSingleDynamicObjectWithSingleRow(rowObject1, result);
    }

    private TestDbTypeTableRowDefiniedType CreateDefiniedTypeFromRowObject(ITestDbTypeTableRow rowObject)
    {
      //yup i can use reflection for mapping, but this reflection i should test...
      return new TestDbTypeTableRowDefiniedType
      {
        BigInt = rowObject.BigInt,
        Binary50 = rowObject.Binary50,
        Bit = rowObject.Bit,
        Char10 = rowObject.Char10,
        Date = rowObject.Date,
        DateTime = rowObject.DateTime,
        DateTime2 = rowObject.DateTime2,
        DateTimeOffset = rowObject.DateTimeOffset,
        Decimal = rowObject.Decimal,
        Float = rowObject.Float,
        Id = rowObject.Id,
        Image = rowObject.Image,
        Int = rowObject.Int,
        Money = rowObject.Money,
        NChar10 = rowObject.NChar10,
        NText = rowObject.NText,
        NVarchar50 = rowObject.NVarchar50,
        Numeric = rowObject.Numeric,
        Real = rowObject.Real,
        SmallDateTime = rowObject.SmallDateTime,
        SmallInt = rowObject.SmallInt,
        SmallMoney = rowObject.SmallMoney,
        Text = rowObject.Text,
        Time = rowObject.Time,
        TinyInt = rowObject.TinyInt,
        Uniqueidentifier = rowObject.Uniqueidentifier,
        Varbinary50 = rowObject.Varbinary50,
        Varchar50 = rowObject.Varchar50,
        Xml = rowObject.Xml
      };
    }
  }
}