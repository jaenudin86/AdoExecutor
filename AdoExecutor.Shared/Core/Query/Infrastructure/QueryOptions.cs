using System;
using System.Data;

namespace AdoExecutor.Core.Query.Infrastructure
{
  public class QueryOptions
  {
    public TimeSpan? Timeout { get; set; }
    public CommandType? CommandType { get; set; }

    public static QueryOptions SetTimeout(TimeSpan timeout)
    {
      return new QueryOptions
      {
        Timeout = timeout
      };
    }

    public static QueryOptions SetTimeout(int timeoutSeconds)
    {
      return new QueryOptions
      {
        Timeout = TimeSpan.FromSeconds(timeoutSeconds)
      };
    }

    public static QueryOptions SetCommandType(CommandType commandType)
    {
      return new QueryOptions
      {
        CommandType = commandType
      };
    }
  }
}