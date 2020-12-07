using System;
using System.Collections.Generic;

public class TypeInBenchmark
{
    public string typeName;
    public Action<int> benchmarkWhileLoop;

    public TypeInBenchmark(string _typeName, Action<int> _BenchmarkWhileLoop)
    {
        typeName = _typeName;
        benchmarkWhileLoop = _BenchmarkWhileLoop;
    }
}
