using System.Data;
using System.Data.Common;
using AdoExecutor.Utilities.Adapter.DataTable.Infrastructure;

namespace AdoExecutor.Utilities.Adapter.DataTable
{
  public class DataTableAdapter : DataAdapter, IDataTableAdapter
  {
    public DataTableAdapter()
    {
      FillLoadOption = LoadOption.PreserveChanges;
      MissingSchemaAction = MissingSchemaAction.AddWithKey;
    }

    public virtual System.Data.DataTable Load(IDataReader dataReader)
    {
      var dataTable = new System.Data.DataTable();

      base.Fill(dataTable, dataReader);

      return dataTable;
    }
  }
}