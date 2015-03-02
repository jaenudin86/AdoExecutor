using System.Data;
using AdoExecutor.Core.Exception.Infrastructure;
using AdoExecutor.Core.ParameterExtractor.Infrastructure;

namespace AdoExecutor.Core.ParameterExtractor
{
  public class DataTableParameterExtractor : IParameterExtractor
  {
    public bool CanProcess(Context.Infrastructure.AdoExecutorContext context)
    {
      return context.ParametersType == typeof (DataTable);
    }

    public void ExtractParameter(Context.Infrastructure.AdoExecutorContext context)
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