﻿using System;
using System.Data;
using System.Text;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Interception.Infrastructure;

namespace AdoExecutor.Core.Interception
{
  public abstract class LoggerInterceptorBase : IInterceptor
  {
    void IInterceptor.OnEntry(AdoExecutorContext context)
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

      logMessage.AppendLine(Environment.NewLine);
      logMessage.AppendLine("*** EXCEPTION ***");
      logMessage.AppendLine(context.Exception.ToString());
      logMessage.Append("*** END OF EXCEPTION ***");

      LogOnError(context, logMessage.ToString());
    }

    void IInterceptor.OnExit(InterceptorExitContext context)
    {
      StringBuilder logMessage = PrepareLogMessage(context);

      if (context.Exception != null)
      {
        logMessage.AppendLine(Environment.NewLine);
        logMessage.AppendLine("*** EXCEPTION ***");
        logMessage.AppendLine(context.Exception.ToString());
        logMessage.Append("*** END OF EXCEPTION ***");
      }

      LogOnExit(context, logMessage.ToString());
    }

    protected virtual void LogOnEntry(AdoExecutorContext context, string logMessage)
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

    protected virtual StringBuilder PrepareLogMessage(AdoExecutorContext context)
    {
      var result = new StringBuilder();
      result.AppendLine("*** QUERY ***");
      result.AppendLine(context.Query);
      result.Append("*** END OF QUERY ***");
      
      if (context.Command.Parameters.Count > 0)
      {
        result.AppendLine(Environment.NewLine);
        result.AppendLine("*** PARAMETERS ***");

        foreach (IDbDataParameter parameter in context.Command.Parameters)
        {
          result.AppendLine(string.Format("Name: {0}, Value: {1}, DbType: {2}", parameter.ParameterName, parameter.Value, parameter.DbType));
        }

        result.Append("*** END OF PARAMETERS ***");
      }

      return result;
    }
  }
}