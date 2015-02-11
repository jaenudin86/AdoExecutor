namespace AdoExecutor.Interception
{
  public interface IAdoExecutorInterceptorErrorContext : IAdoExecutorInterceptorContext
  {
    System.Exception Exception { get; }
  }
}