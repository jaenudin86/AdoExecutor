using System.Data;

namespace AdoExecutor.Core.DataObjectFactory.Infrastructure
{
  public interface IDataObjectFactory
  {
    IDbConnection CreateConnection();
    IDbCommand CreateCommand();
    IDbDataParameter CreateDataParameter();
  }
}