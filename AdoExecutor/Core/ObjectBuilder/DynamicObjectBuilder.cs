using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DynamicObjectBuilder : IObjectBuilder
  {
    private readonly IListAdapterFactory _listAdapterFactory;

    public DynamicObjectBuilder(IListAdapterFactory listAdapterFactory)
    {
      if (listAdapterFactory == null)
        throw new ArgumentNullException("listAdapterFactory");

      _listAdapterFactory = listAdapterFactory;
    }

    public bool CanProcess(ObjectBuilderContext context)
    {
      if (context.ResultType == typeof (object))
        return true;

      IListAdapter listAdapter = _listAdapterFactory.CreateListAdapter(context.ResultType);

      if (listAdapter != null)
        return listAdapter.ElementType == typeof (object);

      return false;
    }

    public object CreateInstance(ObjectBuilderContext context)
    {
      IListAdapter listAdapter = _listAdapterFactory.CreateListAdapter(context.ResultType);

      if (listAdapter != null)
      {
        while (context.DataReader.Read() && !context.DataReader.IsClosed)
          listAdapter.AdapterList.Add(CreateDynamicObject(context.DataReader));

        return listAdapter.ConverToSourceList();
      }
      else
      {
        if (context.DataReader.Read() && !context.DataReader.IsClosed)
          return CreateDynamicObject(context.DataReader);
      }

      throw new AdoExecutorException("Cannot read data from reader.");
    }

    private object CreateDynamicObject(IDataReader dataReader)
    {
      var result = new ExpandoObject();
      var dictionaryResult = (IDictionary<string, object>) result;

      for (int i = 0; i < dataReader.FieldCount; i++)
        dictionaryResult[dataReader.GetName(i)] = dataReader[i];

      return result;
    }
  }
}