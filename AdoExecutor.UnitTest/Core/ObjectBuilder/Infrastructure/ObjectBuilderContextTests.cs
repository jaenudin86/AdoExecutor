using System;
using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using FakeItEasy;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.ObjectBuilder.Infrastructure
{
  [TestFixture(Category = "Unit")]
  public class ObjectBuilderContextTests
  {
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenDataReaderIsNull()
    {
      //ASSET
      Assert.Throws<ArgumentNullException>(
        () => new ObjectBuilderContext(
          string.Empty,
          null,
          typeof (string),
          InvokeMethod.Select,
          A.Fake<IDbConnection>(),
          A.Fake<IDbCommand>(),
          A.Fake<IConfiguration>(),
          null));
    }

    [Test]
    public void Constructor_ShouldInitializePropertiesWithCorrectlyValues()
    {
      //ARRANGE
      const string query = "testQuery";
      const int parameters = 43;
      var resultType = typeof (double);
      const InvokeMethod invokeMethod = InvokeMethod.Execute;
      var connection = A.Fake<IDbConnection>();
      var command = A.Fake<IDbCommand>();
      var configuration = A.Fake<IConfiguration>();
      var dataReader = A.Fake<IDataReader>();

      //ACT
      var context = new ObjectBuilderContext(query, parameters, resultType, invokeMethod, connection, command,
        configuration, dataReader);

      //ASSERT
      Assert.AreEqual(query, context.Query);
      Assert.AreEqual(parameters, context.Parameters);
      Assert.AreEqual(resultType, context.ResultType);
      Assert.AreEqual(invokeMethod, context.InvokeMethod);

      Assert.AreSame(connection, context.Connection);
      Assert.AreSame(command, context.Command);
      Assert.AreSame(configuration, context.Configuration);
      Assert.AreSame(dataReader, context.DataReader);

      CollectionAssert.IsEmpty(context.Bag);
    }
  }
}