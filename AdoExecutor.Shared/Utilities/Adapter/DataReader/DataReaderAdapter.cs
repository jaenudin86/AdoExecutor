using System;
using System.Data;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Shared.Utilities.Adapter.DataReader.Infrastructure;

namespace AdoExecutor.Shared.Utilities.Adapter.DataReader
{
  public class DataReaderAdapter : IDataReaderAdapter, IDataReaderAccess
  {
    private IDataReader _dataReader;

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

    public bool NextResult()
    {
      CheckIsOpen();

      IsReading = false;
      CurrentColumnIndex = 0;

      return _dataReader.NextResult();
    }

    public bool Read()
    {
      CheckIsOpen();

      IsReading = true;
      return _dataReader.Read();
    }

    public object GetValue(int i)
    {
      CheckIsOpen();
      return _dataReader.GetValue(i);
    }

    public string GetName(int i)
    {
      CheckIsOpen();
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

    public bool IsReading { get; private set; }

    IDataReader IDataReaderAccess.DataReader
    {
      get
      {
        return _dataReader;
      }
    }

    public void Dispose()
    {
      _dataReader.Close();
      _dataReader.Dispose();
      _dataReader = null;
    }

    private void CheckIsOpen()
    {
      if (!IsOpen)
        throw new AdoExecutorException("Before use DataReaderAdapter, first should be invoked Open method");
    }
  }
}