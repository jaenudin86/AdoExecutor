using System.Collections.Generic;
using System.Data;
using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.ParameterExtractor;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class DictionaryAdoExecutorParameterExtractor : IAdoExecutorParameterExtractor
  {
    public bool CanProcess(AdoExecutorContext context)
    {
      return context.Parameters is IDictionary<string, object>;
    }

    public void ExtractParameter(AdoExecutorContext context)
    {
      var parameters = (IDictionary<string, object>) context.Parameters;

      foreach (var parameter in parameters)
      {
        IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
        dataParameter.ParameterName = parameter.Key;
        dataParameter.Value = parameter.Value;

        context.Command.Parameters.Add(dataParameter);
      }
    }
  }
}