namespace AdoExecutor.Core.Query.Infrastructure
{
  public class Command
  {
    public Command()
    {
    }

    public Command(string query, object parameters = null)
      : this(query, parameters, null)
    {
    }

    public Command(string query, QueryOptions options)
      : this(query, null, options)
    {
      
    }

    public Command(string query, object parameters = null, QueryOptions options = null)
    {
      Query = query;
      Parameters = parameters;
      Options = options;
    }

    public string Query { get; set; }
    public object Parameters { get; set; }
    public QueryOptions Options { get; set; }
  }
}