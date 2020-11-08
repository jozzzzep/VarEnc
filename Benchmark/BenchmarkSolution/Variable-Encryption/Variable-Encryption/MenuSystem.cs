using System;

static class MenuSystem
{
    static BenchmarkData currentBenchmarkData;

    static private string[] welcomeMessage =
    {
            "Welcome to the console app for speedtesting the VarEnc features",
            "These are the types you can speedtest:"
        };

    static public void DrawMainMenu()
    {
        DrawMenu(welcomeMessage);
        currentBenchmarkData = null;
        DisplayTypeList();
        DrawSeparationLine();
        GetNumberTyped(ChooseFirstType);
    }

    public static void DisplayTypeList()
    {
        for (int i = 0; i < BenchmarksManager.benchmarks.Length; i++)
        {
            int number = i + 1;
            string spaces = new string(' ', 5 - number.ToString().Length);
            Console.WriteLine((i + 1) + "." + spaces + BenchmarksManager.benchmarks[i].typeName);
        }

        Console.WriteLine("");
        Console.WriteLine("Type the number of the type and press Enter");
    }

    #region Choosing

    public static void GetNumberTyped(Action<int> action)
    {
        var line = Console.ReadLine();
        if (String.IsNullOrEmpty(line))
        {
            ActiveError();
        }
        else
        {
            try
            {
                int testNum = int.Parse(line);
                action(testNum);
            }
            catch (Exception)
            {
                ActiveError();
            }
        }
    }

    public static void ChooseFirstType(int benchmarkNum)
    {
        Benchmark benchmark = GetBenchmarkObj(benchmarkNum);

        if (benchmark != null)
        {
            currentBenchmarkData = new BenchmarkData();
            currentBenchmarkData.benchmark1 = benchmark;

            string[] chooseText =
            {
                    "You chose to compare the " + currentBenchmarkData.benchmark1.typeName + " type.",
                    "Now choose the second type:"
                };

            DrawMenu(chooseText);
            DisplayTypeList();
            GetNumberTyped(ChooseSecondType);
        }
        else
        {
            ActiveError();
        }
    }

    public static void ChooseSecondType(int benchmarkNum)
    {
        Benchmark benchmark = GetBenchmarkObj(benchmarkNum);

        if (benchmark != null)
        {
            currentBenchmarkData.benchmark2 = benchmark;

            string[] chooseText =
            {
                    "You chose to compare the " + currentBenchmarkData.benchmark1.typeName + " type",
                    "And the " + currentBenchmarkData.benchmark2.typeName + " type",
                    "Now choose a how many test you want to perform on each type.",
                    "Each test will increment a variable of type " + currentBenchmarkData.benchmark1.typeName +
                    " or " + currentBenchmarkData.benchmark2.typeName
                };

            string[] typeText =
            {
                    "CHOOSE TESTS AMOUNT",
                    "Type a number between " + BenchmarksManager.testInBenchmarks.Min + " and " + BenchmarksManager.testInBenchmarks.Max + " and press Enter",
                    "(If you don't know what to choose, a number between 5 and 10 is recommended)"
                };

            Console.Clear();
            DrawSeparationLine();
            WriteLines(chooseText);
            DrawSeparationLine();
            WriteLines(typeText);
            DrawSeparationLine();
            GetNumberTyped(ChooseHowManyTests);
        }
        else
        {
            ActiveError();
        }
    }

    public static void ChooseHowManyTests(int testsAmount)
    {
        if (BenchmarksManager.testInBenchmarks.IsBetween(testsAmount))
        {
            currentBenchmarkData.testsAmount = testsAmount;

            string[] chooseText =
            {
                    "You chose to benchmark the " + currentBenchmarkData.benchmark1.typeName + " type",
                    "And the " + currentBenchmarkData.benchmark2.typeName + " type",
                    "And you chose to perform " + currentBenchmarkData.testsAmount + " tests on each type",
                    "Now choose how many times you want to increment in each test"
                };

            string[] typeText =
            {
                    "CHOOSE HOW MANY TIMES TO INCREMENT",
                    "Type a number between " + BenchmarksManager.incrementInBenchmarks.Min + " and " + BenchmarksManager.incrementInBenchmarks.Max + " and press Enter",
                    "(If you don't know what to choose, a number between 20,000 and 100,000 is recommended)"
                };

            Console.Clear();
            DrawSeparationLine();
            WriteLines(chooseText);
            DrawSeparationLine();
            WriteLines(typeText);
            DrawSeparationLine();
            GetNumberTyped(ChooseHowMuchToIncrement);
        }
        else
        {
            ActiveError();
        }
    }

    public static void ChooseHowMuchToIncrement(int howMuchToIncrement)
    {
        if (BenchmarksManager.incrementInBenchmarks.IsBetween(howMuchToIncrement))
        {
            currentBenchmarkData.howMuchToIncrement = howMuchToIncrement;
            BenchmarksManager.RunBenchmarks(currentBenchmarkData);
        }
        else
        {
            ActiveError();
        }
    }

    static Benchmark GetBenchmarkObj(int number)
    {
        bool isValid = (number != 0 && number <= BenchmarksManager.benchmarks.Length);
        return (isValid) ? BenchmarksManager.benchmarks[number - 1] : null;
    }

    #endregion

    #region Console Shortcuts

    static public void ActiveError(string _errorMessage)
    {
        string[] errorMessage =
        {
                _errorMessage,
                "Press any key to return"
            };

        DrawMenu(errorMessage);
        currentBenchmarkData = null;
        Console.ReadKey();
        DrawMainMenu();
    }

    static public void ActiveError()
    {
        ActiveError("Error: Invalid input");
    }

    static public void WriteLines(string[] content)
    {
        if (content != null)
        {
            for (int i = 0; i < content.Length; i++)
            {
                Console.WriteLine(content[i]);
            }
        }
    }

    static public void DrawMenu(string[] content)
    {
        if (content != null)
        {
            Console.Clear();
            DrawSeparationLine();
            WriteLines(content);
            DrawSeparationLine();
        }
    }

    public static void DrawSeparationLine()
    {
        Console.WriteLine(" ");
        Console.WriteLine("//////////////////////////////");
        Console.WriteLine(" ");
    }

    public static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

    #endregion
}
