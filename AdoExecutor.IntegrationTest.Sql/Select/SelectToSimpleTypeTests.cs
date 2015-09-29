using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Core.QueryFactory.Infrastructure;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Select
{
  [TestFixture(Category = "Integration")]
  public class SelectToSimpleTypeTests
  {
    private IQueryFactory _queryFactory;

    [SetUp]
    public void SetUp()
    {
      _queryFactory = new SqlQueryFactory("AdoExecutorTestDb");
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_BigInt()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<long>("BigInt", TestDbTypeTable.Row1.BigInt);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<long?>("BigInt", TestDbTypeTable.Row1.BigInt);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<long?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_BigInt()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<long>("BigInt",
        new long[] {TestDbTypeTable.Row1.BigInt, TestDbTypeTable.Row2.BigInt});
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<long?>("BigInt", TestDbTypeTable.Row1.BigInt);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Binary50()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte[]>("Binary50", TestDbTypeTable.Row1.Binary50);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte[]>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Binary50()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<byte[]>("Binary50",
        new[] { TestDbTypeTable.Row1.Binary50, TestDbTypeTable.Row2.Binary50 });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<byte[]>("Binary50", TestDbTypeTable.Row1.Binary50);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Bit()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<bool>("Bit", TestDbTypeTable.Row1.Bit);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<bool?>("Bit", TestDbTypeTable.Row1.Bit);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<bool?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Bit()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<bool>("Bit",
        new[] { TestDbTypeTable.Row1.Bit, TestDbTypeTable.Row2.Bit });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<bool?>("Bit", TestDbTypeTable.Row1.Bit);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Char10()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("Char10", TestDbTypeTable.Row1.Char10);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Char10()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<string>("Char10",
        new[] { TestDbTypeTable.Row1.Char10, TestDbTypeTable.Row2.Char10 });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<string>("Char10", TestDbTypeTable.Row1.Char10);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Date()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime>("Date", TestDbTypeTable.Row1.Date);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("Date", TestDbTypeTable.Row1.Date);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Date()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<DateTime>("Date",
        new[] { TestDbTypeTable.Row1.Date, TestDbTypeTable.Row2.Date });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<DateTime?>("Date", TestDbTypeTable.Row1.Date);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_DateTime()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime>("DateTime", TestDbTypeTable.Row1.DateTime);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("DateTime", TestDbTypeTable.Row1.DateTime);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_DateTime()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<DateTime>("DateTime",
        new[] { TestDbTypeTable.Row1.DateTime, TestDbTypeTable.Row2.DateTime });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<DateTime?>("DateTime", TestDbTypeTable.Row1.DateTime);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_DateTime2()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime>("DateTime2", TestDbTypeTable.Row1.DateTime2);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("DateTime2", TestDbTypeTable.Row1.DateTime2);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_DateTime2()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<DateTime>("DateTime2",
        new[] { TestDbTypeTable.Row1.DateTime2, TestDbTypeTable.Row2.DateTime2 });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<DateTime?>("DateTime2", TestDbTypeTable.Row1.DateTime2);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_DateTimeOffset()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTimeOffset>("DateTimeOffset", TestDbTypeTable.Row1.DateTimeOffset);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTimeOffset?>("DateTimeOffset", TestDbTypeTable.Row1.DateTimeOffset);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTimeOffset?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_DateTimeOffset()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<DateTimeOffset>("DateTimeOffset",
        new[] { TestDbTypeTable.Row1.DateTimeOffset, TestDbTypeTable.Row2.DateTimeOffset });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<DateTimeOffset?>("DateTimeOffset", TestDbTypeTable.Row1.DateTimeOffset);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Decimal()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal>("Decimal", TestDbTypeTable.Row1.Decimal);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("Decimal", TestDbTypeTable.Row1.Decimal);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Decimal()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<decimal>("Decimal",
        new[] { TestDbTypeTable.Row1.Decimal, TestDbTypeTable.Row2.Decimal });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<decimal?>("Decimal", TestDbTypeTable.Row1.Decimal);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Float()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<double>("Float", TestDbTypeTable.Row1.Float);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<double?>("Float", TestDbTypeTable.Row1.Float);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<double?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Float()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<double>("Float",
        new[] { TestDbTypeTable.Row1.Float, TestDbTypeTable.Row2.Float });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<double?>("Float", TestDbTypeTable.Row1.Float);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Image()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte[]>("Image", TestDbTypeTable.Row1.Image);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte[]>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Image()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<byte[]>("Image",
        new[] { TestDbTypeTable.Row1.Image, TestDbTypeTable.Row2.Image });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<byte[]>("Image", TestDbTypeTable.Row1.Image);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Int()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<int>("Int", TestDbTypeTable.Row1.Int);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<int?>("Int", TestDbTypeTable.Row1.Int);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<int?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Int()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<int>("Int",
        new[] { TestDbTypeTable.Row1.Int, TestDbTypeTable.Row2.Int });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<int?>("Int", TestDbTypeTable.Row1.Int);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Money()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal>("Money", TestDbTypeTable.Row1.Money);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("Money", TestDbTypeTable.Row1.Money);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Money()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<decimal>("Money",
        new[] { TestDbTypeTable.Row1.Money, TestDbTypeTable.Row2.Money });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<decimal?>("Money", TestDbTypeTable.Row1.Money);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_NChar10()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("NChar10", TestDbTypeTable.Row1.NChar10);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_NChar10()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<string>("NChar10",
        new[] { TestDbTypeTable.Row1.NChar10, TestDbTypeTable.Row2.NChar10 });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<string>("NChar10", TestDbTypeTable.Row1.NChar10);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_NText()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("NText", TestDbTypeTable.Row1.NText);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_NText()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<string>("NText",
        new[] { TestDbTypeTable.Row1.NText, TestDbTypeTable.Row2.NText });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<string>("NText", TestDbTypeTable.Row1.NText);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Numeric()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal>("Numeric", TestDbTypeTable.Row1.Numeric);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("Numeric", TestDbTypeTable.Row1.Numeric);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Numeric()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<decimal>("Numeric",
        new[] { TestDbTypeTable.Row1.Numeric, TestDbTypeTable.Row2.Numeric });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<decimal?>("Numeric", TestDbTypeTable.Row1.Numeric);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_NVarchar50()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("NVarchar50", TestDbTypeTable.Row1.NVarchar50);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_NVarchar50()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<string>("NVarchar50",
        new[] { TestDbTypeTable.Row1.NVarchar50, TestDbTypeTable.Row2.NVarchar50 });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<string>("NVarchar50", TestDbTypeTable.Row1.NVarchar50);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Real()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<float>("Real", TestDbTypeTable.Row1.Real);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<float?>("Real", TestDbTypeTable.Row1.Real);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<float?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Real()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<float>("Real",
        new[] { TestDbTypeTable.Row1.Real, TestDbTypeTable.Row2.Real });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<float?>("Real", TestDbTypeTable.Row1.Real);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_SmallDateTime()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime>("SmallDateTime", TestDbTypeTable.Row1.SmallDateTime);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("SmallDateTime", TestDbTypeTable.Row1.SmallDateTime);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_SmallDateTime()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<DateTime>("SmallDateTime",
        new[] { TestDbTypeTable.Row1.SmallDateTime, TestDbTypeTable.Row2.SmallDateTime });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<DateTime?>("SmallDateTime", TestDbTypeTable.Row1.SmallDateTime);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_SmallInt()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<short>("SmallInt", TestDbTypeTable.Row1.SmallInt);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<short?>("SmallInt", TestDbTypeTable.Row1.SmallInt);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<short?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_SmallInt()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<short>("SmallInt",
        new[] { TestDbTypeTable.Row1.SmallInt, TestDbTypeTable.Row2.SmallInt });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<short?>("SmallInt", TestDbTypeTable.Row1.SmallInt);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_SmallMoney()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal>("SmallMoney", TestDbTypeTable.Row1.SmallMoney);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("SmallMoney", TestDbTypeTable.Row1.SmallMoney);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_SmallMoney()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<decimal>("SmallMoney",
        new[] { TestDbTypeTable.Row1.SmallMoney, TestDbTypeTable.Row2.SmallMoney });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<decimal?>("SmallMoney", TestDbTypeTable.Row1.SmallMoney);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Text()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("Text", TestDbTypeTable.Row1.Text);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Text()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<string>("Text",
        new[] { TestDbTypeTable.Row1.Text, TestDbTypeTable.Row2.Text });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<string>("Text", TestDbTypeTable.Row1.Text);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Time()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<TimeSpan>("Time", TestDbTypeTable.Row1.Time);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<TimeSpan?>("Time", TestDbTypeTable.Row1.Time);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<TimeSpan?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Time()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<TimeSpan>("Time",
        new[] { TestDbTypeTable.Row1.Time, TestDbTypeTable.Row2.Time });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<TimeSpan?>("Time", TestDbTypeTable.Row1.Time);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_TinyInt()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte>("TinyInt", TestDbTypeTable.Row1.TinyInt);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte?>("TinyInt", TestDbTypeTable.Row1.TinyInt);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_TinyInt_Fail()
    {
      //WARNING: DO NOT SUPPORT COLLECTION OF TINYINT BECOUSE IT USE SAME TYPE (BYTE[]) AS BINARY FORMAT
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Uniqueidentifier()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<Guid>("Uniqueidentifier", TestDbTypeTable.Row1.Uniqueidentifier);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<Guid?>("Uniqueidentifier", TestDbTypeTable.Row1.Uniqueidentifier);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<Guid?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Uniqueidentifier()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<Guid>("Uniqueidentifier",
        new[] { TestDbTypeTable.Row1.Uniqueidentifier, TestDbTypeTable.Row2.Uniqueidentifier });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<Guid?>("Uniqueidentifier", TestDbTypeTable.Row1.Uniqueidentifier);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Varbinary50()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte[]>("Varbinary50", TestDbTypeTable.Row1.Varbinary50);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte[]>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Varbinary50()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<byte[]>("Varbinary50",
        new[] { TestDbTypeTable.Row1.Varbinary50, TestDbTypeTable.Row2.Varbinary50 });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<byte[]>("Varbinary50", TestDbTypeTable.Row1.Varbinary50);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Varchar50()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("Varchar50", TestDbTypeTable.Row1.Varchar50);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Varchar50()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<string>("Varchar50",
        new[] { TestDbTypeTable.Row1.Varchar50, TestDbTypeTable.Row2.Varchar50 });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<string>("Varchar50", TestDbTypeTable.Row1.Varchar50);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Xml()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("Xml", TestDbTypeTable.Row1.Xml);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Xml()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<string>("Xml",
        new[] { TestDbTypeTable.Row1.Xml, TestDbTypeTable.Row2.Xml });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<string>("Xml", TestDbTypeTable.Row1.Xml);
    }

    #region Assert methods

    private void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<TResult>(string columnName, object expectedValue)
    {
      //ARRANGE
      string queryText = string.Format(@"select {0} 
                                         from dbo.TestDbType 
                                         where id = @id", columnName);
      var query = _queryFactory.CreateQuery();
      var rowObject1 = TestDbTypeTable.Row1;

      //ACT
      var result = query.Select<TResult>(queryText, new { id = rowObject1.Id });

      //ASSERT
      Assert.AreEqual(expectedValue, result);

      query.Dispose();
    }

    private void SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<TResult>(string columnName,
      object expectedResult)
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable<TResult[]>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable<List<TResult>>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable<Collection<TResult>>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable<ObservableCollection<TResult>>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable<IList<TResult>>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable<ICollection<TResult>>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable<IEnumerable<TResult>>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable<ReadOnlyCollection<TResult>>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable<ReadOnlyObservableCollection<TResult>>(columnName, expectedResult);
    }

    private void SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable<TResult>(string columnName,
      object firstElementExpectedValue)
      where TResult : IEnumerable
    {
      //ARRANGE
      string queryText = string.Format(@"select {0} 
                                         from dbo.TestDbType 
                                         where id = @id
                                         union all
                                         select null", columnName);
      var query = _queryFactory.CreateQuery();
      var rowObject1 = TestDbTypeTable.Row1;

      //ACT
      var result = query.Select<TResult>(queryText, new {id = rowObject1.Id});

      //ASSERT
      CollectionAssert.AreEqual(new[] {firstElementExpectedValue, null}, result);

      query.Dispose();
    }

    private void SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<TResult>(string columnName,
    IEnumerable expectedResult)
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable<TResult[]>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable<List<TResult>>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable<Collection<TResult>>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable<ObservableCollection<TResult>>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable<IList<TResult>>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable<ICollection<TResult>>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable<IEnumerable<TResult>>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable<ReadOnlyCollection<TResult>>(columnName, expectedResult);
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable<ReadOnlyObservableCollection<TResult>>(columnName, expectedResult);
    }

    private void SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable<TResult>(string columnName,
      IEnumerable expectedResult)
      where TResult : IEnumerable
    {
      //ARRANGE
      string queryText = string.Format(@"select {0} 
                                         from dbo.TestDbType 
                                         where id = @id1 or id = @id2
                                         order by id asc", columnName);
      var query = _queryFactory.CreateQuery();
      var rowObject1 = TestDbTypeTable.Row1;
      var rowObject2 = TestDbTypeTable.Row2;

      //ACT
      var result = query.Select<TResult>(queryText, new {id1 = rowObject1.Id, id2 = rowObject2.Id});

      //ASSERT
      CollectionAssert.AreEqual(expectedResult, result);

      query.Dispose();
    }

    #endregion
  }
}