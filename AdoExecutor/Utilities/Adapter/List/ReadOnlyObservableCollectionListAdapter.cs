using System;
using System.Collections.ObjectModel;

namespace AdoExecutor.Utilities.Adapter.List
{
  public class ReadOnlyObservableCollectionListAdapter : ReadOnlyListAdapterBase
  {
    public ReadOnlyObservableCollectionListAdapter(Type sourceType)
      : base(sourceType)
    {
    }

    protected override Type ReadOnlyListType
    {
      get { return typeof (ReadOnlyObservableCollection<>); }
    }

    protected override Type ReadOnlyAdapterListType
    {
      get { return typeof (ObservableCollection<>); }
    }
  }
}