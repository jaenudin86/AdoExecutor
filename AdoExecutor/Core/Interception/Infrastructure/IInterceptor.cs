using AdoExecutor.Core.Context.Infrastructure;

namespace AdoExecutor.Core.Interception.Infrastructure
{
  public interface IInterceptor
  {
    void OnEntry(Context.Infrastructure.Context context);
    void OnSuccess(InterceptorSuccessContext context);
    void OnError(InterceptorErrorContext context);
    void OnExit(InterceptorExitContext context);
  }
}