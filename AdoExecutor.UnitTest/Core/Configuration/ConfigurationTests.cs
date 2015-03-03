using System.Collections.ObjectModel;
using AdoExecutor.Core.Interception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.Configuration
{
  [TestFixture(Category = "Unit")]
  public class ConfigurationTests
  {
    private AdoExecutor.Core.Configuration.Configuration _configuration;

    [SetUp]
    public void SetUp()
    {
      _configuration = new AdoExecutor.Core.Configuration.Configuration();
    }

    [Test]
    public void Constructor_ShouldInitializeCollectionAsEmpty()
    {
      //ASSERT
      Assert.IsInstanceOf<Collection<IInterceptor>>(_configuration.Interceptors);
      CollectionAssert.IsEmpty(_configuration.Interceptors);

      Assert.IsInstanceOf<Collection<IObjectBuilder>>(_configuration.ObjectBuilders);
      CollectionAssert.IsEmpty(_configuration.ObjectBuilders);

      Assert.IsInstanceOf<Collection<IParameterExtractor>>(_configuration.ParameterExtractors);
      CollectionAssert.IsEmpty(_configuration.ParameterExtractors);
    }
  }
}