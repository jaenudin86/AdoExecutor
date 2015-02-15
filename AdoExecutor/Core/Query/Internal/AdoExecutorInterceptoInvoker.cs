using System;
using AdoExecutor.Infrastructure.Configuration;
using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.Interception;

namespace AdoExecutor.Core.Query.Internal
{
  internal class AdoExecutorInterceptoInvoker
  {
    private readonly IAdoExecutorConfiguration _configuration;

    public AdoExecutorInterceptoInvoker(IAdoExecutorConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException("configuration");

      _configuration = configuration;
    }

    public void OnEntry(AdoExecutorContext context)
    {
      foreach (IAdoExecutorInterceptor interceptor in _configuration.Interceptors)
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

    public void OnSuccess(AdoExecutorInterceptorSuccessContext context)
    {
      foreach (IAdoExecutorInterceptor interceptor in _configuration.Interceptors)
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

    public void OnError(AdoExecutorInterceptorErrorContext context)
    {
      foreach (IAdoExecutorInterceptor interceptor in _configuration.Interceptors)
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

    public void OnExit(AdoExecutorInterceptorExitContext context)
    {
      foreach (IAdoExecutorInterceptor interceptor in _configuration.Interceptors)
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