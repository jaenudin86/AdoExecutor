using System;
using System.Collections;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Utilities.Adapter.List
{
  public abstract class ReadOnlyListAdapterBase : IListAdapter
  {
    protected ReadOnlyListAdapterBase(Type sourceType)
    {
      if (sourceType == null)
        throw new ArgumentNullException("sourceType");

      if (!sourceType.IsGenericType)
        throw new ArgumentException("SourceType must be generic type.");

      Type genericTypeDefinition = sourceType.GetGenericTypeDefinition();

      if (genericTypeDefinition != ReadOnlyListType)
        throw new ArgumentException("Source type must be System.Collections.ObjectModel.ReadOnlyCollection<> type.");

      Type[] genericArguments = sourceType.GetGenericArguments();

      if (genericArguments.Length != 1)
        throw new ArgumentException("Type must has exactly one generic arguments.");

      SourceType = sourceType;
      ElementType = genericArguments[0];

      AdapterType = ReadOnlyAdapterListType.MakeGenericType(ElementType);
      AdapterList = (IList) Activator.CreateInstance(AdapterType);
    }

    protected abstract Type ReadOnlyListType { get; }
    protected abstract Type ReadOnlyAdapterListType { get; }

    public Type SourceType { get; private set; }
    public Type AdapterType { get; private set; }
    public Type ElementType { get; private set; }
    public IList AdapterList { get; private set; }

    public IList ConverToSourceList()
    {
      return (IList) Activator.CreateInstance(SourceType, AdapterList);
    }
  }
}