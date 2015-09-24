using System;

namespace AdoExecutor.Shared.Utilities.Adapter.DataReader.Infrastructure
{
  public interface IDataReaderAdapter : IDisposable
  {
    void Open();
    bool IsOpen { get; }
    int CurrentColumnIndex { get; set; }
    bool IsClosed { get; }
    void Close();
    bool NextResult();
    bool Read();
    object GetValue(int i);
    string GetName(int i);
    object this[string name] { get; }
    object this[int index] { get; }
    int FieldCount { get; }
    bool IsReading { get; }
  }
}