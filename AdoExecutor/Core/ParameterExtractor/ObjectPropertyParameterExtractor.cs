using System;
using System.Collections;
using System.Data;
using System.Reflection;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;
using AdoExecutor.Utilities.PrimitiveTypes;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class ObjectPropertyParameterExtractor : IParameterExtractor
  {
    private readonly PrimitiveSqlDataTypes _primitiveSqlDataTypes = new PrimitiveSqlDataTypes();

    public bool CanProcess(Context.Infrastructure.Context context)
    {
      if (context.ParametersType.IsArray)
        return false;

      if (_primitiveSqlDataTypes.IsSqlPrimitiveType(context.ParametersType))
        return false;

      if(context.Parameters is IEnumerable)
        return false;

      return true;
    }

    public void ExtractParameter(Context.Infrastructure.Context context)
    {
      Type parametersType = context.Parameters.GetType();
      PropertyInfo[] parametersPublicProperies =
        parametersType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

      foreach (PropertyInfo propertyInfo in parametersPublicProperies)
      {
        if (!_primitiveSqlDataTypes.IsSqlPrimitiveType(propertyInfo.PropertyType))
        {
          throw new AdoExecutorException("All object properties should be primitive type.");
        }

        IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
        dataParameter.ParameterName = string.Format("@{0}", propertyInfo.Name);
        dataParameter.Value = propertyInfo.GetValue(context.Parameters, null);

        context.Command.Parameters.Add(dataParameter);
      }
    }
  }
}