using System;
using System.Collections.Generic;
using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;

namespace AdoExecutor.Core.Context.Infrastructure
{
  public class AdoExecutorContext
  {
    private object _parameters;

    public AdoExecutorContext(
      string query,
      object parameters,
      Type resultType,
      InvokeMethod invokeMethod,
      IDbConnection connection,
      IDbCommand command,
      IConfiguration configuration)
    {
      if (query == null)
        throw new ArgumentNullException("query");

      if (resultType == null)
        throw new ArgumentNullException("resultType");

      if (invokeMethod == InvokeMethod.None)
        throw new ArgumentException("InvokeMethod.None should be not used");

      if (connection == null)
        throw new ArgumentNullException("connection");

      if (command == null)
        throw new ArgumentNullException("command");

      if (configuration == null)
        throw new ArgumentNullException("configuration");

      Query = query;
      Parameters = parameters;
      ResultType = resultType;
      InvokeMethod = invokeMethod;
      Connection = connection;
      Command = command;
      Configuration = configuration;
      Bag = new Dictionary<string, object>();
    }

    public string Query { get; private set; }

    public object Parameters
    {
      get { return _parameters; }
      private set
      {
        _parameters = value;
        ParametersType = value != null ? value.GetType() : null;
      }
    }

    public Type ParametersType { get; private set; }
    public Type ResultType { get; private set; }
    public InvokeMethod InvokeMethod { get; private set; }
    public IDbConnection Connection { get; private set; }
    public IDbCommand Command { get; private set; }
    public IConfiguration Configuration { get; private set; }
    public IDictionary<string, object> Bag { get; private set; }
  }
}