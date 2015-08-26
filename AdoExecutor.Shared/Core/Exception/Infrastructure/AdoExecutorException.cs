namespace AdoExecutor.Core.Exception.Infrastructure
{
  public class AdoExecutorException : System.Exception
  {
    public AdoExecutorException()
    {
    }

    public AdoExecutorException(string message)
      : base(message)
    {
    }

    public AdoExecutorException(string message, System.Exception innerException)
      : base(message, innerException)
    {
    }
  }
}