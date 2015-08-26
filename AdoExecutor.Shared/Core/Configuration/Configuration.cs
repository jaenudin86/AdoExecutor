using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.ConnectionString.Infrastructure;
using AdoExecutor.Core.DataObjectFactory.Infrastructure;
using AdoExecutor.Core.Interception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;

namespace AdoExecutor.Core.Configuration
{
  public class Configuration : IConfiguration
  {
    public Configuration()
    {
      Interceptors = new Collection<IInterceptor>();
      ObjectBuilders = new Collection<IObjectBuilder>();
      ParameterExtractors = new Collection<IParameterExtractor>();
    }

    public IConnectionStringProvider ConnectionStringProvider { get; set; }
    public IDataObjectFactory DataObjectFactory { get; set; }
    public ICollection<IInterceptor> Interceptors { get; set; }
    public ICollection<IObjectBuilder> ObjectBuilders { get; set; }
    public ICollection<IParameterExtractor> ParameterExtractors { get; set; }
  }
}