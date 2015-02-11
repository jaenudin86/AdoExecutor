using System;

namespace AdoExecutor.ConnectionString
{
  public class ConstantConnectionStringProvider : IConnectionStringProvider
  {
    public ConstantConnectionStringProvider(string connectionString)
    {
      if (connectionString == null)
        throw new ArgumentNullException("connectionString");

      ConnectionString = connectionString;
    }

    public string ConnectionString { get; private set; }
  }
}