﻿using AdoExecutor.Context;

namespace AdoExecutor.Interception
{
  public class ConnectionStateManagerAdoExecutorInterceptor : IAdoExecutorInterceptor
  {
    public void OnEntry(IAdoExecutorContext context)
    {
      context.Connection.Open();
    }

    public void OnSuccess(IAdoExecutorInterceptorSuccessContext context)
    {
    }

    public void OnError(IAdoExecutorInterceptorSuccessContext context)
    {
    }

    public void OnExit(IAdoExecutorInterceptorExitContext context)
    {
      context.Connection.Close();
    }
  }
}