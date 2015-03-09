using System;
using System.Data;
using System.IO;
using System.Text;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Interception;
using AdoExecutor.Core.Interception.Infrastructure;
using FakeItEasy;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.Interception
{
  [TestFixture(Category = "Unit")]
  public class ConsoleLoggerInterceptorTests
  {
    private ConsoleLoggerInterceptor _consoleLoggerInterceptor;
    private StringBuilder _consoleOutput;

    [SetUp]
    public void SetUp()
    {
      _consoleOutput = new StringBuilder();
      var stringWriter = new StringWriter(_consoleOutput);
      Console.SetOut(stringWriter);

      _consoleLoggerInterceptor = new ConsoleLoggerInterceptor();
    }

    [TearDown]
    public void TearDown()
    {
      var streamWriter = new StreamWriter(Console.OpenStandardOutput());
      Console.SetOut(streamWriter);
    }

    [Test]
    public void LogOnError_ShouldWriteLineErrorMessage()
    {
      //ARRANGE
      var exception = new System.Exception();
      var context = new InterceptorErrorContext(
        "testQuery",
        "test",
        typeof(string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IConfiguration>(),
        exception);

      //ACT
      ((IInterceptor)_consoleLoggerInterceptor).OnError(context);

      //ASSERT
      Assert.IsNotEmpty(_consoleOutput.ToString());
    }

    [Test]
    public void LogOnExit_ShouldWriteExitMessage()
    {
      //ARRANGE
      var exception = new System.Exception();
      var context = new InterceptorExitContext(
        "testQuery",
        "test",
        typeof(string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IConfiguration>(),
        exception,
        null);

      //ACT
      ((IInterceptor)_consoleLoggerInterceptor).OnExit(context);

      //ASSERT
      Assert.IsNotEmpty(_consoleOutput.ToString());
    }
  }
}