using System;
using System.Data;
using AdoExecutor.Infrastructure.Configuration;

namespace AdoExecutor.Infrastructure.Context
{
  public class AdoExecutorContext
  {
    private object _parameters;

    public AdoExecutorContext(
      string query,
      object parameters,
      Type resultType,
      AdoExecutorInvokeMethod invokeMethod,
      IDbConnection connection,
      IDbCommand command,
      IAdoExecutorConfiguration configuration)
    {
      if (query == null)
        throw new ArgumentNullException("query");

      if (resultType == null)
        throw new ArgumentNullException("resultType");

      if (invokeMethod == AdoExecutorInvokeMethod.None)
        throw new ArgumentException("AdoExecutorInvokeMethod.None should be not used");

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
    public AdoExecutorInvokeMethod InvokeMethod { get; private set; }
    public IDbConnection Connection { get; private set; }
    public IDbCommand Command { get; private set; }
    public IAdoExecutorConfiguration Configuration { get; private set; }
  }
}