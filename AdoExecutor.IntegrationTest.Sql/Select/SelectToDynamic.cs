using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Core.QueryFactory.Infrastructure;
using AdoExecutor.IntegrationTest.Sql.Helper.TestDbTypeTable;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Select
{
  [TestFixture(Category = "Integration")]
  public class SelectToDynamic
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
      var result = query.Select<dynamic>(queryText, new { id = rowObject1.Id });

      //ASSERT
      AssertSingleDynamicObjectWithSingleRow(rowObject1, result);
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsArray()
    {
      SelectMultipleRowWithSpecifiedIds<dynamic[]>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsList()
    {
      SelectMultipleRowWithSpecifiedIds<List<dynamic>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsCollection()
    {
      SelectMultipleRowWithSpecifiedIds<Collection<dynamic>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsObservableCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ObservableCollection<dynamic>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIList()
    {
      SelectMultipleRowWithSpecifiedIds<IList<dynamic>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsICollection()
    {
      SelectMultipleRowWithSpecifiedIds<ICollection<dynamic>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIEnumerable()
    {
      SelectMultipleRowWithSpecifiedIds<IEnumerable<dynamic>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyCollection<dynamic>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyObservableCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyObservableCollection<dynamic>>();
    }

    public void SelectMultipleRowWithSpecifiedIds<T>()
      where T : IEnumerable<object>
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
      var result = query.Select<dynamic[]>(queryText, new {id1 = rowObject1.Id, id2 = rowObject2.Id});

      //ASSERT
      Assert.AreEqual(2, result.Length);

      AssertSingleDynamicObjectWithSingleRow(rowObject1, result[0]);
      AssertSingleDynamicObjectWithSingleRow(rowObject2, result[1]);
    }

    private void AssertSingleDynamicObjectWithSingleRow(ITestDbTypeTableRow row, dynamic singleResult)
    {
      Assert.IsInstanceOf<Guid>(singleResult.Id);
      Assert.AreEqual(row.Id, singleResult.Id);

      Assert.IsInstanceOf<long>(singleResult.BigInt);
      Assert.AreEqual(row.BigInt, singleResult.BigInt);

      Assert.IsInstanceOf<byte[]>(singleResult.Binary50);
      CollectionAssert.AreEqual(row.Binary50, singleResult.Binary50);

      Assert.IsInstanceOf<bool>(singleResult.Bit);
      Assert.AreEqual(row.Bit, singleResult.Bit);

      Assert.IsInstanceOf<string>(singleResult.Char10);
      Assert.AreEqual(row.Char10, singleResult.Char10);

      Assert.IsInstanceOf<DateTime>(singleResult.Date);
      Assert.AreEqual(row.Date, singleResult.Date);

      Assert.IsInstanceOf<DateTime>(singleResult.DateTime);
      Assert.AreEqual(row.DateTime, singleResult.DateTime);

      Assert.IsInstanceOf<DateTime>(singleResult.DateTime2);
      Assert.AreEqual(row.DateTime2, singleResult.DateTime2);

      Assert.IsInstanceOf<DateTimeOffset>(singleResult.DateTimeOffset);
      Assert.AreEqual(row.DateTimeOffset, singleResult.DateTimeOffset);

      Assert.IsInstanceOf<decimal>(singleResult.Decimal);
      Assert.AreEqual(row.Decimal, singleResult.Decimal);

      Assert.IsInstanceOf<double>(singleResult.Float);
      Assert.AreEqual(row.Float, singleResult.Float);

      Assert.IsInstanceOf<byte[]>(singleResult.Image);
      Assert.AreEqual(row.Image, singleResult.Image);

      Assert.IsInstanceOf<int>(singleResult.Int);
      Assert.AreEqual(row.Int, singleResult.Int);

      Assert.IsInstanceOf<decimal>(singleResult.Money);
      Assert.AreEqual(row.Money, singleResult.Money);

      Assert.IsInstanceOf<string>(singleResult.NChar10);
      Assert.AreEqual(row.NChar10, singleResult.NChar10);

      Assert.IsInstanceOf<string>(singleResult.NText);
      Assert.AreEqual(row.NText, singleResult.NText);

      Assert.IsInstanceOf<decimal>(singleResult.Numeric);
      Assert.AreEqual(row.Numeric, singleResult.Numeric);

      Assert.IsInstanceOf<string>(singleResult.NVarchar50);
      Assert.AreEqual(row.NVarchar50, singleResult.NVarchar50);

      Assert.IsInstanceOf<float>(singleResult.Real);
      Assert.AreEqual(row.Real, singleResult.Real);

      Assert.IsInstanceOf<DateTime>(singleResult.SmallDateTime);
      Assert.AreEqual(row.SmallDateTime, singleResult.SmallDateTime);

      Assert.IsInstanceOf<short>(singleResult.SmallInt);
      Assert.AreEqual(row.SmallInt, singleResult.SmallInt);

      Assert.IsInstanceOf<decimal>(singleResult.SmallMoney);
      Assert.AreEqual(row.SmallMoney, singleResult.SmallMoney);

      Assert.IsInstanceOf<string>(singleResult.Text);
      Assert.AreEqual(row.Text, singleResult.Text);

      Assert.IsInstanceOf<TimeSpan>(singleResult.Time);
      Assert.AreEqual(row.Time, singleResult.Time);

      Assert.IsInstanceOf<byte>(singleResult.TinyInt);
      Assert.AreEqual(row.TinyInt, singleResult.TinyInt);

      Assert.IsInstanceOf<Guid>(singleResult.Uniqueidentifier);
      Assert.AreEqual(row.Uniqueidentifier, singleResult.Uniqueidentifier);

      Assert.IsInstanceOf<byte[]>(singleResult.Varbinary50);
      CollectionAssert.AreEqual(row.Varbinary50, singleResult.Varbinary50);

      Assert.IsInstanceOf<string>(singleResult.Varchar50);
      Assert.AreEqual(row.Varchar50, singleResult.Varchar50);

      Assert.IsInstanceOf<string>(singleResult.Xml);
      Assert.AreEqual(row.Xml, singleResult.Xml);
    }
  }
}