using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Reflection;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Utilities.Adapter.List.Infrastructure;
using AdoExecutor.Utilities.ObjectConverter.Infrastructure;
using AdoExecutor.Utilities.PrimitiveTypes.Infrastructure;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class DefinedTypeObjectBuilder : IObjectBuilder
  {
    private readonly IListAdapterFactory _listAdapterFactory;
    private readonly IObjectConverter _objectConverter;
    private readonly ISqlPrimitiveDataTypes _sqlPrimitiveDataTypes;

    public DefinedTypeObjectBuilder(IListAdapterFactory listAdapterFactory, ISqlPrimitiveDataTypes sqlPrimitiveDataTypes,
      IObjectConverter objectConverter)
    {
      if (listAdapterFactory == null)
        throw new ArgumentNullException("listAdapterFactory");

      if (sqlPrimitiveDataTypes == null)
        throw new ArgumentNullException("sqlPrimitiveDataTypes");

      if (objectConverter == null)
        throw new ArgumentNullException("objectConverter");

      _listAdapterFactory = listAdapterFactory;
      _sqlPrimitiveDataTypes = sqlPrimitiveDataTypes;
      _objectConverter = objectConverter;
    }

    public bool CanProcess(ObjectBuilderContext context)
    {
      IListAdapter listAdapter = _listAdapterFactory.CreateListAdapter(context.ResultType);
      Type resultType = listAdapter != null ? listAdapter.ElementType : context.ResultType;

      if (resultType.IsValueType)
        return false;

      if (resultType.IsAbstract || resultType.IsInterface)
        return false;

      if (Nullable.GetUnderlyingType(resultType) != null)
        return false;

      if (resultType.GetInterface(typeof (IEnumerable).FullName) != null)
        return false;

      if (resultType == typeof (object))
        return false;

      if (_sqlPrimitiveDataTypes.IsSqlPrimitiveType(resultType))
        return false;

      if (resultType.GetConstructor(Type.EmptyTypes) == null)
        return false;

      return true;
    }

    public object CreateInstance(ObjectBuilderContext context)
    {
      IListAdapter listAdapter = _listAdapterFactory.CreateListAdapter(context.ResultType);

      if (listAdapter != null)
      {
        while (context.DataReader.Read() && !context.DataReader.IsClosed)
        {
          object objectInstance = CreateSingleInstance(context.DataReader, listAdapter.ElementType);
          listAdapter.AdapterList.Add(objectInstance);
        }

        return listAdapter.ConverToSourceList();
      }
      else
      {
        while (context.DataReader.Read() && !context.DataReader.IsClosed)
          return CreateSingleInstance(context.DataReader, context.ResultType);

        if(!context.ResultType.IsValueType)
          return null;

        throw new AdoExecutorException("Cannot read data from reader.");
      }
    }

    private object CreateSingleInstance(IDataReader dataReader, Type instanceType)
    {
      object instance = Activator.CreateInstance(instanceType);
      PropertyInfo[] typeProperties = instanceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

      for (int i = 0; i < dataReader.FieldCount; i++)
      {
        string columnName = dataReader.GetName(i);
        PropertyInfo property =
          typeProperties.SingleOrDefault(x => x.Name.Equals(columnName, StringComparison.OrdinalIgnoreCase));

        if (property != null)
        {
          object value = dataReader.GetValue(i);
          object convertedValue = _objectConverter.ChangeType(property.PropertyType, value);
          property.SetValue(instance, convertedValue, null);
        }
      }

      return instance;
    }
  }
}