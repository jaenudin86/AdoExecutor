using System;
using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Exception.Infrastructure;
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
    private readonly QueryOptionsConfigurator _optionsConfigurator;
    private readonly ParameterExtractorInvoker _parameterExtractorInvoker;
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

    public IDbTransaction Transaction { get; private set; }

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
        var dataReader = command.ExecuteReader();

        return
          (T) _objectBuilderInvoker.CreateInstance(new ObjectBuilderContext(query, parameters, typeof (T),
            InvokeMethod.Select, Connection, command, _configuration, dataReader));
      };

      return InvokeFlow(query, parameters, options, InvokeMethod.Select, selectFunc);
    }

    public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
    {
      TryOpenTransaction();

      Transaction = Connection.BeginTransaction();
    }

    public void CommitTransaction()
    {
      if (Transaction == null)
        throw new AdoExecutorException("Transaction must be begin first.");

      Transaction.Commit();
      CloseTransaction();
    }

    public void RollbackTransaction()
    {
      if (Transaction == null)
        throw new AdoExecutorException("Transaction must be begin first.");

      Transaction.Rollback();
      CloseTransaction();
    }

    protected virtual T InvokeFlow<T>(string query, object parameters, QueryOptions options, InvokeMethod invokeMethod,
      Func<IDbCommand, T> executeCommandFunc)
    {
      var resultType = typeof (T);

      using (var command = _configuration.DataObjectFactory.CreateCommand())
      {
        command.CommandText = query;
        command.Connection = Connection;
        command.Transaction = Transaction;

        _optionsConfigurator.ConfigureCommand(command, options);

        _interceptoInvoker.OnEntry(new AdoExecutorContext(query, parameters, resultType, invokeMethod, Connection,
          command, _configuration));

        _parameterExtractorInvoker.ExtractParameter(new AdoExecutorContext(query, parameters, resultType, invokeMethod,
          Connection, command, _configuration));

        System.Exception exception = null;
        var result = default(T);

        try
        {
          TryOpenTransaction();
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
      var connectionString = _configuration.ConnectionStringProvider.ConnectionString;
      var connection = _configuration.DataObjectFactory.CreateConnection();

      connection.ConnectionString = connectionString;

      return connection;
    }

    private void TryOpenTransaction()
    {
      if (Connection.State == ConnectionState.Closed)
        Connection.Open();
    }

    private void CloseTransaction()
    {
      Transaction.Dispose();
      Transaction = null;
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

        if (Transaction != null)
          CloseTransaction();
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