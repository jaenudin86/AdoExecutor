namespace AdoExecutor.Exception
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