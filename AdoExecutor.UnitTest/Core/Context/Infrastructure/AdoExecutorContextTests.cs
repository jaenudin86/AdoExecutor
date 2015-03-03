using System;
using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using FakeItEasy;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.Context.Infrastructure
{
  [TestFixture(Category = "Unit")]
  public class AdoExecutorContextTests
  {
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenQueryArgumentIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(() => new AdoExecutorContext(
        null,
        "test",
        typeof (string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IConfiguration>()));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenResultTypeArgumentIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(() => new AdoExecutorContext(
        "testQuery",
        "test",
        null,
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IConfiguration>()));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenInvokeMethodArgumentIsNone()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(() => new AdoExecutorContext(
        "testQuery",
        "test",
        typeof (string),
        InvokeMethod.None,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IConfiguration>()));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenConnectionArgumentIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(() => new AdoExecutorContext(
        "testQuery",
        "test",
        typeof (string),
        InvokeMethod.Execute,
        null,
        A.Fake<IDbCommand>(),
        A.Fake<IConfiguration>()));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenCommandArgumentIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(() => new AdoExecutorContext(
        "testQuery",
        "test",
        typeof (string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        null,
        A.Fake<IConfiguration>()));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenConfigurationArgumentIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(() => new AdoExecutorContext(
        "testQuery",
        "test",
        typeof (string),
        InvokeMethod.Execute,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        null));
    }

    [Test]
    public void Constructor_ShouldInitializePropertiesWithCorrectlyValues()
    {
      //ARRANGE
      const string query = "testQuery";
      const int parameters = 43;
      Type resultType = typeof (double);
      const InvokeMethod invokeMethod = InvokeMethod.Execute;
      IDbConnection connection = A.Fake<IDbConnection>();
      IDbCommand command = A.Fake<IDbCommand>();
      IConfiguration configuration = A.Fake<IConfiguration>();

      //ACT
      var context = new AdoExecutorContext(query, parameters, resultType, invokeMethod, connection, command,
        configuration);

      //ASSERT
      Assert.AreEqual(query, context.Query);
      Assert.AreEqual(parameters, context.Parameters);
      Assert.AreEqual(resultType, context.ResultType);
      Assert.AreEqual(invokeMethod, context.InvokeMethod);
      
      Assert.AreSame(connection, context.Connection);
      Assert.AreSame(command, context.Command);
      Assert.AreSame(configuration, context.Configuration);

      CollectionAssert.IsEmpty(context.Bag);
    }

    [Test]
    public void ParametersType_ShouldSetParameterType_WhenParametersValueIsNotNull()
    {
      //ARRANGE
      const string value = "test";
      Type expectedType = typeof (string);

      //ACT
      var context = new AdoExecutorContext(
        "testQuery",
        value,
        typeof(string),
        InvokeMethod.Select,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IConfiguration>());

      //ASSERT
      Assert.AreEqual(expectedType, context.ParametersType);
    }

    [Test]
    public void ParametersType_ShouldBeNull_WhenParametersValueIsNull()
    {
      //ACT
      var context = new AdoExecutorContext(
        "testQuery",
        null,
        typeof(string),
        InvokeMethod.Select,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IConfiguration>());

      //ASSERT
      Assert.IsNull(context.ParametersType);
    }
  }
}