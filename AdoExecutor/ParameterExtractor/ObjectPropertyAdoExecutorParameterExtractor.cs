using System;
using System.Collections;
using System.Data;
using System.Reflection;
using AdoExecutor.Context;
using AdoExecutor.Exception;
using AdoExecutor.Helper;

namespace AdoExecutor.ParameterExtractor
{
  public class ObjectPropertyAdoExecutorParameterExtractor : IAdoExecutorParameterExtractor
  {
    private readonly IDotNetToSqlBridge _bridge = new DotNetToSqlBridge();

    public bool CanProcess(IAdoExecutorContext context)
    {
      if (context.Parameters == null)
        return false;

      var parametersType = context.Parameters.GetType();

      if (parametersType.IsArray)
        return false;

      if (parametersType.IsAssignableFrom(typeof (IEnumerable)))
        return false;

      if(parametersType.IsPrimitive)
        return false;

      if(_bridge.IsSupportedDotNetType(parametersType))
        return false;

      return true;
    }

    public void ExtractParameter(IAdoExecutorContext context)
    {
      Type parametersType = context.Parameters.GetType();
      PropertyInfo[] parametersPublicProperies =
        parametersType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

      foreach (PropertyInfo propertyInfo in parametersPublicProperies)
      {
        if (!_bridge.IsSupportedDotNetType(propertyInfo.PropertyType))
        {
          throw new AdoExecutorException("Not supported type.");
        }

        IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
        dataParameter.ParameterName = string.Format("@{0}", propertyInfo.Name);
        dataParameter.Value = propertyInfo.GetValue(context.Parameters, null);
        dataParameter.DbType = _bridge.GetDbTypeFromDotNetType(propertyInfo.PropertyType);

        context.Command.Parameters.Add(dataParameter);
      }
    }
  }
}