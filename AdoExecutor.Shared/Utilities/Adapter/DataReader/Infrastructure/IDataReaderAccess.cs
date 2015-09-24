using System.Data;

namespace AdoExecutor.Shared.Utilities.Adapter.DataReader.Infrastructure
{
  public interface IDataReaderAccess
  {
    IDataReader DataReader { get; }
  }
}