using AdoExecutor.Context;

namespace AdoExecutor.Interception
{
  public interface IAdoExecutorInterceptorSuccessContext : IAdoExecutorContext
  {
    object Result { get; }
  }
}