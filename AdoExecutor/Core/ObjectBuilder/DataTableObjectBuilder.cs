using System.Data;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Utilities.Adapter;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DataTableObjectBuilder : IObjectBuilder
  {
    private readonly DataTableAdapter _dataTableAdapter = new DataTableAdapter();

    public bool CanProcess(ObjectBuilderContext context)
    {
      return context.ResultType == typeof (DataTable);
    }

    public object CreateInstance(ObjectBuilderContext context)
    {
      return _dataTableAdapter.Load(context.DataReader);
    }
  }
}