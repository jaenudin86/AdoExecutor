using System;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData.Infrastructure;

namespace AdoExecutor.IntegrationTest.Sql.Helpers.TestData
{
  public class TestDataItemNull : ITestDataItem
  {
    public Guid Id
    {
      get { return new Guid("9B85F633-F58B-468B-82F0-99F089A89C47"); }
    }

    public long? BigInt
    {
      get { return null; }
    }

    public byte[] Binary50
    {
      get { return null; }
    }

    public bool? Bit
    {
      get { return null; }
    }

    public string Char10
    {
      get { return null; }
    }

    public DateTime? Date
    {
      get { return null; }
    }

    public DateTime? DateTime
    {
      get { return null; }
    }

    public DateTime? DateTime2
    {
      get { return null; }
    }

    public DateTimeOffset? DateTimeOffset
    {
      get { return null; }
    }

    public decimal? Decimal
    {
      get { return null; }
    }

    public double? Float
    {
      get { return null; }
    }

    public byte[] Image
    {
      get { return null; }
    }

    public int? Int
    {
      get { return null; }
    }

    public decimal? Money
    {
      get { return null; }
    }

    public string NChar10
    {
      get { return null; }
    }

    public string NText
    {
      get { return null; }
    }

    public decimal? Numeric
    {
      get { return null; }
    }

    public string NVarchar50
    {
      get { return null; }
    }

    public float? Real
    {
      get { return null; }
    }

    public DateTime? SmallDateTime
    {
      get { return null; }
    }

    public short? SmallInt
    {
      get { return null; }
    }

    public decimal? SmallMoney
    {
      get { return null; }
    }

    public string Text
    {
      get { return null; }
    }

    public TimeSpan? Time
    {
      get { return null; }
    }

    public byte? TinyInt
    {
      get { return null; }
    }

    public Guid? Uniqueidentifier
    {
      get { return null; }
    }

    public byte[] Varbinary50
    {
      get { return null; }
    }

    public string Varchar50
    {
      get { return null; }
    }

    public string Xml
    {
      get { return null; }
    }
  }
}