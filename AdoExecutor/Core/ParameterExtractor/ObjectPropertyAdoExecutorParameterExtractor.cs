using System;
using System.Collections;
using System.Data;
using System.Reflection;
using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.Exception;
using AdoExecutor.Infrastructure.ParameterExtractor;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class ObjectPropertyAdoExecutorParameterExtractor : IAdoExecutorParameterExtractor
  {
    public bool CanProcess(AdoExecutorContext context)
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

      //todo check type is not primitive
      //if(_bridge.IsSupportedDotNetType(parametersType))
      //  return false;

      return true;
    }

    public void ExtractParameter(AdoExecutorContext context)
    {
      Type parametersType = context.Parameters.GetType();
      PropertyInfo[] parametersPublicProperies =
        parametersType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

      foreach (PropertyInfo propertyInfo in parametersPublicProperies)
      {
        //todo check type is primitive
        //if (!_bridge.IsSupportedDotNetType(propertyInfo.PropertyType))
        //{
        //  throw new AdoExecutorException("Not supported type.");
        //}

        IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
        dataParameter.ParameterName = string.Format("@{0}", propertyInfo.Name);
        dataParameter.Value = propertyInfo.GetValue(context.Parameters, null);

        context.Command.Parameters.Add(dataParameter);
      }
    }
  }
}