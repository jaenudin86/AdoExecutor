using System;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Utilities.ObjectConverter
{
  [TestFixture(Category = "Unit")]
  public class ObjectConverterTests
  {
    private AdoExecutor.Utilities.ObjectConverter.ObjectConverter _objectConverter;

    [SetUp]
    public void SetUp()
    {
      _objectConverter = new AdoExecutor.Utilities.ObjectConverter.ObjectConverter();
    }

    [Test]
    public void ChangeType_ShouldThrowInvalidCastException_WhenObjectToConvertIsNullAndDestinationTypeIsValueType()
    {
      //ASSERT
      Assert.Throws<InvalidCastException>(() => _objectConverter.ChangeType(typeof (int), null));
    }

    [Test]
    public void ChangeType_ShouldReturnNull_WhenObjectToConvertIsNullValue()
    {
      //ACT
      var result = _objectConverter.ChangeType(typeof (string), null);

      //ASSERT
      Assert.IsNull(result);
    }

    [Test]
    public void ChangeType_ShouldReturnNull_WhenObjectToConvertIsDbNullValue()
    {
      //ACT
      var result = _objectConverter.ChangeType(typeof (string), DBNull.Value);

      //ASSERT
      Assert.IsNull(result);
    }

    [Test]
    [TestCase(typeof (int), 5, 5)]
    [TestCase(typeof (int?), 6, 6)]
    [TestCase(typeof (bool), 1, true)]
    [TestCase(typeof (string), 5, "5")]
    [TestCase(typeof (int), "432", 432)]
    public void ChangeType_ShouldReturnConvertedValue(Type destinationType, object objectToConvert, object expectedValue)
    {
      //ACT
      var result = _objectConverter.ChangeType(destinationType, objectToConvert);

      //ASSERT
      Assert.AreEqual(expectedValue, result);
    }
  }
}