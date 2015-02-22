using System;
using AdoExecutor.Core.ConnectionString;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.ConnectionString
{
  [TestFixture]
  public class AppConfigConnectionStringProviderTest
  {
    [Test]
    public void Constructor_ShouldThrownArgumentNullException_WhenConnectionStringAppConfigKeyArgumentIsNull()
    {
      Assert.Throws<ArgumentNullException>(() => new AppConfigConnectionStringProvider(null));
    }

    [Test]
    public void ConnectionString_ShouldReturnConnectionStringFromAppConfig()
    {
      //ARRANGE
      const string connectionStringAppConfigKey = "ConnectionStringTest";

      //ACT
      var sut = new AppConfigConnectionStringProvider(connectionStringAppConfigKey);

      //ASSERT
      const string exceptedConnectionString = "test";
      Assert.AreEqual(exceptedConnectionString, sut.ConnectionString);
    }
  }
}