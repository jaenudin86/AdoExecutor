using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Interception.Infrastructure;

namespace AdoExecutor.Core.Interception
{
  public class ConnectionStateManagerInterceptor : IInterceptor
  {
    public void OnEntry(Context.Infrastructure.AdoExecutorContext context)
    {
      context.Connection.Open();
    }

    public void OnSuccess(InterceptorSuccessContext context)
    {
    }

    public void OnError(InterceptorErrorContext context)
    {
    }

    public void OnExit(InterceptorExitContext context)
    {
      context.Connection.Close();
    }
  }
}