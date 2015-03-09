using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Interception;
using AdoExecutor.Core.Interception.Infrastructure;
using FakeItEasy;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.Interception
{
  [TestFixture(Category = "Unit")]
  public class LoggerInterceptorBaseTests
  {
    private TestLogger _logger;

    const string ExpectedMessageWithParameters =
@"*** QUERY ***
testQuery
*** END OF QUERY ***

*** PARAMETERS ***
Name: testParameter1, Value: testValue1, DbType: String
Name: testParameter2, Value: 20, DbType: Int32
*** END OF PARAMETERS ***";

    const string ExpectedMessageWithParametersAndWithError =
@"*** QUERY ***
testQuery
*** END OF QUERY ***

*** PARAMETERS ***
Name: testParameter1, Value: testValue1, DbType: String
Name: testParameter2, Value: 20, DbType: Int32
*** END OF PARAMETERS ***

*** EXCEPTION ***
System.Exception: testExceptionMessage
*** END OF EXCEPTION ***";

    const string ExpectedMessageWithoutParameters =
@"*** QUERY ***
testQuery
*** END OF QUERY ***";

    const string ExpectedMessageWithoutParametersAndWithError =
@"*** QUERY ***
testQuery
*** END OF QUERY ***

*** EXCEPTION ***
System.Exception: testExceptionMessage
*** END OF EXCEPTION ***";

    [SetUp]
    public void SetUp()
    {
      _logger = new TestLogger();  
    }

    [Test]
    public void LogOnEntry_ShouldPrepareMessageIncludingParameters_WhenSqlCommandHasParameters()
    {
      //ASSERT
      var command = PrepareCommandWithParameters();
      var context = new AdoExecutorContext("testQuery",
        "test",
        typeof(string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        command,
        A.Fake<IConfiguration>());

      //ACT
      ((IInterceptor)_logger).OnEntry(context);

      //ASSERT
      Assert.AreEqual(1, _logger.OnEntryLog.Count);
      Assert.AreEqual(ExpectedMessageWithParameters, _logger.OnEntryLog[0]);
    }

    [Test]
    public void LogOnEntry_ShouldPrepareMessageNotIncludingParameters_WhenSqlCommandHasNotParameters()
    {
      //ASSERT
      var command = new SqlCommand();
      var context = new AdoExecutorContext("testQuery",
        "test",
        typeof(string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        command,
        A.Fake<IConfiguration>());

      //ACT
      ((IInterceptor)_logger).OnEntry(context);

      //ASSERT
      Assert.AreEqual(1, _logger.OnEntryLog.Count);
      Assert.AreEqual(ExpectedMessageWithoutParameters, _logger.OnEntryLog[0]);
    }

    [Test]
    public void LogOnError_ShouldPrepareMessageIncludingParameters_WhenSqlCommandHasParameters()
    {
      //ASSERT
      var exception = new System.Exception("testExceptionMessage");
      var command = PrepareCommandWithParameters();
      var context = new InterceptorErrorContext("testQuery",
        "test",
        typeof(string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        command,
        A.Fake<IConfiguration>(),
        exception);

      //ACT
      ((IInterceptor)_logger).OnError(context);

      //ASSERT
      Assert.AreEqual(1, _logger.OnErrorLog.Count);
      Assert.AreEqual(ExpectedMessageWithParametersAndWithError, _logger.OnErrorLog[0]);
    }

    [Test]
    public void LogOnError_ShouldPrepareMessageNotIncludingParameters_WhenSqlCommandHasNotParameters()
    {
      //ASSERT
      var exception = new System.Exception("testExceptionMessage");
      var command = new SqlCommand();
      var context = new InterceptorErrorContext("testQuery",
        "test",
        typeof(string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        command,
        A.Fake<IConfiguration>(),
        exception);

      //ACT
      ((IInterceptor)_logger).OnError(context);

      //ASSERT
      Assert.AreEqual(1, _logger.OnErrorLog.Count);
      Assert.AreEqual(ExpectedMessageWithoutParametersAndWithError, _logger.OnErrorLog[0]);
    }

    [Test]
    public void LogOnSuccess_ShouldPrepareMessageIncludingParameters_WhenSqlCommandHasParameters()
    {
      //ASSERT
      var command = PrepareCommandWithParameters();
      var context = new InterceptorSuccessContext("testQuery",
        "test",
        typeof(string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        command,
        A.Fake<IConfiguration>(),
        null);

      //ACT
      ((IInterceptor)_logger).OnSuccess(context);

      //ASSERT
      Assert.AreEqual(1, _logger.OnSuccessLog.Count);
      Assert.AreEqual(ExpectedMessageWithParameters, _logger.OnSuccessLog[0]);
    }

    [Test]
    public void LogOnSuccess_ShouldPrepareMessageNotIncludingParameters_WhenSqlCommandHasNotParameters()
    {
      //ASSERT
      var command = new SqlCommand();
      var context = new InterceptorSuccessContext("testQuery",
        "test",
        typeof(string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        command,
        A.Fake<IConfiguration>(),
        null);

      //ACT
      ((IInterceptor)_logger).OnSuccess(context);

      //ASSERT
      Assert.AreEqual(1, _logger.OnSuccessLog.Count);
      Assert.AreEqual(ExpectedMessageWithoutParameters, _logger.OnSuccessLog[0]);
    }

    [Test]
    public void LogOnExit_ShouldPrepareMessageIncludingParameters_WhenSqlCommandHasParameters()
    {
      //ASSERT
      var exception = new System.Exception("testExceptionMessage");
      var command = PrepareCommandWithParameters();
      var context = new InterceptorExitContext("testQuery",
        "test",
        typeof(string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        command,
        A.Fake<IConfiguration>(),
        null,
        exception);

      //ACT
      ((IInterceptor)_logger).OnExit(context);

      //ASSERT
      Assert.AreEqual(1, _logger.OnExitLog.Count);
      Assert.AreEqual(ExpectedMessageWithParametersAndWithError, _logger.OnExitLog[0]);
    }

    [Test]
    public void LogOnExit_ShouldPrepareMessageNotIncludingParameters_WhenSqlCommandHasNotParameters()
    {
      //ASSERT
      var exception = new System.Exception("testExceptionMessage");
      var command = new SqlCommand();
      var context = new InterceptorExitContext("testQuery",
        "test",
        typeof(string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        command,
        A.Fake<IConfiguration>(),
        null,
        exception);

      //ACT
      ((IInterceptor)_logger).OnExit(context);

      //ASSERT
      Assert.AreEqual(1, _logger.OnExitLog.Count);
      Assert.AreEqual(ExpectedMessageWithoutParametersAndWithError, _logger.OnExitLog[0]);
    }

    private SqlCommand PrepareCommandWithParameters()
    {
      var param1 = new SqlParameter
      {
        ParameterName = "testParameter1",
        DbType = DbType.String,
        Value = "testValue1"
      };
      var param2 = new SqlParameter
      {
        ParameterName = "testParameter2",
        DbType = DbType.Int32,
        Value = 20
      };

      var command = new SqlCommand();
      command.Parameters.Add(param1);
      command.Parameters.Add(param2);

      return command;
    }

    public class TestLogger : LoggerInterceptorBase
    {
      public List<string>  OnEntryLog = new List<string>();
      public List<string> OnErrorLog = new List<string>();
      public List<string> OnExitLog = new List<string>();
      public List<string> OnSuccessLog = new List<string>(); 

      protected override void LogOnEntry(AdoExecutorContext context, string logMessage)
      {
        OnEntryLog.Add(logMessage);
      }

      protected override void LogOnError(InterceptorErrorContext context, string logMessage)
      {
        OnErrorLog.Add(logMessage);
      }

      protected override void LogOnExit(InterceptorExitContext context, string logMessage)
      {
        OnExitLog.Add(logMessage);
      }

      protected override void LogOnSuccess(InterceptorSuccessContext context, string logMessage)
      {
        OnSuccessLog.Add(logMessage);
      }
    }
  }
}