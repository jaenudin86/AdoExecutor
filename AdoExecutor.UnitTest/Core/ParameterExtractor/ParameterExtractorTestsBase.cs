using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Utilities.PrimitiveTypes.Infrastructure;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.ParameterExtractor
{
  [TestFixture(Category = "Unit")]
  public abstract class ParameterExtractorTestsBase
  {
    protected IDbCommand CommandFake;
    protected IConfiguration ConfigurationFake;
    protected IDbConnection ConnectionFake;
    protected ISqlPrimitiveDataTypes SqlPrimitiveDataTypesFake;
    protected IDataParameterCollection CommandParametersFake;

    [SetUp]
    public virtual void SetUp()
    {
      CommandParametersFake = A.Fake<IDataParameterCollection>();
      CommandFake = A.Fake<IDbCommand>();
      CommandFake.CallsTo(x => x.Parameters)
        .Returns(CommandParametersFake);

      ConnectionFake = A.Fake<IDbConnection>();
      ConfigurationFake = A.Fake<IConfiguration>();
      SqlPrimitiveDataTypesFake = A.Fake<ISqlPrimitiveDataTypes>();
    }

    protected virtual AdoExecutorContext CreateContext(object parameters)
    {
      return new AdoExecutorContext(
        string.Empty,
        parameters,
        typeof(string),
        InvokeMethod.Select,
        ConnectionFake,
        CommandFake,
        ConfigurationFake);
    }
  }
}