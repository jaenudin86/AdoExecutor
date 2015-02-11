using System;
using System.Data;
using AdoExecutor.Configuration;
using AdoExecutor.ObjectBuilder;

namespace AdoExecutor.Query
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

    public int Execute(string query, object parameters = null)
    {
      return 0;
    }

    public T Select<T>(string query, object parameters = null)
    {
      var command = _configuration.DataObjectFactory.CreateCommand();
      command.CommandText = query;
      command.Connection = Connection;
      Connection.Open();
      var result = command.ExecuteReader();

      var context = new AdoExecutorObjectBuilderContext(typeof (T), result);

      foreach (var adoExecutorObjectBuilder in _configuration.ObjectBuilders)
      {
        if (adoExecutorObjectBuilder.CanProcess(typeof (T)))
          return (T)adoExecutorObjectBuilder.CreateInstance(context);
      }

      Connection.Close();
      throw new System.Exception();
    }

    private IDbConnection PrepareConnection()
    {
      string connectionString = _configuration.ConnectionStringProvider.ConnectionString;
      IDbConnection connection = _configuration.DataObjectFactory.CreateConnection();

      connection.ConnectionString = connectionString;

      return connection;
    }
  }
}