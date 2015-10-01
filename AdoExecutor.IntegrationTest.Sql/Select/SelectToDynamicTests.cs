using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using AdoExecutor.IntegrationTest.Sql.Helpers.Comparators;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData;
using AdoExecutor.IntegrationTest.Sql.Helpers.Tests;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Select
{
  public class SelectToDynamicTests : AdoExecutorTestBase
  {
    private void SelectMultipleRowWithSpecifiedIds<T>()
      where T : IEnumerable
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id1 or id = @id2
                                 order by id asc";

      //ACT
      var result =
        Query.Select<T>(queryText, new {id1 = TestData.Item1.Id, id2 = TestData.Item2.Id}).Cast<ExpandoObject>();
      var resultArray = result.ToArray();

      //ASSERT
      Assert.AreEqual(2, resultArray.Length);

      var expectedResult = new[] {TestData.Item1Dictionary, TestData.Item2Dictionary};

      DictionaryComparator.Compare(expectedResult, resultArray);
    }

    private void SelectMultipleNoRows<T>()
      where T : IEnumerable
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id1 or id = @id2
                                 order by id asc";

      //ACT
      var result =
        Query.Select<T>(queryText, new {id1 = TestData.NotExistingItemId1, id2 = TestData.NotExistingItemId2})
          .Cast<object>();
      var resultArray = result.ToArray();

      //ASSERT
      Assert.AreEqual(0, resultArray.Length);
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsArray()
    {
      SelectMultipleRowWithSpecifiedIds<dynamic[]>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsCollection()
    {
      SelectMultipleRowWithSpecifiedIds<Collection<dynamic>>();
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
    public void SelectMultipleRowWithSpecifiedIds_AsIList()
    {
      SelectMultipleRowWithSpecifiedIds<IList<dynamic>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsList()
    {
      SelectMultipleRowWithSpecifiedIds<List<dynamic>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsObservableCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ObservableCollection<dynamic>>();
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

    [Test]
    public void SelectSingleNoRow()
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id";

      //ACT
      var result = Query.Select<dynamic>(queryText, new {id = TestData.NotExistingItemId1});

      //ASSERT
      Assert.IsNull(result);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId()
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id";

      //ACT
      var result = Query.Select<dynamic>(queryText, new {id = TestData.Item1.Id});

      //ASSERT
      DictionaryComparator.Compare(TestData.Item1Dictionary, result);
    }
  }
}