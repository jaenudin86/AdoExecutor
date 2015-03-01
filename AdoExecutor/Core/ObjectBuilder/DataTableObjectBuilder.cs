﻿using System;
using System.Data;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Utilities.Adapter.DataTable.Infrastructure;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DataTableObjectBuilder : IObjectBuilder
  {
    private readonly IDataTableAdapter _dataTableAdapter;

    public DataTableObjectBuilder(IDataTableAdapter dataTableAdapter)
    {
      if (dataTableAdapter == null)
        throw new ArgumentNullException("dataTableAdapter");

      _dataTableAdapter = dataTableAdapter;
    }

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