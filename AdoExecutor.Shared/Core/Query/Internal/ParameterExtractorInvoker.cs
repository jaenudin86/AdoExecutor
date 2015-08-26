using System;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;

namespace AdoExecutor.Core.Query.Internal
{
  internal class ParameterExtractorInvoker
  {
    private readonly IConfiguration _configuration;

    public ParameterExtractorInvoker(IConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException("configuration");

      _configuration = configuration;
    }

    public void ExtractParameter(Context.Infrastructure.AdoExecutorContext context)
    {
      if (context.Parameters == null)
        return;

      foreach (IParameterExtractor parameterExtractor in _configuration.ParameterExtractors)
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