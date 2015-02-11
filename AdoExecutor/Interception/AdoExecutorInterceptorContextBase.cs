using System;
using System.Data;
using AdoExecutor.Configuration;

namespace AdoExecutor.Interception
{
  public abstract class AdoExecutorInterceptorContextBase : IAdoExecutorInterceptorContext
  {
    protected AdoExecutorInterceptorContextBase(
      string query,
      object parameters,
      IDbConnection connection,
      IDbCommand command,
      IAdoExecutorConfiguration configuration)
    {
      if (query == null) 
        throw new ArgumentNullException("query");

      if (parameters == null) 
        throw new ArgumentNullException("parameters");

      if (connection == null) 
        throw new ArgumentNullException("connection");

      if (command == null) 
        throw new ArgumentNullException("command");

      if (configuration == null) 
        throw new ArgumentNullException("configuration");

      Configuration = configuration;
      Command = command;
      Connection = connection;
      Parameters = parameters;
      Query = query;
    }

    public string Query { get; private set; }
    public object Parameters { get; private set; }
    public IDbConnection Connection { get; private set; }
    public IDbCommand Command { get; private set; }
    public IAdoExecutorConfiguration Configuration { get; private set; }
  }
}