using System;
using AdoExecutor.Core.Interception.Infrastructure;

namespace AdoExecutor.Core.Interception
{
  public class ConsoleLoggerInterceptor : LoggerInterceptorBase
  {
    protected override void LogOnError(InterceptorErrorContext context, string logMessage)
    {
      Console.WriteLine(logMessage);
    }

    protected override void LogOnExit(InterceptorExitContext context, string logMessage)
    {
      Console.WriteLine(logMessage);
    }
  }
}