#if NET30 || NET35 || NET40 || NET45
using AdoExecutor.Shared.Core.Entities.Infrastructure;

namespace AdoExecutor.Shared.Core.Entities
{
  public class MultipleResultSet<T1, T2> : IMultipleResultSet
  {
    public MultipleResultSet(T1 item1, T2 item2)
    {
      Item1 = item1;
      Item2 = item2;
    }

    public T1 Item1 { get; private set; }
    public T2 Item2 { get; private set; }
  }

  public class MultipleResultSet<T1, T2, T3> : IMultipleResultSet
  {
    public MultipleResultSet(T1 item1, T2 item2, T3 item3)
    {
      Item1 = item1;
      Item2 = item2;
      Item3 = item3;
    }

    public T1 Item1 { get; private set; }
    public T2 Item2 { get; private set; }
    public T3 Item3 { get; private set; }
  }

  public class MultipleResultSet<T1, T2, T3, T4> : IMultipleResultSet
  {
    public MultipleResultSet(T1 item1, T2 item2, T3 item3, T4 item4)
    {
      Item1 = item1;
      Item2 = item2;
      Item3 = item3;
      Item4 = item4;
    }

    public T1 Item1 { get; private set; }
    public T2 Item2 { get; private set; }
    public T3 Item3 { get; private set; }
    public T4 Item4 { get; private set; }
  }

  public class MultipleResultSet<T1, T2, T3, T4, T5> : IMultipleResultSet
  {
    public MultipleResultSet(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
    {
      Item1 = item1;
      Item2 = item2;
      Item3 = item3;
      Item4 = item4;
      Item5 = item5;
    }

    public T1 Item1 { get; private set; }
    public T2 Item2 { get; private set; }
    public T3 Item3 { get; private set; }
    public T4 Item4 { get; private set; }
    public T5 Item5 { get; private set; }
  }

  public class MultipleResultSet<T1, T2, T3, T4, T5, T6> : IMultipleResultSet
  {
    public MultipleResultSet(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
    {
      Item1 = item1;
      Item2 = item2;
      Item3 = item3;
      Item4 = item4;
      Item5 = item5;
      Item6 = item6;
    }

    public T1 Item1 { get; private set; }
    public T2 Item2 { get; private set; }
    public T3 Item3 { get; private set; }
    public T4 Item4 { get; private set; }
    public T5 Item5 { get; private set; }
    public T6 Item6 { get; private set; }
  }

  public class MultipleResultSet<T1, T2, T3, T4, T5, T6, T7> : IMultipleResultSet
  {
    public MultipleResultSet(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
    {
      Item1 = item1;
      Item2 = item2;
      Item3 = item3;
      Item4 = item4;
      Item5 = item5;
      Item6 = item6;
      Item7 = item7;
    }

    public T1 Item1 { get; private set; }
    public T2 Item2 { get; private set; }
    public T3 Item3 { get; private set; }
    public T4 Item4 { get; private set; }
    public T5 Item5 { get; private set; }
    public T6 Item6 { get; private set; }
    public T7 Item7 { get; private set; }
  }
}
#endif