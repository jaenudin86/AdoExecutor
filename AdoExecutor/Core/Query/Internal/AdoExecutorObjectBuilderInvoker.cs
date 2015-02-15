using System;
using AdoExecutor.Infrastructure.Configuration;
using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.Exception;
using AdoExecutor.Infrastructure.ObjectBuilder;

namespace AdoExecutor.Core.Query.Internal
{
  internal class AdoExecutorObjectBuilderInvoker
  {
    private readonly IAdoExecutorConfiguration _configuration;

    public AdoExecutorObjectBuilderInvoker(IAdoExecutorConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException("configuration");

      _configuration = configuration;
    }

    public object CreateInstance(AdoExecutorObjectBuilderContext context)
    {
      if (context.InvokeMethod != AdoExecutorInvokeMethod.Select)
        throw new AdoExecutorException("Unsupported invoke method type.");

      foreach (IAdoExecutorObjectBuilder objectBuilder in _configuration.ObjectBuilders)
      {
        if (objectBuilder.CanProcess(context))
          return objectBuilder.CreateInstance(context);
      }

      throw new AdoExecutorException(string.Format("Not found object builder for type: {0}", context.ResultType));
    }
  }
}