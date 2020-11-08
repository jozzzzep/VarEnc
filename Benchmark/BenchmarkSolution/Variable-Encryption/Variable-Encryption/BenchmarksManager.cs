using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class BenchmarksManager
{
    private static Stopwatch stopWatch;

    static public readonly MinAndMax testInBenchmarks = new MinAndMax { Min = 2, Max = 1000000 };
    static public readonly MinAndMax incrementInBenchmarks = new MinAndMax { Min = 50, Max = 1000000000 };

    static public Benchmark[] benchmarks =
    {
            new Benchmark("int", WL_Int),
            new Benchmark("EncInt", WL_EncInt),

            new Benchmark("long", WL_Long),
            new Benchmark("EncLong", WL_EncLong),

            new Benchmark("float", WL_Float),
            new Benchmark("EncFloat", WL_EncFloat),

            new Benchmark("double", WL_Double),
            new Benchmark("EncDouble", WL_EncDouble),

            new Benchmark("decimal", WL_Decimal),
            new Benchmark("EncDecimal", WL_EncDecimal),

            new Benchmark("string", WL_String),
            new Benchmark("EncString", WL_EncString),
        };

    public static void RunBenchmarks(BenchmarkData benchmarkData)
    {
        Console.Clear();
        MenuSystem.DrawSeparationLine();
        RunSingleBenchmark(benchmarkData.howMuchToIncrement, benchmarkData.testsAmount, benchmarkData.benchmark1);
        MenuSystem.DrawSeparationLine();
        RunSingleBenchmark(benchmarkData.howMuchToIncrement, benchmarkData.testsAmount, benchmarkData.benchmark2);
        MenuSystem.DrawSeparationLine();
        AfterBenchmark();
    }

    public static void RunSingleBenchmark(int howMuchToIncrement, int testsAmount, Action<int> whileLoop, string varName)
    {
        Console.WriteLine(varName + ":");
        Console.WriteLine(" ");
        List<TimeSpan> timeSpans = new List<TimeSpan>();

        for (int i = 0; i < testsAmount; i++)
        {
            Console.WriteLine("It will stop when it'll reach " + howMuchToIncrement);
            stopWatch = new Stopwatch();

            // benchmark
            stopWatch.Start();
            whileLoop(howMuchToIncrement);
            stopWatch.Stop();
            AfterWhileLoop();
            PrintTestResults(i + 1, testsAmount, stopWatch.Elapsed);
            timeSpans.Add(stopWatch.Elapsed);
        }

        Console.WriteLine(" ");
        DisplayAverage(timeSpans);
    }

    public static void RunSingleBenchmark(int howMuchToIncrement, int testsAmount, Benchmark benchmark)
    {
        RunSingleBenchmark(howMuchToIncrement, testsAmount, benchmark.benchmarkWhileLoop, benchmark.typeName);
    }

    static void AfterWhileLoop()
    {
        MenuSystem.ClearCurrentConsoleLine();
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        MenuSystem.ClearCurrentConsoleLine();
    }

    static void AfterBenchmark()
    {
        Console.WriteLine("Press any key to return to the menu");
        MenuSystem.DrawSeparationLine();
        Console.ReadKey();
        MenuSystem.DrawMainMenu();
    }

    #region Console Printing

    static void DisplayValue(int value)
    {
        Console.WriteLine("Value: " + value);
        Console.SetCursorPosition(0, Console.CursorTop - 1);
    }

    static void DisplayValue(long value)
    {
        Console.WriteLine("Value: " + value);
        Console.SetCursorPosition(0, Console.CursorTop - 1);
    }

    static void DisplayValue(float value)
    {
        Console.WriteLine("Value: " + value);
        Console.SetCursorPosition(0, Console.CursorTop - 1);
    }

    static void DisplayValue(double value)
    {
        Console.WriteLine("Value: " + value);
        Console.SetCursorPosition(0, Console.CursorTop - 1);
    }

    static void DisplayValue(decimal value)
    {
        Console.WriteLine("Value: " + value);
        Console.SetCursorPosition(0, Console.CursorTop - 1);
    }

    static void DisplayValue(string value)
    {
        Console.WriteLine("Value: " + value);
        Console.SetCursorPosition(0, Console.CursorTop - 1);
    }

    static void PrintTestResults(int testNum, int testsAmount, TimeSpan timeSpan)
    {
        char[] spacesInChar = new char[14 - (testNum.ToString().Length)];
        string spaces = new string(spacesInChar);
        Console.WriteLine("Test " + testNum + "/" + testsAmount + ":" + spaces + timeSpan);
    }

    static void DisplayAverage(List<TimeSpan> timeSpansOfTests)
    {
        TimeSpan timespansCombined = new TimeSpan(0);
        for (int i = 0; i < timeSpansOfTests.Count; i++)
        {
            timespansCombined += timeSpansOfTests[i];
        }

        Console.WriteLine("Average time: " + (timespansCombined / timeSpansOfTests.Count));
    }

    #endregion

    #region While Loops

    public static void WL_Int(int amount)
    {
        int number1 = 0;
        while (number1 < amount)
        {
            number1++;
            DisplayValue(number1);
        }
    }

    public static void WL_EncInt(int amount)
    {
        EncInt number1 = 0;
        while (number1 < amount)
        {
            number1++;
            DisplayValue(number1);
        }
    }

    public static void WL_Long(int amount)
    {
        long number1 = 0;
        while (number1 < amount)
        {
            number1++;
            DisplayValue(number1);
        }
    }

    public static void WL_EncLong(int amount)
    {
        EncLong number1 = 0;
        while (number1 < amount)
        {
            number1++;
            DisplayValue(number1);
        }
    }

    public static void WL_Float(int amount)
    {
        float number1 = (float)EncFloat.GetEncryptionKey();
        int timesIncremented = 0;
        while (timesIncremented < amount)
        {
            number1 += 1.77024436f;
            timesIncremented++;
            DisplayValue(number1);
        }
    }

    public static void WL_EncFloat(int amount)
    {
        EncFloat number1 = (float)EncFloat.GetEncryptionKey();
        int timesIncremented = 0;
        while (timesIncremented < amount)
        {
            number1 += 1.77024436f;
            timesIncremented++;
            DisplayValue(number1);
        }
    }

    public static void WL_Double(int amount)
    {
        double number1 = EncDouble.GetEncryptionKey();
        int timesIncremented = 0;
        while (timesIncremented < amount)
        {
            number1 += 0.46772781036222716d;
            timesIncremented++;
            DisplayValue(number1);
        }
    }

    public static void WL_EncDouble(int amount)
    {
        EncDouble number1 = EncDouble.GetEncryptionKey();
        int timesIncremented = 0;
        while (timesIncremented < amount)
        {
            number1 += 0.46772781036222716d;
            timesIncremented++;
            DisplayValue(number1);
        }
    }

    public static void WL_Decimal(int amount)
    {
        decimal number1 = (decimal)EncDouble.GetEncryptionKey() + 1.467727810362227164677278103622271646772781036222716m;
        int timesIncremented = 0;
        while (timesIncremented < amount)
        {
            number1 += 1.467727810362227164677278103622271646772781036222716m;
            timesIncremented++;
            DisplayValue(number1);
        }
    }

    public static void WL_EncDecimal(int amount)
    {
        EncDecimal number1 = (decimal)EncDouble.GetEncryptionKey() + 1.467727810362227164677278103622271646772781036222716m;
        int timesIncremented = 0;
        while (timesIncremented < amount)
        {
            number1 += 1.467727810362227164677278103622271646772781036222716m;
            timesIncremented++;
            DisplayValue(number1);
        }
    }

    public static void WL_String(int amount)
    {
        string stringVar = EncString.RandomNormalString();
        int currentPos = 0;
        int timesIncremented = 0;
        while (timesIncremented < amount)
        {
            timesIncremented++;
            stringVar = EncString.ReplaceAt(stringVar, currentPos, EncString.RandomNormalChar());
            DisplayValue(stringVar);
            currentPos++;
            if (currentPos >= stringVar.Length)
            {
                currentPos = 0;
            }
        }
    }

    public static void WL_EncString(int amount)
    {
        EncString stringVar = EncString.RandomNormalString();
        int currentPos = 0;
        int timesIncremented = 0;
        while (timesIncremented < amount)
        {
            timesIncremented++;
            stringVar = EncString.ReplaceAt(stringVar, currentPos, EncString.RandomNormalChar());
            DisplayValue(stringVar);
            currentPos++;
            if (currentPos >= stringVar.Length)
            {
                currentPos = 0;
            }
        }
    }

    #endregion
}