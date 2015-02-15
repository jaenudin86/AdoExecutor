using AdoExecutor.Infrastructure.Context;

namespace AdoExecutor.Infrastructure.Interception
{
  public interface IAdoExecutorInterceptor
  {
    void OnEntry(AdoExecutorContext context);
    void OnSuccess(AdoExecutorInterceptorSuccessContext context);
    void OnError(AdoExecutorInterceptorErrorContext context);
    void OnExit(AdoExecutorInterceptorExitContext context);
  }
}