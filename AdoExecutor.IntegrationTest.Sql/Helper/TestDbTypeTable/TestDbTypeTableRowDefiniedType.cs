using System;

namespace AdoExecutor.IntegrationTest.Sql.Helper.TestDbTypeTable
{
  public class TestDbTypeTableRowDefiniedType : ITestDbTypeTableRow
  {
    public Guid Id { get; set; }
    public long BigInt { get; set; }
    public byte[] Binary50 { get; set; }
    public bool Bit { get; set; }
    public string Char10 { get; set; }
    public DateTime Date { get; set; }
    public DateTime DateTime { get; set; }
    public DateTime DateTime2 { get; set; }
    public DateTimeOffset DateTimeOffset { get; set; }
    public decimal Decimal { get; set; }
    public double Float { get; set; }
    public byte[] Image { get; set; }
    public int Int { get; set; }
    public decimal Money { get; set; }
    public string NChar10 { get; set; }
    public string NText { get; set; }
    public decimal Numeric { get; set; }
    public string NVarchar50 { get; set; }
    public float Real { get; set; }
    public DateTime SmallDateTime { get; set; }
    public short SmallInt { get; set; }
    public decimal SmallMoney { get; set; }
    public string Text { get; set; }
    public TimeSpan Time { get; set; }
    public byte TinyInt { get; set; }
    public Guid Uniqueidentifier { get; set; }
    public byte[] Varbinary50 { get; set; }
    public string Varchar50 { get; set; }
    public string Xml { get; set; }
  }
}