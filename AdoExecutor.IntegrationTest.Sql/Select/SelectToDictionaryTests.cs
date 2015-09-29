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

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsArrayOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<Dictionary<string, object>[]>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsCollectionOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<Collection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsICollectionOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ICollection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIEnumerableOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<IEnumerable<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIListOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<IList<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsListOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<List<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsObservableCollectionOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ObservableCollection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyCollectionOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyCollection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyObservableCollectionOfDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyObservableCollection<Dictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsArrayOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<IDictionary<string, object>[]>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsCollectionOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<Collection<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsICollectionOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ICollection<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIEnumerableOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<IEnumerable<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIListOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<IList<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsListOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<List<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsObservableCollectionOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ObservableCollection<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyCollectionOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyCollection<IDictionary<string, object>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyObservableCollectionOfIDictionary()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyObservableCollection<IDictionary<string, object>>>();
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
  }
}