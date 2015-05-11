using AdoExecutor.Core.Context.Infrastructure;

namespace AdoExecutor.Core.ParameterExtractor.Infrastructure
{
  public interface IParameterExtractor
  {
    bool CanProcess(AdoExecutorContext context);
    void ExtractParameter(AdoExecutorContext context);
  }
}