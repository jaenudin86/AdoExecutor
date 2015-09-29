using System;
using AdoExecutor.IntegrationTest.Sql.Helpers.Extension;
using AdoExecutor.IntegrationTest.Sql.Helpers.TestData.Infrastructure;

namespace AdoExecutor.IntegrationTest.Sql.Helpers.TestData
{
  public class TestDataItem2 : ITestDataItem
  {
    public Guid Id
    {
      get { return new Guid("9AA3B743-0A67-4274-8470-F7E978DDC930"); }
    }

    public long BigInt
    {
      get { return 54354354; }
    }

    public byte[] Binary50
    {
      get
      {
        return "ABCDEF0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
          .ToByteArray();
      }
    }

    public bool Bit
    {
      get { return true; }
    }

    public string Char10
    {
      get { return "testChar1 "; }
    }

    public DateTime Date
    {
      get { return DateTime.Parse("2015-02-03"); }
    }

    public DateTime DateTime
    {
      get { return DateTime.Parse("2015-02-03 15:05:23.543"); }
    }

    public DateTime DateTime2
    {
      get { return DateTime.Parse("2015-02-03 15:05:23.5435430"); }
    }

    public DateTimeOffset DateTimeOffset
    {
      get { return DateTimeOffset.Parse("2015-02-03 15:05:23.5430000 +01:00"); }
    }

    public decimal Decimal
    {
      get { return 54.43243M; }
    }

    public double Float
    {
      get { return 214535.43D; }
    }

    public byte[] Image
    {
      get { return "57B3ACC5454565".ToByteArray(); }
    }

    public int Int
    {
      get { return 4321; }
    }

    public decimal Money
    {
      get { return 126.14M; }
    }

    public string NChar10
    {
      get { return "testNChar1"; }
    }

    public string NText
    {
      get { return "testNText1"; }
    }

    public decimal Numeric
    {
      get { return 43254.65400M; }
    }

    public string NVarchar50
    {
      get { return "testNVarchar1"; }
    }

    public float Real
    {
      get { return 654654.563F; }
    }

    public DateTime SmallDateTime
    {
      get { return DateTime.Parse("2015-02-12 23:05:00"); }
    }

    public short SmallInt
    {
      get { return 169; }
    }

    public decimal SmallMoney
    {
      get { return 3123.432M; }
    }

    public string Text
    {
      get { return "testText1"; }
    }

    public TimeSpan Time
    {
      get { return TimeSpan.Parse("23:05:19.0000000"); }
    }

    public byte TinyInt
    {
      get { return 168; }
    }

    public Guid Uniqueidentifier
    {
      get { return new Guid("270E8267-AA79-4E43-8910-EA45ABE62487"); }
    }

    public byte[] Varbinary50
    {
      get { return "AEFDCB".ToByteArray(); }
    }

    public string Varchar50
    {
      get { return "testVarchar1"; }
    }

    public string Xml
    {
      get { return "<test>5</test>"; }
    }
  }
}