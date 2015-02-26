using System;
using AdoExecutor.Core.ConnectionString;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.ConnectionString
{
  [TestFixture]
  public class ConstantConnectionStringProviderTests
  {
    [Test]
    public void Constructor_ShouldThrownArgumentNullException_WhenConnectionStringArgumentIsNull()
    {
      //ACT
      Assert.Throws<ArgumentNullException>(() => new ConstantConnectionStringProvider(null));
    }

    [Test]
    public void ConnectionString_ShouldReturnConstructorArgumentValue()
    {
      //ARANGE
      const string connectionString = "testConnectionString";

      //ACT
      var sut = new ConstantConnectionStringProvider(connectionString);

      //ASSERT
      Assert.AreEqual(connectionString, sut.ConnectionString);
    }
  }
}
