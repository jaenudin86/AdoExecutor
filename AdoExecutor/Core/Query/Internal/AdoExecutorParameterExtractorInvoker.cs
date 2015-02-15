using System;
using AdoExecutor.Infrastructure.Configuration;
using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.Exception;
using AdoExecutor.Infrastructure.ParameterExtractor;

namespace AdoExecutor.Core.Query.Internal
{
  internal class AdoExecutorParameterExtractorInvoker
  {
    private readonly IAdoExecutorConfiguration _configuration;

    public AdoExecutorParameterExtractorInvoker(IAdoExecutorConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException("configuration");

      _configuration = configuration;
    }

    public void ExtractParameter(AdoExecutorContext context)
    {
      if (context.Parameters == null)
        return;

      foreach (IAdoExecutorParameterExtractor parameterExtractor in _configuration.ParameterExtractors)
      {
        if (parameterExtractor.CanProcess(context))
        {
          parameterExtractor.ExtractParameter(context);
          return;
        }
      }

      throw new AdoExecutorException(string.Format("Not found parameter extractor for type: {0}", context.ParametersType));
    }
  }
}