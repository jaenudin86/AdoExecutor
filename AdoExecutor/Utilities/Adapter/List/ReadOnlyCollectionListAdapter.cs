using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AdoExecutor.Utilities.Adapter.List
{
  public class ReadOnlyCollectionListAdapter : ReadOnlyListAdapterBase
  {
    public ReadOnlyCollectionListAdapter(Type sourceType)
      : base(sourceType)
    {
    }

    protected override Type ReadOnlyListType
    {
      get { return typeof (ReadOnlyCollection<>); }
    }

    protected override Type ReadOnlyAdapterListType
    {
      get { return typeof (List<>); }
    }
  }
}