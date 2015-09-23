using System;
using System.Data;

namespace AdoExecutor.Shared.Utilities.Adapter.DataReader.Infrastructure
{
  public interface IDataReaderAdapter : IDisposable
  {
    void Open();
    bool IsOpen { get; }
    int CurrentColumnIndex { get; set; }
    bool IsClosed { get; }
    void Close();
    DataTable GetSchemaTable();
    bool NextResult();
    bool Read();
    object GetValue(int i);
    Type GetFiledType(int i);
    string GetName(int i);
    object this[string name] { get; }
    object this[int index] { get; }
    int FieldCount { get; }
  }
}