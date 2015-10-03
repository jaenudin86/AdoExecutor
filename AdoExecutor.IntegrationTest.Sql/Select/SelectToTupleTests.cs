using System;
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
  public class SelectToTupleTests : AdoExecutorTestBase
  {
    [Test]
    public void SelectSingleRowWithSpecifiedId()
    {
      //ARRANGE
      const string queryText = @"select NVarchar50, Bit, Int, *
                                 from dbo.TestDbType 
                                 where id = @id";
      //ACT
      var result = Query.Select<Tuple<string, bool, int, TestDataItemToFill>>(queryText, new { id = TestData.Item1.Id });

      //ASSERT
      Assert.AreEqual(result.Item1, TestData.Item1.NVarchar50);
      Assert.AreEqual(result.Item2, TestData.Item1.Bit);
      Assert.AreEqual(result.Item3, TestData.Item1.Int);

      var actualDictionary = DictionaryConverter.ConvertToDictionary(result.Item4);

      DictionaryComparator.Compare(TestData.Item1Dictionary, actualDictionary);
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsArray()
    {
      SelectMultipleRowWithSpecifiedIds<Tuple<string, bool, int, TestDataItemToFill>[]>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsList()
    {
      SelectMultipleRowWithSpecifiedIds<List<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsCollection()
    {
      SelectMultipleRowWithSpecifiedIds<Collection<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsObservableCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ObservableCollection<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIList()
    {
      SelectMultipleRowWithSpecifiedIds<IList<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsICollection()
    {
      SelectMultipleRowWithSpecifiedIds<ICollection<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsIEnumerable()
    {
      SelectMultipleRowWithSpecifiedIds<IEnumerable<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyCollection<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    [Test]
    public void SelectMultipleRowWithSpecifiedIds_AsReadOnlyObservableCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ReadOnlyObservableCollection<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    private void SelectMultipleRowWithSpecifiedIds<T>()
      where T : IEnumerable<Tuple<string, bool, int, TestDataItemToFill>>
    {
      //ARRANGE
      const string queryText = @"select NVarchar50, Bit, Int, *
                                 from dbo.TestDbType 
                                 where id = @id1 or id = @id2
                                 order by id asc";

      //ACT
      var result = Query.Select<T>(queryText, new { id1 = TestData.Item1.Id, id2 = TestData.Item2.Id });
      var resultArray = result.ToArray();
      //ASSERT
      Assert.AreEqual(2, resultArray.Length);

      Assert.AreEqual(resultArray[0].Item1, TestData.Item1.NVarchar50);
      Assert.AreEqual(resultArray[0].Item2, TestData.Item1.Bit);
      Assert.AreEqual(resultArray[0].Item3, TestData.Item1.Int);

      var actualDictionary1 = DictionaryConverter.ConvertToDictionary(resultArray[0].Item4);

      DictionaryComparator.Compare(TestData.Item1Dictionary, actualDictionary1);

      Assert.AreEqual(resultArray[1].Item1, TestData.Item2.NVarchar50);
      Assert.AreEqual(resultArray[1].Item2, TestData.Item2.Bit);
      Assert.AreEqual(resultArray[1].Item3, TestData.Item2.Int);

      var actualDictionary2 = DictionaryConverter.ConvertToDictionary(resultArray[1].Item4);

      DictionaryComparator.Compare(TestData.Item2Dictionary, actualDictionary2);
    }

    [Test]
    public void SelectMultipleNoRows_AsArray()
    {
      SelectMultipleNoRows<Tuple<string, bool, int, TestDataItemToFill>[]>();
    }

    [Test]
    public void SelectMultipleNoRows_AsList()
    {
      SelectMultipleNoRows<List<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsCollection()
    {
      SelectMultipleNoRows<Collection<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsObservableCollection()
    {
      SelectMultipleRowWithSpecifiedIds<ObservableCollection<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsIList()
    {
      SelectMultipleNoRows<IList<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsICollection()
    {
      SelectMultipleNoRows<ICollection<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsIEnumerable()
    {
      SelectMultipleNoRows<IEnumerable<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsReadOnlyCollection()
    {
      SelectMultipleNoRows<ReadOnlyCollection<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    [Test]
    public void SelectMultipleNoRows_AsReadOnlyObservableCollection()
    {
      SelectMultipleNoRows<ReadOnlyObservableCollection<Tuple<string, bool, int, TestDataItemToFill>>>();
    }

    private void SelectMultipleNoRows<T>()
  where T : IEnumerable<Tuple<string, bool, int, TestDataItemToFill>>
    {
      //ARRANGE
      const string queryText = @"select NVarchar50, Bit, Int, *
                                 from dbo.TestDbType 
                                 where id = @id1 or id = @id2
                                 order by id asc";

      //ACT
      var result = Query.Select<T>(queryText,
        new { id1 = TestData.NotExistingItemId1, id2 = TestData.NotExistingItemId2 });

      //ASSERT
      Assert.AreEqual(0, result.Count());
      Assert.IsInstanceOf<T>(result);
    }


    [Test]
    public void SelectSingleNullRow()
    {
      //ARRANGE
      const string queryText = @"select NVarchar50, Bit, Int, *
                                 from dbo.TestDbType 
                                 where id = @id";

      //ACT
      var result = Query.Select<Tuple<string, bool?, int?, TestDataItemToFill>>(queryText, new { id = TestData.NullItem.Id });

      //ASSERT
      Assert.AreEqual(result.Item1, TestData.NullItem.NVarchar50);
      Assert.AreEqual(result.Item2, TestData.NullItem.Bit);
      Assert.AreEqual(result.Item3, TestData.NullItem.Int);

      var actualDictionary = DictionaryConverter.ConvertToDictionary(result.Item4);

      DictionaryComparator.Compare(TestData.NullItemDictionary, actualDictionary);
    }
  }
}