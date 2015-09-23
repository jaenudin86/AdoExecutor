#if NET30 || NET35 || NET40 || NET45
using System;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Shared.Core.Entities.Infrastructure;
using AdoExecutor.Shared.Utilities.Adapter.List;
using AdoExecutor.Utilities.Adapter.DataTable;
using AdoExecutor.Utilities.ObjectConverter;
using AdoExecutor.Utilities.PrimitiveTypes;

namespace AdoExecutor.Shared.Core.ObjectBuilder
{
  public class MultipleResultSetObjectBuilder : IObjectBuilder
  {
    private readonly IObjectBuilder[] _objectBuilders =
    {
      new CollectionObjectBuilder(new ListAdapterFactory()),
      new DataTableObjectBuilder(new DataTableAdapter()),
      new DefinedTypeObjectBuilder(new SqlPrimitiveDataTypes(), new ObjectConverter()),
      new DictionaryObjectBuilder(),
      new SqlSimpleTypeObjectBuilder(new SqlPrimitiveDataTypes(), new ObjectConverter()),
#if NET40 || NET45
      new TupleObjectBuilder(),
      new DynamicObjectBuilder(),
 #endif
    };

    public bool CanProcess(ObjectBuilderContext context)
    {
      return context.ResultType.GetInterface(typeof (IMultipleResultSet).FullName) != null;
    }

    public object CreateInstance(ObjectBuilderContext context)
    {
      var multipleResultSetGenericArguments = context.ResultType.GetGenericArguments();
      var multipleData = new object[multipleResultSetGenericArguments.Length];

      context.DataReaderAdapter.Open();

      if (!context.DataReaderAdapter.Read())
        return null;

      while (!context.DataReaderAdapter.IsClosed)
      {
        if (context.DataReaderAdapter.FieldCount != 0)
          throw new AdoExecutorException("DataReader has 0 filed count");

        for (int i = 0; i < multipleResultSetGenericArguments.Length; i++)
        {
          var subContext = new ObjectBuilderContext(multipleResultSetGenericArguments[i], context.DataReaderAdapter);
          var objectBuilder = GetObjectBuilder(subContext);

          if (objectBuilder == null)
            throw new AdoExecutorException("Cannot find supported object builder");

          multipleData[i] = objectBuilder.CreateInstance(subContext);
        }

        if (!context.DataReaderAdapter.NextResult())
          break;
      }

      if (multipleResultSetGenericArguments.Length != multipleData.Length)
        throw new AdoExecutorException("DataReader results are not equals with MultipleResultSet generic arguments.");

      return Activator.CreateInstance(context.ResultType, multipleData);
    }

    private IObjectBuilder GetObjectBuilder(ObjectBuilderContext context)
    {
      foreach(IObjectBuilder objectBuilder in _objectBuilders)
      {
        if (objectBuilder.CanProcess(context))
          return objectBuilder;
      }

      return null;
    }
  }
}
#endif