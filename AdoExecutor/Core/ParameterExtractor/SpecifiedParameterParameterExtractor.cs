using System.Data;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Parameter;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class SpecifiedParameterParameterExtractor : IParameterExtractor
  {
    public bool CanProcess(Context.Infrastructure.Context context)
    {
      return context.ParametersType == typeof (SpecifiedParameter) ||
             context.ParametersType == typeof (SpecifiedParameter[]);
    }

    public void ExtractParameter(Context.Infrastructure.Context context)
    {
      if (context.ParametersType.IsArray)
      {
        var parameters = (SpecifiedParameter[]) context.Parameters;

        foreach (SpecifiedParameter parameter in parameters)
        {
          AddParameter(context, parameter);
        }
      }
      else
      {
        var parameter = (SpecifiedParameter) context.Parameters;
        AddParameter(context, parameter);
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