using System;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;
using AdoExecutor.Utilities.ObjectConverter.Infrastructure;
using AdoExecutor.Utilities.PrimitiveTypes.Infrastructure;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class SimpleTypeObjectBuilder : IObjectBuilder
  {
    private readonly IListAdapterFactory _listAdapterFactory;
    private readonly IObjectConverter _objectConverter;
    private readonly ISqlPrimitiveDataTypes _sqlPrimitiveDataTypes;

    public SimpleTypeObjectBuilder(ISqlPrimitiveDataTypes sqlPrimitiveDataTypes, IListAdapterFactory listAdapterFactory,
      IObjectConverter objectConverter)
    {
      if (sqlPrimitiveDataTypes == null)
        throw new ArgumentNullException("sqlPrimitiveDataTypes");

      if (listAdapterFactory == null)
        throw new ArgumentNullException("listAdapterFactory");

      if (objectConverter == null)
        throw new ArgumentNullException("objectConverter");

      _sqlPrimitiveDataTypes = sqlPrimitiveDataTypes;
      _listAdapterFactory = listAdapterFactory;
      _objectConverter = objectConverter;
    }

    public bool CanProcess(ObjectBuilderContext context)
    {
      if (_sqlPrimitiveDataTypes.IsSqlPrimitiveType(context.ResultType))
        return true;

      IListAdapter listAdapter = _listAdapterFactory.CreateListAdapter(context.ResultType);

      if (listAdapter != null)
        return _sqlPrimitiveDataTypes.IsSqlPrimitiveType(listAdapter.ElementType);

      return false;
    }

    public object CreateInstance(ObjectBuilderContext context)
    {
      if (context.DataReader.FieldCount != 1)
        throw new AdoExecutorException("Sql query must return exacly one column");

      IListAdapter listAdapter = _listAdapterFactory.CreateListAdapter(context.ResultType);

      if (listAdapter != null)
      {
        while (context.DataReader.Read() && !context.DataReader.IsClosed)
        {
          object convertedValue = _objectConverter.ChangeType(listAdapter.ElementType, context.DataReader.GetValue(0));
          listAdapter.AdapterList.Add(convertedValue);
        }

        return listAdapter.ConverToSourceList();
      }
      else
      {
        if (context.DataReader.Read() && !context.DataReader.IsClosed)
          return _objectConverter.ChangeType(context.ResultType, context.DataReader.GetValue(0));
      }

      throw new AdoExecutorException("Cannot read data from reader.");
    }
  }
}