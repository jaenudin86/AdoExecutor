using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AdoExecutor.IntegrationTest.Sql.Helpers.Comparators;
using AdoExecutor.IntegrationTest.Sql.Helpers.Covnerters;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData;
using AdoExecutor.IntegrationTest.Sql.Helpers.Tests;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Select
{
  public class SelectToDefinedTypeTests : AdoExecutorTestBase
  {
    private void SelectMultipleRowWithSpecifiedIds<T>()
      where T : IEnumerable<TestDataItemToFill>
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id1 or id = @id2
                                 order by id asc";

      //ACT
      var result = Query.Select<T>(queryText, new {id1 = TestData.Item1.Id, id2 = TestData.Item2.Id});
      var resultArray = result.ToArray();

      //ASSERT
      Assert.IsInstanceOf<T>(result);
      Assert.AreEqual(2, resultArray.Length);

      var dictionaryResult = new[]
      {
        DictionaryConverter.ConvertToDictionary(resultArray[0]),
        DictionaryConverter.ConvertToDictionary(resultArray[1])
      };

      var expectedResult = new[] {TestData.Item1Dictionary, TestData.Item2Dictionary};

      DictionaryComparator.Compare(expectedResult, dictionaryResult);
    }

    private void SelectMultipleNoRows<T>()
      where T : IEnumerable<TestDataItemToFill>
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id1 or id = @id2
                                 order by id asc";

      //ACT
      var result = Query.Select<T>(queryText, new {id1 = TestData.NotExistingItemId1, id2 = TestData.NotExistingItemId2});
      var resultArray = result.ToArray();

      //ASSERT
      Assert.IsInstanceOf<T>(result);
      Assert.AreEqual(0, resultArray.Length);
    }

    [Test]
    public void SelectMultipleNoRows_AsArray()
    {
      SelectMultipleNoRows<TestDataItemToFill[]>();
    }

    [Test]
    public void SelectMultipleNoRows_AsCollection()
    {
      SelectMultipleNoRows<Collection<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsICollection()
    {
      SelectMultipleNoRows<ICollection<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsIEnumerable()
    {
      SelectMultipleNoRows<IEnumerable<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsIList()
    {
      SelectMultipleNoRows<IList<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsList()
    {
      SelectMultipleNoRows<List<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsObservableCollection()
    {
      SelectMultipleNoRows<ObservableCollection<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsReadOnlyCollection()
    {
      SelectMultipleNoRows<ReadOnlyCollection<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsReadOnlyObservableCollection()
    {
      SelectMultipleNoRows<ReadOnlyObservableCollection<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsArray()
    {
      SelectMultipleRowWithSpecifiedIds<TestDataItemToFill[]>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsCollection()
    {
      SelectMultipleRowWithSpecifiedIds<Collection<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsICollection()
    {
      SelectMultipleRowWithSpecifiedIds<ICollection<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIEnumerable()
    {
      SelectMultipleRowWithSpecifiedIds<IEnumerable<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIList()
    {
      SelectMultipleRowWithSpecifiedIds<IList<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsList()
    {
      SelectMultipleRowWithSpecifiedIds<List<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsObservableCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ObservableCollection<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyCollection<TestDataItemToFill>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyObservableCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyObservableCollection<TestDataItemToFill>>();
    }

    [Test]
    public void SelectSignleNoRows()
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id";

      //ACT
      var result = Query.Select<TestDataItemToFill>(queryText, new {id = TestData.NotExistingItemId1});

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
      var result = Query.Select<TestDataItemToFill>(queryText, new {id = TestData.Item1.Id});

      //ASSERT
      var dictionaryResult = DictionaryConverter.ConvertToDictionary(result);

      DictionaryComparator.Compare(TestData.Item1Dictionary, dictionaryResult);
    }

    [Test]
    public void SelectSingleNullRow()
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id";

      //ACT
      var result = Query.Select<TestDataItemToFill>(queryText, new { id = TestData.NullItem.Id });

      //ASSERT
      var dictionaryResult = DictionaryConverter.ConvertToDictionary(result);

      DictionaryComparator.Compare(TestData.NullItemDictionary, dictionaryResult);
    }
  }
}