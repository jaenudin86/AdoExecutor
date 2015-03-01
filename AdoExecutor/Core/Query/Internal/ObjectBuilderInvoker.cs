using System;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;

namespace AdoExecutor.Core.Query.Internal
{
  internal class ObjectBuilderInvoker
  {
    private readonly IConfiguration _configuration;

    public ObjectBuilderInvoker(IConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException("configuration");

      _configuration = configuration;
    }

    public object CreateInstance(ObjectBuilderContext context)
    {
      if (context.InvokeMethod != InvokeMethod.Select)
        throw new AdoExecutorException("Unsupported invoke method type.");

      foreach (IObjectBuilder objectBuilder in _configuration.ObjectBuilders)
      {
        if (objectBuilder.CanProcess(context))
          return objectBuilder.CreateInstance(context);
      }

      throw new AdoExecutorException(string.Format("Not found object builder for type: {0}", context.ResultType));
    }
  }
}