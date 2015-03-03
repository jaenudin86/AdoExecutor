using System.Data.Odbc;
using AdoExecutor.Core.DataObjectFactory;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.DataObjectFactory
{
  [TestFixture(Category = "Unit")]
  public class OdbcDataObjectFactoryTests
  {
    private OdbcDataObjectFactory _dataObjectFactory;

    [SetUp]
    public void SetUp()
    {
      _dataObjectFactory = new OdbcDataObjectFactory();
    }

    [Test]
    public void CreateConnection_ShouldReturnOdbcConnection()
    {
      //ACT
      var connection = _dataObjectFactory.CreateConnection();

      //ASSERT
      Assert.IsInstanceOf<OdbcConnection>(connection);
    }

    [Test]
    public void CreateCommand_ShouldReturnOdbcCommand()
    {
      //ACT
      var command = _dataObjectFactory.CreateCommand();

      //ASSERT
      Assert.IsInstanceOf<OdbcCommand>(command);
    }

    [Test]
    public void CreateDataParameter_ShouldReturnOdbcParameter()
    {
      //ACT
      var parameter = _dataObjectFactory.CreateDataParameter();

      //ASSERT
      Assert.IsInstanceOf<OdbcParameter>(parameter);
    }
  }
}