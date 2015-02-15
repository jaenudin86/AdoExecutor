using System.Data;

namespace AdoExecutor.Infrastructure.DataObjectFactory
{
  public interface IAdoExecutorDataObjectFactory
  {
    IDbConnection CreateConnection();
    IDbCommand CreateCommand();
    IDbDataParameter CreateDataParameter();
  }
}