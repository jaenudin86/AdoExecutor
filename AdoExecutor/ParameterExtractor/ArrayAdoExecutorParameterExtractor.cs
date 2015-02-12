using System;
using System.Collections;
using System.Data;
using AdoExecutor.Context;
using AdoExecutor.Exception;
using AdoExecutor.Helper;

namespace AdoExecutor.ParameterExtractor
{
  public class ArrayAdoExecutorParameterExtractor : IAdoExecutorParameterExtractor
  {
    private readonly IDotNetToSqlBridge _bridge = new DotNetToSqlBridge();

    public bool CanProcess(IAdoExecutorContext context)
    {
      if (context.Parameters == null)
        return false;

      Type parametersType = context.Parameters.GetType();

      if (parametersType == typeof (byte[]))
        return false;

      if (!parametersType.IsArray)
        return false;

      Type elementType = parametersType.GetElementType();

      if (elementType != typeof (object) || !_bridge.IsSupportedDotNetType(elementType))
        return false;

      return true;
    }

    public void ExtractParameter(IAdoExecutorContext context)
    {
      var parameters = (IList) context.Parameters;

      for (int i = 0; i < parameters.Count; i++)
      {
        object parameter = parameters[i];

        if (parameter == null)
        {
          throw new AdoExecutorException("Cannot pass null into array.");
        }

        Type parameterType = parameter.GetType();

        if (!_bridge.IsSupportedDotNetType(parameterType))
        {
          throw new AdoExecutorException("Not supported type.");
        }

        IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
        dataParameter.ParameterName = string.Format("@{0}", i);
        dataParameter.Value = parameters[i];
        dataParameter.DbType = _bridge.GetDbTypeFromDotNetType(parameterType);

        context.Command.Parameters.Add(dataParameter);
      }
    }
  }
}