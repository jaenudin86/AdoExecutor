using System;
using System.Collections.Generic;
using System.Data;
using AdoExecutor.Core.Entities;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class SpecifiedParameterParameterExtractor : IParameterExtractor
  {
    public bool CanProcess(Context.Infrastructure.AdoExecutorContext context)
    {
      if (context.Parameters is SpecifiedParameter)
        return true;

      if (context.Parameters is IEnumerable<SpecifiedParameter>)
        return true;

      return false;
    }

    public void ExtractParameter(Context.Infrastructure.AdoExecutorContext context)
    {
      var specifiedParameters = context.Parameters as IEnumerable<SpecifiedParameter>;

      if (specifiedParameters != null)
      {
        var parameters = specifiedParameters;

        foreach (SpecifiedParameter specifiedParameter in parameters)
          AddParameter(context, specifiedParameter);
      }
      else
      {
        var specifiedParameter = (SpecifiedParameter) context.Parameters;
        AddParameter(context, specifiedParameter);
      }
    }

    private void AddParameter(Context.Infrastructure.AdoExecutorContext context, SpecifiedParameter parameter)
    {
      IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
      dataParameter.ParameterName = parameter.ParameterName;
      dataParameter.Value = parameter.Value ?? DBNull.Value;

      if (parameter.DbType.HasValue)
        dataParameter.DbType = parameter.DbType.Value;

      if (parameter.Direction.HasValue)
        dataParameter.Direction = parameter.Direction.Value;

      if (parameter.Precision.HasValue)
        dataParameter.Precision = parameter.Precision.Value;

      if (parameter.Scale.HasValue)
        dataParameter.Scale = parameter.Scale.Value;

      if (parameter.Size.HasValue)
        dataParameter.Size = parameter.Size.Value;

      parameter.SetParameter(dataParameter);

      context.Command.Parameters.Add(dataParameter);
    }
  }
}