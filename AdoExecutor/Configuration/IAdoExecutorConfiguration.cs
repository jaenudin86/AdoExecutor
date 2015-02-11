using System.Collections.Generic;
using AdoExecutor.ConnectionString;
using AdoExecutor.DataObjectFactory;
using AdoExecutor.Interception;
using AdoExecutor.ObjectBuilder;
using AdoExecutor.ParameterExtractor;

namespace AdoExecutor.Configuration
{
  public interface IAdoExecutorConfiguration
  {
    IConnectionStringProvider ConnectionStringProvider { get; }
    IAdoExecutorDataObjectFactory DataObjectFactory { get; }
    ICollection<IAdoExecutorInterceptor> Interceptors { get; }
    ICollection<IAdoExecutorObjectBuilder> ObjectBuilders { get; }
    ICollection<IAdoExecutorParameterExtractor> ParameterExtractors { get; } 
  }
}