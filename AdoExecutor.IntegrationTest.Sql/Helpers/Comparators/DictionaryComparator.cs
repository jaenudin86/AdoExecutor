using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Helpers.Comparators
{
  public static class DictionaryComparator
  {
    public static void Compare(IDictionary<string, object> expected, IDictionary<string, object> actual)
    {
      Assert.AreEqual(expected.Count, actual.Count);

      foreach (var expectedItem in expected)
      {
        var actualItem = actual[expectedItem.Key];

        Assert.AreEqual(expectedItem.Value, actualItem, $"Not equals values with name: {expectedItem.Key}");
      }
    }

    public static void Compare(IEnumerable<IDictionary<string, object>> expected,
      IEnumerable<IDictionary<string, object>> actual)
    {
      var expectedArray = expected.ToArray();
      var actualArray = actual.ToArray();

      Assert.AreEqual(expectedArray.Length, actualArray.Length);

      for (var i = 0; i < expectedArray.Length; i++)
        Compare(expectedArray[i], actualArray[i]);
    }
  }
}