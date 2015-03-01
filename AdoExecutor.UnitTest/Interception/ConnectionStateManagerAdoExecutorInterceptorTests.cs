using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Interception;
using AdoExecutor.Core.Interception.Infrastructure;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Interception
{
  [TestFixture]
  public class ConnectionStateManagerAdoExecutorInterceptorTests
  {
    private ConnectionStateManagerInterceptor _interceptor;

    [SetUp]
    public void SetUp()
    {
      _interceptor = new ConnectionStateManagerInterceptor();
    }

    [Test]
    public void OnEntry_ShouldOpenConnection()
    {
      //ARRANGE
      var connectionFake = A.Fake<IDbConnection>();
      var context = new Context(
        "test",
        null,
        typeof (string),
        InvokeMethod.Select,
        connectionFake,
        A.Fake<IDbCommand>(),
        A.Fake<IConfiguration>());

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
      var context = new InterceptorExitContext(
        "test", 
        null, 
        typeof (string), 
        InvokeMethod.Select,
        connectionFake, 
        A.Fake<IDbCommand>(), 
        A.Fake<IConfiguration>(), 
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