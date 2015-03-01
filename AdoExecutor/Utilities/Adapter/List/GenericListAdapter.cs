using System;
using System.Collections;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Utilities.Adapter.List
{
  public class GenericListAdapter : IListAdapter
  {
    public GenericListAdapter(Type sourceType)
    {
      if (sourceType == null)
        throw new ArgumentNullException("sourceType");

      if (!sourceType.IsGenericType)
        throw new ArgumentException("SourceType must be generic type.");

      if (sourceType.GetInterface(typeof (IList).FullName) == null)
        throw new ArgumentException("SourceType must implements System.Collections.IList");

      if (sourceType.IsAbstract || sourceType.IsInterface)
        throw new ArgumentException("SourceType cannot be interface or abstract class");

      Type[] genericArguments = sourceType.GetGenericArguments();

      if (genericArguments.Length != 1)
        throw new ArgumentException("Type must has exactly one generic arguments.");

      SourceType = sourceType;
      ElementType = genericArguments[0];
      AdapterType = sourceType;

      AdapterList = (IList) Activator.CreateInstance(sourceType);
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