using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AdoExecutor.IntegrationTest.Sql.Helpers.Comparators;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData;
using AdoExecutor.IntegrationTest.Sql.Helpers.Tests;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Select
{
  public class SelectToDictionaryTests : AdoExecutorTestBase
  {
    [Test]
    public void SelectMultipleNoRows_AsArrayOfDictionary()
    {
      SelectMultipleNoRows<Dictionary<string, object>[]>();
    }

    [Test]
    public void SelectMultipleNoRows_AsArrayOfIDictionary()
    {
      SelectMultipleNoRows<IDictionary<string, object>[]>();
    }

    [Test]
    public void SelectMultipleNoRows_AsCollectionOfDictionary()
    {
      SelectMultipleNoRows<Collection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsCollectionOfIDictionary()
    {
      SelectMultipleNoRows<Collection<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsICollectionOfDictionary()
    {
      SelectMultipleNoRows<ICollection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsICollectionOfIDictionary()
    {
      SelectMultipleNoRows<ICollection<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsIEnumerableOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<IEnumerable<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsIEnumerableOfIDictionary()
    {
      SelectMultipleNoRows<IEnumerable<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsIListOfDictionary()
    {
      SelectMultipleNoRows<IList<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsIListOfIDictionary()
    {
      SelectMultipleNoRows<IList<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsListOfDictionary()
    {
      SelectMultipleNoRows<List<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsListOfIDictionary()
    {
      SelectMultipleNoRows<List<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsObservableCollectionOfDictionary()
    {
      SelectMultipleNoRows<ObservableCollection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsObservableCollectionOfIDictionary()
    {
      SelectMultipleNoRows<ObservableCollection<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsReadOnlyCollectionOfDictionary()
    {
      SelectMultipleNoRows<ReadOnlyCollection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsReadOnlyCollectionOfIDictionary()
    {
      SelectMultipleNoRows<ReadOnlyCollection<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsReadOnlyObservableCollectionOfDictionary()
    {
      SelectMultipleNoRows<ReadOnlyObservableCollection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsReadOnlyObservableCollectionOfIDictionary()
    {
      SelectMultipleNoRows<ReadOnlyObservableCollection<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsArrayOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<Dictionary<string, object>[]>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsArrayOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<IDictionary<string, object>[]>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsCollectionOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<Collection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsCollectionOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<Collection<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsICollectionOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ICollection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsICollectionOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ICollection<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIEnumerableOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<IEnumerable<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIEnumerableOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<IEnumerable<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIListOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<IList<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIListOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<IList<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsListOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<List<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsListOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<List<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsObservableCollectionOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ObservableCollection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsObservableCollectionOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ObservableCollection<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyCollectionOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyCollection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyCollectionOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyCollection<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyObservableCollectionOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyObservableCollection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyObservableCollectionOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyObservableCollection<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectNoRows()
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id";

      //ACT
      var result = Query.Select<Dictionary<string, object>>(queryText, new {id = TestData.NotExistingItemId1});

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
      var result = Query.Select<Dictionary<string, object>>(queryText, new {id = TestData.Item1.Id});

      //ASSERT
      DictionaryComparator.Compare(TestData.Item1Dictionary, result);
    }

    private void SelectMultipleRowWithSpecifiedIds<T>()
      where T : IEnumerable<IDictionary<string, object>>
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id1 or id = @id2
                                 order by id asc";

      //ACT
      var result = Query.Select<T>(queryText,
        new {id1 = TestData.Item1.Id, id2 = TestData.Item2.Id});

      //ASSERT
      Assert.AreEqual(2, result.Count());
      Assert.IsInstanceOf<T>(result);

      var expected = new[] {TestData.Item1Dictionary, TestData.Item2Dictionary};

      DictionaryComparator.Compare(expected, result);
    }

    public void SelectMultipleNoRows<T>()
      where T : IEnumerable<IDictionary<string, object>>
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id1 or id = @id2
                                 order by id asc";

      //ACT
      var result = Query.Select<T>(queryText,
        new {id1 = TestData.NotExistingItemId1, id2 = TestData.NotExistingItemId2});

      //ASSERT
      Assert.AreEqual(0, result.Count());
      Assert.IsInstanceOf<T>(result);
    }
  }
}