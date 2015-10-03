using System.Data;
using AdoExecutor.IntegrationTest.Sql.Helpers.Comparators;
using AdoExecutor.IntegrationTest.Sql.Helpers.Covnerters;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData;
using AdoExecutor.IntegrationTest.Sql.Helpers.Tests;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Select
{
  public class SelectToDataTableTests : AdoExecutorTestBase
  {
    [Test]
    public void SelectMultipleRowWithSpecifiedIds()
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id1 or id = @id2
                                 order by id asc";

      //ACT
      var result = Query.Select<DataTable>(queryText, new {id1 = TestData.Item1.Id, id2 = TestData.Item2.Id});

      //ASSERT
      Assert.AreEqual(2, result.Rows.Count);

      var expected = new[] {TestData.Item1Dictionary, TestData.Item2Dictionary};

      var actual = new[]
      {
        DictionaryConverter.ConvertToDictionary(result.Rows[0]),
        DictionaryConverter.ConvertToDictionary(result.Rows[1])
      };

      DictionaryComparator.Compare(expected, actual);
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId()
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id";

      //ACT
      var result = Query.Select<DataTable>(queryText, new {id = TestData.Item1.Id});


      //ASSERT
      Assert.AreEqual(1, result.Rows.Count);
      var actual = DictionaryConverter.ConvertToDictionary(result.Rows[0]);

      DictionaryComparator.Compare(TestData.Item1Dictionary, actual);
    }

    [Test]
    public void SelectSingleNullRow()
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id";

      //ACT
      var result = Query.Select<DataTable>(queryText, new { id = TestData.NullItem.Id });


      //ASSERT
      Assert.AreEqual(1, result.Rows.Count);
      var actual = DictionaryConverter.ConvertToDictionary(result.Rows[0]);

      DictionaryComparator.Compare(TestData.DbNullItemDictionary, actual);
    }

    [Test]
    public void SelectNoRows()
    {
      //ARRANGE
      const string queryText = @"select * 
                                 from dbo.TestDbType 
                                 where id = @id";

      //ACT
      var result = Query.Select<DataTable>(queryText, new { id = TestData.NotExistingItemId1 });

      //ASSERT
      Assert.AreEqual(0, result.Rows.Count);
    }
  }
}