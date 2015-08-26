namespace AdoExecutor.Core.Interception.Infrastructure
{
  public interface IInterceptor
  {
    void OnEntry(Context.Infrastructure.AdoExecutorContext context);
    void OnSuccess(InterceptorSuccessContext context);
    void OnError(InterceptorErrorContext context);
    void OnExit(InterceptorExitContext context);
  }
}