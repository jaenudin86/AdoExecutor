using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using AdoExecutor.IntegrationTest.Sql.Helpers.Comparators;
using AdoExecutor.IntegrationTest.Sql.Helpers.Covnerters;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData;
using AdoExecutor.IntegrationTest.Sql.Helpers.Tests;
using AdoExecutor.Shared.Core.Entities;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Select
{
  public class MultipleResultSetTests : AdoExecutorTestBase
  {
    [Test]
    public void SelectMultipleRowsOfType()
    {
      //ARRANGE
      const string queryText = @"select NVarchar50
                                 from dbo.TestDbType 
                                 where id = @id1 or id = @id2;

                                select *
                                from dbo.TestDbType 
                                where id = @id1 or id = @id2
                                order by id asc;

                                select *
                                from dbo.TestDbType 
                                where id = @id1

                                select NVarchar50 
                                from dbo.TestDbType
                                where id = @id1

                                select *
                                from dbo.TestDbType 
                                where id = @id1

                                select *
                                from dbo.TestDbType 
                                where id = @id1 or id = @id2
                                order by id asc

                                select *
                                from dbo.TestDbType 
                                where id = @id1 or id = @id2
                                order by id asc";

      //ACT
      var result = Query.Select<MultipleResultSet<string[], DataTable, Dictionary<string, object>, string, Tuple<TestDataItemToFill>,
                       dynamic[], TestDataItemToFill[]>>(queryText, new {id1 = TestData.Item1.Id, id2 = TestData.Item2.Id});

      //Assert Item 1
      var item1 = result.Item1;
      Assert.AreEqual(2, item1.Length);
      Assert.AreEqual(TestData.Item1.NVarchar50, item1[0]);
      Assert.AreEqual(TestData.Item2.NVarchar50, item1[1]);

      //Assert Item 2
      var item2 = result.Item2;

      var actualItem2 = new[]
      {
        DictionaryConverter.ConvertToDictionary(item2.Rows[0]),
        DictionaryConverter.ConvertToDictionary(item2.Rows[1]),
      };

      DictionaryComparator.Compare(new[] { TestData.Item1Dictionary, TestData.Item2Dictionary}, actualItem2);

      //Assert Item 3
      var item3 = result.Item3;
      DictionaryComparator.Compare(TestData.Item1Dictionary, item3);

      //Assert Item 4
      var item4 = result.Item4;
      Assert.AreEqual(TestData.Item1.NVarchar50, item4);

      //Assert Item 5
      var item5 = result.Item5;
      DictionaryComparator.Compare(TestData.Item1Dictionary, DictionaryConverter.ConvertToDictionary(item5.Item1));

      //Assert Item 6
      var item6 = result.Item6;

      var actualItem6 = new IDictionary<string, object>[]
      {
        (ExpandoObject) item6[0],
        (ExpandoObject) item6[1],
      };
      DictionaryComparator.Compare(new[] {TestData.Item1Dictionary, TestData.Item2Dictionary}, actualItem6);

      //Assert Item 7
      var item7 = result.Item7;

      var actualItem7 = new[]
      {
        DictionaryConverter.ConvertToDictionary(item7[0]),
        DictionaryConverter.ConvertToDictionary(item7[1])
      };
      DictionaryComparator.Compare(new[] { TestData.Item1Dictionary, TestData.Item2Dictionary}, actualItem7);
    }
  }
}