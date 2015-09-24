using System;
using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.Interception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Core.Query.Infrastructure;
using AdoExecutor.Core.Query.Internal;
using AdoExecutor.Shared.Utilities.Adapter.DataReader;

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
    private IDbTransaction _transaction;

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

    protected delegate T ExecuteCommandDelegate<out T>(IDbCommand command); 

    public virtual int Execute(string query, object parameters = null, QueryOptions options = null)
    {
      ExecuteCommandDelegate<int> executeFunc = command => command.ExecuteNonQuery();

      return InvokeFlow(query, parameters, options, InvokeMethod.Execute, executeFunc);
    }

    public virtual int Execute(Command command)
    {
      return Execute(command.Query, command.Parameters, command.Options);
    }

    public virtual T Select<T>(string query, object parameters = null, QueryOptions options = null)
    {
      ExecuteCommandDelegate<T> selectFunc = command =>
      {
        var dataReader = command.ExecuteReader();
        using (var dataReaderAdapter = new DataReaderAdapter(dataReader))
        {
          return (T)_objectBuilderInvoker.CreateInstance(new ObjectBuilderContext(typeof(T), dataReaderAdapter));
        }
      };

      return InvokeFlow(query, parameters, options, InvokeMethod.Select, selectFunc);
    }

    public virtual T Select<T>(Command command)
    {
      return Select<T>(command.Query, command.Parameters, command.Options);
    }

    public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
    {
      TryOpenConnection();

      if(_transaction != null)
        throw new AdoExecutorException("Commit or rollback earlier transaction.");

      _transaction = Connection.BeginTransaction();
    }

    public void CommitTransaction()
    {
      if (_transaction == null)
        throw new AdoExecutorException("Transaction must be begin first.");

      _transaction.Commit();
      DisposeTransaction();
    }

    public void RollbackTransaction()
    {
      if (_transaction == null)
        throw new AdoExecutorException("Transaction must be begin first.");

      _transaction.Rollback();
      DisposeTransaction();
    }

    protected virtual T InvokeFlow<T>(string query, object parameters, QueryOptions options, InvokeMethod invokeMethod,
      ExecuteCommandDelegate<T> executeCommandFunc)
    {
      var resultType = typeof (T);

      using (var command = _configuration.DataObjectFactory.CreateCommand())
      {
        command.CommandText = query;
        command.Connection = Connection;
        command.Transaction = _transaction;

        _optionsConfigurator.ConfigureCommand(command, options);

        _interceptoInvoker.OnEntry(new AdoExecutorContext(query, parameters, resultType, invokeMethod, Connection,
          command, _configuration));

        _parameterExtractorInvoker.ExtractParameter(new AdoExecutorContext(query, parameters, resultType, invokeMethod,
          Connection, command, _configuration));

        System.Exception exception = null;
        var result = default(T);

        try
        {
          TryOpenConnection();
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

    private void TryOpenConnection()
    {
      if (Connection.State == ConnectionState.Closed)
        Connection.Open();
    }

    #region IDisposable

    private bool _isDisposed;

    public void Dispose()
    {
      if (!_isDisposed)
      {
        DisposeConnection();
        DisposeTransaction();
      }

      _isDisposed = true;

      GC.SuppressFinalize(this);
    }

    private void DisposeConnection()
    {
      if (_connection != null)
      {
        _connection.Dispose();
        _connection = null;
      }
    }

    private void DisposeTransaction()
    {
      if (_transaction != null)
      {
        _transaction.Dispose();
        _transaction = null;
      }
    }

    #endregion
  }
}