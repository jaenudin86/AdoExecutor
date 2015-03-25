using System;
using System.Collections;
using AdoExecutor.Utilities.Adapter.List;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Utilities.Adapter.List
{
  [TestFixture(Category = "Unit")]
  public class ArrayListAdapterTests
  {
    private readonly Type _sourceListType = typeof (string[]);
    private ArrayListAdapter _adapter;

    [SetUp]
    public void SetUp()
    {
      _adapter = new ArrayListAdapter(_sourceListType);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenAnyArgumentIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(() => new ArrayListAdapter(null));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenSourceListTypeIsNotArrayType()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(() => new ArrayListAdapter(typeof (object)));
    }

    [Test]
    public void Constructor_ShouldInitializeTypeProperties()
    {
      //ASSERT
      Assert.AreEqual(_sourceListType, _adapter.SourceListType);
      Assert.AreEqual(typeof (string), _adapter.ElementType);
      Assert.AreEqual(typeof (ArrayList), _adapter.AdapterListType);
    }

    [Test]
    public void AdapterList_ShouldReturnArrayListInstance()
    {
      //ACT
      var adapterList = _adapter.AdapterList;

      //ASSERT
      Assert.IsInstanceOf<ArrayList>(adapterList);
    }

    [Test]
    public void AdapterList_ShouldCreateOnlyOneAdapterListInstance()
    {
      //ACT
      var adapterList1 = _adapter.AdapterList;
      var adapterList2 = _adapter.AdapterList;

      //ASSERT
      Assert.AreSame(adapterList1, adapterList2);
    }

    [Test]
    public void ConvertToSourceList_ShouldReturnListOfSourceType()
    {
      //ARRANGE
      const string item1 = "test1";
      const string item2 = "test2";

      var adapterList = _adapter.AdapterList;
      adapterList.Add(item1);
      adapterList.Add(item2);

      //ACT
      var convertedList = _adapter.ConverToSourceList();

      //ASSERT
      Assert.IsInstanceOf(_sourceListType, convertedList);
      CollectionAssert.AreEqual(adapterList, convertedList);
    }
  }
}