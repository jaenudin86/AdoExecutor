using System;
using System.Collections;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Utilities.Adapter.List
{
  public class AbstractGenericListAdapter : IListAdapter
  {
    public AbstractGenericListAdapter(Type sourceType, Type adapterType)
    {
      if (sourceType == null)
        throw new ArgumentNullException("sourceType");

      if (adapterType == null)
        throw new ArgumentNullException("adapterType");

      if (!sourceType.IsGenericType)
        throw new ArgumentException("SourceType must be generic type.");

      if (sourceType.GetInterface(typeof (IEnumerable).FullName) == null)
        throw new ArgumentException("SourceType must implements System.Collections.IEnumerable");

      if (!sourceType.IsInterface && !sourceType.IsAbstract)
        throw new ArgumentException("SourceType must be interface or abstract class type.");

      if (adapterType.GetInterface(typeof (IList).FullName) == null)
        throw new ArgumentException("AdapterType must implements System.Collections.IList");

      Type[] genericArguments = sourceType.GetGenericArguments();

      if (genericArguments.Length != 1)
        throw new ArgumentException("Type must has exactly one generic arguments.");

      SourceType = sourceType;
      ElementType = genericArguments[0];
      AdapterType = adapterType.MakeGenericType(ElementType);

      AdapterList = (IList) Activator.CreateInstance(AdapterType);
    }

    public Type SourceType { get; private set; }
    public Type AdapterType { get; private set; }
    public Type ElementType { get; private set; }
    public IList AdapterList { get; private set; }

    public IList ConverToSourceList()
    {
      return AdapterList;
    }
  }
}