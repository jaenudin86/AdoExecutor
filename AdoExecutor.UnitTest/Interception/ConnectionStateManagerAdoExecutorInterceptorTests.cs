using System.Data;
using AdoExecutor.Core.Interception;
using AdoExecutor.Infrastructure.Configuration;
using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.Interception;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Interception
{
  [TestFixture]
  public class ConnectionStateManagerAdoExecutorInterceptorTests
  {
    private ConnectionStateManagerAdoExecutorInterceptor _interceptor;

    [SetUp]
    public void SetUp()
    {
      _interceptor = new ConnectionStateManagerAdoExecutorInterceptor();
    }

    [Test]
    public void OnEntry_ShouldOpenConnection()
    {
      //ARRANGE
      var connectionFake = A.Fake<IDbConnection>();
      var context = new AdoExecutorContext(
        "test",
        null,
        typeof (string),
        AdoExecutorInvokeMethod.Select,
        connectionFake,
        A.Fake<IDbCommand>(),
        A.Fake<IAdoExecutorConfiguration>());

      //ACT
      _interceptor.OnEntry(context);

      //ASSERT
      connectionFake.CallsTo(x => x.Open())
        .MustHaveHappened(Repeated.Exactly.Once);
    }

    [Test]
    public void OnExit_ShouldCloseConnection()
    {
      //ARRANGE
      var connectionFake = A.Fake<IDbConnection>();
      var context = new AdoExecutorInterceptorExitContext(
        "test", 
        null, 
        typeof (string), 
        AdoExecutorInvokeMethod.Select,
        connectionFake, 
        A.Fake<IDbCommand>(), 
        A.Fake<IAdoExecutorConfiguration>(), 
        null, 
        null);

      //ACT
      _interceptor.OnExit(context);

      //ASSERT
      connectionFake.CallsTo(x => x.Close())
        .MustHaveHappened(Repeated.Exactly.Once);
    }
  }
}