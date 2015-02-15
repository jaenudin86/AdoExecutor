using System.Data;
using AdoExecutor.Core.Helper;
using AdoExecutor.Infrastructure.ObjectBuilder;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DataTableAdoExecutorObjectBuilder : IAdoExecutorObjectBuilder
  {
    private readonly DataTableAdapter _dataTableAdapter = new DataTableAdapter();

    public bool CanProcess(AdoExecutorObjectBuilderContext context)
    {
      return context.ResultType == typeof (DataTable);
    }

    public object CreateInstance(AdoExecutorObjectBuilderContext context)
    {
      return _dataTableAdapter.Load(context.DataReader);
    }
  }
}