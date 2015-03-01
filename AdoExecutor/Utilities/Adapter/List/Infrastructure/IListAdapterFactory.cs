using System;

namespace AdoExecutor.Utilities.Adapter.List.Infrastructure
{
  public interface IListAdapterFactory
  {
    IListAdapter CreateListAdapter(Type sourceType);
  }
}