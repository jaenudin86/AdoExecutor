using System.Data;
using System.Data.OleDb;
using AdoExecutor.Infrastructure.DataObjectFactory;

namespace AdoExecutor.Core.DataObjectFactory
{
  public class OleDbAdoExecutorDataObjectFactory : IAdoExecutorDataObjectFactory
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