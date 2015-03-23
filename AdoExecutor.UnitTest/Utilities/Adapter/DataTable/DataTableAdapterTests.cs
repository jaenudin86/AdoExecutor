using System;
using System.Data;
using AdoExecutor.Utilities.Adapter.DataTable;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Utilities.Adapter.DataTable
{
  [TestFixture(Category = "Unit")]
  public class DataTableAdapterTests
  {
    private DataTableAdapter _dataTableAdapter;

    [SetUp]
    public void SetUp()
    {
      _dataTableAdapter = new DataTableAdapter();
    }

    [Test]
    public void Load_ShouldFillDataFromDataReader()
    {
      //ARRANGE
      var dataTable = new System.Data.DataTable("testName");
      dataTable.Columns.Add("testColumn1", typeof (string));
      dataTable.Columns.Add("testColumn2", typeof (int));

      dataTable.Rows.Add("testValueText", 5);
      dataTable.Rows.Add("testValueText1", 432);

      var dataTableReader = new DataTableReader(dataTable);

      //ACT
      var result = _dataTableAdapter.Load(dataTableReader);

      Assert.AreEqual(2, result.Columns.Count);
      Assert.AreEqual(dataTable.Columns[0].ColumnName, result.Columns[0].ColumnName);
      Assert.AreEqual(dataTable.Columns[0].DataType, result.Columns[0].DataType);

      Assert.AreEqual(2, result.Rows.Count);
      Assert.AreEqual(dataTable.Rows[0][0], result.Rows[0][0]);
      Assert.AreEqual(dataTable.Rows[0][1], result.Rows[0][1]);
      Assert.AreEqual(dataTable.Rows[1][0], result.Rows[1][0]);
      Assert.AreEqual(dataTable.Rows[1][1], result.Rows[1][1]);

      Guid tableNameId;
      Assert.IsTrue(Guid.TryParse(result.TableName, out tableNameId));
    }
  }
}