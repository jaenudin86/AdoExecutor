using System.Data;
using System.Data.OleDb;
using AdoExecutor.Core.DataObjectFactory.Infrastructure;

namespace AdoExecutor.Core.DataObjectFactory
{
  public class OleDbDataObjectFactory : IDataObjectFactory
  {
    public IDbConnection CreateConnection()
    {
      return new OleDbConnection();
    }

    public IDbCommand CreateCommand()
    {
      return new OleDbCommand();
    }

    public IDbDataParameter CreateDataParameter()
    {
      return new OleDbParameter();
    }
  }
}