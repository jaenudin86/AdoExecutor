using System;
using System.Collections;
using AdoExecutor.Core.Helper;
using AdoExecutor.Infrastructure.Exception;
using AdoExecutor.Infrastructure.ObjectBuilder;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class SimpleTypeAdoExecutorObjectBuilder : IAdoExecutorObjectBuilder
  {
    private readonly PrimitiveSqlDataTypes _primitiveSqlDataTypes = new PrimitiveSqlDataTypes();

    public bool CanProcess(AdoExecutorObjectBuilderContext context)
    {
      Type elementType = context.ResultType;

      if (context.ResultType.IsArray)
      {
        elementType = context.ResultType.GetElementType();
      }

      return _primitiveSqlDataTypes.IsSqlPrimitiveType(elementType);
    }

    public object CreateInstance(AdoExecutorObjectBuilderContext context)
    {
      if (context.DataReader.FieldCount != 1)
        throw new AdoExecutorException("Sql query must return exacly one column");

      if (context.ResultType.IsArray)
      {
        var resultList = new ArrayList();

        while (context.DataReader.Read() && !context.DataReader.IsClosed)
        {
          resultList.Add(context.DataReader.GetValue(0));
        }

        Type elementType = context.ResultType.GetElementType();
        return resultList.ToArray(elementType);
      }
      else if (context.DataReader.Read() && !context.DataReader.IsClosed)
      {
        return context.DataReader.GetValue(0);
      }

      return null;
    }
  }
}