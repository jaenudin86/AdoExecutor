using System;
using System.Configuration;
using AdoExecutor.Infrastructure.ConnectionString;

namespace AdoExecutor.Core.ConnectionString
{
  public class AppConfigConnectionStringProvider : IConnectionStringProvider
  {
    public AppConfigConnectionStringProvider(string connectionStringAppConfigKey)
    {
      if (connectionStringAppConfigKey == null)
        throw new ArgumentNullException("connectionStringAppConfigKey");

      ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringAppConfigKey];

      ConnectionString = connectionStringSettings.ConnectionString;
    }

    public string ConnectionString { get; private set; }
  }
}