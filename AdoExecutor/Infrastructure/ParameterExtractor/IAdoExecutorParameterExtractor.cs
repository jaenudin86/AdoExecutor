using AdoExecutor.Infrastructure.Context;

namespace AdoExecutor.Infrastructure.ParameterExtractor
{
  public interface IAdoExecutorParameterExtractor
  {
    bool CanProcess(AdoExecutorContext context);
    void ExtractParameter(AdoExecutorContext context);
  }
}