using System;
using System.Data;
using AdoExecutor.Core.Configuration.Infrastructure;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using FakeItEasy;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.ObjectBuilder
{
  [TestFixture(Category = "Unit")]
  public abstract class ObjectBuilderTestsBase
  {
    protected virtual ObjectBuilderContext CreateContext(Type resultType, IDataReader dataReader)
    {
      return new ObjectBuilderContext(
        "testQuery",
        null,
        resultType,
        InvokeMethod.Select,
        A.Fake<IDbConnection>(),
        A.Fake<IDbCommand>(),
        A.Fake<IConfiguration>(),
        dataReader);
    }
  }
}