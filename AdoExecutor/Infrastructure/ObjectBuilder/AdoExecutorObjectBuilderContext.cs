using System;
using System.Data;
using AdoExecutor.Infrastructure.Configuration;
using AdoExecutor.Infrastructure.Context;

namespace AdoExecutor.Infrastructure.ObjectBuilder
{
  public class AdoExecutorObjectBuilderContext : AdoExecutorContext
  {
    public AdoExecutorObjectBuilderContext(
      string query, 
      object parameters, 
      Type resultType,
      AdoExecutorInvokeMethod invokeMethod, 
      IDbConnection connection, 
      IDbCommand command,
      IAdoExecutorConfiguration configuration, 
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