using System;
using AdoExecutor.Utilities.ObjectConverter.Infrastructure;

namespace AdoExecutor.Utilities.ObjectConverter
{
  public class ObjectConverter : IObjectConverter
  {
    public virtual object ChangeType(Type destinationType, object objectToConvert)
    {
      Type destinationNullableUnderlyingType = Nullable.GetUnderlyingType(destinationType);
      bool isNull = objectToConvert == null || objectToConvert == DBNull.Value;
      bool canBeNull = !destinationType.IsValueType || destinationNullableUnderlyingType != null;

      if (isNull)
      {
        if (canBeNull)
          return null;

        throw new InvalidCastException($"Cannot change 'NULL' to type: {destinationType}");
      }

      Type objectToConvertType = objectToConvert.GetType();

      if (destinationType == objectToConvertType || destinationNullableUnderlyingType == objectToConvertType)
        return objectToConvert;

      return Convert.ChangeType(objectToConvert, destinationNullableUnderlyingType ?? destinationType);
    }
  }
}