namespace AdoExecutor.Interception
{
  public interface IAdoExecutorInterceptor
  {
    void OnEntry(IAdoExecutorInterceptorEntryContext context);
    void OnSuccess(IAdoExecutorInterceptorSuccessContext context);
    void OnError(IAdoExecutorInterceptorSuccessContext context);
    void OnExit(IAdoExecutorInterceptorExitContext context);
  }
}