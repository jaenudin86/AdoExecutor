using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdoExecutor.Shared.Utilities.Adapter.List.Infrastructure;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Shared.Utilities.Adapter.List
{
  public class ListAdapterFactory : IListAdapterFactory
  {
    public IListAdapter CreateAdapter(Type collectionType)
    {
      if (collectionType.IsArray)
      {
        var itemType = collectionType.GetElementType();
        return new ArrayListAdapter(itemType);
      }
      else if (collectionType.IsGenericType)
      {
        var genericTypeDefinition = collectionType.GetGenericTypeDefinition();
        var itemType = collectionType.GetGenericArguments()[0];

        if (genericTypeDefinition == typeof(List<>)
          || genericTypeDefinition == typeof(IList<>)
          || genericTypeDefinition == typeof(IEnumerable<>))
        {
          return new ListAdapter(itemType);
        }

        if (genericTypeDefinition == typeof(Collection<>)
          || genericTypeDefinition == typeof(ICollection<>))
        {
          return new CollectionAdapter(itemType);
        }

        if (genericTypeDefinition == typeof(ReadOnlyCollection<>))
        {
          return new ReadOnlyCollectionAdapter(itemType);
        }

        if (genericTypeDefinition == typeof(ObservableCollection<>))
        {
          return new ObservableCollectionAdapter(itemType);
        }

        if (genericTypeDefinition == typeof(ReadOnlyObservableCollection<>))
        {
          return new ReadOnlyObservableCollectionAdapter(itemType);
        }
      }

      throw new NotSupportedException($"Type '{collectionType}' is not supported collection type.");
    }
  }
}