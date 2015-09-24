using System;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Shared.Utilities.Adapter.List.Infrastructure
{
  public interface IListAdapterFactory
  {
    IListAdapter CreateAdapter(Type collectionType);
  }
}