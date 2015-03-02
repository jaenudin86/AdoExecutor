using System;
using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;

namespace AdoExecutor.Core.ObjectBuilder.Infrastructure
{
  public class ObjectBuilderContext : Context.Infrastructure.AdoExecutorContext
  {
    public ObjectBuilderContext(
      string query, 
      object parameters, 
      Type resultType,
      InvokeMethod invokeMethod, 
      IDbConnection connection, 
      IDbCommand command,
      IConfiguration configuration, 
      IDataReader dataReader)
      : base(query, parameters, resultType, invokeMethod, connection, command, configuration)
    {
      if (dataReader == null)
        throw new ArgumentNullException("dataReader");

      DataReader = dataReader;
    }

    public IDataReader DataReader { get; private set; }
  }
}