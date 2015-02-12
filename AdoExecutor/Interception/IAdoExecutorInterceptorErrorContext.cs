using AdoExecutor.Context;

namespace AdoExecutor.Interception
{
  public interface IAdoExecutorInterceptorErrorContext : IAdoExecutorContext
  {
    System.Exception Exception { get; }
  }
}