using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using AdoExecutor.Infrastructure.ObjectBuilder;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DynamicAdoExecutorObjectBuilder : IAdoExecutorObjectBuilder
  {
    public bool CanProcess(AdoExecutorObjectBuilderContext context)
    {
      return context.ResultType == typeof (object) || context.ResultType == typeof (object[]);
    }

    public object CreateInstance(AdoExecutorObjectBuilderContext context)
    {
      if (context.ResultType.IsArray)
      {
        var result = new List<object>();

        while (context.DataReader.Read() && !context.DataReader.IsClosed)
        {
          result.Add(CreateDynamicObject(context.DataReader));
        }

        return result.ToArray();
      }
      else
      {
        while (context.DataReader.Read() && !context.DataReader.IsClosed)
        {
          return CreateDynamicObject(context.DataReader);
        } 
      }

      return null;
    }

    private object CreateDynamicObject(IDataReader dataReader)
    {
      var result = new ExpandoObject();
      var dictionaryResult = (IDictionary<string, object>) result;

      for (int i = 0; i < dataReader.FieldCount; i++)
      {
        dictionaryResult[dataReader.GetName(i)] = dataReader[i];
      }

      return result;
    }
  }
}