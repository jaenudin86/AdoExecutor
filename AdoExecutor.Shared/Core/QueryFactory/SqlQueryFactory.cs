using System;
using AdoExecutor.Core.DataObjectFactory;
using AdoExecutor.Shared.Core.ConnectionString;

namespace AdoExecutor.Core.QueryFactory
{
  public class SqlQueryFactory : QueryFactoryBase
  {
    private readonly string _connectionStringOrAppConfigKey;

    public SqlQueryFactory(string connectionStringOrAppConfigKey)
    {
      if (connectionStringOrAppConfigKey == null)
        throw new ArgumentNullException(nameof(connectionStringOrAppConfigKey));

      _connectionStringOrAppConfigKey = connectionStringOrAppConfigKey;
    }

    protected override void ConfigureConnectionStringProvider(Configuration.Configuration configuration)
    {
      configuration.ConnectionStringProvider =
        new AppConfigOrConstantConnectionStringProvider(_connectionStringOrAppConfigKey);
    }

    protected override void ConfigureDataObjectFactory(Configuration.Configuration configuration)
    {
      configuration.DataObjectFactory = new SqlDataObjectFactory();
    }
  }
}