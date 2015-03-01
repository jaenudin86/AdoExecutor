using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Utilities.Adapter.List
{
  public class ReadOnlyCollectionListAdapter : IListAdapter
  {
    private IList _adapterList;

    public ReadOnlyCollectionListAdapter(Type sourceListType)
    {
      if (sourceListType == null)
        throw new ArgumentNullException("SourceListType");

      if (!sourceListType.IsGenericType)
        throw new ArgumentException("SourceListType must be generic type.");

      Type genericTypeDefinition = sourceListType.GetGenericTypeDefinition();

      if (genericTypeDefinition != typeof (ReadOnlyCollection<>))
        throw new ArgumentException("SourceListType must be ReadOnlyCollection<> type.");

      Type[] genericArguments = sourceListType.GetGenericArguments();

      if (genericArguments.Length != 1)
        throw new ArgumentException("Type must has exactly one generic arguments.");

      SourceListType = sourceListType;
      ElementType = genericArguments[0];
      AdapterListType = typeof (List<>).MakeGenericType(ElementType);
    }
    public Type SourceListType { get; private set; }
    public Type AdapterListType { get; private set; }
    public Type ElementType { get; private set; }

    public IList AdapterList
    {
      get
      {
        if (_adapterList != null)
          return _adapterList;

        _adapterList = (IList)Activator.CreateInstance(AdapterListType);

        return _adapterList;
      }
    }

    public IList ConverToSourceList()
    {
      return (IList) Activator.CreateInstance(SourceListType, AdapterList);
    }
  }
}