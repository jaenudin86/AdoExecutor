using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.ObjectBuilder;
using AdoExecutor.Core.ParameterExtractor;
using AdoExecutor.Core.Query.Infrastructure;
using AdoExecutor.Core.QueryFactory.Infrastructure;
using AdoExecutor.Utilities.Adapter.DataTable;
using AdoExecutor.Utilities.Adapter.List;
using AdoExecutor.Utilities.ObjectConverter;
using AdoExecutor.Utilities.PrimitiveTypes;

namespace AdoExecutor.Core.QueryFactory
{
  public abstract class QueryFactoryBase : IQueryFactory
  {
    public virtual IQuery CreateQuery()
    {
      var configuration = CreateConfiguration();
      return new Query.Query(configuration);
    }

    protected virtual IConfiguration CreateConfiguration()
    {
      var configuration = new Configuration.Configuration();

      ConfigureConnectionStringProvider(configuration);
      ConfigureDataObjectFactory(configuration);
      ConfigureObjectBuilders(configuration);
      ConfigureInterceptors(configuration);
      ConfigureParameterExtractors(configuration);

      return configuration;
    }

    protected abstract void ConfigureConnectionStringProvider(Configuration.Configuration configuration);
    protected abstract void ConfigureDataObjectFactory(Configuration.Configuration configuration);

    protected virtual void ConfigureObjectBuilders(Configuration.Configuration configuration)
    {
      configuration.ObjectBuilders.Add(new DataSetObjectBuilder(new DataTableAdapter()));
      configuration.ObjectBuilders.Add(new DataTableObjectBuilder(new DataTableAdapter()));
      configuration.ObjectBuilders.Add(new SimpleTypeObjectBuilder(new SqlPrimitiveDataTypes(), new ListAdapterFactory(),
        new ObjectConverter()));
      configuration.ObjectBuilders.Add(new DefinedTypeObjectBuilder(new ListAdapterFactory(),
        new SqlPrimitiveDataTypes(), new ObjectConverter()));

      #if NET40 || NET45
      configuration.ObjectBuilders.Add(new DynamicObjectBuilder(new ListAdapterFactory()));
      #endif
    }

    protected virtual void ConfigureInterceptors(Configuration.Configuration configuration)
    {
    }

    protected virtual void ConfigureParameterExtractors(Configuration.Configuration configuration)
    {
      configuration.ParameterExtractors.Add(new SpecifiedParameterParameterExtractor());
      configuration.ParameterExtractors.Add(new DataTableParameterExtractor());
      configuration.ParameterExtractors.Add(new DictionaryParameterExtractor(new SqlPrimitiveDataTypes()));
      configuration.ParameterExtractors.Add(new EnumerableParameterExtractor(new SqlPrimitiveDataTypes()));
      configuration.ParameterExtractors.Add(new ObjectPropertyParameterExtractor(new SqlPrimitiveDataTypes()));
    }
  }
}