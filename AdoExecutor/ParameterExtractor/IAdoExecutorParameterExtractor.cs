using System;

namespace AdoExecutor.ParameterExtractor
{
  public interface IAdoExecutorParameterExtractor
  {
    Type[] SupportedTypes { get; }
  }
}