using System;
using System.Collections;

namespace AdoExecutor.Utilities.Adapter.List.Infrastructure
{
  public interface IListAdapter
  {
    Type SourceType { get; }
    Type AdapterType { get; }
    Type ElementType { get; }
    IList AdapterList { get; }
    IList ConverToSourceList();
  }
}