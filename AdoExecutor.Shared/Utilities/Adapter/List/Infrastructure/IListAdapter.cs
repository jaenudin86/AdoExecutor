using System;
using System.Collections;

namespace AdoExecutor.Utilities.Adapter.List.Infrastructure
{
  public interface IListAdapter
  {
    void AddItem(object item);
    IList GetCollection();
    Type ItemType { get; }
  }
}