using System;
using System.Data;
using System.Text;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Interception.Infrastructure;

namespace AdoExecutor.Core.Interception
{
  public abstract class LoggerInterceptorBase : IInterceptor
  {
    void IInterceptor.OnEntry(Context.Infrastructure.Context context)
    {
      StringBuilder logMessage = PrepareLogMessage(context);
      LogOnEntry(context, logMessage.ToString());
    }

    void IInterceptor.OnSuccess(InterceptorSuccessContext context)
    {
      StringBuilder logMessage = PrepareLogMessage(context);
      LogOnSuccess(context, logMessage.ToString());
    }

    void IInterceptor.OnError(InterceptorErrorContext context)
    {
      StringBuilder logMessage = PrepareLogMessage(context);
      
      logMessage.AppendLine("*** EXCEPTION ***");
      logMessage.AppendLine(context.Exception.ToString());
      logMessage.AppendLine("*** END OF EXCEPTION ***");

      LogOnError(context, logMessage.ToString());
    }

    void IInterceptor.OnExit(InterceptorExitContext context)
    {
      StringBuilder logMessage = PrepareLogMessage(context);
      LogOnExit(context, logMessage.ToString());
    }

    protected virtual void LogOnEntry(Context.Infrastructure.Context context, string logMessage)
    {
    }

    protected virtual void LogOnSuccess(InterceptorSuccessContext context, string logMessage)
    {
    }

    protected virtual void LogOnError(InterceptorErrorContext context, string logMessage)
    {
    }

    protected virtual void LogOnExit(InterceptorExitContext context, string logMessage)
    {
    }

    protected virtual StringBuilder PrepareLogMessage(Context.Infrastructure.Context context)
    {
      var result = new StringBuilder();
      result.AppendLine("*** QUERY ***");
      result.AppendLine(context.Query);
      result.AppendLine("*** END OF QUERY ***");
      result.AppendLine(Environment.NewLine);

      if (context.Command.Parameters.Count > 0)
      {
        result.AppendLine("*** PARAMETERS ***");

        foreach (IDbDataParameter parameter in context.Command.Parameters)
        {
          result.AppendLine(string.Format("Name: {0}, Value: {1}, DbType: {2}", parameter.ParameterName, parameter.Value,
            parameter.DbType));
        }

        result.AppendLine("*** END OF PARAMETERS ***");
        result.AppendLine(Environment.NewLine);
      }

      return result;
    }
  }
}