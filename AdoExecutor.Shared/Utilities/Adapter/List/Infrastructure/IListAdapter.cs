using System;
using System.Collections;

namespace AdoExecutor.Utilities.Adapter.List.Infrastructure
{
  public interface IListAdapter
  {
    Type SourceListType { get; }
    Type AdapterListType { get; }
    Type ElementType { get; }
    IList AdapterList { get; }
    IList ConverToSourceList();
  }
}