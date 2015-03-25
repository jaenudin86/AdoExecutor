using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdoExecutor.Utilities.Adapter.List;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Utilities.Adapter.List
{
  [TestFixture(Category = "Unit")]
  public class ListAdapterFactoryTests
  {
    private ListAdapterFactory _adapterFactory;

    [SetUp]
    public void SetUp()
    {
      _adapterFactory = new ListAdapterFactory();
    }

    [Test]
    [TestCase(typeof(ArrayListAdapter), typeof(string[]))]
    [TestCase(typeof(GenericListAdapter), typeof(List<>))]
    [TestCase(typeof(GenericListAdapter), typeof(Collection<>))]
    [TestCase(typeof(GenericListAdapter), typeof(ObservableCollection<>))]
    [TestCase(typeof(AbstractGenericListAdapter), typeof(IList<>))]
    [TestCase(typeof(AbstractGenericListAdapter), typeof(ICollection<>))]
    [TestCase(typeof(AbstractGenericListAdapter), typeof(IEnumerable<>))]
    [TestCase(typeof(ReadOnlyCollectionListAdapter), typeof(ReadOnlyCollection<>))]
    [TestCase(typeof(ReadOnlyObservableCollectionListAdapter), typeof(ReadOnlyObservableCollection<>))]
    public void CreateListAdapter_ShouldReturnExpectedAdapter(Type expectedType, Type sourceListType)
    {
      //ACT
      var adapter = _adapterFactory.CreateListAdapter(sourceListType);

      //ASSERT
      Assert.IsInstanceOf(expectedType, adapter);
    }

    [Test]
    public void CreateListAdapter_ShouldReturnNull_WhenSourceListTypeIsNotGeneric()
    {
      //ACT
      var adapter = _adapterFactory.CreateListAdapter(typeof(string));

      //ASSERT
      Assert.IsNull(adapter);
    }

    [Test]
    public void CreateListAdapter_ShouldReturnNull_WhenSourceListTypeIsUnknownGenericType()
    {
      //ACT
      var adapter = _adapterFactory.CreateListAdapter(typeof(Tuple<string>));

      //ASSERT
      Assert.IsNull(adapter);
    }
  }
}