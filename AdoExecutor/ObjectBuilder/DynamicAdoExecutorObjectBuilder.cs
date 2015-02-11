using System;

namespace AdoExecutor.ObjectBuilder
{
  public class DynamicAdoExecutorObjectBuilder : IAdoExecutorObjectBuilder
  {
    public bool CanProcess(Type objectType)
    {
      return objectType == typeof (object);
    }

    public object CreateInstance(IAdoExecutorObjectBuilderContext context)
    {
      throw new NotImplementedException();
    }
  }
}