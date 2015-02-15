using System;
using System.Data;
using System.Text;
using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.Interception;

namespace AdoExecutor.Core.Interception
{
  public abstract class LoggerAdoExecutorInterceptorBase : IAdoExecutorInterceptor
  {
    void IAdoExecutorInterceptor.OnEntry(AdoExecutorContext context)
    {
      StringBuilder logMessage = PrepareLogMessage(context);
      LogOnEntry(context, logMessage.ToString());
    }

    void IAdoExecutorInterceptor.OnSuccess(AdoExecutorInterceptorSuccessContext context)
    {
      StringBuilder logMessage = PrepareLogMessage(context);
      LogOnSuccess(context, logMessage.ToString());
    }

    void IAdoExecutorInterceptor.OnError(AdoExecutorInterceptorErrorContext context)
    {
      StringBuilder logMessage = PrepareLogMessage(context);
      
      logMessage.AppendLine("*** EXCEPTION ***");
      logMessage.AppendLine(context.Exception.ToString());
      logMessage.AppendLine("*** END OF EXCEPTION ***");

      LogOnError(context, logMessage.ToString());
    }

    void IAdoExecutorInterceptor.OnExit(AdoExecutorInterceptorExitContext context)
    {
      StringBuilder logMessage = PrepareLogMessage(context);
      LogOnExit(context, logMessage.ToString());
    }

    protected virtual void LogOnEntry(AdoExecutorContext context, string logMessage)
    {
    }

    protected virtual void LogOnSuccess(AdoExecutorInterceptorSuccessContext context, string logMessage)
    {
    }

    protected virtual void LogOnError(AdoExecutorInterceptorErrorContext context, string logMessage)
    {
    }

    protected virtual void LogOnExit(AdoExecutorInterceptorExitContext context, string logMessage)
    {
    }

    protected virtual StringBuilder PrepareLogMessage(AdoExecutorContext context)
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