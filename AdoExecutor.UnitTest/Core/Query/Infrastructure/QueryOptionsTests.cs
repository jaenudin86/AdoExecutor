using System;
using System.Data;
using AdoExecutor.Core.Query.Infrastructure;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.Query.Infrastructure
{
  [TestFixture(Category = "Unit")]
  public class QueryOptionsTests
  {
    [Test]
    public void SetTimeout_ShouldSetTimeoutFromTimeSpan()
    {
      //ARRANGE
      TimeSpan time = TimeSpan.FromSeconds(200);

      //ACT
      var queryOptions = QueryOptions.SetTimeout(time);

      //ASSERT
      Assert.IsNotNull(queryOptions.Timeout);
      Assert.AreEqual(time, queryOptions.Timeout);
      Assert.IsNull(queryOptions.CommandType);
    }

    [Test]
    public void SetTimeout_ShouldSetTimeoutFromSeconds()
    {
      //ARRANGE
      const int seconds = 150;

      //ACT
      var queryOptions = QueryOptions.SetTimeout(seconds);

      //ASSERT
      Assert.IsNotNull(queryOptions.Timeout);
      Assert.AreEqual(seconds, queryOptions.Timeout.Value.TotalSeconds);
      Assert.IsNull(queryOptions.CommandType);
    }

    [Test]
    public void SetCommandType_ShouldSetCommandType()
    {
      //ARRANGE
      const CommandType commandType = CommandType.TableDirect;

      //ACT
      var queryOptions = QueryOptions.SetCommandType(commandType);

      //ASSERT
      Assert.IsNotNull(queryOptions.CommandType);
      Assert.AreEqual(commandType, queryOptions.CommandType);
      Assert.IsNull(queryOptions.Timeout);
    }
  }
}