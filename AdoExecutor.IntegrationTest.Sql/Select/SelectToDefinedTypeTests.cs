using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Core.QueryFactory.Infrastructure;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Select
{
  [TestFixture(Category = "Integration")]
  public class SelectToDefinedTypeTests
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
      var expectedDefiniedType = CreateDefiniedTypeFromRowObject(rowObject1);

      //ACT
      var result = query.Select<TestDbTypeTableRowDefiniedType>(queryText, new { id = rowObject1.Id });

      //ASSERT
      AssertCompareObject(expectedDefiniedType, result);

      query.Dispose();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsArray()
    {
      SelectMultipleRowWithSpecifiedIds<TestDbTypeTableRowDefiniedType[]>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsList()
    {
      SelectMultipleRowWithSpecifiedIds<List<TestDbTypeTableRowDefiniedType>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsCollection()
    {
      SelectMultipleRowWithSpecifiedIds<Collection<TestDbTypeTableRowDefiniedType>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsObservableCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ObservableCollection<TestDbTypeTableRowDefiniedType>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIList()
    {
      SelectMultipleRowWithSpecifiedIds<IList<TestDbTypeTableRowDefiniedType>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsICollection()
    {
      SelectMultipleRowWithSpecifiedIds<ICollection<TestDbTypeTableRowDefiniedType>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIEnumerable()
    {
      SelectMultipleRowWithSpecifiedIds<IEnumerable<TestDbTypeTableRowDefiniedType>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyCollection<TestDbTypeTableRowDefiniedType>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyObservableCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyObservableCollection<TestDbTypeTableRowDefiniedType>>();
    }

    public void SelectMultipleRowWithSpecifiedIds<T>()
      where T : IEnumerable<TestDbTypeTableRowDefiniedType>
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id1 or id = @id2
                                 order by id asc";

      var query = _queryFactory.CreateQuery();
      var rowObject1 = TestDbTypeTable.Row1;
      var rowObject2 = TestDbTypeTable.Row2;

      var expectedDefiniedType1 = CreateDefiniedTypeFromRowObject(rowObject1);
      var expectedDefiniedType2 = CreateDefiniedTypeFromRowObject(rowObject2);

      //ACT
      var result = query.Select<T>(queryText, new { id1 = rowObject1.Id, id2 = rowObject2.Id });
      var resultArray = result.ToArray();
      //ASSERT
      Assert.AreEqual(2, resultArray.Length);

      AssertCompareObject(expectedDefiniedType1, resultArray[0]);
      AssertCompareObject(expectedDefiniedType2, resultArray[1]);

      query.Dispose();
    }

    private void AssertCompareObject(TestDbTypeTableRowDefiniedType expected, TestDbTypeTableRowDefiniedType actually)
    {
      CompareLogic compareLogic = new CompareLogic();
      ComparisonResult compareResult = compareLogic.Compare(expected, actually);
      Assert.IsTrue(compareResult.AreEqual, "Compared objects are not equal\r\n{0}", compareResult.DifferencesString);
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