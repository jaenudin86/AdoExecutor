using System;
using System.Data;
using AdoExecutor.Infrastructure.Query;

namespace AdoExecutor.Core.Query.Internal
{
  public class AdoExecutorQueryOptionsConfigurator
  {
    public void ConfigureCommand(IDbCommand command, AdoExecutorQueryOptions options)
    {
      if (command == null)
        throw new ArgumentNullException("command");

      if (options == null)
        return;

      if (options.Timeout != null)
        command.CommandTimeout = (int) options.Timeout.Value.TotalSeconds;

      if (options.CommandType != null)
        command.CommandType = options.CommandType.Value;
    }
  }
}