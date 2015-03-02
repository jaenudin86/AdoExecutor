using System.Collections.Generic;
using System.Data;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class DictionaryParameterExtractor : IParameterExtractor
  {
    public bool CanProcess(Context.Infrastructure.AdoExecutorContext context)
    {
      return context.Parameters is IDictionary<string, object>;
    }

    public void ExtractParameter(Context.Infrastructure.AdoExecutorContext context)
    {
      var parameters = (IDictionary<string, object>) context.Parameters;

      foreach (var parameter in parameters)
      {
        if (string.IsNullOrWhiteSpace(parameter.Key))
          throw new AdoExecutorException("Dictionary item key cannot be null or empty.");

        if (parameter.Value == null)
          throw new AdoExecutorException("Dictionary item value cannot be null.");

        IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
        dataParameter.ParameterName = parameter.Key;
        dataParameter.Value = parameter.Value;

        context.Command.Parameters.Add(dataParameter);
      }
    }
  }
}