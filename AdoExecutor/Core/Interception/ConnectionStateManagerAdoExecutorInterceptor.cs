using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.Interception;

namespace AdoExecutor.Core.Interception
{
  public class ConnectionStateManagerAdoExecutorInterceptor : IAdoExecutorInterceptor
  {
    public void OnEntry(AdoExecutorContext context)
    {
      context.Connection.Open();
    }

    public void OnSuccess(AdoExecutorInterceptorSuccessContext context)
    {
    }

    public void OnError(AdoExecutorInterceptorErrorContext context)
    {
    }

    public void OnExit(AdoExecutorInterceptorExitContext context)
    {
      context.Connection.Close();
    }
  }
}