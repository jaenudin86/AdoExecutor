using System.Data;
using AdoExecutor.Core.Helper;
using AdoExecutor.Infrastructure.ObjectBuilder;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DataTableAdoExecutorObjectBuilder : IAdoExecutorObjectBuilder
  {
    public bool CanProcess(AdoExecutorObjectBuilderContext context)
    {
      return context.ResultType == typeof (DataTable);
    }

    public object CreateInstance(AdoExecutorObjectBuilderContext context)
    {
      var adapter = new DataTableAdapter();
      return adapter.Load(context.DataReader);
    }
  }
}