using System;
using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.Interception;

namespace AdoExecutor.Core.Interception
{
  public class ConsoleLoggerAdoExecutorInterceptor : LoggerAdoExecutorInterceptorBase
  {
    protected override void LogOnError(AdoExecutorInterceptorErrorContext context, string logMessage)
    {
      Console.WriteLine(logMessage);
    }

    protected override void LogOnExit(AdoExecutorInterceptorExitContext context, string logMessage)
    {
      Console.WriteLine(logMessage);
    }
  }
}