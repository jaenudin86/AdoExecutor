using System;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Utilities.ObjectConverter.Infrastructure;
using AdoExecutor.Utilities.PrimitiveTypes.Infrastructure;

namespace AdoExecutor.Core.ObjectBuilder
{
  public class SqlSimpleTypeObjectBuilder : IObjectBuilder
  {
    private readonly IObjectConverter _objectConverter;
    private readonly ISqlPrimitiveDataTypes _sqlPrimitiveDataTypes;

    public SqlSimpleTypeObjectBuilder(ISqlPrimitiveDataTypes sqlPrimitiveDataTypes, IObjectConverter objectConverter)
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
      if (_sqlPrimitiveDataTypes.IsSqlPrimitiveType(context.ResultType))
        return true;

      return false;
    }

    public object CreateInstance(ObjectBuilderContext context)
    {
      if (!context.DataReaderAdapter.IsOpen)
      {
        context.DataReaderAdapter.Open();
        if (!context.DataReaderAdapter.Read())
        {
          if(!context.ResultType.IsValueType)
            return null;

          throw new AdoExecutorException("Cannot read data from reader.");
        }

        if (context.DataReaderAdapter.FieldCount != 1)
          throw new AdoExecutorException("Sql query must return exacly one column");

        context.DataReaderAdapter.CurrentColumnIndex = 0;
      }

      if (!context.DataReaderAdapter.IsClosed)
        return _objectConverter.ChangeType(context.ResultType, context.DataReaderAdapter.GetValue(context.DataReaderAdapter.CurrentColumnIndex));

      throw new AdoExecutorException("Cannot read data from reader.");
    }
  }
}