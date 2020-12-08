using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using static Utilities;
using static TestLibrary;

public static class BenchmarksManager
{
    static BenchmarkResults currentBenchmarkResults;
    private static Stopwatch testsStopWatch;

    static public TypeInBenchmark[] benchmarkTypes =
    {
        new TypeInBenchmark("EncInt", WL_EncInt), // 0
        new TypeInBenchmark("int", WL_Int), 
        new TypeInBenchmark("EncLong", WL_EncLong), // 2
        new TypeInBenchmark("long", WL_Long), 
        new TypeInBenchmark("EncFloat", WL_EncFloat), // 4
        new TypeInBenchmark("float", WL_Float),
        new TypeInBenchmark("EncDouble", WL_EncDouble), // 6
        new TypeInBenchmark("double", WL_Double),
        new TypeInBenchmark("EncDecimal", WL_EncDecimal), // 8
        new TypeInBenchmark("decimal", WL_Decimal),
        new TypeInBenchmark("EncString", WL_EncString), // 10
        new TypeInBenchmark("string", WL_String),
        new TypeInBenchmark("EncString (0.5.0)", WL_EncString_0_5_0), // 12
        new TypeInBenchmark("EncString (0.6.0)", WL_EncString_0_6_0), 
        new TypeInBenchmark("EncInt (0.3.0)", WL_EncInt_0_3_0), // 14
        new TypeInBenchmark("EncInt (0.7.0)", WL_EncInt_0_7_0),
        new TypeInBenchmark("EncDouble (0.5.0)", WL_EncDouble_0_5_0), // 16
        new TypeInBenchmark("EncDouble (0.7.0)", WL_EncDouble_0_7_0), 
    };

    static public BenchmarkData[] comparisons =
    {
        new BenchmarkData(benchmarkTypes[0], benchmarkTypes[1]),
        new BenchmarkData(benchmarkTypes[0], benchmarkTypes[14]),
        new BenchmarkData(benchmarkTypes[0], benchmarkTypes[15]),
        new BenchmarkData(benchmarkTypes[2], benchmarkTypes[3]),
        new BenchmarkData(benchmarkTypes[4], benchmarkTypes[5]),
        new BenchmarkData(benchmarkTypes[6], benchmarkTypes[7]),
        new BenchmarkData(benchmarkTypes[6], benchmarkTypes[16]),
        new BenchmarkData(benchmarkTypes[6], benchmarkTypes[17]),
        new BenchmarkData(benchmarkTypes[8], benchmarkTypes[9]),
        new BenchmarkData(benchmarkTypes[10], benchmarkTypes[11]),
        new BenchmarkData(benchmarkTypes[10], benchmarkTypes[12]),
        new BenchmarkData(benchmarkTypes[10], benchmarkTypes[13]),
    };

    static BenchmarkPreset[] benchmarkPresetsFastest =
    {
        new BenchmarkPreset(20, 50000),
        new BenchmarkPreset(100, 10000),
        new BenchmarkPreset(2000, 500),
        new BenchmarkPreset(10, 100000),
    };

    static BenchmarkPreset[] benchmarkPresetsVeryFast =
    {
        new BenchmarkPreset(20, 500000),
        new BenchmarkPreset(100, 100000),
        new BenchmarkPreset(2000, 5000),
        new BenchmarkPreset(10, 1000000),
    };

    static BenchmarkPreset[] benchmarkPresetsFast =
    {
        new BenchmarkPreset(20, 1000000),
        new BenchmarkPreset(100, 200000),
        new BenchmarkPreset(2000, 10000),
        new BenchmarkPreset(10, 2000000),
    };

    static BenchmarkPreset[] benchmarkPresetsNormal =
    {
        new BenchmarkPreset(40, 1000000),
        new BenchmarkPreset(100, 400000),
        new BenchmarkPreset(4000, 10000),
        new BenchmarkPreset(10, 4000000),
    };

    static BenchmarkPreset[] benchmarkPresetsMedium =
    {
        new BenchmarkPreset(40, 2000000),
        new BenchmarkPreset(100, 800000),
        new BenchmarkPreset(4000, 20000),
        new BenchmarkPreset(10, 8000000),
    };

    static BenchmarkPreset[] benchmarkPresetsLong =
    {
        new BenchmarkPreset(40, 4000000),
        new BenchmarkPreset(100, 2000000),
        new BenchmarkPreset(4000, 40000),
        new BenchmarkPreset(10, 20000000),
    };

    static BenchmarkPreset[] benchmarkPresetsVeryLong =
    {
        new BenchmarkPreset(40, 10000000),
        new BenchmarkPreset(100, 5000000),
        new BenchmarkPreset(4000, 100000),
        new BenchmarkPreset(10, 50000000),
    };


    static public BenchmarkPresetGroup[] benchmarkPresetGroups =
    {
        new BenchmarkPresetGroup("Fastest", benchmarkPresetsFastest),
        new BenchmarkPresetGroup("Very Fast", benchmarkPresetsVeryFast),
        new BenchmarkPresetGroup("Fast", benchmarkPresetsFast),
        new BenchmarkPresetGroup("Normal", benchmarkPresetsNormal),
        new BenchmarkPresetGroup("Medium", benchmarkPresetsMedium),
        new BenchmarkPresetGroup("Long", benchmarkPresetsLong),
        new BenchmarkPresetGroup("Very Long", benchmarkPresetsVeryLong),
    };

    public static void RunBenchmarks(BenchmarkData benchmarkData)
    {
        Console.Clear();

        currentBenchmarkResults = new BenchmarkResults();
        currentBenchmarkResults.SetData(benchmarkData);

        SeparationLine();
        RunTests(benchmarkData.changesAmount, benchmarkData.testsAmount, benchmarkData.benchmark1);
        SeparationLine();
        RunTests(benchmarkData.changesAmount, benchmarkData.testsAmount, benchmarkData.benchmark2);
        SeparationLine();

        AfterBenchmark();
    }

    public static void RunTests(int changesAmount, int testsAmount, Action<int> whileLoop, string varName)
    {
        WL_Invisible(2000);
        WriteLine(varName + ":");
        WriteLine(" ");
        List<TimeSpan> timeSpans = new List<TimeSpan>();
        testsStopWatch = new Stopwatch();

        for (int i = 0; i < testsAmount; i++)
        {
            WriteLine("Test {0}/{1}: It will make {2} changes in each test.", i + 1, testsAmount, changesAmount);

            // benchmark
            testsStopWatch.Restart();
            testsStopWatch.Start();
            whileLoop(changesAmount);
            testsStopWatch.Stop();
            AfterWhileLoop();
            PrintTestResults(i + 1, testsAmount, testsStopWatch.Elapsed);
            timeSpans.Add(testsStopWatch.Elapsed);
        }

        WriteLine(" ");
        TimeSpan average = GetAverage(timeSpans);
        DisplayAverage(average);
        currentBenchmarkResults.SetAverageTimeSpan(average);
    }

    public static void RunTests(int howMuchToIncrement, int testsAmount, TypeInBenchmark benchmark)
    {
        RunTests(howMuchToIncrement, testsAmount, benchmark.benchmarkWhileLoop, benchmark.typeName);
    }

    static void AfterWhileLoop()
    {
        ClearCurrentConsoleLine();
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        ClearCurrentConsoleLine();
    }

    static void AfterBenchmark()
    {
        string[] title =
        {
            "  _____  ______  _____ _    _ _   _______ _____",
            " |  __ \\|  ____|/ ____| |  | | | |__   __/ ____|",
            " | |__) | |__  | (___ | |  | | |    | | | (___  ",
            " |  _  /|  __|  \\___ \\| |  | | |    | |  \\___ \\",
            " | | \\ \\| |____ ____) | |__| | |____| |  ____) |",
            " |_|  \\_\\______|_____/ \\____/|______|_| |_____/ ",
            ""
        };

        WriteLines(title);

        string[] description =
        {
            string.Format("A comparison between the types {0} and {1}", currentBenchmarkResults.firstTypeName, currentBenchmarkResults.secondTypeName),
            string.Format("Benchmark #{0} of type [{1}]", currentBenchmarkResults.presetNumber, currentBenchmarkResults.presetGroupName)
        };

        int higherLength = GetTheHigherLength(currentBenchmarkResults.firstTypeName, currentBenchmarkResults.secondTypeName);
        string firstTypeSpaces = new string(' ', higherLength - currentBenchmarkResults.firstTypeName.Length);
        string secondTypeSpaces = new string(' ', higherLength - currentBenchmarkResults.secondTypeName.Length);
        double changesPerSec1 = ChangesPerSecond(currentBenchmarkResults.changesAmount, currentBenchmarkResults.firstBenchmarkAverage.TotalMilliseconds);
        double changesPerSec2 = ChangesPerSecond(currentBenchmarkResults.changesAmount, currentBenchmarkResults.secondBenchmarkAverage.TotalMilliseconds);

        string[] afterBenchmarkLines =
        {
            string.Format("{0}" + firstTypeSpaces + "average: {1}", currentBenchmarkResults.firstTypeName, currentBenchmarkResults.firstBenchmarkAverage),
            string.Format("{0}" + secondTypeSpaces + "average: {1}", currentBenchmarkResults.secondTypeName, currentBenchmarkResults.secondBenchmarkAverage),
            " ",
            string.Format("{0}" + firstTypeSpaces + "changes per second: {1}", currentBenchmarkResults.firstTypeName, (int)changesPerSec1),
            string.Format("{0}" + secondTypeSpaces + "changes per second: {1}", currentBenchmarkResults.secondTypeName, (int)changesPerSec2),
            " ",
            string.Format("The type {0} performed better by {1}%", currentBenchmarkResults.BetterTypeName, currentBenchmarkResults.GetHowMuchBetterPercentage()),
        };

        WriteLines(description);
        SeparationLineSmall();
        WriteLines(afterBenchmarkLines);
        SeparationLineSmall();
        WriteLine("Press any key to return to the menu");
        Utilities.SeparationLine();
        currentBenchmarkResults = null;
        Console.ReadKey();
        MenuSystem.StartProgram();
    }
    
    static double ChangesPerSecond(int changes, double seconds)
    {
        return (changes / seconds);
    }
}