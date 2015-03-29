using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdoExecutor.Utilities.Adapter.List;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Utilities.Adapter.List
{
  [TestFixture(Category = "Unit")]
  public class ReadOnlyObservableCollectionListAdapterTests
  {
    private readonly Type _sourceListType = typeof (ReadOnlyObservableCollection<string>);
    private ReadOnlyObservableCollectionListAdapter _adapter;

    [SetUp]
    public void SetUp()
    {
      _adapter = new ReadOnlyObservableCollectionListAdapter(_sourceListType);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenAnyArgumentIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(() => new ReadOnlyObservableCollectionListAdapter(null));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenTypeIsNotGeneric()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(() => new ReadOnlyObservableCollectionListAdapter(typeof (object)));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenTypeIsNotReadOnlyObservableCollection()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(() => new ReadOnlyObservableCollectionListAdapter(typeof (List<>)));
    }

    [Test]
    public void Constructor_ShouldInitializeTypeProperties()
    {
      //ASSERT
      Assert.AreEqual(_sourceListType, _adapter.SourceListType);
      Assert.AreEqual(typeof(string), _adapter.ElementType);
      Assert.AreEqual(typeof(ObservableCollection<string>), _adapter.AdapterListType);
    }

    [Test]
    public void AdapterList_ShouldReturnListInstance()
    {
      //ACT
      var adapterList = _adapter.AdapterList;

      //ASSERT
      Assert.IsInstanceOf<ObservableCollection<string>>(adapterList);
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
    public void ConvertToSourceList_ShouldReturnSameAsAdapterListInstance()
    {
      //ACT
      var adapterList = _adapter.AdapterList;
      adapterList.Add("test");

      var convertedList = _adapter.ConverToSourceList();

      //ASSERT
      Assert.AreNotSame(adapterList, convertedList);
      Assert.IsInstanceOf<ReadOnlyObservableCollection<string>>(convertedList);
      Assert.AreEqual(adapterList.Count, convertedList.Count);
      Assert.AreEqual(adapterList[0], convertedList[0]);
    }
  }
}