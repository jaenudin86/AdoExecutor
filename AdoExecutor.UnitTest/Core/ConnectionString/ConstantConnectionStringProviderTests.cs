using System;
using AdoExecutor.Core.ConnectionString;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.ConnectionString
{
  [TestFixture(Category = "Unit")]
  public class ConstantConnectionStringProviderTests
  {
    [Test]
    public void Constructor_ShouldThrownArgumentNullException_WhenConnectionStringArgumentIsNull()
    {
      //ASSERT
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
