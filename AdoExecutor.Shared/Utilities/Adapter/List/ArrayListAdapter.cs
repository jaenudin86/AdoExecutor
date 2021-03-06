﻿using System;
using System.Collections;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Shared.Utilities.Adapter.List
{
  public class ArrayListAdapter : IListAdapter
  {
    private readonly ArrayList _innerList;

    public ArrayListAdapter(Type itemType)
    {
      ItemType = itemType;
      _innerList = new ArrayList();
    }

    public void AddItem(object item)
    {
      _innerList.Add(item);
    }

    public IList GetCollection()
    {
      return _innerList.ToArray(ItemType);
    }

    public Type ItemType { get; private set; }
  }
}