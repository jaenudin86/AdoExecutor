﻿using System.Data;
using AdoExecutor.Core.DataObjectFactory.Infrastructure;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ParameterExtractor;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.ParameterExtractor
{
  [TestFixture(Category = "Unit")]
  public class DataTableParameterExtractorTests : ParameterExtractorTestsBase
  {
    private DataTableParameterExtractor _parameterExtractor;

    [SetUp]
    public override void SetUp()
    {
      base.SetUp();

      _parameterExtractor = new DataTableParameterExtractor();
    }

    [Test]
    public void CanProcess_ShouldReturnTrue_WhenParametersTypeIsDataTable()
    {
      //ARRANGE
      var context = CreateContext(new DataTable());

      //ACT
      var canProcess = _parameterExtractor.CanProcess(context);

      //ASSERT
      Assert.IsTrue(canProcess);
    }

    [Test]
    public void CanProcess_ShouldReturnFalse_WhenParametersTypeIsNotDataTable()
    {
      //ARRANGE
      var context = CreateContext(new DataSet());

      //ACT
      var canProcess = _parameterExtractor.CanProcess(context);

      //ASSERT
      Assert.IsFalse(canProcess);
    }

    [TestCase(0)]
    [TestCase(2)]
    [TestCase(10)]
    public void ExtractParameter_ShouldThrowAdoExecutorException_WhenDataTableHasLessOrMoreThanOneRow(int rowCount)
    {
      //ARRANGE
      var dataTable = new DataTable();
      dataTable.Columns.Add("testColumn", typeof (string));

      for (var i = 0; i < rowCount; i++)
        dataTable.Rows.Add("test" + i);

      var context = CreateContext(dataTable);

      //ASSERT
      Assert.Throws<AdoExecutorException>(() => _parameterExtractor.ExtractParameter(context));
    }

    [Test]
    public void ExtractParameter_ShouldAddEqualParametersThanDataRowColumns()
    {
      //ARRANGE
      var dataTable = new DataTable();
      dataTable.Columns.Add("testColumn1", typeof (string));
      dataTable.Columns.Add("testColumn2", typeof (int));

      dataTable.Rows.Add("testValue1", 2);

      var dataObjectFactory = A.Fake<IDataObjectFactory>();
      ConfigurationFake.CallsTo(x => x.DataObjectFactory)
        .Returns(dataObjectFactory);

      var dataParameterCollectionFake = A.Fake<IDataParameterCollection>();
      CommandFake.CallsTo(x => x.Parameters)
        .Returns(dataParameterCollectionFake);

      var context = CreateContext(dataTable);

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