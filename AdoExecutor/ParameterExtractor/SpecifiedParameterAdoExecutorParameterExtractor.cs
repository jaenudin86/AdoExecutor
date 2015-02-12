using System;
using System.Data;
using AdoExecutor.Context;
using AdoExecutor.Exception;
using AdoExecutor.Parameter;

namespace AdoExecutor.ParameterExtractor
{
  public class SpecifiedParameterAdoExecutorParameterExtractor : IAdoExecutorParameterExtractor
  {
    public bool CanProcess(IAdoExecutorContext context)
    {
      if (context.Parameters == null)
        return false;

      Type parametersType = context.Parameters.GetType();

      return parametersType == typeof (AdoExecutorSpecifiedParameter);
    }

    public void ExtractParameter(IAdoExecutorContext context)
    {
      var outputParameter = (AdoExecutorSpecifiedParameter) context.Parameters;

      if (outputParameter.Value == null && outputParameter.DbType == null &&
          (outputParameter.Direction == ParameterDirection.Input || outputParameter.Direction == ParameterDirection.InputOutput))
      {
        throw new AdoExecutorException("Cannot set parameter type.");
      }

      IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
      dataParameter.ParameterName = outputParameter.ParameterName;
      dataParameter.Value = outputParameter.Value;

      if (outputParameter.DbType.HasValue)
        dataParameter.DbType = outputParameter.DbType.Value;

      if (outputParameter.Direction.HasValue)
        dataParameter.Direction = outputParameter.Direction.Value;

      if (outputParameter.Precision.HasValue)
        dataParameter.Precision = outputParameter.Precision.Value;

      if (outputParameter.Scale.HasValue)
        dataParameter.Scale = outputParameter.Scale.Value;

      if (outputParameter.Size.HasValue)
        dataParameter.Size = outputParameter.Size.Value;

      if (outputParameter.Direction != ParameterDirection.Input)
        outputParameter.SetParameter(dataParameter);

      context.Command.Parameters.Add(dataParameter);
    }
  }
}