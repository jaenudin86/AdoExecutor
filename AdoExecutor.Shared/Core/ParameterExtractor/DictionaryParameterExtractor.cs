﻿using System;
using System.Collections.Generic;
using System.Data;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;
using AdoExecutor.Utilities.PrimitiveTypes.Infrastructure;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class DictionaryParameterExtractor : IParameterExtractor
  {
    private readonly ISqlPrimitiveDataTypes _sqlPrimitiveDataTypes;

    public DictionaryParameterExtractor(ISqlPrimitiveDataTypes sqlPrimitiveDataTypes)
    {
      if (sqlPrimitiveDataTypes == null)
        throw new ArgumentNullException("sqlPrimitiveDataTypes");

      _sqlPrimitiveDataTypes = sqlPrimitiveDataTypes;
    }

    public bool CanProcess(Context.Infrastructure.AdoExecutorContext context)
    {
      return context.Parameters is IDictionary<string, object>;
    }

    public void ExtractParameter(Context.Infrastructure.AdoExecutorContext context)
    {
      var parameters = (IDictionary<string, object>) context.Parameters;

      foreach (var parameter in parameters)
      {
        if (string.IsNullOrEmpty(parameter.Key))
          throw new AdoExecutorException("Dictionary item key cannot be null or empty.");

        if (parameter.Value == null)
          throw new AdoExecutorException("Dictionary item value cannot be null.");

        var parameterType = parameter.Value.GetType();

        if (!_sqlPrimitiveDataTypes.IsSqlPrimitiveType(parameterType))
          throw new AdoExecutorException("Array item must be sql primitive type.");

        IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
        dataParameter.ParameterName = parameter.Key;
        dataParameter.Value = parameter.Value;

        context.Command.Parameters.Add(dataParameter);
      }
    }
  }
}