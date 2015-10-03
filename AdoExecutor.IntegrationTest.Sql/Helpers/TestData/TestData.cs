using System;
using System.Collections.Generic;
using System.Linq;
using AdoExecutor.IntegrationTest.Sql.Helpers.Covnerters;

namespace AdoExecutor.IntegrationTest.Sql.Helpers.TestData
{
  public static class TestData
  {
    public static TestDataItem1 Item1 = new TestDataItem1();
    public static TestDataItem2 Item2 = new TestDataItem2();
    public static TestDataItemNull NullItem = new TestDataItemNull();

    public static IDictionary<string, object> Item1Dictionary
    {
      get { return DictionaryConverter.ConvertToDictionary(Item1); }
    }

    public static IDictionary<string, object> Item2Dictionary
    {
      get { return DictionaryConverter.ConvertToDictionary(Item2); }
    }

    public static IDictionary<string, object> NullItemDictionary
    {
      get { return DictionaryConverter.ConvertToDictionary(NullItem); }
    }

    public static IDictionary<string, object> DbNullItemDictionary
    {
      get { return NullItemDictionary.ToDictionary(x => x.Key, y => y.Value ?? DBNull.Value); }
    } 

    public static Guid NotExistingItemId1 = new Guid("D2C3E806-CD91-4066-BD3F-291C98BFCDBA");
    public static Guid NotExistingItemId2 = new Guid("6530BDFA-2BE8-4FA0-97D5-0AE6559DC899");
  }
}