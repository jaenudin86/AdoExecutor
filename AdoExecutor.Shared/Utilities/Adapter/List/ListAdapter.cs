using System;
using System.Collections;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;
using System.Collections.Generic;

namespace AdoExecutor.Shared.Utilities.Adapter.List
{
  public class ListAdapter : IListAdapter
  {
    private readonly IList _innerList;

    public ListAdapter(Type itemType)
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
      return _innerList;
    }

    public Type ItemType { get; private set; }
  }
}