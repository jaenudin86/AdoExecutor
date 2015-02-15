using System.Data;
using System.Data.Odbc;
using AdoExecutor.Infrastructure.DataObjectFactory;

namespace AdoExecutor.Core.DataObjectFactory
{
  public class OdbcAdoExecutorDataObjectFactory : IAdoExecutorDataObjectFactory
  {
    public IDbConnection CreateConnection()
    {
      return new OdbcConnection();
    }

    public IDbCommand CreateCommand()
    {
      return new OdbcCommand();
    }

    public IDbDataParameter CreateDataParameter()
    {
      return new OdbcParameter();
    }
  }
}