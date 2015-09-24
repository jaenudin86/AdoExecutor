using System;
using System.Data;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Shared.Utilities.Adapter.DataReader.Infrastructure;
using AdoExecutor.Utilities.Adapter.DataTable.Infrastructure;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DataSetObjectBuilder : IObjectBuilder
  {
    private readonly IDataTableAdapter _dataTableAdapter;

    public DataSetObjectBuilder(IDataTableAdapter dataTableAdapter)
    {
      if (dataTableAdapter == null)
        throw new ArgumentNullException(nameof(dataTableAdapter));

      _dataTableAdapter = dataTableAdapter;
    }

    public bool CanProcess(ObjectBuilderContext context)
    {
      return context.ResultType == typeof (DataSet);
    }

    public object CreateInstance(ObjectBuilderContext context)
    {
      context.DataReaderAdapter.Open();

      var dataSet = new DataSet();

      while (!context.DataReaderAdapter.IsClosed)
      {
        if (context.DataReaderAdapter.FieldCount != 0)
        {
          DataTable dataTable = _dataTableAdapter.Load(((IDataReaderAccess)context.DataReaderAdapter).DataReader);
          dataSet.Tables.Add(dataTable);
        }

        if (!context.DataReaderAdapter.NextResult())
          break;
      }

      return dataSet;
    }
  }
}