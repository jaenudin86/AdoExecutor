using System.Collections.Generic;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Shared.Utilities.Adapter.DataReader.Infrastructure;

namespace AdoExecutor.Shared.Core.ObjectBuilder
{
  public class DictionaryObjectBuilder : IObjectBuilder
  {
    public bool CanProcess(ObjectBuilderContext context)
    {
      return context.ResultType == typeof (Dictionary<string, object>)
             || context.ResultType == typeof (IDictionary<string, object>);
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
        return CreateDictionaryObject(context.DataReaderAdapter);

      return null;
    }

    private object CreateDictionaryObject(IDataReaderAdapter dataReaderAdapter)
    {
      var result = new Dictionary<string, object>();

      for (var i = 0; i < dataReaderAdapter.FieldCount; i++)
        result[dataReaderAdapter.GetName(i)] = dataReaderAdapter[i];

      return result;
    }
  }
}