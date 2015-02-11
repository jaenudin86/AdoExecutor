namespace AdoExecutor.Interception
{
  public interface IAdoExecutorInterceptorSuccessContext : IAdoExecutorInterceptorContext
  {
    object Result { get; }
  }
}