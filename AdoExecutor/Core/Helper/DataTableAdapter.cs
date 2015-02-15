using System.Data;
using System.Data.Common;

namespace AdoExecutor.Core.Helper
{
  public class DataTableAdapter : DataAdapter
  {
    public DataTableAdapter()
    {
      FillLoadOption = LoadOption.PreserveChanges;
      MissingSchemaAction = MissingSchemaAction.AddWithKey;
    }

    public DataTable Load(IDataReader dataReader)
    {
      var dataTable = new DataTable();

      base.Fill(dataTable, dataReader);

      return dataTable;
    }
  }
}