using System;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Interception.Infrastructure;

namespace AdoExecutor.Core.Query.Internal
{
  internal class InterceptoInvoker
  {
    private readonly IConfiguration _configuration;

    public InterceptoInvoker(IConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException("configuration");

      _configuration = configuration;
    }

    public void OnEntry(Context.Infrastructure.Context context)
    {
      foreach (IInterceptor interceptor in _configuration.Interceptors)
      {
        try
        {
          interceptor.OnEntry(context);
        }
        catch
        {
          //Interceptors shoud do not affect to query execution flow
        }
      }
    }

    public void OnSuccess(InterceptorSuccessContext context)
    {
      foreach (IInterceptor interceptor in _configuration.Interceptors)
      {
        try
        {
          interceptor.OnSuccess(context);
        }
        catch
        {
          //Interceptors shoud do not affect to query execution flow
        }
      }
    }

    public void OnError(InterceptorErrorContext context)
    {
      foreach (IInterceptor interceptor in _configuration.Interceptors)
      {
        try
        {
          interceptor.OnError(context);
        }
        catch
        {
          //Interceptors shoud do not affect to query execution flow
        }
      }
    }

    public void OnExit(InterceptorExitContext context)
    {
      foreach (IInterceptor interceptor in _configuration.Interceptors)
      {
        try
        {
          interceptor.OnExit(context);
        }
        catch
        {
          //Interceptors shoud do not affect to query execution flow
        }
      }
    }
  }
}