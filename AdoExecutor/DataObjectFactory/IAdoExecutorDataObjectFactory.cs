using System.Data;

namespace AdoExecutor.DataObjectFactory
{
  public interface IAdoExecutorDataObjectFactory
  {
    IDbConnection CreateConnection();
    IDbCommand CreateCommand();
    IDbDataParameter CreateDataParameter();
  }
}