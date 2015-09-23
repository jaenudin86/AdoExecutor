using System;
using System.Collections;
using System.Reflection;
using AdoExecutor.Core.Entities;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Shared.Utilities.Adapter.DataReader.Infrastructure;
using AdoExecutor.Utilities.ObjectConverter.Infrastructure;
using AdoExecutor.Utilities.PrimitiveTypes.Infrastructure;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DefinedTypeObjectBuilder : IObjectBuilder
  {
    private readonly IObjectConverter _objectConverter;
    private readonly ISqlPrimitiveDataTypes _sqlPrimitiveDataTypes;

    public DefinedTypeObjectBuilder(ISqlPrimitiveDataTypes sqlPrimitiveDataTypes,
      IObjectConverter objectConverter)
    {
      if (sqlPrimitiveDataTypes == null)
        throw new ArgumentNullException(nameof(sqlPrimitiveDataTypes));

      if (objectConverter == null)
        throw new ArgumentNullException(nameof(objectConverter));

      _sqlPrimitiveDataTypes = sqlPrimitiveDataTypes;
      _objectConverter = objectConverter;
    }

    public bool CanProcess(ObjectBuilderContext context)
    {
      if (context.ResultType.IsAbstract || context.ResultType.IsInterface)
        return false;

      if (Nullable.GetUnderlyingType(context.ResultType) != null)
        return false;

      if (context.ResultType.GetInterface(typeof (IEnumerable).FullName) != null)
        return false;

      if (context.ResultType == typeof (object))
        return false;

      if (_sqlPrimitiveDataTypes.IsSqlPrimitiveType(context.ResultType))
        return false;

      if (context.ResultType.GetConstructor(Type.EmptyTypes) == null)
        return false;

      return true;
    }

    public object CreateInstance(ObjectBuilderContext context)
    {
      if (!context.DataReaderAdapter.IsOpen)
      {
        context.DataReaderAdapter.Open();

        if (!context.DataReaderAdapter.Read())
        {
          if (!context.ResultType.IsValueType)
            return null;

          throw new AdoExecutorException("Cannot read data from reader.");
        }
      }

      if (!context.DataReaderAdapter.IsClosed)
        return CreateSingleInstance(context.DataReaderAdapter, context.ResultType);

      throw new AdoExecutorException("Cannot read data from reader.");
    }

    private object CreateSingleInstance(IDataReaderAdapter dataReaderAdapter, Type instanceType)
    {
      var instance = Activator.CreateInstance(instanceType);
      var typeProperties = instanceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

      for (var i = 0; i < dataReaderAdapter.FieldCount; i++)
      {
        var columnName = dataReaderAdapter.GetName(i);
        var property = GetPropertyInfo(typeProperties, columnName);

        if (property != null)
        {
          var value = dataReaderAdapter.GetValue(i);
          var convertedValue = _objectConverter.ChangeType(property.PropertyType, value);
          property.SetValue(instance, convertedValue, null);
        }
      }

      return instance;
    }

    private PropertyInfo GetPropertyInfo(PropertyInfo[] properties, string columnName)
    {
      foreach (var propertyInfo in properties)
      {
        var propertyAttribute =
          Attribute.GetCustomAttribute(propertyInfo, typeof (SqlNameAttribute)) as SqlNameAttribute;

        if (propertyAttribute != null)
        {
          if (propertyInfo.Name.Equals(propertyAttribute.Name, StringComparison.OrdinalIgnoreCase))
            return propertyInfo;
        }

        if (propertyInfo.Name.Equals(columnName, StringComparison.OrdinalIgnoreCase))
          return propertyInfo;
      }

      return null;
    }
  }
}