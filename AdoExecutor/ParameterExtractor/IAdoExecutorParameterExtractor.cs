using AdoExecutor.Context;

namespace AdoExecutor.ParameterExtractor
{
  public interface IAdoExecutorParameterExtractor
  {
    bool CanProcess(IAdoExecutorContext context);
    void ExtractParameter(IAdoExecutorContext context);
  }
}