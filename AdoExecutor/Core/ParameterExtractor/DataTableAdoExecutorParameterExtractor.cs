using System.Data;
using AdoExecutor.Infrastructure.Context;
using AdoExecutor.Infrastructure.Exception;
using AdoExecutor.Infrastructure.ParameterExtractor;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class DataTableAdoExecutorParameterExtractor : IAdoExecutorParameterExtractor
  {
    public bool CanProcess(AdoExecutorContext context)
    {
      return context.ParametersType == typeof (DataTable);
    }

    public void ExtractParameter(AdoExecutorContext context)
    {
      var parameters = (DataTable) context.Parameters;

      if (parameters.Rows.Count != 1)
        throw new AdoExecutorException("Table should has exacly one row.");

      foreach (DataColumn column in parameters.Columns)
      {
        IDbDataParameter dataParameter = context.Configuration.DataObjectFactory.CreateDataParameter();
        dataParameter.ParameterName = column.ColumnName;
        dataParameter.Value = parameters.Rows[0][column];

        context.Command.Parameters.Add(dataParameter);
      }
    }
  }
}