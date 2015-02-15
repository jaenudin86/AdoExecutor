namespace AdoExecutor.Infrastructure.ObjectBuilder
{
  public interface IAdoExecutorObjectBuilder
  {
    bool CanProcess(AdoExecutorObjectBuilderContext context);
    object CreateInstance(AdoExecutorObjectBuilderContext context);
  }
}