using System;

namespace AdoExecutor.IntegrationTest.Sql.Helpers.TestData.Infrastructure
{
  public interface ITestDataItem
  {
    Guid Id { get; }
    long BigInt { get; }
    byte[] Binary50 { get; }
    bool Bit { get; }
    string Char10 { get; }
    DateTime Date { get; }
    DateTime DateTime { get; }
    DateTime DateTime2 { get; }
    DateTimeOffset DateTimeOffset { get; }
    decimal Decimal { get; }
    double Float { get; }
    byte[] Image { get; }
    int Int { get; }
    decimal Money { get; }
    string NChar10 { get; }
    string NText { get; }
    decimal Numeric { get; }
    string NVarchar50 { get; }
    float Real { get; }
    DateTime SmallDateTime { get; }
    short SmallInt { get; }
    decimal SmallMoney { get; }
    string Text { get; }
    TimeSpan Time { get; }
    byte TinyInt { get; }
    Guid Uniqueidentifier { get; }
    byte[] Varbinary50 { get; }
    string Varchar50 { get; }
    string Xml { get; }
  }
}