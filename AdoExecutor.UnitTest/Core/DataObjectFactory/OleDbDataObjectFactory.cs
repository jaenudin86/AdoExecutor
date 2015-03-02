using System.Data.OleDb;
using AdoExecutor.Core.DataObjectFactory;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.DataObjectFactory
{
  [TestFixture]
  public class OleDbDataObjectFactoryTests
  {
    private OleDbDataObjectFactory _dataObjectFactory;

    [SetUp]
    public void SetUp()
    {
      _dataObjectFactory = new OleDbDataObjectFactory();
    }

    [Test]
    public void CreateConnection_ShouldReturnOleDbConnection()
    {
      //ACT
      var connection = _dataObjectFactory.CreateConnection();

      //ASSERT
      Assert.IsInstanceOf<OleDbConnection>(connection);
    }

    [Test]
    public void CreateCommand_ShouldReturnOleDbCommand()
    {
      //ACT
      var command = _dataObjectFactory.CreateCommand();

      //ASSERT
      Assert.IsInstanceOf<OleDbCommand>(command);
    }

    [Test]
    public void CreateDataParameter_ShouldReturnOleDbParameter()
    {
      //ACT
      var parameter = _dataObjectFactory.CreateDataParameter();

      //ASSERT
      Assert.IsInstanceOf<OleDbParameter>(parameter);
    }
  }
}