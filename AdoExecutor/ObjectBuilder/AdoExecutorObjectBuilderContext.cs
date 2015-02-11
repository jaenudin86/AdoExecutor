using System;
using System.Data;

namespace AdoExecutor.ObjectBuilder
{
  public class AdoExecutorObjectBuilderContext : IAdoExecutorObjectBuilderContext
  {
    public AdoExecutorObjectBuilderContext(Type resultType, IDataReader dataReader)
    {
      if (resultType == null)
        throw new ArgumentNullException("resultType");

      if (dataReader == null)
        throw new ArgumentNullException("dataReader");

      ResultType = resultType;
      DataReader = dataReader;
    }

    public Type ResultType { get; private set; }
    public IDataReader DataReader { get; private set; }
  }
}