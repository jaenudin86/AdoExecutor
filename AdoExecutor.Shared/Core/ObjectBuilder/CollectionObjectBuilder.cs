using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Shared.Utilities.Adapter.List.Infrastructure;
using AdoExecutor.Utilities.Adapter.DataTable;
using AdoExecutor.Utilities.ObjectConverter;
using AdoExecutor.Utilities.PrimitiveTypes;

namespace AdoExecutor.Shared.Core.ObjectBuilder
{
  public class CollectionObjectBuilder : IObjectBuilder
  {
    private readonly IListAdapterFactory _listAdapterFactory;

    private readonly IObjectBuilder[] _objectBuilders =
    {
      new DictionaryObjectBuilder(),
      new SqlSimpleTypeObjectBuilder(new SqlPrimitiveDataTypes(), new ObjectConverter()),
#if NET40 || NET45
      new TupleObjectBuilder(),
      new DynamicObjectBuilder(),
 #endif
      new DefinedTypeObjectBuilder(new SqlPrimitiveDataTypes(), new ObjectConverter()),
    };

    public CollectionObjectBuilder(IListAdapterFactory listAdapterFactory)
    {
      _listAdapterFactory = listAdapterFactory;
    }

    public bool CanProcess(ObjectBuilderContext context)
    {
      var listAdapter = _listAdapterFactory.CreateAdapter(context.ResultType);

      return listAdapter != null;
    }

    public object CreateInstance(ObjectBuilderContext context)
    {
      var listAdapter = _listAdapterFactory.CreateAdapter(context.ResultType);

      if (!context.DataReaderAdapter.IsOpen)
      {
        context.DataReaderAdapter.Open();
      }

      while (context.DataReaderAdapter.Read() && !context.DataReaderAdapter.IsClosed)
      {
        var subContext = new ObjectBuilderContext(listAdapter.ItemType, context.DataReaderAdapter);
        var objectBuilder = GetObjectBuilder(subContext);

        if (objectBuilder == null)
          throw new AdoExecutorException("Cannot find supported object builder");

        var instance = objectBuilder.CreateInstance(subContext);
        listAdapter.AddItem(instance);
      }

      return listAdapter.GetCollection();
    }

    private IObjectBuilder GetObjectBuilder(ObjectBuilderContext context)
    {
      foreach (IObjectBuilder objectBuilder in _objectBuilders)
       {
        if (objectBuilder.CanProcess(context))
          return objectBuilder;
      }

      return null;
    }
  }
}