using System.Data;

namespace AdoExecutor.Utilities.Adapter.DataTable.Infrastructure
{
  public interface IDataTableAdapter
  {
    System.Data.DataTable Load(IDataReader dataReader);
  }
}