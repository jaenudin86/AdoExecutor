using System;

namespace AdoExecutor.Utilities.ObjectConverter.Infrastructure
{
  public interface IObjectConverter
  {
    object ChangeType(Type destinationType, object objectToConvert);
  }
}