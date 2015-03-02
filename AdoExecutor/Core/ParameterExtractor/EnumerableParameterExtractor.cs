using System;
using System.Collections;
using System.Data;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;
using AdoExecutor.Utilities.PrimitiveTypes.Infrastructure;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class EnumerableParameterExtractor : IParameterExtractor
  {
    private readonly ISqlPrimitiveDataTypes _sqlPrimitiveDataTypes;

    public EnumerableParameterExtractor(ISqlPrimitiveDataTypes sqlPrimitiveDataTypes)
    {
      if (sqlPrimitiveDataTypes == null) 
        throw new ArgumentNullException("sqlPrimitiveDataTypes");

      _sqlPrimitiveDataTypes = sqlPrimitiveDataTypes;
    }

    public bool CanProcess(Context.Infrastructure.AdoExecutorContext context)
    {
      if(_sqlPrimitiveDataTypes.IsSqlPrimitiveType(context.ParametersType))
        return false;

      return context.Parameters is IEnumerable;
    }

    public void ExtractParameter(Context.Infrastructure.AdoExecutorContext context)
    {
      var parameters = (IEnumerable) context.Parameters;
      int counter = 0;

      foreach (object parameter in parameters)
      {
        if(parameter == null)
          throw new AdoExecutorException("Array item cannot be null.");

        var parameterType = parameter.GetType();

        if (!_sqlPrimitiveDataTypes.IsSqlPrimitiveType(parameterType))
          throw new AdoExecutorException("Array item must be sql primitive type.");

        IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
        dataParameter.ParameterName = string.Format("@{0}", counter++);
        dataParameter.Value = parameter;

        context.Command.Parameters.Add(dataParameter);
      }
    }
  }
}