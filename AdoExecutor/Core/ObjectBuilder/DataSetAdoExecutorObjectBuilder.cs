using System.Data;
using AdoExecutor.Core.Helper;
using AdoExecutor.Infrastructure.ObjectBuilder;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DataSetAdoExecutorObjectBuilder : IAdoExecutorObjectBuilder
  {
    public bool CanProcess(AdoExecutorObjectBuilderContext context)
    {
      return context.ResultType == typeof (DataSet);
    }

    public object CreateInstance(AdoExecutorObjectBuilderContext context)
    {
      var adapter = new DataTableAdapter();
      var dataSet = new DataSet();

      do
      {
        DataTable dataTable = adapter.Load(context.DataReader);

        dataSet.Tables.Add(dataTable);
      } while (context.DataReader.NextResult() && !context.DataReader.IsClosed);

      return dataSet;
    }
  }
}