using System.Collections.Generic;
using AdoExecutor.Infrastructure.ConnectionString;
using AdoExecutor.Infrastructure.DataObjectFactory;
using AdoExecutor.Infrastructure.Interception;
using AdoExecutor.Infrastructure.ObjectBuilder;
using AdoExecutor.Infrastructure.ParameterExtractor;

namespace AdoExecutor.Infrastructure.Configuration
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