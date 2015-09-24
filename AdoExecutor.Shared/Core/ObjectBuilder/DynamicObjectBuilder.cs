#if NET40 || NET45

using System;
using System.Collections.Generic;
using System.Dynamic;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Shared.Utilities.Adapter.DataReader.Infrastructure;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DynamicObjectBuilder : IObjectBuilder
  {
    public bool CanProcess(ObjectBuilderContext context)
    {
      if (context.ResultType == typeof (object))
        return true;

      return false;
    }

    public object CreateInstance(ObjectBuilderContext context)
    {
      if (!context.DataReaderAdapter.IsOpen)
      {
        context.DataReaderAdapter.Open();
      }

      if (!context.DataReaderAdapter.IsReading)
      {
        if (!context.DataReaderAdapter.Read())
          return null;
      }

      if (!context.DataReaderAdapter.IsClosed)
        return CreateDynamicObject(context.DataReaderAdapter);

      return null;
    }

    private object CreateDynamicObject(IDataReaderAdapter dataReaderAdapter)
    {
      var result = new ExpandoObject();
      var dictionaryResult = (IDictionary<string, object>) result;

      for (var i = 0; i < dataReaderAdapter.FieldCount; i++)
      {
        var value = dataReaderAdapter[i];
        if (value == DBNull.Value)
          value = null;

        dictionaryResult[dataReaderAdapter.GetName(i)] = value;
      }

      return result;
    }
  }
}

#endif