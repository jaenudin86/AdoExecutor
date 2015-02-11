using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdoExecutor.ConnectionString;
using AdoExecutor.DataObjectFactory;
using AdoExecutor.Interception;
using AdoExecutor.ObjectBuilder;
using AdoExecutor.ParameterExtractor;

namespace AdoExecutor.Configuration
{
  public class AdoExecutorConfiguration : IAdoExecutorConfiguration
  {
    public AdoExecutorConfiguration()
    {
      Interceptors = new Collection<IAdoExecutorInterceptor>();
      ObjectBuilders = new Collection<IAdoExecutorObjectBuilder>();
      ParameterExtractors = new Collection<IAdoExecutorParameterExtractor>();
    }

    public IConnectionStringProvider ConnectionStringProvider { get; set; }
    public IAdoExecutorDataObjectFactory DataObjectFactory { get; set; }
    public ICollection<IAdoExecutorInterceptor> Interceptors { get; set; }
    public ICollection<IAdoExecutorObjectBuilder> ObjectBuilders { get; set; }
    public ICollection<IAdoExecutorParameterExtractor> ParameterExtractors { get; set; }
  }
}