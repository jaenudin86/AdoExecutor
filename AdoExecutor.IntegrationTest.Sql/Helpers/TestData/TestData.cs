using System;
using System.Collections.Generic;
using AdoExecutor.IntegrationTest.Sql.Helpers.Covnerters;

namespace AdoExecutor.IntegrationTest.Sql.Helpers.TestData
{
  public static class TestData
  {
    public static TestDataItem1 Item1 = new TestDataItem1();
    public static TestDataItem2 Item2 = new TestDataItem2();

    public static IDictionary<string, object> Item1Dictionary
    {
      get { return DictionaryConverter.ConvertToDictionary(Item1); }
    }

    public static IDictionary<string, object> Item2Dictionary
    {
      get { return DictionaryConverter.ConvertToDictionary(Item2); }
    }

    public static Guid NotExistingItemId1 = new Guid("D2C3E806-CD91-4066-BD3F-291C98BFCDBA");
    public static Guid NotExistingItemId2 = new Guid("6530BDFA-2BE8-4FA0-97D5-0AE6559DC899");
    public static Guid NullItemId = new Guid("9b85f633-f58b-468b-82f0-99f089a89c47");
  }
}