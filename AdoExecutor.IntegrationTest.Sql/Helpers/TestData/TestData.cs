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
  }
}