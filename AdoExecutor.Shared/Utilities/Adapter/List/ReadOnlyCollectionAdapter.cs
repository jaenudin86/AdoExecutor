using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Shared.Utilities.Adapter.List
{
  public class ReadOnlyCollectionAdapter : IListAdapter
  {
    private readonly IList _innerList;

    public ReadOnlyCollectionAdapter(Type itemType)
    {
      ItemType = itemType;

      var listType = typeof(List<>).MakeGenericType(itemType);
      _innerList = (IList)Activator.CreateInstance(listType);
    }

    public void AddItem(object item)
    {
      _innerList.Add(item);
    }

    public IList GetCollection()
    {
      var readOnlyCollectionType = typeof(ReadOnlyCollection<>).MakeGenericType(ItemType);
      return (IList)Activator.CreateInstance(readOnlyCollectionType, _innerList);
    }

    public Type ItemType { get; private set; }
  }
}