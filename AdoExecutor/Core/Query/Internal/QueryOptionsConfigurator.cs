using System;
using System.Data;
using AdoExecutor.Core.Query.Infrastructure;

namespace AdoExecutor.Core.Query.Internal
{
  public class QueryOptionsConfigurator
  {
    public void ConfigureCommand(IDbCommand command, QueryOptions options)
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