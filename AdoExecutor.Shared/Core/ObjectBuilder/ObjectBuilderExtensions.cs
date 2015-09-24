using System.Data;
using AdoExecutor.Core.ObjectBuilder.Infrastructure;
using AdoExecutor.Shared.Utilities.Adapter.DataReader;

namespace AdoExecutor.Shared.Core.ObjectBuilder
{
  public static class ObjectBuilderExtensions
  {
#if NET30 || NET35 || NET40 || NET45
    public static T BuildFromDataSet<T>(DataSet dataSet)
    {
      var objectBuilder = new MultipleResultSetObjectBuilder();
      var dataReader = dataSet.CreateDataReader();
      var dataReaderAdapter = new DataReaderAdapter(dataReader);
      var context = new ObjectBuilderContext(typeof (T), dataReaderAdapter);

      return (T) objectBuilder.CreateInstance(context);
    }
#endif
  }
}