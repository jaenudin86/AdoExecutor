using AdoExecutor.Context;

namespace AdoExecutor.Interception
{
  public interface IAdoExecutorInterceptor
  {
    void OnEntry(IAdoExecutorContext context);
    void OnSuccess(IAdoExecutorInterceptorSuccessContext context);
    void OnError(IAdoExecutorInterceptorSuccessContext context);
    void OnExit(IAdoExecutorInterceptorExitContext context);
  }
}