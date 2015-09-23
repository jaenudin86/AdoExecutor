using System;
using System.Data;
using AdoExecutor.Shared.Utilities.Adapter.DataReader.Infrastructure;

namespace AdoExecutor.Shared.Utilities.Adapter.DataReader
{
  public class DataReaderAdapter : IDataReaderAdapter, IDataReaderAccess
  {
    private readonly IDataReader _dataReader;

    public DataReaderAdapter(IDataReader dataReader)
    {
      if (dataReader == null)
        throw new ArgumentNullException(nameof(dataReader));

      _dataReader = dataReader;
    }

    public void Open()
    {
      if(IsOpen)
        throw new Exception("Reader is already opened."); //TODO

      IsOpen = true;
    }

    public bool IsOpen { get; private set; }
    public int CurrentColumnIndex { get; set; }

    public bool IsClosed
    {
      get { return _dataReader.IsClosed; }
    }

    public void Close()
    {
      _dataReader.Close();
    }

    public DataTable GetSchemaTable()
    {
      return _dataReader.GetSchemaTable();
    }

    public bool NextResult()
    {
      return _dataReader.NextResult();
    }

    public bool Read()
    {
      return _dataReader.Read();
    }

    public object GetValue(int i)
    {
      return _dataReader.GetValue(i);
    }

    public Type GetFiledType(int i)
    {
      return _dataReader.GetFieldType(i);
    }

    public string GetName(int i)
    {
      return _dataReader.GetName(i);
    }

    public object this[string name]
    {
      get { return _dataReader[name]; }
    }

    object IDataReaderAdapter.this[int index]
    {
      get { return _dataReader[index]; }
    }

    public int FieldCount
    {
      get { return _dataReader.FieldCount; }
    }

    IDataReader IDataReaderAccess.DataReader
    {
      get
      {
        return _dataReader;
      }
    }

    public void Dispose()
    {
      _dataReader.Dispose();
    }
  }
}