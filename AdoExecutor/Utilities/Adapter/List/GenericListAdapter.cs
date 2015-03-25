 using System;
using System.Collections;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Utilities.Adapter.List
{
  public class GenericListAdapter : IListAdapter
  {
    private IList _adapterList;

    public GenericListAdapter(Type sourceListType)
    {
      if (sourceListType == null)
        throw new ArgumentNullException("sourceListType");

      if (!sourceListType.IsGenericType)
        throw new ArgumentException("sourceListType must be generic type.");

      if (sourceListType.GetInterface(typeof (IList).FullName) == null)
        throw new ArgumentException("sourceListType must implements System.Collections.IList");

      if (sourceListType.IsAbstract || sourceListType.IsInterface)
        throw new ArgumentException("sourceListType cannot be interface or abstract class");

      Type[] genericArguments = sourceListType.GetGenericArguments();

      if (genericArguments.Length != 1)
        throw new ArgumentException("Type must has exactly one generic arguments.");

      SourceListType = sourceListType;
      ElementType = genericArguments[0];
      AdapterListType = sourceListType;
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

    public virtual IList ConverToSourceList()
    {
      return AdapterList;
    }
  }
}