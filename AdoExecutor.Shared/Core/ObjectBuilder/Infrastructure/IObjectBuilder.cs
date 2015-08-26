namespace AdoExecutor.Core.ObjectBuilder.Infrastructure
{
  public interface IObjectBuilder
  {
    bool CanProcess(ObjectBuilderContext context);
    object CreateInstance(ObjectBuilderContext context);
  }
}