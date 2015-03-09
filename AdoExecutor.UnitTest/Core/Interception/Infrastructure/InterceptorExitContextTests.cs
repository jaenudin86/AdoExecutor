using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Interception.Infrastructure;
using FakeItEasy;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.Interception.Infrastructure
{
  [TestFixture(Category = "Unit")]
  public class InterceptorExitContextTests
  {
    [Test]
    public void Constructor_ShouldPass_WhenAllRequiredParametersAreNotNull()
    {
      //ASSERT
      var exception = new System.Exception();
      const string result = "testResult";

      //ACT
      var context = new InterceptorExitContext("testQuery",
        "test",
        typeof (string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IConfiguration>(),
        result,
        exception);

      //ASSERT
      Assert.AreSame(exception, context.Exception);
      Assert.AreEqual(result, context.Result);
    }
  }
}
