using System.Data;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Shared.Utilities.Adapter.DataReader.Infrastructure;

namespace AdoExecutor.Shared.Core.ObjectBuilder
{
  public class DataReaderObjectBuilder : IObjectBuilder
  {
    public bool CanProcess(ObjectBuilderContext context)
    {
      return context.ResultType == typeof (IDataReader);
    }

    public object CreateInstance(ObjectBuilderContext context)
    {
      return ((IDataReaderAccess) context.DataReaderAdapter).DataReader;
    }
  }
}