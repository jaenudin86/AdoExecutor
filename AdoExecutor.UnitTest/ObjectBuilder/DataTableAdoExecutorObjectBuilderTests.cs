using System;
using System.Data;
using AdoExecutor.Core.ObjectBuilder;
using AdoExecutor.Infrastructure.Configuration;
using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.ObjectBuilder;
using FakeItEasy;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.ObjectBuilder
{
  [TestFixture]
  public class DataTableAdoExecutorObjectBuilderTests
  {
    private DataTableAdoExecutorObjectBuilder _objectBuilder;

    [SetUp]
    public void SetUp()
    {
      _objectBuilder = new DataTableAdoExecutorObjectBuilder();
    }

    [Test]
    public void CanProcess_ShouldReturnTrue_WhenResultTypeIsDataTable()
    {
      //ARRANGE
      var context = new AdoExecutorObjectBuilderContext(
        "test",
        null,
        typeof (DataTable),
        AdoExecutorInvokeMethod.Select,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IAdoExecutorConfiguration>(),
        A.Fake<IDataReader>());

      //ACT
      bool canProcess = _objectBuilder.CanProcess(context);

      //ASSERT
      Assert.IsTrue(canProcess);
    }

    [Test]
    [TestCase(typeof(string))]
    [TestCase(typeof(DataSet))]
    [TestCase(typeof(int))]
    public void CanProcess_ShouldReturnFalse_WhenResultTypeIsNotDataTable(Type resultType)
    {
      //ARRANGE
      var context = new AdoExecutorObjectBuilderContext(
        "test",
        null,
        resultType,
        AdoExecutorInvokeMethod.Select,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IAdoExecutorConfiguration>(),
        A.Fake<IDataReader>());

      //ACT
      bool canProcess = _objectBuilder.CanProcess(context);

      //ASSERT
      Assert.IsFalse(canProcess);
    }

    [Test]
    public void CreateInstance_ShouldReturnDataTableCreatedFromDataReader()
    {
      //ARRANGE
      var sourceDataTable = new DataTable();
      sourceDataTable.Columns.Add("column1", typeof (string));
      sourceDataTable.Columns.Add("column2", typeof (int));

      sourceDataTable.Rows.Add("row1", 1);
      sourceDataTable.Rows.Add("row2", 2);
      sourceDataTable.Rows.Add("row3", 3);

      var dataReader = new DataTableReader(sourceDataTable);

      var context = new AdoExecutorObjectBuilderContext(
        "test",
        null,
        typeof(DataTable),
        AdoExecutorInvokeMethod.Select,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IAdoExecutorConfiguration>(),
        dataReader);

      //ACT
      object instance = _objectBuilder.CreateInstance(context);

      //ASSERT
      Assert.IsInstanceOf<DataTable>(instance);

      var resultDataTable = (DataTable) instance;

      Assert.AreEqual("column1", resultDataTable.Columns[0].ColumnName);
      Assert.AreEqual(typeof(string), resultDataTable.Columns[0].DataType);
      Assert.AreEqual("column2", resultDataTable.Columns[1].ColumnName);
      Assert.AreEqual(typeof(int), resultDataTable.Columns[1].DataType);

      Assert.AreEqual("row1", resultDataTable.Rows[0]["column1"]);
      Assert.AreEqual(1, resultDataTable.Rows[0]["column2"]);
      Assert.AreEqual("row2", resultDataTable.Rows[1]["column1"]);
      Assert.AreEqual(2, resultDataTable.Rows[1]["column2"]);
      Assert.AreEqual("row3", resultDataTable.Rows[2]["column1"]);
      Assert.AreEqual(3, resultDataTable.Rows[2]["column2"]);
    }
  }
}