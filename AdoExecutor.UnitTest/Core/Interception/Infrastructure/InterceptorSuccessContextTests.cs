using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Interception.Infrastructure;
using FakeItEasy;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.Interception.Infrastructure
{
  [TestFixture(Category = "Unit")]
  public class InterceptorSuccessContextTests
  {
    [Test]
    public void Constructor_ShouldPass_WhenAllRequiredParametersAreNotNull()
    {
      //ASSERT
      const string result = "testResult";

      //ACT
      var context = new InterceptorSuccessContext(
        "testQuery",
        "test",
        typeof(string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IConfiguration>(),
        result);

      //ASSERT
      Assert.AreEqual(result, context.Result);
    }
  }
}