using System;
using System.Collections;
using System.Data;
using AdoExecutor.Utilities.PrimitiveTypes;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Utilities.PrimitiveTypes
{
  [TestFixture(Category = "Unit")]
  public class SqlPrimitiveDataTypesTests
  {
    private SqlPrimitiveDataTypes _sqlPrimitiveDataTypes;

    [SetUp]
    public void SetUp()
    {
      _sqlPrimitiveDataTypes = new SqlPrimitiveDataTypes();
    }

    [Test]
    [TestCase(typeof (object))]
    [TestCase(typeof (Tuple))]
    [TestCase(typeof (IEnumerable))]
    [TestCase(typeof (DbType))]
    public void IsSqlPrimitiveType_ShouldReturnFalse_WhenTypeIsNotPrimitiveType(Type notPrimitiveType)
    {
      //ACT
      var isPrimitiveType = _sqlPrimitiveDataTypes.IsSqlPrimitiveType(notPrimitiveType);

      //ASSERT
      Assert.IsFalse(isPrimitiveType);
    }

    [Test]
    [TestCase(typeof (bool))]
    [TestCase(typeof (bool?))]
    [TestCase(typeof (byte))]
    [TestCase(typeof (byte?))]
    [TestCase(typeof (sbyte))]
    [TestCase(typeof (sbyte?))]
    [TestCase(typeof (byte[]))]
    [TestCase(typeof (char))]
    [TestCase(typeof (char?))]
    [TestCase(typeof (char[]))]
    [TestCase(typeof (string))]
    [TestCase(typeof (short))]
    [TestCase(typeof (short?))]
    [TestCase(typeof (ushort))]
    [TestCase(typeof (ushort?))]
    [TestCase(typeof (int))]
    [TestCase(typeof (int?))]
    [TestCase(typeof (uint))]
    [TestCase(typeof (uint?))]
    [TestCase(typeof (long))]
    [TestCase(typeof (long?))]
    [TestCase(typeof (ulong))]
    [TestCase(typeof (ulong?))]
    [TestCase(typeof (float))]
    [TestCase(typeof (float?))]
    [TestCase(typeof (double))]
    [TestCase(typeof (double?))]
    [TestCase(typeof (decimal))]
    [TestCase(typeof (decimal?))]
    [TestCase(typeof (DateTime))]
    [TestCase(typeof (DateTime?))]
    [TestCase(typeof (DateTimeOffset))]
    [TestCase(typeof (DateTimeOffset?))]
    [TestCase(typeof (TimeSpan))]
    [TestCase(typeof (TimeSpan?))]
    [TestCase(typeof (Guid))]
    [TestCase(typeof (Guid?))]
    public void IsSqlPrimitiveType_ShouldReturnTrue_WhenTypeIsPrimitiveType(Type primitiveType)
    {
      //ACT
      var isPrimitiveType = _sqlPrimitiveDataTypes.IsSqlPrimitiveType(primitiveType);

      //ASSERT
      Assert.IsTrue(isPrimitiveType);
    }

    [Test]
    public void GetAllSqlPrimitiveTypes_ShouldReturnArrayWithExceptedPrimitivesTypes()
    {
      //ARRANGE
      Type[] exptectedPrimitivesTypes =
      {
        typeof (bool),
        typeof (bool?),
        typeof (byte),
        typeof (byte?),
        typeof (sbyte),
        typeof (sbyte?),
        typeof (byte[]),
        typeof (char),
        typeof (char?),
        typeof (char[]),
        typeof (string),
        typeof (short),
        typeof (short?),
        typeof (ushort),
        typeof (ushort?),
        typeof (int),
        typeof (int?),
        typeof (uint),
        typeof (uint?),
        typeof (long),
        typeof (long?),
        typeof (ulong),
        typeof (ulong?),
        typeof (float),
        typeof (float?),
        typeof (double),
        typeof (double?),
        typeof (decimal),
        typeof (decimal?),
        typeof (DateTime),
        typeof (DateTime?),
        typeof (DateTimeOffset),
        typeof (DateTimeOffset?),
        typeof (TimeSpan),
        typeof (TimeSpan?),
        typeof (Guid),
        typeof (Guid?)
      };

      //ACT
      var primitivesTypes = _sqlPrimitiveDataTypes.GetAllSqlPrimitiveTypes();

      //ASSERT
      CollectionAssert.AreEqual(exptectedPrimitivesTypes, primitivesTypes);
    }
  }
}