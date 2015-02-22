using System;
using System.Data;

namespace AdoExecutor.Infrastructure.Query
{
  public class AdoExecutorQueryOptions
  {
    public TimeSpan? Timeout { get; set; }
    public CommandType? CommandType { get; set; }

    public static AdoExecutorQueryOptions SetTimeout(TimeSpan timeout)
    {
      return new AdoExecutorQueryOptions
      {
        Timeout = timeout
      };
    }

    public static AdoExecutorQueryOptions SetTimeout(int timeoutSeconds)
    {
      return new AdoExecutorQueryOptions
      {
        Timeout = TimeSpan.FromSeconds(timeoutSeconds)
      };
    }

    public static AdoExecutorQueryOptions SetCommandType(CommandType commandType)
    {
      return new AdoExecutorQueryOptions
      {
        CommandType = commandType
      };
    }
  }
}