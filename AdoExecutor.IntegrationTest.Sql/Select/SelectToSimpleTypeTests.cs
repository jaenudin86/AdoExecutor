using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData;
using AdoExecutor.IntegrationTest.Sql.Helpers.Tests;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Select
{
  public class SelectToSimpleTypeTests : AdoExecutorTestBase
  {
    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_BigInt()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<long>("BigInt", TestData.Item1.BigInt);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<long?>("BigInt", TestData.Item1.BigInt);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<long?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_BigInt()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<long>("BigInt",
        new[] {TestData.Item1.BigInt, TestData.Item2.BigInt});
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<long?>("BigInt", TestData.Item1.BigInt);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Binary50()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte[]>("Binary50", TestData.Item1.Binary50);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte[]>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Binary50()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<byte[]>("Binary50",
        new[] { TestData.Item1.Binary50, TestData.Item2.Binary50 });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<byte[]>("Binary50", TestData.Item1.Binary50);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Bit()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<bool>("Bit", TestData.Item1.Bit);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<bool?>("Bit", TestData.Item1.Bit);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<bool?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Bit()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<bool>("Bit",
        new[] { TestData.Item1.Bit, TestData.Item2.Bit });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<bool?>("Bit", TestData.Item1.Bit);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Char10()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("Char10", TestData.Item1.Char10);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Char10()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<string>("Char10",
        new[] { TestData.Item1.Char10, TestData.Item2.Char10 });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<string>("Char10", TestData.Item1.Char10);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Date()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime>("Date", TestData.Item1.Date);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("Date", TestData.Item1.Date);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Date()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<DateTime>("Date",
        new[] { TestData.Item1.Date, TestData.Item2.Date });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<DateTime?>("Date", TestData.Item1.Date);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_DateTime()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime>("DateTime", TestData.Item1.DateTime);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("DateTime", TestData.Item1.DateTime);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_DateTime()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<DateTime>("DateTime",
        new[] { TestData.Item1.DateTime, TestData.Item2.DateTime });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<DateTime?>("DateTime", TestData.Item1.DateTime);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_DateTime2()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime>("DateTime2", TestData.Item1.DateTime2);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("DateTime2", TestData.Item1.DateTime2);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_DateTime2()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<DateTime>("DateTime2",
        new[] { TestData.Item1.DateTime2, TestData.Item2.DateTime2 });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<DateTime?>("DateTime2", TestData.Item1.DateTime2);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_DateTimeOffset()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTimeOffset>("DateTimeOffset", TestData.Item1.DateTimeOffset);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTimeOffset?>("DateTimeOffset", TestData.Item1.DateTimeOffset);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTimeOffset?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_DateTimeOffset()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<DateTimeOffset>("DateTimeOffset",
        new[] { TestData.Item1.DateTimeOffset, TestData.Item2.DateTimeOffset });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<DateTimeOffset?>("DateTimeOffset", TestData.Item1.DateTimeOffset);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Decimal()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal>("Decimal", TestData.Item1.Decimal);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("Decimal", TestData.Item1.Decimal);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Decimal()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<decimal>("Decimal",
        new[] { TestData.Item1.Decimal, TestData.Item2.Decimal });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<decimal?>("Decimal", TestData.Item1.Decimal);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Float()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<double>("Float", TestData.Item1.Float);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<double?>("Float", TestData.Item1.Float);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<double?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Float()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<double>("Float",
        new[] { TestData.Item1.Float, TestData.Item2.Float });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<double?>("Float", TestData.Item1.Float);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Image()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte[]>("Image", TestData.Item1.Image);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte[]>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Image()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<byte[]>("Image",
        new[] { TestData.Item1.Image, TestData.Item2.Image });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<byte[]>("Image", TestData.Item1.Image);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Int()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<int>("Int", TestData.Item1.Int);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<int?>("Int", TestData.Item1.Int);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<int?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Int()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<int>("Int",
        new[] { TestData.Item1.Int, TestData.Item2.Int });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<int?>("Int", TestData.Item1.Int);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Money()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal>("Money", TestData.Item1.Money);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("Money", TestData.Item1.Money);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Money()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<decimal>("Money",
        new[] { TestData.Item1.Money, TestData.Item2.Money });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<decimal?>("Money", TestData.Item1.Money);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_NChar10()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("NChar10", TestData.Item1.NChar10);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_NChar10()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<string>("NChar10",
        new[] { TestData.Item1.NChar10, TestData.Item2.NChar10 });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<string>("NChar10", TestData.Item1.NChar10);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_NText()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("NText", TestData.Item1.NText);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_NText()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<string>("NText",
        new[] { TestData.Item1.NText, TestData.Item2.NText });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<string>("NText", TestData.Item1.NText);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Numeric()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal>("Numeric", TestData.Item1.Numeric);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("Numeric", TestData.Item1.Numeric);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Numeric()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<decimal>("Numeric",
        new[] { TestData.Item1.Numeric, TestData.Item2.Numeric });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<decimal?>("Numeric", TestData.Item1.Numeric);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_NVarchar50()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("NVarchar50", TestData.Item1.NVarchar50);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_NVarchar50()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<string>("NVarchar50",
        new[] { TestData.Item1.NVarchar50, TestData.Item2.NVarchar50 });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<string>("NVarchar50", TestData.Item1.NVarchar50);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Real()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<float>("Real", TestData.Item1.Real);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<float?>("Real", TestData.Item1.Real);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<float?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Real()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<float>("Real",
        new[] { TestData.Item1.Real, TestData.Item2.Real });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<float?>("Real", TestData.Item1.Real);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_SmallDateTime()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime>("SmallDateTime", TestData.Item1.SmallDateTime);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("SmallDateTime", TestData.Item1.SmallDateTime);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<DateTime?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_SmallDateTime()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<DateTime>("SmallDateTime",
        new[] { TestData.Item1.SmallDateTime, TestData.Item2.SmallDateTime });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<DateTime?>("SmallDateTime", TestData.Item1.SmallDateTime);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_SmallInt()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<short>("SmallInt", TestData.Item1.SmallInt);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<short?>("SmallInt", TestData.Item1.SmallInt);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<short?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_SmallInt()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<short>("SmallInt",
        new[] { TestData.Item1.SmallInt, TestData.Item2.SmallInt });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<short?>("SmallInt", TestData.Item1.SmallInt);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_SmallMoney()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal>("SmallMoney", TestData.Item1.SmallMoney);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("SmallMoney", TestData.Item1.SmallMoney);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<decimal?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_SmallMoney()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<decimal>("SmallMoney",
        new[] { TestData.Item1.SmallMoney, TestData.Item2.SmallMoney });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<decimal?>("SmallMoney", TestData.Item1.SmallMoney);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Text()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("Text", TestData.Item1.Text);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Text()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<string>("Text",
        new[] { TestData.Item1.Text, TestData.Item2.Text });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<string>("Text", TestData.Item1.Text);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Time()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<TimeSpan>("Time", TestData.Item1.Time);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<TimeSpan?>("Time", TestData.Item1.Time);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<TimeSpan?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Time()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<TimeSpan>("Time",
        new[] { TestData.Item1.Time, TestData.Item2.Time });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<TimeSpan?>("Time", TestData.Item1.Time);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_TinyInt()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte>("TinyInt", TestData.Item1.TinyInt);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte?>("TinyInt", TestData.Item1.TinyInt);
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
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<Guid>("Uniqueidentifier", TestData.Item1.Uniqueidentifier);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<Guid?>("Uniqueidentifier", TestData.Item1.Uniqueidentifier);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<Guid?>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Uniqueidentifier()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<Guid>("Uniqueidentifier",
        new[] { TestData.Item1.Uniqueidentifier, TestData.Item2.Uniqueidentifier });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<Guid?>("Uniqueidentifier", TestData.Item1.Uniqueidentifier);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Varbinary50()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte[]>("Varbinary50", TestData.Item1.Varbinary50);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<byte[]>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Varbinary50()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<byte[]>("Varbinary50",
        new[] { TestData.Item1.Varbinary50, TestData.Item2.Varbinary50 });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<byte[]>("Varbinary50", TestData.Item1.Varbinary50);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Varchar50()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("Varchar50", TestData.Item1.Varchar50);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Varchar50()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<string>("Varchar50",
        new[] { TestData.Item1.Varchar50, TestData.Item2.Varchar50 });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<string>("Varchar50", TestData.Item1.Varchar50);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem_Xml()
    {
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("Xml", TestData.Item1.Xml);
      SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<string>("null", null);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId_WhenTypeIsCollection_Xml()
    {
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNotNullable_CheckAllPosibilities<string>("Xml",
        new[] { TestData.Item1.Xml, TestData.Item2.Xml });
      SelectMultipleRowsWithSpecifiedIds_WhenTypeIsCollectionAndItemIsNullable_CheckAllPosibilities<string>("Xml", TestData.Item1.Xml);
    }

    #region Assert methods

    private void SelectSingleRowWithSpecifiedId_WhenTypeIsSingleItem<TResult>(string columnName, object expectedValue)
    {
      //ARRANGE
      string queryText = string.Format(@"select {0} 
                                         from dbo.TestDbType 
                                         where id = @id", columnName);

      //ACT
      var result = Query.Select<TResult>(queryText, new { id = TestData.Item1.Id });

      //ASSERT
      Assert.AreEqual(expectedValue, result);
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

      //ACT
      var result = Query.Select<TResult>(queryText, new {id = TestData.Item1.Id});

      //ASSERT
      CollectionAssert.AreEqual(new[] {firstElementExpectedValue, null}, result);
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

      //ACT
      var result = Query.Select<TResult>(queryText, new {id1 = TestData.Item1.Id, id2 = TestData.Item2.Id});

      //ASSERT
      CollectionAssert.AreEqual(expectedResult, result);
    }

    #endregion
  }
}