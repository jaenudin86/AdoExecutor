using System;
using AdoExecutor.Infrastructure.ObjectBuilder;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DynamicAdoExecutorObjectBuilder : IAdoExecutorObjectBuilder
  {
    public bool CanProcess(AdoExecutorObjectBuilderContext context)
    {
      return context.ResultType == typeof (object);
    }

    public object CreateInstance(AdoExecutorObjectBuilderContext context)
    {
      throw new NotImplementedException();
    }
  }
}