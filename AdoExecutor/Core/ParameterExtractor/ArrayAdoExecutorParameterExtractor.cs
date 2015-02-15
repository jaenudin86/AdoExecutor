using System;
using System.Collections;
using System.Data;
using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.Exception;
using AdoExecutor.Infrastructure.ParameterExtractor;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class ArrayAdoExecutorParameterExtractor : IAdoExecutorParameterExtractor
  {
    public bool CanProcess(AdoExecutorContext context)
    {
      if (context.Parameters == null)
        return false;

      if (context.ParametersType == typeof (byte[]))
        return false;

      if (!context.ParametersType.IsArray)
        return false;

      //TODO check ElementType is primitive
      //Type elementType = context.ParametersType.GetElementType();
      //if (elementType != typeof (object))
      //  return false;

      return true;
    }

    public void ExtractParameter(AdoExecutorContext context)
    {
      var parameters = (IList) context.Parameters;

      for (int i = 0; i < parameters.Count; i++)
      {
        object parameter = parameters[i];

        if (parameter == null)
        {
          throw new AdoExecutorException("Cannot pass null into array.");
        }

        //todo checkType is Primitive
        //Type parameterType = parameter.GetType();
        //if (!_bridge.IsSupportedDotNetType(parameterType))
        //{
        //  throw new AdoExecutorException("Not supported type.");
        //}

        IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
        dataParameter.ParameterName = string.Format("@{0}", i);
        dataParameter.Value = parameters[i];

        context.Command.Parameters.Add(dataParameter);
      }
    }
  }
}