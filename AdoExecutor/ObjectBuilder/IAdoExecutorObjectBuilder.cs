using System;

namespace AdoExecutor.ObjectBuilder
{
  public interface IAdoExecutorObjectBuilder
  {
    bool CanProcess(Type objectType);
    object CreateInstance(IAdoExecutorObjectBuilderContext context);
  }
}