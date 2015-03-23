using System;
using System.Data;
using AdoExecutor.Core.ObjectBuilder;
using AdoExecutor.Utilities.Adapter.DataTable.Infrastructure;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.ObjectBuilder
{
  [TestFixture(Category = "Unit")]
  public class DataTableObjectBuilderTests : ObjectBuilderTestsBase
  {
    private IDataTableAdapter _dataTableAdapter;
    private DataTableObjectBuilder _objectBuilder;

    [SetUp]
    public void SetUp()
    {
      _dataTableAdapter = A.Fake<IDataTableAdapter>();
      _objectBuilder = new DataTableObjectBuilder(_dataTableAdapter);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenAnyParameterIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(() => new DataTableObjectBuilder(null));
    }

    [Test]
    public void CanProcess_ShouldReturnTrue_WhenResultTypeIsDataTable()
    {
      //ARRANGE
      var context = CreateContext(typeof (DataTable), A.Fake<IDataReader>());

      //ACT
      var canProcess = _objectBuilder.CanProcess(context);

      //ASSERT
      Assert.IsTrue(canProcess);
    }

    [Test]
    [TestCase(typeof (int))]
    [TestCase(typeof (string))]
    [TestCase(typeof (Tuple<string, int>))]
    public void CanProcess_ShouldReturnFalse_WhenResultTypeIsNotDataTable(Type resultType)
    {
      //ARRANGE
      var context = CreateContext(resultType, A.Fake<IDataReader>());

      //ACT
      var canProcess = _objectBuilder.CanProcess(context);

      //ASSERT
      Assert.IsFalse(canProcess);
    }

    [Test]
    public void CreateInstance_ShouldCreateInstanceFromDataTableAdapter()
    {
      //ARRANGE
      var dataReader = A.Fake<IDataReader>();
      var context = CreateContext(typeof (DataTable), dataReader);

      var objectInstance = new DataTable();
      _dataTableAdapter.CallsTo(x => x.Load(dataReader))
        .Returns(objectInstance);

      //ACT
      var instance = _objectBuilder.CreateInstance(context);

      //ASSERT
      Assert.AreSame(objectInstance, instance);
      _dataTableAdapter.CallsTo(x => x.Load(dataReader))
        .MustHaveHappened(Repeated.Exactly.Once);
    }
  }
}