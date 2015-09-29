using System;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.PassParameter
{
  public abstract class PassParameterBase
  {
    protected virtual void AssertSingleDynamicObjectWithSingleRow(ITestDbTypeTableRow row, dynamic singleResult)
    {
      Assert.AreEqual(row.BigInt, singleResult.BigInt);
      CollectionAssert.AreEqual(row.Binary50, singleResult.Binary50);
      Assert.AreEqual(row.Bit, singleResult.Bit);
      Assert.AreEqual(row.Char10, singleResult.Char10);
      Assert.AreEqual(row.Date, singleResult.Date);
      Assert.AreEqual(row.DateTime, singleResult.DateTime);
      //WARNING: Default sql DateTime / DateTime2 sql type is DateTime so value is round by .003 ms.
      Assert.AreEqual(DateTime.Parse(row.DateTime2.ToString("yyyy-MM-dd hh:mm:ss.fff")), singleResult.DateTime2);
      Assert.AreEqual(row.DateTimeOffset, singleResult.DateTimeOffset);
      Assert.AreEqual(row.Decimal, singleResult.Decimal);
      Assert.AreEqual(row.Float, singleResult.Float);
      Assert.AreEqual(row.Image, singleResult.Image);
      Assert.AreEqual(row.Int, singleResult.Int);
      Assert.AreEqual(row.Money, singleResult.Money);
      Assert.AreEqual(row.NChar10, singleResult.NChar10);
      Assert.AreEqual(row.NText, singleResult.NText);
      Assert.AreEqual(row.Numeric, singleResult.Numeric);
      Assert.AreEqual(row.NVarchar50, singleResult.NVarchar50);
      Assert.AreEqual(row.Real, singleResult.Real);
      Assert.AreEqual(row.SmallDateTime, singleResult.SmallDateTime);
      Assert.AreEqual(row.SmallInt, singleResult.SmallInt);
      Assert.AreEqual(row.SmallMoney, singleResult.SmallMoney);
      Assert.AreEqual(row.Text, singleResult.Text);
      Assert.AreEqual(row.Time, singleResult.Time);
      Assert.AreEqual(row.TinyInt, singleResult.TinyInt);
      Assert.AreEqual(row.Uniqueidentifier, singleResult.Uniqueidentifier);
      CollectionAssert.AreEqual(row.Varbinary50, singleResult.Varbinary50);
      Assert.AreEqual(row.Varchar50, singleResult.Varchar50);
      Assert.AreEqual(row.Xml, singleResult.Xml);
    }
  }
}