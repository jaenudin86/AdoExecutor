using System;
using AdoExecutor.Shared.Utilities.Adapter.DataReader.Infrastructure;

namespace AdoExecutor.Core.ObjectBuilder.Infrastructure
{
  public class ObjectBuilderContext
  {
    public ObjectBuilderContext(Type resultType, IDataReaderAdapter dataReaderAdapter)
    {
      if (resultType == null)
        throw new ArgumentNullException(nameof(resultType));

      if (dataReaderAdapter == null)
        throw new ArgumentNullException(nameof(dataReaderAdapter));

      ResultType = resultType;
      DataReaderAdapter = dataReaderAdapter;
    }

    public Type ResultType { get; private set; }
    public IDataReaderAdapter DataReaderAdapter { get; private set; }
  }
}