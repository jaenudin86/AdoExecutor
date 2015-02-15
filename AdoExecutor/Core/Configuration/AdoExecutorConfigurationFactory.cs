using AdoExecutor.Core.ConnectionString;
using AdoExecutor.Core.DataObjectFactory;
using AdoExecutor.Core.Interception;
using AdoExecutor.Core.ObjectBuilder;
using AdoExecutor.Core.ParameterExtractor;
using AdoExecutor.Infrastructure.Configuration;

namespace AdoExecutor.Core.Configuration
{
  public class AdoExecutorConfigurationFactory
  {
    public IAdoExecutorConfiguration CreateDefaultConfiguration(string connectionStringAppConfigKey)
    {
      var configuration = new AdoExecutorConfiguration();
      configuration.ConnectionStringProvider = new AppConfigConnectionStringProvider(connectionStringAppConfigKey);
      configuration.DataObjectFactory = new SqlAdoExecutorDataObjectFactory();

      configuration.ObjectBuilders.Add(new DataSetAdoExecutorObjectBuilder());
      configuration.ObjectBuilders.Add(new DataTableAdoExecutorObjectBuilder());
      //configuration.ObjectBuilders.Add(new SimpleTypeAdoExecutorObjectBuilder());

      configuration.Interceptors.Add(new ConnectionStateManagerAdoExecutorInterceptor());

      configuration.ParameterExtractors.Add(new SpecifiedParameterAdoExecutorParameterExtractor());
      configuration.ParameterExtractors.Add(new ArrayAdoExecutorParameterExtractor());
      configuration.ParameterExtractors.Add(new ObjectPropertyAdoExecutorParameterExtractor());

      return configuration;
    }
  }
}