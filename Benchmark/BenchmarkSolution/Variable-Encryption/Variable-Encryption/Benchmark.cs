using System;

public class Benchmark
{
    public string typeName;
    public Action<int> benchmarkWhileLoop;

    public Benchmark(string _typeName, Action<int> _BenchmarkWhileLoop)
    {
        typeName = _typeName;
        benchmarkWhileLoop = _BenchmarkWhileLoop;
    }
}
