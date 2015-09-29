using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AdoExecutor.Core.Query.Infrastructure;
using AdoExecutor.Core.QueryFactory;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Select
{
  [TestFixture(Category = "Integration")]
  public class SelectToTupleTests
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
    public void SelectSingleRowWithSpecifiedId()
    {
      //ARRANGE
      const string queryText = @"select NVarchar50, Bit, Int, Decimal, DateTime, Uniqueidentifier, Varbinary50
                                 from dbo.TestDbType 
                                 where id = @id";
      var rowObject1 = TestDbTypeTable.Row1;
      var expectedDefiniedType = CreateDefiniedTypeFromRowObject(rowObject1);

      //ACT
      var result = _query.Select<Tuple<string, bool, int, decimal, DateTime, Guid, byte[]>>(queryText, new { id = rowObject1.Id });

      //ASSERT
      AssertCompareObject(expectedDefiniedType, result);
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsArray()
    {
      SelectMultipleRowWithSpecifiedIds<Tuple<string, bool, int, decimal, DateTime, Guid, byte[]>[]>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsList()
    {
      SelectMultipleRowWithSpecifiedIds<List<Tuple<string, bool, int, decimal, DateTime, Guid, byte[]>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsCollection()
    {
      SelectMultipleRowWithSpecifiedIds<Collection<Tuple<string, bool, int, decimal, DateTime, Guid, byte[]>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsObservableCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ObservableCollection<Tuple<string, bool, int, decimal, DateTime, Guid, byte[]>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIList()
    {
      SelectMultipleRowWithSpecifiedIds<IList<Tuple<string, bool, int, decimal, DateTime, Guid, byte[]>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsICollection()
    {
      SelectMultipleRowWithSpecifiedIds<ICollection<Tuple<string, bool, int, decimal, DateTime, Guid, byte[]>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIEnumerable()
    {
      SelectMultipleRowWithSpecifiedIds<IEnumerable<Tuple<string, bool, int, decimal, DateTime, Guid, byte[]>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyCollection<Tuple<string, bool, int, decimal, DateTime, Guid, byte[]>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyObservableCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyObservableCollection<Tuple<string, bool, int, decimal, DateTime, Guid, byte[]>>>();
    }

    public void SelectMultipleRowWithSpecifiedIds<T>()
      where T : IEnumerable<Tuple<string, bool, int, decimal, DateTime, Guid, byte[]>>
    {
      //ARRANGE
      const string queryText = @"select NVarchar50, Bit, Int, Decimal, DateTime, Uniqueidentifier, Varbinary50
                                 from dbo.TestDbType 
                                 where id = @id1 or id = @id2
                                 order by id asc";

      var rowObject1 = TestDbTypeTable.Row1;
      var rowObject2 = TestDbTypeTable.Row2;

      var expectedDefiniedType1 = CreateDefiniedTypeFromRowObject(rowObject1);
      var expectedDefiniedType2 = CreateDefiniedTypeFromRowObject(rowObject2);

      //ACT
      var result = _query.Select<T>(queryText, new { id1 = rowObject1.Id, id2 = rowObject2.Id });
      var resultArray = result.ToArray();
      //ASSERT
      Assert.AreEqual(2, resultArray.Length);

      AssertCompareObject(expectedDefiniedType1, resultArray[0]);
      AssertCompareObject(expectedDefiniedType2, resultArray[1]);
    }

    private void AssertCompareObject(Tuple<string, bool, int, decimal, DateTime, Guid, byte[]> expected, Tuple<string, bool, int, decimal, DateTime, Guid, byte[]> actually)
    {
      CompareLogic compareLogic = new CompareLogic();
      ComparisonResult compareResult = compareLogic.Compare(expected, actually);
      Assert.IsTrue(compareResult.AreEqual, "Compared objects are not equal\r\n{0}", compareResult.DifferencesString);
    }

    private Tuple<string, bool, int, decimal, DateTime, Guid, byte[]> CreateDefiniedTypeFromRowObject(ITestDbTypeTableRow rowObject)
    {
      return new Tuple<string, bool, int, decimal, DateTime, Guid, byte[]>(
        rowObject.NVarchar50,
        rowObject.Bit,
        rowObject.Int,
        rowObject.Decimal,
        rowObject.DateTime,
        rowObject.Uniqueidentifier,
        rowObject.Varbinary50);
    }
  }
}