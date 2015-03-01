using System.Data;
using System.Data.SqlClient;
using AdoExecutor.Core.DataObjectFactory.Infrastructure;

namespace AdoExecutor.Core.DataObjectFactory
{
  public class SqlDataObjectFactory : IDataObjectFactory
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