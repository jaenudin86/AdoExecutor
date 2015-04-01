using System;
using System.Collections.Generic;
using System.Data;
using AdoExecutor.Core.ObjectBuilder;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.ObjectBuilder
{
  [TestFixture(Category = "Unit")]
  public class DynamicObjectBuilderTests : ObjectBuilderTestsBase
  {
    private DynamicObjectBuilder _dynamicObjectBuilder;
    private IListAdapterFactory _listAdapterFactoryFake;

    [SetUp]
    public void SetUp()
    {
      _listAdapterFactoryFake = A.Fake<IListAdapterFactory>();
      _dynamicObjectBuilder = new DynamicObjectBuilder(_listAdapterFactoryFake);
    }

    [Test]
    public void Constructor_ShouldThrownArgumentNullException_WhenAnyParameterIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(() => new DynamicObjectBuilder(null));
    }

    [Test]
    public void CanProcess_ShouldReturnTrue_WhenResultTypeIsObject()
    {
      //ARRANGE
      var fakeDataReader = A.Fake<IDataReader>();
      var context = CreateContext(typeof (object), fakeDataReader);

      //ACT
      var canProcess = _dynamicObjectBuilder.CanProcess(context);

      //ASSERT
      Assert.IsTrue(canProcess);
    }

    [Test]
    public void CanProcess_ShouldReturnTrue_WhenElementListIsObject()
    {
      //ARRANGE
      var listAdapterFake = A.Fake<IListAdapter>();
      listAdapterFake.CallsTo(x => x.ElementType)
        .Returns(typeof (object));

      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(A<Type>._))
        .Returns(listAdapterFake);

      var fakeDataReader = A.Fake<IDataReader>();
      var context = CreateContext(typeof (object[]), fakeDataReader);

      //ACT
      var canProcess = _dynamicObjectBuilder.CanProcess(context);

      //ASSERT
      Assert.IsTrue(canProcess);
    }

    [Test]
    [TestCase(typeof (string))]
    [TestCase(typeof (int))]
    [TestCase(typeof (Tuple<string, int>))]
    public void CanProcess_ShouldReturnFalse_WhenResultTypeIsNotObject(Type resultType)
    {
      //ARRANGE
      var fakeDataReader = A.Fake<IDataReader>();
      var context = CreateContext(resultType, fakeDataReader);

      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(A<Type>._))
        .Returns(null);

      //ACT
      var canProcess = _dynamicObjectBuilder.CanProcess(context);

      //ASSERT
      Assert.IsFalse(canProcess);
    }

    [Test]
    [TestCase(typeof (string))]
    [TestCase(typeof (int))]
    [TestCase(typeof (Tuple<string, int>))]
    public void CanProcess_ShouldReturnFalse_WhenElementListIsNotObject(Type elementType)
    {
      //ARRANGE
      var listAdapterFake = A.Fake<IListAdapter>();
      listAdapterFake.CallsTo(x => x.ElementType)
        .Returns(elementType);

      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(A<Type>._))
        .Returns(listAdapterFake);

      var fakeDataReader = A.Fake<IDataReader>();
      var context = CreateContext(elementType, fakeDataReader);

      //ACT
      var canProcess = _dynamicObjectBuilder.CanProcess(context);

      //ASSERT
      Assert.False(canProcess);
    }

    [Test]
    public void CreateInstance_ShouldReturnDynamicInstance_WhenTypeIsSingleObject()
    {
      //ARRANGE
      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(A<Type>._))
        .Returns(null);

      var dataTable = new DataTable();
      dataTable.Columns.Add("testColumn", typeof (string));
      dataTable.Rows.Add("testValue");

      var dataTableReader = new DataTableReader(dataTable);
      var context = CreateContext(typeof (object), dataTableReader);

      //ACT
      dynamic instance = _dynamicObjectBuilder.CreateInstance(context);

      //ASSERT
      Assert.AreEqual("testValue", instance.testColumn);
    }

    [Test]
    public void CreateInstance_ShouldReturnDynamicArray_WhenTypeIsObjectArray()
    {
      //ARRANGE
      var dataTable = new DataTable();
      dataTable.Columns.Add("testColumn", typeof (string));
      dataTable.Rows.Add("testValue1");
      dataTable.Rows.Add("testValue2");

      var adapterList = new List<object>();

      var listAdapterFake = A.Fake<IListAdapter>();
      listAdapterFake.CallsTo(x => x.ElementType)
        .Returns(typeof (object));
      listAdapterFake.CallsTo(x => x.AdapterList)
        .Returns(adapterList);

      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(A<Type>._))
        .Returns(listAdapterFake);

      var dataTableReader = new DataTableReader(dataTable);
      var context = CreateContext(typeof (object), dataTableReader);

      //ACT
      var instance = _dynamicObjectBuilder.CreateInstance(context);

      //ASSERT
      Assert.IsNotNull(instance);
      Assert.AreEqual("testValue1", ((dynamic) adapterList[0]).testColumn);
      Assert.AreEqual("testValue2", ((dynamic) adapterList[1]).testColumn);
    }

    [Test]
    public void CreateInstance_ShouldReturnNull_WhenReaderIsClosedAndResultTypeIsObject()
    {
      //ARRANGE
      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(A<Type>._))
        .Returns(null);

      var dataReaderFake = A.Fake<IDataReader>();
      dataReaderFake.CallsTo(x => x.IsClosed)
        .Returns(true);

      var context = CreateContext(typeof (object), dataReaderFake);

      //ACT
      var result = _dynamicObjectBuilder.CreateInstance(context);

      //ASSERT
      Assert.IsNull(result);
    }

    [Test]
    public void CreateInstance_ShouldReturnNull_WhenReaderHasNoResultAndResultTypeIsObject()
    {
      //ARRANGE
      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(A<Type>._))
        .Returns(null);

      var dataReaderFake = A.Fake<IDataReader>();
      dataReaderFake.CallsTo(x => x.Read())
        .Returns(false);

      var context = CreateContext(typeof (object), dataReaderFake);

      //ACT
      var result = _dynamicObjectBuilder.CreateInstance(context);

      //ASSERT
      Assert.IsNull(result);
    }

    [Test]
    public void CreateInstance_ShouldReturnEmptyArray_WhenReaderIsClosedAndResultTypeIsObjectArray()
    {
      //ARRANGE
      var adapterList = new List<object>();

      var listAdapterFake = A.Fake<IListAdapter>();
      listAdapterFake.CallsTo(x => x.ElementType)
        .Returns(typeof (object));
      listAdapterFake.CallsTo(x => x.AdapterList)
        .Returns(adapterList);

      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(A<Type>._))
        .Returns(listAdapterFake);

      var dataReaderFake = A.Fake<IDataReader>();
      dataReaderFake.CallsTo(x => x.IsClosed)
        .Returns(true);

      var context = CreateContext(typeof (object), dataReaderFake);

      //ASSERT
      CollectionAssert.IsEmpty(adapterList);
    }

    [Test]
    public void CreateInstance_ShouldReturnEmptyArray_WhenReaderHasNoResultAndResultTypeIsObjectArray()
    {
      //ARRANGE
      var adapterList = new List<object>();

      var listAdapterFake = A.Fake<IListAdapter>();
      listAdapterFake.CallsTo(x => x.ElementType)
        .Returns(typeof (object));
      listAdapterFake.CallsTo(x => x.AdapterList)
        .Returns(adapterList);

      _listAdapterFactoryFake.CallsTo(x => x.CreateListAdapter(A<Type>._))
        .Returns(listAdapterFake);

      var dataReaderFake = A.Fake<IDataReader>();
      dataReaderFake.CallsTo(x => x.Read())
        .Returns(false);

      var context = CreateContext(typeof (object), dataReaderFake);

      //ASSERT
      CollectionAssert.IsEmpty(adapterList);
    }
  }
}