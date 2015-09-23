using System;

namespace AdoExecutor.Core.Entities
{
  [AttributeUsage(AttributeTargets.Property)]
  public class SqlNameAttribute : Attribute
  {
    public SqlNameAttribute()
    {
    }

    public SqlNameAttribute(string name)
    {
      Name = name;
    }

    public string Name { get; set; }
  }
}