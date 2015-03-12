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

      while (!context.DataReader.IsClosed)
      {
        if (context.DataReader.FieldCount != 0)
        {
          DataTable dataTable = _dataTableAdapter.Load(context.DataReader);
          dataSet.Tables.Add(dataTable);
        }

        if (!context.DataReader.NextResult())
          break;
      }

      return dataSet;
    }
  }
}