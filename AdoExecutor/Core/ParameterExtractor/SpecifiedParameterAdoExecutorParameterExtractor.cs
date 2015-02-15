using System.Data;
using AdoExecutor.Core.Parameter;
using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.ParameterExtractor;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class SpecifiedParameterAdoExecutorParameterExtractor : IAdoExecutorParameterExtractor
  {
    public bool CanProcess(AdoExecutorContext context)
    {
      return context.ParametersType == typeof (AdoExecutorSpecifiedParameter) ||
             context.ParametersType == typeof (AdoExecutorSpecifiedParameter[]);
    }

    public void ExtractParameter(AdoExecutorContext context)
    {
      if (context.ParametersType.IsArray)
      {
        var parameters = (AdoExecutorSpecifiedParameter[]) context.Parameters;

        foreach (AdoExecutorSpecifiedParameter parameter in parameters)
        {
          AddParameter(context, parameter);
        }
      }
      else
      {
        var parameter = (AdoExecutorSpecifiedParameter) context.Parameters;
        AddParameter(context, parameter);
      }
    }

    private void AddParameter(AdoExecutorContext context, AdoExecutorSpecifiedParameter parameter)
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