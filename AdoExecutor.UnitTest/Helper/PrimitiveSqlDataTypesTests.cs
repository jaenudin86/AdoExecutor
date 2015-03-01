using System;
using System.Collections;
using System.Data;
using AdoExecutor.Utilities.PrimitiveTypes;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Helper
{
  [TestFixture]
  public class PrimitiveSqlDataTypesTests
  {
    [SetUp]
    public void SetUp()
    {
      _primitiveSqlDataTypes = new PrimitiveSqlDataTypes();
    }

    private PrimitiveSqlDataTypes _primitiveSqlDataTypes;

    [Test]
    [TestCase(typeof (object))]
    [TestCase(typeof (Tuple))]
    [TestCase(typeof (IEnumerable))]
    [TestCase(typeof (DbType))]
    public void IsSqlPrimitiveType_ShouldReturnFalse_WhenTypeIsNotPrimitiveType(Type notPrimitiveType)
    {
      //ACT
      bool isPrimitiveType = _primitiveSqlDataTypes.IsSqlPrimitiveType(notPrimitiveType);

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
      bool isPrimitiveType = _primitiveSqlDataTypes.IsSqlPrimitiveType(primitiveType);

      //ASSERT
      Assert.IsTrue(isPrimitiveType);
    }
  }
}