using System;
using System.Runtime.Remoting.Messaging;
using AdoExecutor.Core.Configuration;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.ConnectionString;
using AdoExecutor.Core.DataObjectFactory;
using AdoExecutor.Core.Interception;
using AdoExecutor.Core.ObjectBuilder;
using AdoExecutor.Core.ParameterExtractor;
using AdoExecutor.Core.Query;
using AdoExecutor.Core.Query.Infrastructure;
using AdoExecutor.Core.QueryFactory.Infrastructure;
using AdoExecutor.Utilities.Adapter.DataTable;
using AdoExecutor.Utilities.Adapter.List;
using AdoExecutor.Utilities.ObjectConverter;
using AdoExecutor.Utilities.PrimitiveTypes;

namespace AdoExecutor.Core.QueryFactory
{
  public class SqlQueryFactory : IQueryFactory
  {
    private readonly string _connectionStringAppConfigKey;

    public SqlQueryFactory(string connectionStringAppConfigKey)
    {
      if (connectionStringAppConfigKey == null)
        throw new ArgumentNullException("connectionStringAppConfigKey");

      _connectionStringAppConfigKey = connectionStringAppConfigKey;
    }

    public IQuery CreateQuery()
    {
      IConfiguration configuration = CreateConfiguration();
      return new Query.Query(configuration);
    }

    private IConfiguration CreateConfiguration()
    {
      var configuration = new Configuration.Configuration();
      configuration.ConnectionStringProvider = new AppConfigConnectionStringProvider(_connectionStringAppConfigKey);
      configuration.DataObjectFactory = new SqlDataObjectFactory();

      configuration.ObjectBuilders.Add(new DataSetObjectBuilder(new DataTableAdapter()));
      configuration.ObjectBuilders.Add(new DataTableObjectBuilder(new DataTableAdapter()));
      configuration.ObjectBuilders.Add(new SimpleTypeObjectBuilder(new SqlPrimitiveDataTypes(), new ListAdapterFactory(), new ObjectConverter()));
      configuration.ObjectBuilders.Add(new DefinedTypeObjectBuilder(new ListAdapterFactory(), new SqlPrimitiveDataTypes(), new ObjectConverter()));
      configuration.ObjectBuilders.Add(new DynamicObjectBuilder(new ListAdapterFactory()));

      configuration.Interceptors.Add(new ConnectionStateManagerInterceptor());

      configuration.ParameterExtractors.Add(new SpecifiedParameterParameterExtractor());
      configuration.ParameterExtractors.Add(new DataTableParameterExtractor());
      configuration.ParameterExtractors.Add(new DictionaryParameterExtractor());
      configuration.ParameterExtractors.Add(new EnumerableParameterExtractor(new SqlPrimitiveDataTypes()));
      configuration.ParameterExtractors.Add(new ObjectPropertyParameterExtractor(new SqlPrimitiveDataTypes()));

      return configuration;
    }
  }
}