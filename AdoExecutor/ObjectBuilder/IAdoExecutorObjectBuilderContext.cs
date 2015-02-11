using System;
using System.Data;

namespace AdoExecutor.ObjectBuilder
{
  public interface IAdoExecutorObjectBuilderContext
  {
    Type ResultType { get; }
    IDataReader DataReader { get; } 
  }
}