using System;
using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Interception.Infrastructure;
using FakeItEasy;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.Interception.Infrastructure
{
  [TestFixture(Category = "Unit")]
  public class InterceptorErrorContextTests
  {
    [Test]
    public void Constructor_ShouldThrownArgumentNullException_WhenExceptionIsNull()
    {
      //ACT
      Assert.Throws<ArgumentNullException>(() => new InterceptorErrorContext(
        "testQuery",
        "test",
        typeof (string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IConfiguration>(),
        null));
    }

    [Test]
    public void Constructor_ShouldPass_WhenAllRequiredParametersAreNotNull()
    {
      //ARRANGE
      var exception = new System.Exception();

      //ACT
      var context = new InterceptorErrorContext(
        "testQuery",
        "test",
        typeof (string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IConfiguration>(),
        exception);

      //ASSERT
      Assert.AreSame(exception, context.Exception);
    }
  }
}