using AdoExecutor.Core.Context.Infrastructure;

namespace AdoExecutor.Core.ParameterExtractor.Infrastructure
{
  public interface IParameterExtractor
  {
    bool CanProcess(Context.Infrastructure.Context context);
    void ExtractParameter(Context.Infrastructure.Context context);
  }
}