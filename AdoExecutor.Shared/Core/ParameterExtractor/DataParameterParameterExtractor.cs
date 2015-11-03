using System.Collections.Generic;
using System.Data;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;

namespace AdoExecutor.Shared.Core.ParameterExtractor
{
  public class DataParameterParameterExtractor : IParameterExtractor
  {
    public bool CanProcess(AdoExecutorContext context)
    {
      if (context.Parameters is IDataParameter)
        return true;

      if (context.Parameters is IEnumerable<IDataParameter>)
        return true;

      return false;
    }

    public void ExtractParameter(AdoExecutorContext context)
    {
      var parameters = context.Parameters as IEnumerable<IDataParameter>;

      if (parameters != null)
      {
        foreach (var dataParameter in parameters)
        {
          context.Command.Parameters.Add(dataParameter);
        }
      }
      else
      {
        var dataParameter = (IDataParameter) context.Parameters;
        context.Command.Parameters.Add(dataParameter);
      }
    }
  }
}