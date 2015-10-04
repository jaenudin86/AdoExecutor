#if NET40 || NET45

using System;
using System.Linq;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Utilities.ObjectConverter;
using AdoExecutor.Utilities.PrimitiveTypes;

namespace AdoExecutor.Shared.Core.ObjectBuilder
{
  public class TupleObjectBuilder : IObjectBuilder
  {
    private readonly IObjectBuilder[] _objectBuilders =
    {
      new SqlSimpleTypeObjectBuilder(new SqlPrimitiveDataTypes(), new ObjectConverter()),
      new DefinedTypeObjectBuilder(new SqlPrimitiveDataTypes(), new ObjectConverter()),
    };

    public bool CanProcess(ObjectBuilderContext context)
    {
      if (!context.ResultType.IsGenericType)
        return false;

      var genericType = context.ResultType.GetGenericTypeDefinition();

      return genericType == typeof(Tuple<>)
             || genericType == typeof (Tuple<,>)
             || genericType == typeof (Tuple<,,>)
             || genericType == typeof (Tuple<,,,>)
             || genericType == typeof (Tuple<,,,,>)
             || genericType == typeof (Tuple<,,,,,>)
             || genericType == typeof (Tuple<,,,,,,>)
             || genericType == typeof (Tuple<,,,,,,,>);
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
        return CreateTupleObject(context);

      return null;
    }

    private object CreateTupleObject(ObjectBuilderContext context)
    {
      var tupleGenericArguments = context.ResultType.GetGenericArguments();
      var tupleData = new object[tupleGenericArguments.Length];

      for (var i = 0; i < tupleGenericArguments.Length; i++)
      {
        context.DataReaderAdapter.CurrentColumnIndex = i;
        var subContext = new ObjectBuilderContext(tupleGenericArguments[i], context.DataReaderAdapter);

        var objectBuilder = _objectBuilders.FirstOrDefault(x => x.CanProcess(subContext));

        if (objectBuilder == null)
          throw new AdoExecutorException("Cannot find supported object builder");

        tupleData[i] = objectBuilder.CreateInstance(subContext);
      }

      return Activator.CreateInstance(context.ResultType, tupleData);
    }
  }
}

#endif