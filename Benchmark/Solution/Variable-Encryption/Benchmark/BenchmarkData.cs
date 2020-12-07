public class BenchmarkData
{
    public int changesAmount;
    public int testsAmount;

    public string benchmarkPresetGroupName;
    public int benchmarkPresetNumber;

    public TypeInBenchmark benchmark1;
    public TypeInBenchmark benchmark2;

    public BenchmarkData(TypeInBenchmark _benchmark1, TypeInBenchmark _benchmark2, int _howMuchToIncrement, int _testsAmount)
    {
        changesAmount = _howMuchToIncrement;
        testsAmount = _testsAmount;

        benchmarkPresetGroupName = null;
        benchmarkPresetNumber = 0;

        benchmark1 = _benchmark1;
        benchmark2 = _benchmark2;
    }

    public BenchmarkData(BenchmarkData benchmarkData)
    : this(benchmarkData.benchmark1, benchmarkData.benchmark2) { }

    public BenchmarkData(TypeInBenchmark _benchmark1, TypeInBenchmark _benchmark2) 
        : this(_benchmark1, _benchmark2, 0, 0) { }

    public BenchmarkData()
        : this(null, null, 0, 0) { }

    public void InputPreset(BenchmarkPreset benchmarkPreset, string presetGroupName, int presetNum)
    {
        changesAmount = benchmarkPreset.ChangesAmount;
        testsAmount = benchmarkPreset.TestsAmount;
        benchmarkPresetGroupName = presetGroupName;
        benchmarkPresetNumber = presetNum;
    }

    public string[] DataInText()
    {
        string[] dataString =
        {
                "Type #1: " + benchmark1.typeName,
                "Type #2: " + benchmark2.typeName,
                "Tests amount: " + changesAmount,
            };
        return dataString;
    }
}