#if NET30 || NET35 || NET40 || NET45
using System;
using System.Collections;
using System.Collections.ObjectModel;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Shared.Utilities.Adapter.List
{
  public class ObservableCollectionAdapter : IListAdapter
  {
    private readonly IList _innerList;

    public ObservableCollectionAdapter(Type itemType)
    {
      ItemType = itemType;

      var listType = typeof (ObservableCollection<>).MakeGenericType(itemType);
      _innerList = (IList) Activator.CreateInstance(listType);
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
#endif