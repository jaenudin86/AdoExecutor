using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Reflection;
using AdoExecutor.Infrastructure.ObjectBuilder;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DefinedTypeAdoExecutorObjectBuilder : IAdoExecutorObjectBuilder
  {
    public bool CanProcess(AdoExecutorObjectBuilderContext context)
    {
      Type resultType = context.ResultType.IsArray ? context.ResultType.GetElementType() : context.ResultType;
      resultType = Nullable.GetUnderlyingType(resultType) ?? resultType;

      return (resultType.BaseType == typeof (ValueType) && !resultType.IsEnum) ||
             (resultType.BaseType == typeof (object) && resultType.IsClass && !resultType.IsAbstract && !resultType.IsInterface);
    }

    public object CreateInstance(AdoExecutorObjectBuilderContext context)
    {
      if (context.ResultType.IsArray)
      {
        var instanceType = context.ResultType.GetElementType();
        var resultList = new ArrayList();

        while (context.DataReader.Read() && !context.DataReader.IsClosed)
        {
          var objectInstance = CreateSingleInstance(context.DataReader, instanceType);
          resultList.Add(objectInstance);
        }

        return resultList.ToArray(instanceType);
      }
      else
      {
        while (context.DataReader.Read() && !context.DataReader.IsClosed)
        {
          return CreateSingleInstance(context.DataReader, context.ResultType);
        }
      }

      return null;
    }

    //todo cache
    private object CreateSingleInstance(IDataReader dataReader, Type instanceType)
    {
      var instance = Activator.CreateInstance(instanceType);
      var typeProperties = instanceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

      for (int i = 0; i < dataReader.FieldCount; i++)
      {
        var columnName = dataReader.GetName(i);
        var property = typeProperties.SingleOrDefault(x => x.Name.Equals(columnName, StringComparison.OrdinalIgnoreCase));

        if (property != null)
        {
          property.SetValue(instance, dataReader.GetValue(i), null);
        }
      }

      return instance;
    }
  }
}