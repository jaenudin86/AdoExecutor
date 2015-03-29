using System;
using System.Collections;
using System.Collections.Generic;
using AdoExecutor.Utilities.Adapter.List;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Utilities.Adapter.List
{
  [TestFixture(Category = "Unit")]
  public class AbstractGenericListAdapterTests
  {
    private readonly Type _adapterType = typeof (List<>);
    private readonly Type _sourceListType = typeof(IEnumerable<string>);
    private AbstractGenericListAdapter _adapter;

    [SetUp]
    public void SetUp()
    {
      _adapter = new AbstractGenericListAdapter(_sourceListType, _adapterType);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenAnyParameterIsNull()
    {
      //ASSERT
      Assert.Throws<ArgumentNullException>(() => new AbstractGenericListAdapter(null, typeof (string)));
      Assert.Throws<ArgumentNullException>(() => new AbstractGenericListAdapter(typeof (string), null));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenTypeIsNotGeneric()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(() => new AbstractGenericListAdapter(typeof (ArrayList), typeof (string)));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenTypeNotImplementIEnumerableInterface()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(() => new AbstractGenericListAdapter(typeof (Tuple<string>), typeof (string)));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenTypeIsNotInterfaceOrAbstract()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(() => new AbstractGenericListAdapter(typeof (List<string>), typeof (string)));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenAdapterTypeNotImplementIListInterface()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(() => new AbstractGenericListAdapter(typeof (IList<string>), typeof (string)));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenAdapterTypeIsInterface()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(
        () => new AbstractGenericListAdapter(typeof (IList<string>), typeof (IList<string>)));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenAdapterTypeIsAbstract()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(
        () => new AbstractGenericListAdapter(typeof (IList<string>), typeof (AbstractGenericCollection<string>)));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenTypHasNotExaclyOneGenericArguments()
    {
      //ASSERT
      Assert.Throws<ArgumentException>(
        () => new AbstractGenericListAdapter(typeof (IDictionary<string, int>), typeof (List<>)));
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
  }
}