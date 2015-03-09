using AdoExecutor.Core.Exception.Infrastructure;
using NUnit.Framework;

namespace AdoExecutor.UnitTest.Core.Exception.Infrastructure
{
  [TestFixture(Category = "Unit")]
  public class AdoExecutorExceptionTests
  {
    [Test]
    public void Constructor_ShouldInitializeCorrectly()
    {
      //ACT
      var expcetion = new AdoExecutorException();

      //ASSERT
      Assert.Pass();
    }

    [Test]
    public void Constructor_ShouldSetInnerExceptionMessage()
    {
      //ARRANGE
      const string errorMessage = "testMessage";

      //ACT
      var exception = new AdoExecutorException(errorMessage);

      //ASSERT
      Assert.AreEqual(errorMessage, exception.Message);
    }

    [Test]
    public void Constructor_ShouldSetInnerException()
    {
      //ARRANGE
      const string errorMessage = "testMessage";
      System.Exception innerException = new System.Exception();

      //ACT
      var exception = new AdoExecutorException(errorMessage, innerException);

      //ASSERT
      Assert.AreEqual(errorMessage, exception.Message);
      Assert.AreSame(innerException, exception.InnerException);
    }
  }
}