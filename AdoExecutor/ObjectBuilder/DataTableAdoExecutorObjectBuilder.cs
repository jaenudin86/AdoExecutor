using System;
using System.Data;

namespace AdoExecutor.ObjectBuilder
{
  public class DataTableAdoExecutorObjectBuilder : IAdoExecutorObjectBuilder
  {
    public bool CanProcess(Type objectType)
    {
      return objectType == typeof (DataTable);
    }

    public object CreateInstance(IAdoExecutorObjectBuilderContext context)
    {
      var dataTable = new DataTable();
      dataTable.Load(context.DataReader);
      
      return dataTable;
    }
  }
}