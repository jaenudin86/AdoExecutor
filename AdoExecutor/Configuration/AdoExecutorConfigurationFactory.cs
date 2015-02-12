using AdoExecutor.ConnectionString;
using AdoExecutor.DataObjectFactory;
using AdoExecutor.Interception;
using AdoExecutor.ObjectBuilder;
using AdoExecutor.ParameterExtractor;

namespace AdoExecutor.Configuration
{
  public class AdoExecutorConfigurationFactory
  {
    public IAdoExecutorConfiguration CreateDefaultConfiguration(string connectionStringAppConfigKey)
    {
      var configuration = new AdoExecutorConfiguration();
      configuration.ConnectionStringProvider = new AppConfigConnectionStringProvider(connectionStringAppConfigKey);
      configuration.DataObjectFactory = new SqlAdoExecutorDataObjectFactory();

      configuration.ObjectBuilders.Add(new DataTableAdoExecutorObjectBuilder());
      configuration.ObjectBuilders.Add(new SimpleTypeAdoExecutorObjectBuilder());

      configuration.Interceptors.Add(new ConnectionStateManagerAdoExecutorInterceptor());

      configuration.ParameterExtractors.Add(new SpecifiedParameterAdoExecutorParameterExtractor());
      configuration.ParameterExtractors.Add(new ArrayAdoExecutorParameterExtractor());
      configuration.ParameterExtractors.Add(new ObjectPropertyAdoExecutorParameterExtractor());

      return configuration;
    }
  }
}