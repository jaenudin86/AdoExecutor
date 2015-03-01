using System;
using System.Collections;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Utilities.Adapter.List
{
  public class AbstractGenericListAdapter : IListAdapter
  {
    private IList _adapterList;

    public AbstractGenericListAdapter(Type sourceListType, Type adapterType)
    {
      if (sourceListType == null)
        throw new ArgumentNullException("SourceListType");

      if (adapterType == null)
        throw new ArgumentNullException("adapterType");

      if (!sourceListType.IsGenericType)
        throw new ArgumentException("SourceListType must be generic type.");

      if (sourceListType.GetInterface(typeof (IEnumerable).FullName) == null)
        throw new ArgumentException("SourceListType must implements System.Collections.IEnumerable");

      if (!sourceListType.IsInterface && !sourceListType.IsAbstract)
        throw new ArgumentException("SourceListType must be interface or abstract class type.");

      if (adapterType.GetInterface(typeof (IList).FullName) == null)
        throw new ArgumentException("AdapterListType must implements System.Collections.IList");

      Type[] genericArguments = sourceListType.GetGenericArguments();

      if (genericArguments.Length != 1)
        throw new ArgumentException("Type must has exactly one generic arguments.");

      SourceListType = sourceListType;
      ElementType = genericArguments[0];
      AdapterListType = adapterType.MakeGenericType(ElementType);
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

        _adapterList = (IList) Activator.CreateInstance(AdapterListType);

        return _adapterList;
      }
    }

    public virtual IList ConverToSourceList()
    {
      return AdapterList;
    }
  }
}