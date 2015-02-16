using System;
using AdoExecutor.Core.Configuration;
using AdoExecutor.Core.ConnectionString;
using AdoExecutor.Core.DataObjectFactory;
using AdoExecutor.Core.Interception;
using AdoExecutor.Core.ObjectBuilder;
using AdoExecutor.Core.ParameterExtractor;
using AdoExecutor.Core.Query;
using AdoExecutor.Infrastructure.Configuration;
using AdoExecutor.Infrastructure.Query;
using AdoExecutor.Infrastructure.QueryFactory;

namespace AdoExecutor.Core.QueryFactory
{
  public class SqlAdoExecutorQueryFactory : IAdoExecutorQueryFactory
  {
    private readonly string _connectionStringAppConfigKey;

    public SqlAdoExecutorQueryFactory(string connectionStringAppConfigKey)
    {
      if (connectionStringAppConfigKey == null)
        throw new ArgumentNullException("connectionStringAppConfigKey");

      _connectionStringAppConfigKey = connectionStringAppConfigKey;
    }

    public IAdoExecutorQuery CreateQuery()
    {
      IAdoExecutorConfiguration configuration = CreateConfiguration();
      return new AdoExecutorQuery(configuration);
    }

    private IAdoExecutorConfiguration CreateConfiguration()
    {
      var configuration = new AdoExecutorConfiguration();
      configuration.ConnectionStringProvider = new AppConfigConnectionStringProvider(_connectionStringAppConfigKey);
      configuration.DataObjectFactory = new SqlAdoExecutorDataObjectFactory();

      configuration.ObjectBuilders.Add(new DataSetAdoExecutorObjectBuilder());
      configuration.ObjectBuilders.Add(new DataTableAdoExecutorObjectBuilder());
      configuration.ObjectBuilders.Add(new SimpleTypeAdoExecutorObjectBuilder());
      configuration.ObjectBuilders.Add(new DefinedTypeAdoExecutorObjectBuilder());
      configuration.ObjectBuilders.Add(new DynamicAdoExecutorObjectBuilder());

      configuration.Interceptors.Add(new ConnectionStateManagerAdoExecutorInterceptor());

      configuration.ParameterExtractors.Add(new SpecifiedParameterAdoExecutorParameterExtractor());
      configuration.ParameterExtractors.Add(new DataTableAdoExecutorParameterExtractor());
      configuration.ParameterExtractors.Add(new DictionaryAdoExecutorParameterExtractor());
      configuration.ParameterExtractors.Add(new ArrayAdoExecutorParameterExtractor());
      configuration.ParameterExtractors.Add(new ObjectPropertyAdoExecutorParameterExtractor());

      return configuration;
    }
  }
}