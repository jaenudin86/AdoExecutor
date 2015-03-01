using System.Data;
using System.Data.Odbc;
using AdoExecutor.Core.DataObjectFactory.Infrastructure;

namespace AdoExecutor.Core.DataObjectFactory
{
  public class OdbcDataObjectFactory : IDataObjectFactory
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