using System;
using System.Data;
using AdoExecutor.IntegrationTest.Sql.Helper.TestDbTypeTable;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Select
{
  public abstract class DataTableRowAssertBase
  {
    protected virtual void AssertSingleDynamicObjectWithSingleRow(ITestDbTypeTableRow row, DataRow singleResultDataRow)
    {
      Assert.IsInstanceOf<Guid>(singleResultDataRow["Id"]);
      Assert.AreEqual(row.Id, singleResultDataRow["Id"]);

      Assert.IsInstanceOf<long>(singleResultDataRow["BigInt"]);
      Assert.AreEqual(row.BigInt, singleResultDataRow["BigInt"]);

      Assert.IsInstanceOf<byte[]>(singleResultDataRow["Binary50"]);
      CollectionAssert.AreEqual(row.Binary50, (byte[])singleResultDataRow["Binary50"]);

      Assert.IsInstanceOf<bool>(singleResultDataRow["Bit"]);
      Assert.AreEqual(row.Bit, singleResultDataRow["Bit"]);

      Assert.IsInstanceOf<string>(singleResultDataRow["Char10"]);
      Assert.AreEqual(row.Char10, singleResultDataRow["Char10"]);

      Assert.IsInstanceOf<DateTime>(singleResultDataRow["Date"]);
      Assert.AreEqual(row.Date, singleResultDataRow["Date"]);

      Assert.IsInstanceOf<DateTime>(singleResultDataRow["DateTime"]);
      Assert.AreEqual(row.DateTime, singleResultDataRow["DateTime"]);

      Assert.IsInstanceOf<DateTime>(singleResultDataRow["DateTime2"]);
      Assert.AreEqual(row.DateTime2, singleResultDataRow["DateTime2"]);

      Assert.IsInstanceOf<DateTimeOffset>(singleResultDataRow["DateTimeOffset"]);
      Assert.AreEqual(row.DateTimeOffset, singleResultDataRow["DateTimeOffset"]);

      Assert.IsInstanceOf<decimal>(singleResultDataRow["Decimal"]);
      Assert.AreEqual(row.Decimal, singleResultDataRow["Decimal"]);

      Assert.IsInstanceOf<double>(singleResultDataRow["Float"]);
      Assert.AreEqual(row.Float, singleResultDataRow["Float"]);

      Assert.IsInstanceOf<byte[]>(singleResultDataRow["Image"]);
      Assert.AreEqual(row.Image, singleResultDataRow["Image"]);

      Assert.IsInstanceOf<int>(singleResultDataRow["Int"]);
      Assert.AreEqual(row.Int, singleResultDataRow["Int"]);

      Assert.IsInstanceOf<decimal>(singleResultDataRow["Money"]);
      Assert.AreEqual(row.Money, singleResultDataRow["Money"]);

      Assert.IsInstanceOf<string>(singleResultDataRow["NChar10"]);
      Assert.AreEqual(row.NChar10, singleResultDataRow["NChar10"]);

      Assert.IsInstanceOf<string>(singleResultDataRow["NText"]);
      Assert.AreEqual(row.NText, singleResultDataRow["NText"]);

      Assert.IsInstanceOf<decimal>(singleResultDataRow["Numeric"]);
      Assert.AreEqual(row.Numeric, singleResultDataRow["Numeric"]);

      Assert.IsInstanceOf<string>(singleResultDataRow["NVarchar50"]);
      Assert.AreEqual(row.NVarchar50, singleResultDataRow["NVarchar50"]);

      Assert.IsInstanceOf<float>(singleResultDataRow["Real"]);
      Assert.AreEqual(row.Real, singleResultDataRow["Real"]);

      Assert.IsInstanceOf<DateTime>(singleResultDataRow["SmallDateTime"]);
      Assert.AreEqual(row.SmallDateTime, singleResultDataRow["SmallDateTime"]);

      Assert.IsInstanceOf<short>(singleResultDataRow["SmallInt"]);
      Assert.AreEqual(row.SmallInt, singleResultDataRow["SmallInt"]);

      Assert.IsInstanceOf<decimal>(singleResultDataRow["SmallMoney"]);
      Assert.AreEqual(row.SmallMoney, singleResultDataRow["SmallMoney"]);

      Assert.IsInstanceOf<string>(singleResultDataRow["Text"]);
      Assert.AreEqual(row.Text, singleResultDataRow["Text"]);

      Assert.IsInstanceOf<TimeSpan>(singleResultDataRow["Time"]);
      Assert.AreEqual(row.Time, singleResultDataRow["Time"]);

      Assert.IsInstanceOf<byte>(singleResultDataRow["TinyInt"]);
      Assert.AreEqual(row.TinyInt, singleResultDataRow["TinyInt"]);

      Assert.IsInstanceOf<Guid>(singleResultDataRow["Uniqueidentifier"]);
      Assert.AreEqual(row.Uniqueidentifier, singleResultDataRow["Uniqueidentifier"]);

      Assert.IsInstanceOf<byte[]>(singleResultDataRow["Varbinary50"]);
      CollectionAssert.AreEqual(row.Varbinary50, (byte[])singleResultDataRow["Varbinary50"]);

      Assert.IsInstanceOf<string>(singleResultDataRow["Varchar50"]);
      Assert.AreEqual(row.Varchar50, singleResultDataRow["Varchar50"]);

      Assert.IsInstanceOf<string>(singleResultDataRow["Xml"]);
      Assert.AreEqual(row.Xml, singleResultDataRow["Xml"]);
    }
  }
}