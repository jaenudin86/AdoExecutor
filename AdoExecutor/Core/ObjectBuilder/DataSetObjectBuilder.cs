using System;
using System.Data;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Utilities.Adapter.DataTable.Infrastructure;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DataSetObjectBuilder : IObjectBuilder
  {
    private readonly IDataTableAdapter _dataTableAdapter;

    public DataSetObjectBuilder(IDataTableAdapter dataTableAdapter)
    {
      if (dataTableAdapter == null)
        throw new ArgumentNullException("dataTableAdapter");

      _dataTableAdapter = dataTableAdapter;
    }

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