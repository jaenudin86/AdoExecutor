using System;
using System.Data;

namespace AdoExecutor.Core.Parameter
{
  public class AdoExecutorSpecifiedParameter
  {
    private IDbDataParameter _dataParameter;

    public AdoExecutorSpecifiedParameter(
      string parameterName, 
      object value = null, 
      DbType? dbType = null, 
      ParameterDirection direction = ParameterDirection.Input, 
      byte? precision = null, 
      byte? scale = null, 
      int? size = null)
    {
      if (string.IsNullOrEmpty(parameterName))
        throw new ArgumentNullException("parameterName");
      
      ParameterName = parameterName;
      Value = value;
      DbType = dbType;
      Direction = direction;
      Precision = precision;
      Scale = scale;
      Size = size;
    }

    public string ParameterName { get; private set; }
    public object Value { get; private set; }
    public DbType? DbType { get; private set; }
    public ParameterDirection? Direction { get; private set; }
    public byte? Precision { get; private set; }
    public byte? Scale { get; private set; }
    public int? Size { get; private set; }


    internal void SetParameter(IDbDataParameter dataParameter)
    {
      if (dataParameter == null)
        throw new ArgumentNullException("dataParameter");

      _dataParameter = dataParameter;
    }

    public object GetOutputValue()
    {
      return _dataParameter.Value;
    }
  }
}