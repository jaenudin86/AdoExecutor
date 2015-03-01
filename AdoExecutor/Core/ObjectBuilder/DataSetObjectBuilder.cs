using System.Data;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Utilities.Adapter;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DataSetObjectBuilder : IObjectBuilder
  {
    private readonly DataTableAdapter _dataTableAdapter = new DataTableAdapter();

    public bool CanProcess(ObjectBuilderContext context)
    {
      return context.ResultType == typeof (DataSet);
    }

    public object CreateInstance(ObjectBuilderContext context)
    {
      var dataSet = new DataSet();

      do
      {
        DataTable dataTable = _dataTableAdapter.Load(context.DataReader);

        dataSet.Tables.Add(dataTable);
      } while (context.DataReader.NextResult() && !context.DataReader.IsClosed);

      return dataSet;
    }
  }
}