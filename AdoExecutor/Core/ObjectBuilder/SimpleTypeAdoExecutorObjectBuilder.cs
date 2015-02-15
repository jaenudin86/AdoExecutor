//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using AdoExecutor.Infrastructure.Exception;
//using AdoExecutor.Infrastructure.ObjectBuilder;

//namespace AdoExecutor.Core.ObjectBuilder
//{
//  public class SimpleTypeAdoExecutorObjectBuilder : IAdoExecutorObjectBuilder
//  {
//    private readonly Type[] _supportedTypes =
//    {
//      typeof (bool),
//      typeof (byte),
//      typeof (char),
//      typeof (Guid),
//      typeof (short),
//      typeof (int),
//      typeof (long),
//      typeof (float),
//      typeof (double),
//      typeof (decimal),
//      typeof (DateTime),
//      typeof (string)
//    };

//    public bool CanProcess(Type objectType)
//    {
//      var type = ExtractType(objectType);

//      if (_supportedTypes.Contains(type))
//        return true;
    
//      return false;
//    }

//    public object CreateInstance(IAdoExecutorObjectBuilderContext context)
//    {
//      if (context.DataReader.FieldCount != 1)
//      {
//        throw new AdoExecutorException("Column must be exacly once"); //todo
//      }

//      var dataReader = context.DataReader;
//      var resultType = ExtractType(context.ResultType);

//      //todo walidować, czy obiekt możę być nullable
//      if (context.ResultType.IsArray)
//      {
//        var result = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(resultType));

//        while (dataReader.Read())
//        {
//          var value = CreateSingleObject(dataReader, resultType);
//          result.Add(value);
//        }

//        var result1 = Array.CreateInstance(resultType, result.Count);
//        for (int i = 0; i < result.Count; i++)
//          result1.SetValue(result[i], i);

//        return result1;
//      }
//      else
//      {
//        if (dataReader.Read())
//        {
//          return CreateSingleObject(dataReader, resultType);
//        }

//        return null;
//      }
//    }

//    private object CreateSingleObject(IDataRecord dataRecord, Type resultType)
//    {
//      if (dataRecord.IsDBNull(0))
//        return null;

//      if (resultType == typeof (bool))
//        return dataRecord.GetBoolean(0);

//      if (resultType == typeof (byte))
//        return dataRecord.GetByte(0);

//      if (resultType == typeof (char))
//        return dataRecord.GetChar(0);

//      if (resultType == typeof (Guid))
//        return dataRecord.GetGuid(0);

//      if (resultType == typeof (short))
//        return dataRecord.GetInt16(0);

//      if (resultType == typeof (int))
//        return dataRecord.GetInt32(0);

//      if (resultType == typeof (long))
//        return dataRecord.GetInt64(0);

//      if (resultType == typeof (float))
//        return dataRecord.GetFloat(0);

//      if (resultType == typeof (double))
//        return dataRecord.GetDouble(0);

//      if (resultType == typeof (decimal))
//        return dataRecord.GetDecimal(0);

//      if (resultType == typeof (DateTime))
//        return dataRecord.GetDateTime(0);

//      if (resultType == typeof (string))
//        return dataRecord.GetString(0);

//      throw new AdoExecutorException("Not supported type"); //todo
//    }

//    private Type ExtractType(Type sourceType)
//    {
//      if (sourceType.IsArray)
//      {
//        sourceType = sourceType.GetElementType();
//      }

//      return Nullable.GetUnderlyingType(sourceType) ?? sourceType;
//    }
//  }
//}