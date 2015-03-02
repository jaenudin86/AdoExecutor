using AdoExecutor.Core.Context.Infrastructure;

namespace AdoExecutor.Core.ParameterExtractor.Infrastructure
{
  public interface IParameterExtractor
  {
    bool CanProcess(Context.Infrastructure.AdoExecutorContext context);
    void ExtractParameter(Context.Infrastructure.AdoExecutorContext context);
  }
}