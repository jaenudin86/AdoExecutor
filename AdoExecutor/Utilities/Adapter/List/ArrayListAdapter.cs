using System;
using System.Collections;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Utilities.Adapter.List
{
  public class ArrayListAdapter : IListAdapter
  {
    private readonly ArrayList _arrayList = new ArrayList();

    public ArrayListAdapter(Type sourceType)
    {
      if (sourceType == null)
        throw new ArgumentNullException("sourceType");

      if (!sourceType.IsArray)
        throw new ArgumentException("SourceType must be array type.");

      SourceType = sourceType;
      ElementType = sourceType.GetElementType();
      AdapterType = typeof (ArrayList);
    }

    public Type SourceType { get; private set; }
    public Type AdapterType { get; private set; }
    public Type ElementType { get; private set; }

    public IList AdapterList
    {
      get { return _arrayList; }
    }

    public IList ConverToSourceList()
    {
      return _arrayList.ToArray(ElementType);
    }
  }
}