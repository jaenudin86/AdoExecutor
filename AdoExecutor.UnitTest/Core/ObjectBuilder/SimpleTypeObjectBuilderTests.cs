using System;
using System.Collections.Generic;
using System.Data;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;
using AdoExecutor.Utilities.ObjectConverter.Infrastructure;
using AdoExecutor.Utilities.PrimitiveTypes.Infrastructure;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.ObjectBuilder
{
  [TestFixture(Category = "Unit")]
  public class SimpleTypeObjectBuilderTests : ObjectBuilderTestsBase
  {
    private IListAdapterFactory _listAdapterFactoryFake;
    private SqlSimpleTypeObjectBuilder _objectBuilder;
    private IObjectConverter _objectConverter;
    private ISqlPrimitiveDataTypes _sqlPrimitiveDataTypes;

    [SetUp]
    public void SetUp()
    {
      _listAdapterFactoryFake = A.Fake<IListAdapterFactory>();
      _sqlPrimitiveDataTypes = A.Fake<ISqlPrimitiveDataTypes>();
      _objectConverter = A.Fake<IObjectConverter>();
      _objectBuilder = new SqlSimpleTypeObjectBuilder(_sqlPrimitiveDataTypes, _listAdapterFactoryFake, _objectConverter);
    }

    [Test]
    public void Constructor_ShouldThrownArgumentNullException_WhenAnyParameterIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(
        () => new SqlSimpleTypeObjectBuilder(null, _listAdapterFactoryFake, _objectConverter));
      Assert.Throws<ArgumentNullException>(
        () => new SqlSimpleTypeObjectBuilder(_sqlPrimitiveDataTypes, null, _objectConverter));
      Assert.Throws<ArgumentNullException>(
        () => new SqlSimpleTypeObjectBuilder(_sqlPrimitiveDataTypes, _listAdapterFactoryFake, null));
    }

    [Test]
    public void CanProcess_ShouldReturnTrue_WhenResultTypeIsPrimitive()
    {
      //ARRANGE
      var context = CreateContext(typeof (string), A.Fake<IDataReader>());
      _sqlPrimitiveDataTypes.CallsTo(x => x.IsSqlPrimitiveType(typeof (string)))
        .Returns(true);

      //ACT
      var canProcess = _objectBuilder.CanProcess(context);

      //ASSERT
      Assert.IsTrue(canProcess);
    }

    [Test]
    public void CanProcess_ShouldReturnTrue_WhenResultTypeIsListOfPrimitive()
    {
      //ARRANGE
      var context = CreateContext(typeof (List<string>), A.Fake<IDataReader>());

      _sqlPrimitiveDataTypes.CallsTo(x => x.IsSqlPrimitiveType(typeof (List<string>)))
        .Returns(false);
      _sqlPrimitiveDataTypes.CallsTo(x => x.IsSqlPrimitiveType(typeof (string)))
        .Returns(true);

      var listAdapter = A.Fake<IListAdapter>();
      listAdapter.CallsTo(x => x.ElementType)
        .Returns(typeof (string));

      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(typeof (List<string>)))
        .Returns(listAdapter);

      //ACT
      var canProcess = _objectBuilder.CanProcess(context);

      //ASSERT
      Assert.IsTrue(canProcess);
    }

    [Test]
    public void CanProcess_ShouldReturnFalse_WhenResultTypeIsNotPrimitive()
    {
      //ARRANGE
      var context = CreateContext(typeof (string), A.Fake<IDataReader>());
      _sqlPrimitiveDataTypes.CallsTo(x => x.IsSqlPrimitiveType(typeof (string)))
        .Returns(false);

      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(typeof (string)))
        .Returns(null);

      //ACT
      var canProcess = _objectBuilder.CanProcess(context);

      //ASSERT
      Assert.IsFalse(canProcess);
    }

    [Test]
    public void CanProcess_ShouldReturnFalse_WhenResultTypeIsNotListOfPrimitive()
    {
      //ARRANGE
      var context = CreateContext(typeof (List<string>), A.Fake<IDataReader>());

      _sqlPrimitiveDataTypes.CallsTo(x => x.IsSqlPrimitiveType(typeof (List<string>)))
        .Returns(false);
      _sqlPrimitiveDataTypes.CallsTo(x => x.IsSqlPrimitiveType(typeof (string)))
        .Returns(false);

      var listAdapter = A.Fake<IListAdapter>();
      listAdapter.CallsTo(x => x.ElementType)
        .Returns(typeof (string));

      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(typeof (List<string>)))
        .Returns(listAdapter);

      //ACT
      var canProcess = _objectBuilder.CanProcess(context);

      //ASSERT
      Assert.IsFalse(canProcess);
    }

    [Test]
    [TestCase(0)]
    [TestCase(2)]
    [TestCase(10)]
    public void CreateInstance_ShouldThrowAdoExecutorException_WhenDataReaderHasNotExaclyOneFieldCount(int fieldCount)
    {
      //ARRANGE
      var dataReader = A.Fake<IDataReader>();
      dataReader.CallsTo(x => x.FieldCount)
        .Returns(fieldCount);

      var context = CreateContext(typeof (string), dataReader);

      //ASSERT
      Assert.Throws<AdoExecutorException>(() => _objectBuilder.CreateInstance(context));
    }

    [Test]
    public void CreateInstance_ShouldReturnNull_WhenResultTypeIsPrimitiveAndDataReaderHasNoResult()
    {
      //ARRANGE
      var dataReader = A.Fake<IDataReader>();
      dataReader.CallsTo(x => x.FieldCount)
        .Returns(1);
      dataReader.CallsTo(x => x.Read())
        .Returns(false);

      _sqlPrimitiveDataTypes.CallsTo(x => x.IsSqlPrimitiveType(typeof (string)))
        .Returns(true);

      _objectConverter.CallsTo(x => x.ChangeType(typeof (string), null))
        .Returns(null);

      var context = CreateContext(typeof (string), dataReader);

      //ACT
      var instance = _objectBuilder.CreateInstance(context);

      //ASSERT
      Assert.IsNull(instance);

      _objectConverter.CallsTo(x => x.ChangeType(typeof (string), null))
        .MustHaveHappened(Repeated.Exactly.Once);
    }

    [Test]
    public void CreateInstance_ShouldReturnNull_WhenResultTypeIsPrimitiveAndDataReaderIsClosed()
    {
      //ARRANGE
      var dataReader = A.Fake<IDataReader>();
      dataReader.CallsTo(x => x.FieldCount)
        .Returns(1);
      dataReader.CallsTo(x => x.Read())
        .Returns(true);
      dataReader.CallsTo(x => x.IsClosed)
        .Returns(true);

      _sqlPrimitiveDataTypes.CallsTo(x => x.IsSqlPrimitiveType(typeof (string)))
        .Returns(true);

      _objectConverter.CallsTo(x => x.ChangeType(typeof (string), null))
        .Returns(null);

      var context = CreateContext(typeof (string), dataReader);

      //ACT
      var instance = _objectBuilder.CreateInstance(context);

      //ASSERT
      Assert.IsNull(instance);

      _objectConverter.CallsTo(x => x.ChangeType(typeof (string), null))
        .MustHaveHappened(Repeated.Exactly.Once);
    }

    [Test]
    public void CreateInstance_ShouldReturnConvertedObject_WhenResultTypeIsPrimitiveAndDataReaderHasResults()
    {
      //ARRANGE
      const string convertedValue = "convertedValue";
      const string value = "test";

      var dataReader = A.Fake<IDataReader>();
      dataReader.CallsTo(x => x.FieldCount)
        .Returns(1);
      dataReader.CallsTo(x => x.Read())
        .Returns(true);
      dataReader.CallsTo(x => x.GetValue(0))
        .Returns(value);

      _sqlPrimitiveDataTypes.CallsTo(x => x.IsSqlPrimitiveType(typeof (string)))
        .Returns(true);

      _objectConverter.CallsTo(x => x.ChangeType(typeof (string), value))
        .Returns(convertedValue);

      var context = CreateContext(typeof (string), dataReader);

      //ACT
      var instance = _objectBuilder.CreateInstance(context);

      //ASSERT
      Assert.AreEqual(convertedValue, instance);

      _objectConverter.CallsTo(x => x.ChangeType(typeof (string), value))
        .MustHaveHappened(Repeated.Exactly.Once);
    }

    [Test]
    public void CreateInstance_ShouldReturnEmptyList_WhenResultTypeIsListOfPrimitiveAndDataReaderIsClosed()
    {
      //ARRANGE
      var dataReader = A.Fake<IDataReader>();
      dataReader.CallsTo(x => x.FieldCount)
        .Returns(1);
      dataReader.CallsTo(x => x.Read())
        .Returns(true);
      dataReader.CallsTo(x => x.IsClosed)
        .Returns(true);

      var listAdapter = A.Fake<IListAdapter>();
      listAdapter.CallsTo(x => x.ElementType)
        .Returns(typeof (string));

      listAdapter.CallsTo(x => x.ConverToSourceList())
        .Returns(null);

      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(typeof (List<string>)))
        .Returns(listAdapter);

      var context = CreateContext(typeof (List<string>), dataReader);

      //ACT
      var instance = _objectBuilder.CreateInstance(context);

      //ASSERT
      Assert.IsNull(instance);

      _objectConverter.CallsTo(x => x.ChangeType(A<Type>._, A<object>._))
        .MustHaveHappened(Repeated.Never);

      listAdapter.CallsTo(x => x.ConverToSourceList())
        .MustHaveHappened(Repeated.Exactly.Once);
    }

    [Test]
    public void CreateInstance_ShouldReturnEmptyList_WhenResultTypeIsListOfPrimitiveAndDataReaderHasNoResult()
    {
      //ARRANGE
      var dataReader = A.Fake<IDataReader>();
      dataReader.CallsTo(x => x.FieldCount)
        .Returns(1);
      dataReader.CallsTo(x => x.Read())
        .Returns(false);

      var listAdapter = A.Fake<IListAdapter>();
      listAdapter.CallsTo(x => x.ElementType)
        .Returns(typeof(string));

      listAdapter.CallsTo(x => x.ConverToSourceList())
        .Returns(null);

      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(typeof(List<string>)))
        .Returns(listAdapter);

      var context = CreateContext(typeof(List<string>), dataReader);

      //ACT
      var instance = _objectBuilder.CreateInstance(context);

      //ASSERT
      Assert.IsNull(instance);

      _objectConverter.CallsTo(x => x.ChangeType(A<Type>._, A<object>._))
        .MustHaveHappened(Repeated.Never);

      listAdapter.CallsTo(x => x.ConverToSourceList())
        .MustHaveHappened(Repeated.Exactly.Once);
    }

    [Test]
    public void CreateInstance_ShouldReturnListOfPrimitive_WhenResultTypeIsListOfPrimitiveAndDataReaderHasResult()
    {
      //ARRANGE
      const string value = "testValue";
      const string convertedValue = "convertedValue";
      
      int readMethodInvokeCounter = 0;
      var dataReader = A.Fake<IDataReader>();
      dataReader.CallsTo(x => x.FieldCount)
        .Returns(1);
      dataReader.CallsTo(x => x.Read())
        .ReturnsLazily(() => readMethodInvokeCounter++ < 2);
      dataReader.CallsTo(x => x.GetValue(0))
        .Returns(value);

      var adapterList = new List<object>();
      var listAdapter = A.Fake<IListAdapter>();

      listAdapter.CallsTo(x => x.ElementType)
        .Returns(typeof(string));
      listAdapter.CallsTo(x => x.AdapterList)
        .Returns(adapterList);

      listAdapter.CallsTo(x => x.ConverToSourceList())
        .Returns(adapterList);

      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(typeof (List<string>)))
        .Returns(listAdapter);

      _objectConverter.CallsTo(x => x.ChangeType(typeof (string), value))
        .Returns(convertedValue);

      var context = CreateContext(typeof(List<string>), dataReader);

      //ACT
      var instance = _objectBuilder.CreateInstance(context);

      //ASSERT
      Assert.AreSame(instance, adapterList);
      Assert.AreEqual(2, adapterList.Count);

      _objectConverter.CallsTo(x => x.ChangeType(typeof (string), value))
        .MustHaveHappened(Repeated.Exactly.Twice);
    }
  }
}