using System.Data;
using System.Data.SqlClient;

namespace AdoExecutor.DataObjectFactory
{
  public class SqlAdoExecutorDataObjectFactory : IAdoExecutorDataObjectFactory
  {
    public IDbConnection CreateConnection()
    {
      return new SqlConnection();
    }

    public IDbCommand CreateCommand()
    {
      return new SqlCommand();
    }

    public IDbDataParameter CreateDataParameter()
    {
      return new SqlParameter();
    }
  }
}