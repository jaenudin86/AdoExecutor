using System.Collections.Generic;
using AdoExecutor.Core.ConnectionString.Infrastructure;
using AdoExecutor.Core.DataObjectFactory.Infrastructure;
using AdoExecutor.Core.Interception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;

namespace AdoExecutor.Core.Configuration.Infrastructure
{
  public interface IConfiguration
  {
    IConnectionStringProvider ConnectionStringProvider { get; }
    IDataObjectFactory DataObjectFactory { get; }
    ICollection<IInterceptor> Interceptors { get; }
    ICollection<IObjectBuilder> ObjectBuilders { get; }
    ICollection<IParameterExtractor> ParameterExtractors { get; } 
  }
}