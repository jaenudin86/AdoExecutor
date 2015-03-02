using System;
using AdoExecutor.Core.QueryFactory;
using AdoExecutor.Core.QueryFactory.Infrastructure;
using AdoExecutor.IntegrationTest.Sql.Extensions;
using NUnit.Framework;

namespace AdoExecutor.IntegrationTest.Sql.Dynamic
{
  [TestFixture(Category = "Integration Slow")]
  public class SelectToDynamic
  {
    private IQueryFactory _queryFactory;

    [SetUp]
    public void SetUp()
    {
      _queryFactory = new SqlQueryFactory("AdoExecutorTestDb");
    }

    [Test]
    public void SelectSingleRowWithSpecifiedId()
    {
      //ARRANGE
      const string queryText = "select * from dbo.TestDbType where id = @id";
      var query = _queryFactory.CreateQuery();

      //ACT
      var result = query.Select<dynamic>(queryText, new { id = new Guid("CDFC5A0B-74B4-4322-AE68-12A76A30AA09") });

      //ASSERT
      Assert.IsInstanceOf<Guid>(result.Id);
      Assert.AreEqual(new Guid("CDFC5A0B-74B4-4322-AE68-12A76A30AA09"), result.Id);

      Assert.IsInstanceOf<long>(result.BigInt);
      Assert.AreEqual(5643765856, result.BigInt);

      Assert.IsInstanceOf<byte[]>(result.Binary50);
      CollectionAssert.AreEqual("ABCDFE0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000".ToByteArray(), result.Binary50);

      Assert.IsInstanceOf<bool>(result.Bit);
      Assert.AreEqual(false, result.Bit);

      Assert.IsInstanceOf<string>(result.Char10);
      Assert.AreEqual("testChar2 ", result.Char10);

      Assert.IsInstanceOf<DateTime>(result.Date);
      Assert.AreEqual(DateTime.Parse("2011-06-25"), result.Date);

      Assert.IsInstanceOf<DateTime>(result.DateTime);
      Assert.AreEqual(DateTime.Parse("2011-04-26 12:13:14.000"), result.DateTime);

      Assert.IsInstanceOf<DateTime>(result.DateTime2);
      Assert.AreEqual(DateTime.Parse("2011-04-26 12:13:14.5432340"), result.DateTime2);

      Assert.IsInstanceOf<DateTimeOffset>(result.DateTimeOffset);
      Assert.AreEqual(DateTimeOffset.Parse("2011-04-26 12:13:14.5432340 +02:00"), result.DateTimeOffset);

      Assert.IsInstanceOf<decimal>(result.Decimal);
      Assert.AreEqual(543249.36548M, result.Decimal);

      Assert.IsInstanceOf<double>(result.Float);
      Assert.AreEqual(4564.4858D, result.Float);

      Assert.IsInstanceOf<byte[]>(result.Image);
      Assert.AreEqual("57897435454565".ToByteArray(), result.Image);

      Assert.IsInstanceOf<int>(result.Int);
      Assert.AreEqual(897698, result.Int);

      Assert.IsInstanceOf<decimal>(result.Money);
      Assert.AreEqual(156.2574M, result.Money);

      Assert.IsInstanceOf<string>(result.NChar10);
      Assert.AreEqual("testNChar2", result.NChar10);

      Assert.IsInstanceOf<string>(result.NText);
      Assert.AreEqual("testNText2", result.NText);

      Assert.IsInstanceOf<decimal>(result.Numeric);
      Assert.AreEqual(876.54354M, result.Numeric);

      Assert.IsInstanceOf<string>(result.NVarchar50);
      Assert.AreEqual("testNVarchar2", result.NVarchar50);

      Assert.IsInstanceOf<float>(result.Real);
      Assert.AreEqual(65877.57F, result.Real);

      Assert.IsInstanceOf<DateTime>(result.SmallDateTime);
      Assert.AreEqual(DateTime.Parse("2014-06-25 11:15:00"), result.SmallDateTime);

      Assert.IsInstanceOf<short>(result.SmallInt);
      Assert.AreEqual((short)765, result.SmallInt);

      Assert.IsInstanceOf<decimal>(result.SmallMoney);
      Assert.AreEqual(342.6547M, result.SmallMoney);

      Assert.IsInstanceOf<string>(result.Text);
      Assert.AreEqual("testText2", result.Text);

      Assert.IsInstanceOf<TimeSpan>(result.Time);
      Assert.AreEqual(TimeSpan.Parse("21:09:27.0000000"), result.Time);

      Assert.IsInstanceOf<byte>(result.TinyInt);
      Assert.AreEqual((byte)232, result.TinyInt);

      Assert.IsInstanceOf<Guid>(result.Uniqueidentifier);
      Assert.AreEqual(new Guid("CE9C740E-0EF6-48B5-8608-5FC93E3E92E7"), result.Uniqueidentifier);

      Assert.IsInstanceOf<byte[]>(result.Varbinary50);
      CollectionAssert.AreEqual("2F4B5A".ToByteArray(), result.Varbinary50);

      Assert.IsInstanceOf<string>(result.Varchar50);
      Assert.AreEqual("testVarchar2", result.Varchar50);

      Assert.IsInstanceOf<string>(result.Xml);
      Assert.AreEqual("<test>564</test>", result.Xml);
    }
  }
}