﻿using System;
using System.Data;
using AdoExecutor.Core.DataObjectFactory.Infrastructure;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ParameterExtractor;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.ParameterExtractor
{
  [TestFixture(Category = "Unit")]
  public class EnumerableParameterExtractorTests : ParameterExtractorTestsBase
  {
    private EnumerableParameterExtractor _parameterExtractor;

    [SetUp]
    public override void SetUp()
    {
      base.SetUp();

      _parameterExtractor = new EnumerableParameterExtractor(SqlPrimitiveDataTypesFake);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenAnyArgumentsIsNull()
    {
      Assert.Throws<ArgumentNullException>(() => new EnumerableParameterExtractor(null));
    }

    [Test]
    public void CanProcess_ShouldReturnTrue_WhenParametersTypeIsEnumerable()
    {
      //ARRANGE
      var context = CreateContext(new string[0]);

      //ACT
      var canProcess = _parameterExtractor.CanProcess(context);

      //ASSERT
      Assert.IsTrue(canProcess);
    }

    [Test]
    public void CanProcess_ShouldReturnFalse_WhenParametersTypeIsNotEnumerableAndIsNotPrimitiveType()
    {
      //ARRANGE
      var context = CreateContext(new DataSet());

      //ACT
      var canProcess = _parameterExtractor.CanProcess(context);

      //ASSERT
      Assert.IsFalse(canProcess);
    }

    [Test]
    public void CanProcess_ShouldReturnFalse_WhenParametersTypeIsEnumerableAndIsPrimitiveType()
    {
      //ARRANGE
      var context = CreateContext(new string[0]);
      SqlPrimitiveDataTypesFake.CallsTo(x => x.IsSqlPrimitiveType(A<Type>._))
        .Returns(true);

      //ACT
      var canProcess = _parameterExtractor.CanProcess(context);

      //ASSERT
      Assert.IsFalse(canProcess);
    }

    [Test]
    public void ExtractParameter_ShouldThrowAdoExecutorException_WhenItemIsNull()
    {
      //ARRANGE
      var array = new object[] {null};
      var context = CreateContext(array);

      //ASSERT
      Assert.Throws<AdoExecutorException>(() => _parameterExtractor.ExtractParameter(context));
    }

    [Test]
    public void ExtrtactParameter_ShouldThrowAdoExecutorException_WhenParameterTypeIsNotPrimitive()
    {
      //ARRANGE
      var array = new object[] {new DataSet()};
      var context = CreateContext(array);

      //ASSERT
      Assert.Throws<AdoExecutorException>(() => _parameterExtractor.ExtractParameter(context));
    }

    [Test]
    public void ExtractParameter_ShouldAddEqualParametersThanArrayItems()
    {
      //ARRANGE
      const string firstItem = "test1";
      const int secondItem = 2;

      var array = new object[] {firstItem, secondItem};
      var context = CreateContext(array);

      var dataObjectFactory = A.Fake<IDataObjectFactory>();
      ConfigurationFake.CallsTo(x => x.DataObjectFactory)
        .Returns(dataObjectFactory);

      var dataParameterCollectionFake = A.Fake<IDataParameterCollection>();
      CommandFake.CallsTo(x => x.Parameters)
        .Returns(dataParameterCollectionFake);

      SqlPrimitiveDataTypesFake.CallsTo(x => x.IsSqlPrimitiveType(A<Type>._))
        .Returns(true);

      //ACT
      _parameterExtractor.ExtractParameter(context);

      //ASSERT
      dataParameterCollectionFake.CallsTo(
        x => x.Add(A<IDbDataParameter>.That.Matches(
          parameter => parameter.ParameterName == "0" && (string) parameter.Value == firstItem)))
        .MustHaveHappened(Repeated.Exactly.Once);

      dataParameterCollectionFake.CallsTo(
        x => x.Add(A<IDbDataParameter>.That.Matches(
          parameter => parameter.ParameterName == "1" && (int) parameter.Value == secondItem)))
        .MustHaveHappened(Repeated.Exactly.Once);

      dataObjectFactory.CallsTo(x => x.CreateDataParameter())
        .MustHaveHappened(Repeated.Exactly.Twice);
    }
  }
}