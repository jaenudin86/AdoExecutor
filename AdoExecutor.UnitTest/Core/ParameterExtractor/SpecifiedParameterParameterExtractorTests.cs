using System.Collections.Generic;
using System.Data;
using AdoExecutor.Core.Parameter;
using AdoExecutor.Core.ParameterExtractor;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.ParameterExtractor
{
  [TestFixture(Category = "Unit")]
  public class SpecifiedParameterParameterExtractorTests : ParameterExtractorTestsBase
  {
    private SpecifiedParameterParameterExtractor _parameterExtractor;

    [SetUp]
    public override void SetUp()
    {
      base.SetUp();

      _parameterExtractor = new SpecifiedParameterParameterExtractor();
    }

    [Test]
    public void CanProcess_ShouldReturnTrue_WhenParametersIsSpecifiedParameter()
    {
      //ARRANGE
      var context = CreateContext(new SpecifiedParameter("test"));

      //ACT
      var canProcess = _parameterExtractor.CanProcess(context);

      //ASSERT
      Assert.IsTrue(canProcess);
    }

    [Test]
    public void CanProcess_ShouldReturnTrue_WhenParametersIsSpecifiedParameterEnumerable()
    {
      //ARRANGE
      var context = CreateContext(new SpecifiedParameter[0]);

      //ACT
      var canProcess = _parameterExtractor.CanProcess(context);

      //ASSERT
      Assert.IsTrue(canProcess);
    }

    [Test]
    public void CanProcess_ShouldReturnFalse_WhenParametersTypeIsNotSpecifiedParameterOrSpecifiedParameterEnumerable()
    {
      //ARRANGE
      var context = CreateContext(new DataSet());

      //ACT
      var canProcess = _parameterExtractor.CanProcess(context);

      //ASSERT
      Assert.IsFalse(canProcess);
    }

    [Test]
    public void ExtractParameter_ShouldMapSpecifiedParameterToIDbDataParameter()
    {
      //ARRANGE
      var specifiedParameter = new SpecifiedParameter("testName", "testValue", DbType.String,
        ParameterDirection.InputOutput, 3, 4, 5);

      var context = CreateContext(specifiedParameter);

      var dataParameters = new List<IDbDataParameter>();
      CommandParametersFake.CallsTo(x => x.Add(A<object>._))
        .Invokes((object parameter) => dataParameters.Add((IDbDataParameter) parameter));

      //ACT
      _parameterExtractor.ExtractParameter(context);

      //ASSERT
      Assert.AreEqual(1, dataParameters.Count);
      AssertSpecifiedParameterWithDbDataParameter(specifiedParameter, dataParameters[0]);
    }

    [Test]
    public void ExtractParameter_ShouldMapSpecifiedParameterEnumerableToIDbDataParameter()
    {
      //ARRANGE
      var specifiedParameter1 = new SpecifiedParameter("testName", "testValue", DbType.String,
        ParameterDirection.InputOutput, 3, 4, 5);

      var specifiedParameter2 = new SpecifiedParameter("testName", 5436543, DbType.Int32,
        ParameterDirection.Output, 13, 14, 15);

      var specifiedParameters = new[] {specifiedParameter1, specifiedParameter2};

      var context = CreateContext(specifiedParameters);

      var dataParameters = new List<IDbDataParameter>();
      CommandParametersFake.CallsTo(x => x.Add(A<object>._))
        .Invokes((object parameter) => dataParameters.Add((IDbDataParameter) parameter));

      //ACT
      _parameterExtractor.ExtractParameter(context);

      //ASSERT
      Assert.AreEqual(2, dataParameters.Count);
      AssertSpecifiedParameterWithDbDataParameter(specifiedParameter1, dataParameters[0]);
      AssertSpecifiedParameterWithDbDataParameter(specifiedParameter2, dataParameters[1]);
    }

    private bool AssertSpecifiedParameterWithDbDataParameter(SpecifiedParameter specifiedParameter,
      IDbDataParameter dataParameter)
    {
      Assert.AreEqual(specifiedParameter.ParameterName, dataParameter.ParameterName);
      Assert.AreEqual(specifiedParameter.Value, dataParameter.Value);
      Assert.AreEqual(specifiedParameter.DbType.Value, dataParameter.DbType);
      Assert.AreEqual(specifiedParameter.Direction.Value, dataParameter.Direction);
      Assert.AreEqual(specifiedParameter.Precision.Value, dataParameter.Precision);
      Assert.AreEqual(specifiedParameter.Scale.Value, dataParameter.Scale);
      Assert.AreEqual(specifiedParameter.Size.Value, dataParameter.Size);

      return true;
    }
  }
}