using System;
using System.Configuration;
using AdoExecutor.Core.ConnectionString.Infrastructure;

namespace AdoExecutor.Shared.Core.ConnectionString
{
  public class AppConfigOrConstantConnectionStringProvider : IConnectionStringProvider
  {
    private readonly string _appConfigOrConstant;
    private string _connectionString;

    public AppConfigOrConstantConnectionStringProvider(string appConfigOrConstant)
    {
      if (appConfigOrConstant == null)
        throw new ArgumentNullException(nameof(appConfigOrConstant));

      _appConfigOrConstant = appConfigOrConstant;
    }

    public string ConnectionString
    {
      get
      {
        return _connectionString ??
               (_connectionString = ConfigurationManager.ConnectionStrings[_appConfigOrConstant] != null
                 ? ConfigurationManager.ConnectionStrings[_appConfigOrConstant].ConnectionString
                 : _appConfigOrConstant);
      }
    }
  }
}