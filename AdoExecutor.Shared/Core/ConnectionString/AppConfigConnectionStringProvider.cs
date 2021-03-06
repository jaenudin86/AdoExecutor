﻿using System;
using System.Configuration;
using AdoExecutor.Core.ConnectionString.Infrastructure;

namespace AdoExecutor.Core.ConnectionString
{
  public class AppConfigConnectionStringProvider : IConnectionStringProvider
  {
    private readonly string _connectionStringAppConfigKey;
    private string _connectionString;

    public AppConfigConnectionStringProvider(string connectionStringAppConfigKey)
    {
      if (connectionStringAppConfigKey == null)
        throw new ArgumentNullException(nameof(connectionStringAppConfigKey));

      _connectionStringAppConfigKey = connectionStringAppConfigKey;
    }

    public string ConnectionString
    {
      get
      {
        if (_connectionString == null)
          _connectionString = ConfigurationManager.ConnectionStrings[_connectionStringAppConfigKey].ConnectionString;

        return _connectionString;
      }
    }
  }
}