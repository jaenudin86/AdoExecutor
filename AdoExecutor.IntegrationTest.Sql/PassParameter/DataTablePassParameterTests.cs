using System;
using System.Data;
using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Core.QueryFactory.Infrastructure;
using AdoExecutor.IntegrationTest.Sql.Helper.TestDbTypeTable;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.PassParameter
{
  [TestFixture(Category = "Integration")]
  public class DataTablePassParameterTests : PassParameterBase
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

      var dataTable = new DataTable();
      dataTable.Columns.Add("BigInt", typeof (long));
      dataTable.Columns.Add("Binary50", typeof(byte[]));
      dataTable.Columns.Add("Bit", typeof(bool));
      dataTable.Columns.Add("Char10", typeof(string));
      dataTable.Columns.Add("Date", typeof(DateTime));
      dataTable.Columns.Add("DateTime", typeof(DateTime));
      dataTable.Columns.Add("DateTime2", typeof(DateTime));
      dataTable.Columns.Add("DateTimeOffset", typeof(DateTimeOffset));
      dataTable.Columns.Add("Decimal", typeof(decimal));
      dataTable.Columns.Add("Float", typeof(double));
      dataTable.Columns.Add("Image", typeof(byte[]));
      dataTable.Columns.Add("Int", typeof(int));
      dataTable.Columns.Add("Money", typeof(decimal));
      dataTable.Columns.Add("NChar10", typeof(string));
      dataTable.Columns.Add("NText", typeof(string));
      dataTable.Columns.Add("Numeric", typeof(decimal));
      dataTable.Columns.Add("NVarchar50", typeof(string));
      dataTable.Columns.Add("Real", typeof(float));
      dataTable.Columns.Add("SmallDateTime", typeof(DateTime));
      dataTable.Columns.Add("SmallInt", typeof(short));
      dataTable.Columns.Add("SmallMoney", typeof(decimal));
      dataTable.Columns.Add("Text", typeof(string));
      dataTable.Columns.Add("Time", typeof(TimeSpan));
      dataTable.Columns.Add("TinyInt", typeof(byte));
      dataTable.Columns.Add("Uniqueidentifier", typeof(Guid));
      dataTable.Columns.Add("Varbinary50", typeof(byte[]));
      dataTable.Columns.Add("Varchar50", typeof(string));
      dataTable.Columns.Add("Xml", typeof(string));

      dataTable.Rows.Add(new object[]
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
      });

      var query = _queryFactory.CreateQuery();

      //ACT
      var result = query.Select<dynamic>(ExecuteProcQuery, dataTable);

      //ASSERT
      AssertSingleDynamicObjectWithSingleRow(TestDbTypeTable.Row1, result);
    }
  }
}
