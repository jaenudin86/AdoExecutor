using System;
using AdoExecutor.IntegrationTest.Sql.Helpers.Extension;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData.Infrastructure;

namespace AdoExecutor.IntegrationTest.Sql.Helpers.TestData
{
  public class TestDataItem1 : ITestDataItem
  {
    public Guid Id
    {
      get { return new Guid("CDFC5A0B-74B4-4322-AE68-12A76A30AA09"); }
    }

    public long BigInt
    {
      get { return 5643765856; }
    }

    public byte[] Binary50
    {
      get
      {
        return "ABCDFE0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
          .ToByteArray();
      }
    }

    public bool Bit
    {
      get { return false; }
    }

    public string Char10
    {
      get { return "testChar2 "; }
    }

    public DateTime Date
    {
      get { return DateTime.Parse("2011-06-25"); }
    }

    public DateTime DateTime
    {
      get { return DateTime.Parse("2011-04-26 12:13:14.000"); }
    }

    public DateTime DateTime2
    {
      get { return DateTime.Parse("2011-04-26 12:13:14.5432340"); }
    }

    public DateTimeOffset DateTimeOffset
    {
      get { return DateTimeOffset.Parse("2011-04-26 12:13:14.5432340 +02:00"); }
    }

    public decimal Decimal
    {
      get { return 543249.36548M; }
    }

    public double Float
    {
      get { return 4564.4858D; }
    }

    public byte[] Image
    {
      get { return "57897435454565".ToByteArray(); }
    }

    public int Int
    {
      get { return 897698; }
    }

    public decimal Money
    {
      get { return 156.2574M; }
    }

    public string NChar10
    {
      get { return "testNChar2"; }
    }

    public string NText
    {
      get { return "testNText2"; }
    }

    public decimal Numeric
    {
      get { return 876.54354M; }
    }

    public string NVarchar50
    {
      get { return "testNVarchar2"; }
    }

    public float Real
    {
      get { return 65877.57F; }
    }

    public DateTime SmallDateTime
    {
      get { return DateTime.Parse("2014-06-25 11:15:00"); }
    }

    public short SmallInt
    {
      get { return 765; }
    }

    public decimal SmallMoney
    {
      get { return 342.6547M; }
    }

    public string Text
    {
      get { return "testText2"; }
    }

    public TimeSpan Time
    {
      get { return TimeSpan.Parse("21:09:27.0000000"); }
    }

    public byte TinyInt
    {
      get { return 232; }
    }

    public Guid Uniqueidentifier
    {
      get { return new Guid("CE9C740E-0EF6-48B5-8608-5FC93E3E92E7"); }
    }

    public byte[] Varbinary50
    {
      get { return "2F4B5A".ToByteArray(); }
    }

    public string Varchar50
    {
      get { return "testVarchar2"; }
    }

    public string Xml
    {
      get { return "<test>564</test>"; }
    }
  }
}