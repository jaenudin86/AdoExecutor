﻿using System;
using System.Data;

namespace AdoExecutor.Core.Query.Infrastructure
{
  public interface IQuery : IDisposable
  {
    IDbConnection Connection { get; }
    int Execute(string query, object parameters = null, QueryOptions options = null);
    T Select<T>(string query, object parameters = null, QueryOptions options = null);
  }
}