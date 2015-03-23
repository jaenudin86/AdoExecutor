using System;
using System.Data;
using AdoExecutor.Core.Parameter;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.Parameter
{
  [TestFixture(Category = "Unit")]
  public class SpecifiedParameterTests
  {
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenParameterNameIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(() => new SpecifiedParameter(null));
    }

    [Test]
    public void Constructor_ShouldInitializeWithDefaultValues()
    {
      //ARRANGE
      const string parameterName = "testParameterName";
      const ParameterDirection direction = ParameterDirection.Input;

      //ACT
      var parameter = new SpecifiedParameter(parameterName);

      //ASSERT
      Assert.AreEqual(parameterName, parameter.ParameterName);
      Assert.IsNull(parameter.Value);
      Assert.IsNull(parameter.DbType);
      Assert.AreEqual(direction, parameter.Direction);
      Assert.IsNull(parameter.Precision);
      Assert.IsNull(parameter.Scale);
      Assert.IsNull(parameter.Size);
    }

    [Test]
    public void Constructor_ShouldInitializeWithSpecifiedValues()
    {
      //ARRANGE
      const string parameterName = "testParameterName";
      const int value = 4;
      const DbType dbType = DbType.Date;
      const ParameterDirection direction = ParameterDirection.Input;
      const byte precision = 4;
      const byte scale = 8;
      const int size = 3;

      //ACT
      var parameter = new SpecifiedParameter(parameterName, value, dbType, direction, precision, scale, size);

      //ASSERT
      Assert.AreEqual(parameterName, parameter.ParameterName);
      Assert.AreEqual(value, parameter.Value);
      Assert.AreEqual(dbType, parameter.DbType);
      Assert.AreEqual(direction, parameter.Direction);
      Assert.AreEqual(precision, parameter.Precision);
      Assert.AreEqual(scale, parameter.Scale);
      Assert.AreEqual(size, parameter.Size);
    }

    [Test]
    public void SetParameter_ShouldThrowArgumentNullException_WhenValueIsNull()
    {
      //ARRANGE
      const string parameterName = "testParameterName";
      var parameter = new SpecifiedParameter(parameterName);

      //ASSERT
      Assert.Throws<ArgumentNullException>(() => parameter.SetParameter(null));
    }

    [Test]
    public void GetOutputValue_ShouldReturnValueFromDataParameter()
    {
      //ARRANGE
      const string parameterName = "testParameterName";
      var parameter = new SpecifiedParameter(parameterName);

      const int value = 5;
      IDbDataParameter dataParameter = A.Fake<IDbDataParameter>();
      dataParameter.CallsTo(x => x.Value)
        .Returns(value);

      //ACT
      parameter.SetParameter(dataParameter);
      var valueFromParameter = parameter.GetOutputValue<int>();

      //ASSERT
      Assert.AreEqual(value, valueFromParameter);
      dataParameter.CallsTo(x => x.Value)
        .MustHaveHappened(Repeated.Exactly.Once);
    }
  }
}