using System;
using System.Data;
using AdoExecutor.Core.Query.Internal;
using AdoExecutor.Infrastructure.Configuration;
using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.Interception;
using AdoExecutor.Infrastructure.ObjectBuilder;
using AdoExecutor.Infrastructure.Query;

namespace AdoExecutor.Core.Query
{
  public class AdoExecutorQuery : IAdoExecutorQuery
  {
    private readonly IAdoExecutorConfiguration _configuration;
    private readonly AdoExecutorInterceptoInvoker _interceptoInvoker;
    private readonly AdoExecutorObjectBuilderInvoker _objectBuilderInvoker;
    private readonly AdoExecutorParameterExtractorInvoker _parameterExtractorInvoker;
    private readonly AdoExecutorQueryOptionsConfigurator _optionsConfigurator;

    private IDbConnection _connection;

    public AdoExecutorQuery(IAdoExecutorConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException("configuration");

      _configuration = configuration;
      _interceptoInvoker = new AdoExecutorInterceptoInvoker(_configuration);
      _parameterExtractorInvoker = new AdoExecutorParameterExtractorInvoker(_configuration);
      _objectBuilderInvoker = new AdoExecutorObjectBuilderInvoker(_configuration);
      _optionsConfigurator = new AdoExecutorQueryOptionsConfigurator();
    }

    public IDbConnection Connection
    {
      get { return _connection ?? (_connection = PrepareConnection()); }
    }

    public virtual int Execute(string query, object parameters = null, AdoExecutorQueryOptions options = null)
    {
      Func<IDbCommand, int> executeFunc = command => command.ExecuteNonQuery();

      return InvokeFlow(query, parameters, options, AdoExecutorInvokeMethod.Execute, executeFunc);
    }

    public virtual T Select<T>(string query, object parameters = null, AdoExecutorQueryOptions options = null)
    {
      Func<IDbCommand, T> selectFunc = command =>
      {
        IDataReader dataReader = command.ExecuteReader();

        return
          (T) _objectBuilderInvoker.CreateInstance(new AdoExecutorObjectBuilderContext(query, parameters, typeof (T),
            AdoExecutorInvokeMethod.Select, Connection, command, _configuration, dataReader));
      };

      return InvokeFlow(query, parameters, options, AdoExecutorInvokeMethod.Select, selectFunc);
    }

    protected virtual T InvokeFlow<T>(string query, object parameters, AdoExecutorQueryOptions options, AdoExecutorInvokeMethod invokeMethod,
      Func<IDbCommand, T> executeCommandFunc)
    {
      Type resultType = typeof (T);

      using (IDbCommand command = _configuration.DataObjectFactory.CreateCommand())
      {
        command.CommandText = query;
        command.Connection = Connection;

        _optionsConfigurator.ConfigureCommand(command, options);

        _interceptoInvoker.OnEntry(new AdoExecutorContext(query, parameters, resultType, invokeMethod, Connection,
          command, _configuration));

        _parameterExtractorInvoker.ExtractParameter(new AdoExecutorContext(query, parameters, resultType, invokeMethod,
          Connection, command, _configuration));

        Exception exception = null;
        T result = default(T);

        try
        {
          result = executeCommandFunc(command);

          _interceptoInvoker.OnSuccess(new AdoExecutorInterceptorSuccessContext(query, parameters, resultType,
            invokeMethod, Connection, command, _configuration, result));
        }
        catch (Exception ex)
        {
          exception = ex;

          _interceptoInvoker.OnError(new AdoExecutorInterceptorErrorContext(query, parameters, resultType, invokeMethod,
            Connection, command, _configuration, ex));
          throw;
        }
        finally
        {
          _interceptoInvoker.OnExit(new AdoExecutorInterceptorExitContext(query, parameters, resultType, invokeMethod,
            Connection, command, _configuration, result, exception));
        }

        return result;
      }
    }

    protected virtual IDbConnection PrepareConnection()
    {
      string connectionString = _configuration.ConnectionStringProvider.ConnectionString;
      IDbConnection connection = _configuration.DataObjectFactory.CreateConnection();

      connection.ConnectionString = connectionString;

      return connection;
    }

    #region IDisposable

    private bool _isDisposed;

    public void Dispose()
    {
      InternalDispose();
      GC.SuppressFinalize(this);
    }

    protected void InternalDispose()
    {
      if (!_isDisposed)
      {
        Connection.Dispose();
      }

      _isDisposed = true;
    }

    ~AdoExecutorQuery()
    {
      InternalDispose();
    }

    #endregion
  }
}