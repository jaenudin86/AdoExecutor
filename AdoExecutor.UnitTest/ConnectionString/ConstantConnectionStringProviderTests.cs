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
      Assert.Throws<ArgumentNullException>(() => new ConstantConnectionStringProvider(null));
    }

    [Test]
    public void ConnectionString_ShouldReturnConstructorArgumentValue()
    {
      const string connectionString = "testConnectionString";

      var sut = new ConstantConnectionStringProvider(connectionString);

      Assert.AreEqual(connectionString, sut.ConnectionString);
    }
  }
}
