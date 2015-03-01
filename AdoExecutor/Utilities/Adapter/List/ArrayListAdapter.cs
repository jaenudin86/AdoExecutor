using System;
using System.Collections;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;

namespace AdoExecutor.Utilities.Adapter.List
{
  public class ArrayListAdapter : IListAdapter
  {
    private ArrayList _adapterList;

    public ArrayListAdapter(Type sourceListType)
    {
      if (sourceListType == null)
        throw new ArgumentNullException("SourceListType");

      if (!sourceListType.IsArray)
        throw new ArgumentException("SourceListType must be array type.");

      SourceListType = sourceListType;
      ElementType = sourceListType.GetElementType();
      AdapterListType = typeof (ArrayList);
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

        _adapterList = new ArrayList();

        return _adapterList;
      }
    }

    public virtual IList ConverToSourceList()
    {
      return ((ArrayList) AdapterList).ToArray(ElementType);
    }
  }
}