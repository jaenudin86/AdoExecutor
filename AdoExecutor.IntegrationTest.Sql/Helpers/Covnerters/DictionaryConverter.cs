using System.Collections.Generic;
using System.Data;

namespace AdoExecutor.IntegrationTest.Sql.Helpers.Covnerters
{
  public static class DictionaryConverter
  {
    public static IDictionary<string, object> ConvertToDictionary(DataRow dataRow)
    {
      var result = new Dictionary<string, object>();

      foreach (DataColumn column in dataRow.Table.Columns)
      {
        result[column.ColumnName] = dataRow[column];
      }

      return result;
    }

    public static IDictionary<string, object> ConvertToDictionary(object @object)
    {
      var result = new Dictionary<string, object>();
      var properties = @object.GetType().GetProperties();

      foreach (var propertyInfo in properties)
      {
        result[propertyInfo.Name] = propertyInfo.GetValue(@object, null);
      }

      return result;
    }
  }
}