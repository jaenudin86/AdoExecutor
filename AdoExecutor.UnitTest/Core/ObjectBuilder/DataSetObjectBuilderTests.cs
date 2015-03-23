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
  public class DataSetObjectBuilderTests : ObjectBuilderTestsBase
  {
    private DataSetObjectBuilder _dataSetObjectBuilder;
    private IDataTableAdapter _dataTableAdapterFake;

    [SetUp]
    public void SetUp()
    {
      _dataTableAdapterFake = A.Fake<IDataTableAdapter>();
      _dataSetObjectBuilder = new DataSetObjectBuilder(_dataTableAdapterFake);
    }

    [Test]
    public void Constructor_ShouldThrownArgumentNullException_WhenAnyParameterIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(() => new DataSetObjectBuilder(null));
    }

    [Test]
    public void CanProcess_ShouldReturnTrue_WhenContextResultTypeIsDataSet()
    {
      //ARRANGE
      var context = CreateContext(typeof (DataSet), A.Fake<IDataReader>());

      //ACT
      var canProcess = _dataSetObjectBuilder.CanProcess(context);

      //ASSERT
      Assert.IsTrue(canProcess);
    }

    [Test]
    [TestCase(typeof (int))]
    [TestCase(typeof (string))]
    [TestCase(typeof (object))]
    public void CanProcess_ShouldReturnFalse_WhenContextResultTypeIsNotDataSet(Type resultType)
    {
      //ARRANGE
      var context = CreateContext(resultType, A.Fake<IDataReader>());

      //ACT
      var canProcess = _dataSetObjectBuilder.CanProcess(context);

      //ASSERT
      Assert.IsFalse(canProcess);
    }

    [Test]
    public void CreateInstance_ShouldReturnEmptyDataSet_WhenDataReaderHasNotResult()
    {
      //ARRANGE
      var dataReader = A.Fake<IDataReader>();
      dataReader.CallsTo(x => x.NextResult())
        .Returns(false);

      var context = CreateContext(typeof (DataSet), dataReader);

      //ACT
      var dataSet = (DataSet) _dataSetObjectBuilder.CreateInstance(context);

      //ASSERT
      Assert.AreEqual(0, dataSet.Tables.Count);
    }

    [Test]
    public void CreateInstance_ShouldReturnEmptyDataSet_WhenReaderIsClosed()
    {
      //ARRANGE
      var dataReader = A.Fake<IDataReader>();
      dataReader.CallsTo(x => x.IsClosed)
        .Returns(false);

      var context = CreateContext(typeof (DataSet), dataReader);

      //ACT
      var dataSet = (DataSet) _dataSetObjectBuilder.CreateInstance(context);

      //ASSERT
      Assert.AreEqual(0, dataSet.Tables.Count);
    }

    [Test]
    public void CreateInstance_ShouldReturnDataSetWithSingleDataTable_WhenReaderHasOneResultSet()
    {
      //ARRANGE
      const string columnName = "testColumn";
      var columnType = typeof (string);
      const string testValue = "testValue";

      var dataTable = new DataTable();
      dataTable.Columns.Add(columnName, columnType);
      dataTable.Rows.Add(testValue);

      _dataTableAdapterFake.CallsTo(x => x.Load(A<IDataReader>._))
        .Returns(dataTable);

      var dataReaderFake = A.Fake<IDataReader>();
      dataReaderFake.CallsTo(x => x.FieldCount)
        .Returns(1);

      var context = CreateContext(typeof (DataSet), dataReaderFake);

      //ACT
      var dataSet = (DataSet) _dataSetObjectBuilder.CreateInstance(context);

      //ASSERT
      Assert.AreEqual(1, dataSet.Tables.Count);

      Assert.AreEqual(1, dataSet.Tables[0].Columns.Count);
      Assert.AreEqual(columnName, dataSet.Tables[0].Columns[0].ColumnName);
      Assert.AreEqual(columnType, dataSet.Tables[0].Columns[0].DataType);
      Assert.AreEqual(1, dataSet.Tables[0].Rows.Count);
    }

    [Test]
    public void CreateInstance_ShouldReturnDataSetWithThreeDataTAbles_WhenReaderHasThreeResultSet()
    {
      //ARRANGE
      const string columnName = "testColumn";
      var columnType = typeof (string);
      const string testValue = "testValue";

      Func<DataTable> createDataTableFunc = () =>
      {
        var dataTable = new DataTable();
        dataTable.TableName = Guid.NewGuid().ToString();
        dataTable.Columns.Add(columnName, columnType);
        dataTable.Rows.Add(testValue);
        return dataTable;
      };

      _dataTableAdapterFake.CallsTo(x => x.Load(A<IDataReader>._))
        .ReturnsLazily(x => createDataTableFunc());

      var dataReaderFake = A.Fake<IDataReader>();
      dataReaderFake.CallsTo(x => x.FieldCount)
        .Returns(1);

      var returnResultSet = 0;
      dataReaderFake.CallsTo(x => x.NextResult())
        .ReturnsLazily(x => ++returnResultSet < 3);

      var context = CreateContext(typeof (DataSet), dataReaderFake);

      //ACT
      var dataSet = (DataSet) _dataSetObjectBuilder.CreateInstance(context);

      //ASSERT
      Assert.AreEqual(3, dataSet.Tables.Count);

      var dataTable1 = dataSet.Tables[0];
      Assert.AreEqual(1, dataTable1.Columns.Count);
      Assert.AreEqual(columnName, dataTable1.Columns[0].ColumnName);
      Assert.AreEqual(columnType, dataTable1.Columns[0].DataType);
      Assert.AreEqual(1, dataTable1.Rows.Count);
      Assert.AreEqual(testValue, dataTable1.Rows[0][0]);

      var dataTable2 = dataSet.Tables[0];
      Assert.AreEqual(1, dataTable2.Columns.Count);
      Assert.AreEqual(columnName, dataTable2.Columns[0].ColumnName);
      Assert.AreEqual(columnType, dataTable2.Columns[0].DataType);
      Assert.AreEqual(1, dataTable2.Rows.Count);
      Assert.AreEqual(testValue, dataTable2.Rows[0][0]);

      var dataTable3 = dataSet.Tables[0];
      Assert.AreEqual(1, dataTable3.Columns.Count);
      Assert.AreEqual(columnName, dataTable3.Columns[0].ColumnName);
      Assert.AreEqual(columnType, dataTable3.Columns[0].DataType);
      Assert.AreEqual(1, dataTable3.Rows.Count);
      Assert.AreEqual(testValue, dataTable3.Rows[0][0]);
    }
  }
}