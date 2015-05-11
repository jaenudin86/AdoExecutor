using System;
using System.Collections;
using System.Data;
using System.Reflection;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;
using AdoExecutor.Utilities.PrimitiveTypes.Infrastructure;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class ObjectPropertyParameterExtractor : IParameterExtractor
  {
    private readonly ISqlPrimitiveDataTypes _sqlPrimitiveDataTypes;

    public ObjectPropertyParameterExtractor(ISqlPrimitiveDataTypes sqlPrimitiveDataTypes)
    {
      if (sqlPrimitiveDataTypes == null) 
        throw new ArgumentNullException("sqlPrimitiveDataTypes");

      _sqlPrimitiveDataTypes = sqlPrimitiveDataTypes;
    }

    public bool CanProcess(Context.Infrastructure.AdoExecutorContext context)
    {
      if (_sqlPrimitiveDataTypes.IsSqlPrimitiveType(context.ParametersType))
        return false;

      if(context.Parameters is IEnumerable)
        return false;

      return true;
    }

    public void ExtractParameter(Context.Infrastructure.AdoExecutorContext context)
    {
      PropertyInfo[] parametersPublicProperies =
        context.ParametersType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

      foreach (PropertyInfo propertyInfo in parametersPublicProperies)
      {
        if (!_sqlPrimitiveDataTypes.IsSqlPrimitiveType(propertyInfo.PropertyType))
          throw new AdoExecutorException("Object property must be sql primitive type.");

        IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
        dataParameter.ParameterName = propertyInfo.Name;
        dataParameter.Value = propertyInfo.GetValue(context.Parameters, null);

        if (_sqlPrimitiveDataTypes.IsNull(dataParameter.Value))
          dataParameter.DbType = _sqlPrimitiveDataTypes.ConvertTypeToDbType(propertyInfo.PropertyType);

        context.Command.Parameters.Add(dataParameter);
      }
    }
  }
}