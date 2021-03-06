﻿using System;
using System.Collections.Generic;
using System.Data;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.DataObjectFactory.Infrastructure;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ParameterExtractor;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.ParameterExtractor
{
  [TestFixture(Category = "Unit")]
  public class DictionaryParameterExtractorTests : ParameterExtractorTestsBase
  {
    private DictionaryParameterExtractor _parameterExtractor;

    [SetUp]
    public override void SetUp()
    {
      base.SetUp();

      _parameterExtractor = new DictionaryParameterExtractor(SqlPrimitiveDataTypesFake);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenAnyArgumentsIsNull()
    {
      Assert.Throws<ArgumentNullException>(() => new DictionaryParameterExtractor(null));
    }

    [Test]
    public void CanProcess_ShouldReturnTrue_WhenParametersTypeIsDictionary()
    {
      //ARRANGE
      var context = CreateContext(new Dictionary<string, object>());

      //ACT
      var canProcess = _parameterExtractor.CanProcess(context);

      //ASSERT
      Assert.IsTrue(canProcess);
    }

    [Test]
    public void CanProcess_ShouldReturnFalse_WhenParametersTypeIsNotDictionary()
    {
      //ARRANGE
      var context = CreateContext(new DataSet());

      //ACT
      var canProcess = _parameterExtractor.CanProcess(context);

      //ASSERT
      Assert.IsFalse(canProcess);
    }

    [Test]
    public void ExtractParameter_ShouldThrowAdoExecutorException_WhenParameterKeyIsStringEmpty()
    {
      //ARRANGE
      var dictionary = new Dictionary<string, object>();
      dictionary[string.Empty] = "testValue";
      var context = CreateContext(dictionary);

      //ASSERT
      Assert.Throws<AdoExecutorException>(() => _parameterExtractor.ExtractParameter(context));
    }

    [Test]
    public void ExtractParameter_ShouldThrowAdoExecutorException_WhenParameterValueIsNull()
    {
      //ARRANGE
      var dictionary = new Dictionary<string, object>();
      dictionary["testParameter"] = null;
      var context = CreateContext(dictionary);

      //ASSERT
      Assert.Throws<AdoExecutorException>(() => _parameterExtractor.ExtractParameter(context));
    }

    [Test]
    public void ExtrtactParameter_ShouldThrowAdoExecutorException_WhenParameterTypeIsNotPrimitive()
    {
      //ARRANGE
      var dictionary = new Dictionary<string, object>();
      dictionary["testParameter"] = "testValue";
      var context = CreateContext(dictionary);

      SqlPrimitiveDataTypesFake.CallsTo(x => x.IsSqlPrimitiveType(A<Type>._))
        .Returns(false);

      //ASSERT
      Assert.Throws<AdoExecutorException>(() => _parameterExtractor.ExtractParameter(context));
    }

    [Test]
    public void ExtractParameter_ShouldAddEqualParametersThanDataRowColumns()
    {
      //ARRANGE
      var dictionary = new Dictionary<string, object>();
      dictionary["testColumn1"] = "testValue1";
      dictionary["testColumn2"] = 2;

      var dataObjectFactory = A.Fake<IDataObjectFactory>();
      ConfigurationFake.CallsTo(x => x.DataObjectFactory)
        .Returns(dataObjectFactory);

      var dataParameterCollectionFake = A.Fake<IDataParameterCollection>();
      CommandFake.CallsTo(x => x.Parameters)
        .Returns(dataParameterCollectionFake);

      var context = CreateContext(dictionary);

      SqlPrimitiveDataTypesFake.CallsTo(x => x.IsSqlPrimitiveType(A<Type>._))
        .Returns(true);

      //ACT
      _parameterExtractor.ExtractParameter(context);

      //ASSERT
      dataParameterCollectionFake.CallsTo(
        x => x.Add(A<IDbDataParameter>.That.Matches(
          parameter => parameter.ParameterName == "testColumn1" && (string) parameter.Value == "testValue1")))
        .MustHaveHappened(Repeated.Exactly.Once);

      dataParameterCollectionFake.CallsTo(
        x => x.Add(A<IDbDataParameter>.That.Matches(
          parameter => parameter.ParameterName == "testColumn2" && (int) parameter.Value == 2)))
        .MustHaveHappened(Repeated.Exactly.Once);

      dataObjectFactory.CallsTo(x => x.CreateDataParameter())
        .MustHaveHappened(Repeated.Exactly.Twice);
    }
  }
}