using System;
using System.Collections;
using System.Collections.Generic;
using AdoExecutor.Utilities.Adapter.List;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Utilities.Adapter.List
{
  [TestFixture(Category = "Unit")]
  public class GenericListAdapterTests
  {
    private readonly Type _sourceListType = typeof (List<string>);
    private GenericListAdapter _adapter;

    [SetUp]
    public void SetUp()
    {
      _adapter = new GenericListAdapter(_sourceListType);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenAnyParameterIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(() => new GenericListAdapter(null));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenTypeIsNotGeneric()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(() => new GenericListAdapter(typeof (ArrayList)));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenTypeNotImplementIListInterface()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(() => new GenericListAdapter(typeof (Tuple<string>)));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenTypeIsAbstract()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(() => new GenericListAdapter(typeof (AbstractGenericCollection<string>)));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenTypeIsInterface()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(() => new GenericListAdapter(typeof (IGenericCollectionInterface<string>)));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenTypHasNotExaclyOneGenericArguments()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(() => new GenericListAdapter(typeof (MultipleGenericCollection<string, int>)));
    }

    [Test]
    public void Constructor_ShouldInitializeTypeProperties()
    {
      //ASSERT
      Assert.AreEqual(_sourceListType, _adapter.SourceListType);
      Assert.AreEqual(typeof (string), _adapter.ElementType);
      Assert.AreEqual(typeof (List<string>), _adapter.AdapterListType);
    }

    [Test]
    public void AdapterList_ShouldReturnListInstance()
    {
      //ACT
      var adapterList = _adapter.AdapterList;

      //ASSERT
      Assert.IsInstanceOf<List<string>>(adapterList);
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
      var convertedList = _adapter.ConverToSourceList();

      //ASSERT
      Assert.AreSame(adapterList, convertedList);
    }

    private abstract class AbstractGenericCollection<T> : List<T>
    {
    }

    private interface IGenericCollectionInterface<T> : IList
    {
    }

    private class MultipleGenericCollection<T1, T> : List<T>
    {
    }
  }
}