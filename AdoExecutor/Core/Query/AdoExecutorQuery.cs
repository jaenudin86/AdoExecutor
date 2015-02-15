using System;
using System.Data;
using AdoExecutor.Core.Interception;
using AdoExecutor.Core.ObjectBuilder;
using AdoExecutor.Infrastructure.Configuration;
using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.Interception;
using AdoExecutor.Infrastructure.ObjectBuilder;
using AdoExecutor.Infrastructure.ParameterExtractor;
using AdoExecutor.Infrastructure.Query;

namespace AdoExecutor.Core.Query
{
  public class AdoExecutorQuery : IAdoExecutorQuery
  {
    private readonly IAdoExecutorConfiguration _configuration;

    public AdoExecutorQuery(IAdoExecutorConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException("configuration");

      _configuration = configuration;
      Connection = PrepareConnection();
    }

    public IDbConnection Connection { get; private set; }

    public virtual int Execute(string query, object parameters = null)
    {
      return 0;
    }

    public virtual T Select<T>(string query, object parameters = null)
    {
      IDbCommand command = _configuration.DataObjectFactory.CreateCommand();
      command.CommandText = query;
      command.Connection = Connection;

      //interception - onEntry
      foreach (IAdoExecutorInterceptor interceptor in _configuration.Interceptors)
      {
        var interceptorContext = new AdoExecutorContext(query, parameters, typeof (T),
          AdoExecutorInvokeMethod.Select, Connection, command, _configuration);

        interceptor.OnEntry(interceptorContext);
      }

      foreach (IAdoExecutorParameterExtractor adoExecutorParameterExtractor in _configuration.ParameterExtractors)
      {
        var parameterExtractorContext = new AdoExecutorContext(query, parameters, typeof (T),
          AdoExecutorInvokeMethod.Select, Connection, command, _configuration);

        if (adoExecutorParameterExtractor.CanProcess(parameterExtractorContext))
        {
          adoExecutorParameterExtractor.ExtractParameter(parameterExtractorContext);
          break;
        }
      }

      Exception exception = null;
      T result = default (T);

      try
      {
        IDataReader dataReader = command.ExecuteReader();

        foreach (IAdoExecutorObjectBuilder objectBuilder in _configuration.ObjectBuilders)
        {
          var objectBuilderContext = new AdoExecutorObjectBuilderContext(query, parameters, typeof (T),
            AdoExecutorInvokeMethod.Select, Connection, command, _configuration, dataReader);

          if (objectBuilder.CanProcess(objectBuilderContext))
          {
            result = (T) objectBuilder.CreateInstance(objectBuilderContext);
            break;
          }
        }

        foreach (IAdoExecutorInterceptor interceptor in _configuration.Interceptors)
        {
          var interceptorContext = new AdoExecutorInterceptorSuccessContext(query, parameters, typeof (T),
            AdoExecutorInvokeMethod.Select, Connection, command, _configuration, result);

          interceptor.OnSuccess(interceptorContext);
        }
      }
      catch (Exception ex)
      {
        exception = ex;

        foreach (IAdoExecutorInterceptor interceptor in _configuration.Interceptors)
        {
          var interceptorContext = new AdoExecutorInterceptorErrorContext(query, parameters, typeof (T),
            AdoExecutorInvokeMethod.Select, Connection, command, _configuration, ex);

          interceptor.OnError(interceptorContext);
        }

        throw;
      }
      finally
      {
        foreach (IAdoExecutorInterceptor interceptor in _configuration.Interceptors)
        {
          var interceptorContext = new AdoExecutorInterceptorExitContext(query, parameters, typeof (T),
            AdoExecutorInvokeMethod.Select, Connection, command, _configuration, result, exception);

          interceptor.OnExit(interceptorContext);
        }
      }

      return result;
    }

    protected virtual IDbConnection PrepareConnection()
    {
      string connectionString = _configuration.ConnectionStringProvider.ConnectionString;
      IDbConnection connection = _configuration.DataObjectFactory.CreateConnection();

      connection.ConnectionString = connectionString;

      return connection;
    }
  }
}