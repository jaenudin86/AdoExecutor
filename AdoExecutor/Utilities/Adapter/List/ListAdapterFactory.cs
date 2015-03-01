﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Utilities.Adapter.List
{
  public class ListAdapterFactory : IListAdapterFactory
  {
    public virtual IListAdapter CreateListAdapter(Type sourceListType)
    {
      if (sourceListType.IsArray)
        return new ArrayListAdapter(sourceListType);

      if (sourceListType.IsGenericType)
      {
        Type sourceGenericTypeDefinition = sourceListType.GetGenericTypeDefinition();

        if (sourceGenericTypeDefinition == typeof (List<>) ||
            sourceGenericTypeDefinition == typeof (Collection<>) ||
            sourceGenericTypeDefinition == typeof (ObservableCollection<>))
        {
          return new GenericListAdapter(sourceListType);
        }

        if (sourceGenericTypeDefinition == typeof (IList<>))
          return new AbstractGenericListAdapter(sourceListType, typeof (List<>));

        if (sourceGenericTypeDefinition == typeof (ICollection<>))
          return new AbstractGenericListAdapter(sourceListType, typeof (Collection<>));

        if (sourceGenericTypeDefinition == typeof (IEnumerable<>))
          return new AbstractGenericListAdapter(sourceListType, typeof (List<>));

        if (sourceGenericTypeDefinition == typeof (ReadOnlyCollection<>))
          return new ReadOnlyCollectionListAdapter(sourceListType);

        if (sourceGenericTypeDefinition == typeof (ReadOnlyObservableCollection<>))
          return new ReadOnlyObservableCollectionListAdapter(sourceListType);
      }

      return null;
    }
  }
}