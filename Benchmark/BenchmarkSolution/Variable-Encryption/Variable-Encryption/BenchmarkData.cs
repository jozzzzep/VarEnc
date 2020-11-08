public class BenchmarkData
{
    public int howMuchToIncrement;
    public int testsAmount;
    public Benchmark benchmark1;
    public Benchmark benchmark2;

    public BenchmarkData(Benchmark _benchmark1, Benchmark _benchmark2, int _howMuchToIncrement, int _testsAmount)
    {
        howMuchToIncrement = _howMuchToIncrement;
        testsAmount = _testsAmount;
        benchmark1 = _benchmark1;
        benchmark2 = _benchmark2;
    }

    public BenchmarkData()
        : this(null, null, 0, 0) { }

    public string[] DataInText()
    {
        string[] dataString =
        {
                "Type #1: " + benchmark1.typeName,
                "Type #2: " + benchmark2.typeName,
                "Tests amount: " + howMuchToIncrement,
            };
        return dataString;
    }
}