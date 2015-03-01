using System.Collections;
using System.Collections.Generic;
using System.Data;
using AdoExecutor.Core.Parameter;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class SpecifiedParameterParameterExtractor : IParameterExtractor
  {
    public bool CanProcess(Context.Infrastructure.Context context)
    {
      if (context.Parameters is SpecifiedParameter)
        return true;

      if (context.Parameters is IEnumerable<SpecifiedParameter>)
        return true;

      return false;
    }

    public void ExtractParameter(Context.Infrastructure.Context context)
    {
      if (context.Parameters is IEnumerable<SpecifiedParameter>)
      {
        var parameters = (IEnumerable<SpecifiedParameter>) context.Parameters;

        foreach (SpecifiedParameter specifiedParameter in parameters)
        {
          AddParameter(context, specifiedParameter);
        }
      }
      else
      {
        var specifiedParameter = (SpecifiedParameter) context.Parameters;
        AddParameter(context, specifiedParameter);
      }
    }

    private void AddParameter(Context.Infrastructure.Context context, SpecifiedParameter parameter)
    {
      IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
      dataParameter.ParameterName = parameter.ParameterName;
      dataParameter.Value = parameter.Value;

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

      if (parameter.Direction != ParameterDirection.Input)
        parameter.SetParameter(dataParameter);

      context.Command.Parameters.Add(dataParameter);
    }
  }
}