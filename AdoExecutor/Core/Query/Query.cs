using System;
using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Interception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Core.Query.Infrastructure;
using AdoExecutor.Core.Query.Internal;

namespace AdoExecutor.Core.Query
{
  public class Query : IQuery
  {
    private readonly IConfiguration _configuration;
    private readonly InterceptoInvoker _interceptoInvoker;
    private readonly ObjectBuilderInvoker _objectBuilderInvoker;
    private readonly ParameterExtractorInvoker _parameterExtractorInvoker;
    private readonly QueryOptionsConfigurator _optionsConfigurator;

    private IDbConnection _connection;

    public Query(IConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException("configuration");

      _configuration = configuration;
      _interceptoInvoker = new InterceptoInvoker(_configuration);
      _parameterExtractorInvoker = new ParameterExtractorInvoker(_configuration);
      _objectBuilderInvoker = new ObjectBuilderInvoker(_configuration);
      _optionsConfigurator = new QueryOptionsConfigurator();
    }

    public IDbConnection Connection
    {
      get { return _connection ?? (_connection = PrepareConnection()); }
    }

    public virtual int Execute(string query, object parameters = null, QueryOptions options = null)
    {
      Func<IDbCommand, int> executeFunc = command => command.ExecuteNonQuery();

      return InvokeFlow(query, parameters, options, InvokeMethod.Execute, executeFunc);
    }

    public virtual T Select<T>(string query, object parameters = null, QueryOptions options = null)
    {
      Func<IDbCommand, T> selectFunc = command =>
      {
        IDataReader dataReader = command.ExecuteReader();

        return
          (T) _objectBuilderInvoker.CreateInstance(new ObjectBuilderContext(query, parameters, typeof (T),
            InvokeMethod.Select, Connection, command, _configuration, dataReader));
      };

      return InvokeFlow(query, parameters, options, InvokeMethod.Select, selectFunc);
    }

    protected virtual T InvokeFlow<T>(string query, object parameters, QueryOptions options, InvokeMethod invokeMethod,
      Func<IDbCommand, T> executeCommandFunc)
    {
      Type resultType = typeof (T);

      using (IDbCommand command = _configuration.DataObjectFactory.CreateCommand())
      {
        command.CommandText = query;
        command.Connection = Connection;

        _optionsConfigurator.ConfigureCommand(command, options);

        _interceptoInvoker.OnEntry(new Context.Infrastructure.Context(query, parameters, resultType, invokeMethod, Connection,
          command, _configuration));

        _parameterExtractorInvoker.ExtractParameter(new Context.Infrastructure.Context(query, parameters, resultType, invokeMethod,
          Connection, command, _configuration));

        System.Exception exception = null;
        T result = default(T);

        try
        {
          result = executeCommandFunc(command);

          _interceptoInvoker.OnSuccess(new InterceptorSuccessContext(query, parameters, resultType,
            invokeMethod, Connection, command, _configuration, result));
        }
        catch (System.Exception ex)
        {
          exception = ex;

          _interceptoInvoker.OnError(new InterceptorErrorContext(query, parameters, resultType, invokeMethod,
            Connection, command, _configuration, ex));
          throw;
        }
        finally
        {
          _interceptoInvoker.OnExit(new InterceptorExitContext(query, parameters, resultType, invokeMethod,
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

    ~Query()
    {
      InternalDispose();
    }

    #endregion
  }
}