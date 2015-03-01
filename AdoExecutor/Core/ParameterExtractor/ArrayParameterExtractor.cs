using System;
using System.Collections;
using System.Data;
using AdoExecutor.Core.Context.Infrastructure;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;
using AdoExecutor.Utilities.PrimitiveTypes;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class ArrayParameterExtractor : IParameterExtractor
  {
    private readonly SqlPrimitiveDataTypes _sqlPrimitiveDataTypes = new SqlPrimitiveDataTypes();

    public bool CanProcess(Context.Infrastructure.Context context)
    {
      if (context.Parameters == null)
        return false;

      if (context.ParametersType == typeof (byte[]))
        return false;

      if (!context.ParametersType.IsArray)
        return false;

      Type elementType = context.ParametersType.GetElementType();
      if (elementType != typeof (object) && !_sqlPrimitiveDataTypes.IsSqlPrimitiveType(elementType)) 
        return false;

      return true;
    }

    public void ExtractParameter(Context.Infrastructure.Context context)
    {
      Type elementType = context.ParametersType.GetElementType();
      var parameters = (IList) context.Parameters;

      for (int i = 0; i < parameters.Count; i++)
      {
        object parameter = parameters[i];

        if (elementType == typeof(object) && parameter == null)
          throw new AdoExecutorException("Cannot pass null value in object array type.");

        if (elementType != typeof (object) && !_sqlPrimitiveDataTypes.IsSqlPrimitiveType(elementType))
          throw new AdoExecutorException("Array item muse be primitive type.");

        IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
        dataParameter.ParameterName = string.Format("@{0}", i);
        dataParameter.Value = parameters[i];

        context.Command.Parameters.Add(dataParameter);
      }
    }
  }
}