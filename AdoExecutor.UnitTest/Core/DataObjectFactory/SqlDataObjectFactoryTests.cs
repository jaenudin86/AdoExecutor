using System.Data.SqlClient;
using AdoExecutor.Core.DataObjectFactory;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.DataObjectFactory
{
  [TestFixture(Category = "Unit")]
  public class SqlDataObjectFactoryTests
  {
    private SqlDataObjectFactory _dataObjectFactory;

    [SetUp]
    public void SetUp()
    {
      _dataObjectFactory = new SqlDataObjectFactory();
    }

    [Test]
    public void CreateConnection_ShouldReturnSqlConnection()
    {
      //ACT
      var connection = _dataObjectFactory.CreateConnection();

      //ASSERT
      Assert.IsInstanceOf<SqlConnection>(connection);
    }

    [Test]
    public void CreateCommand_ShouldReturnSqlCommand()
    {
      //ACT
      var command = _dataObjectFactory.CreateCommand();

      //ASSERT
      Assert.IsInstanceOf<SqlCommand>(command);
    }

    [Test]
    public void CreateDataParameter_ShouldReturnSqlParameter()
    {
      //ACT
      var parameter = _dataObjectFactory.CreateDataParameter();

      //ASSERT
      Assert.IsInstanceOf<SqlParameter>(parameter);
    }
  }
}