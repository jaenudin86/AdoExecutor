using System;
using System.Collections;
using System.Collections.ObjectModel;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Shared.Utilities.Adapter.List
{
  public class CollectionAdapter : IListAdapter
  {
    private readonly IList _innerList;

    public CollectionAdapter(Type itemType)
    {
      ItemType = itemType;

      var listType = typeof(Collection<>).MakeGenericType(itemType);
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