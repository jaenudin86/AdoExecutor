using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Utilities.Adapter.List
{
  public class ListAdapterFactory : IListAdapterFactory
  {
    public IListAdapter CreateListAdapter(Type sourceType)
    {
      if (sourceType.IsArray)
        return new ArrayListAdapter(sourceType);

      if (sourceType.IsGenericType)
      {
        Type sourceGenericTypeDefinition = sourceType.GetGenericTypeDefinition();

        if (sourceGenericTypeDefinition == typeof (List<>) ||
            sourceGenericTypeDefinition == typeof (Collection<>) ||
            sourceGenericTypeDefinition == typeof (ObservableCollection<>))
        {
          return new GenericListAdapter(sourceType);
        }

        if (sourceGenericTypeDefinition == typeof (IList<>))
          return new AbstractGenericListAdapter(sourceType, typeof (List<>));

        if (sourceGenericTypeDefinition == typeof (ICollection<>))
          return new AbstractGenericListAdapter(sourceType, typeof (Collection<>));

        if (sourceGenericTypeDefinition == typeof (IEnumerable<>))
          return new AbstractGenericListAdapter(sourceType, typeof (List<>));

        if (sourceGenericTypeDefinition == typeof (ReadOnlyCollection<>))
          return new ReadOnlyCollectionListAdapter(sourceType);

        if (sourceGenericTypeDefinition == typeof (ReadOnlyObservableCollection<>))
          return new ReadOnlyObservableCollectionListAdapter(sourceType);
      }

      return null;
    }
  }
}