using System;
using AdoExecutor.Core.ConnectionString;
using AdoExecutor.Core.DataObjectFactory;

namespace AdoExecutor.Core.QueryFactory
{
  public class SqlQueryFactory : QueryFactoryBase
  {
    private readonly string _connectionStringAppConfigKey;

    public SqlQueryFactory(string connectionStringAppConfigKey)
    {
      if (connectionStringAppConfigKey == null)
        throw new ArgumentNullException("connectionStringAppConfigKey");

      _connectionStringAppConfigKey = connectionStringAppConfigKey;
    }

    protected override void ConfigureConnectionStringProvider(Configuration.Configuration configuration)
    {
      configuration.ConnectionStringProvider = new AppConfigConnectionStringProvider(_connectionStringAppConfigKey);
    }

    protected override void ConfigureDataObjectFactory(Configuration.Configuration configuration)
    {
      configuration.DataObjectFactory = new SqlDataObjectFactory();
    }
  }
}