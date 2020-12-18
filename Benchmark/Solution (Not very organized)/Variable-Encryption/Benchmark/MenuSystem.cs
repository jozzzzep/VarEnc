using System;
using System.Collections.Generic;
using static Utilities;

static class MenuSystem
{
    static string currentVersion = "- Current version - 0.9.0";
    static string titleOfApplication = "VarEnc's Benchmarking Console Application";
    static ChoosingState currentState;
    public static BenchmarkData currentBenchmarkData;
    static BenchmarkPresetGroup currentBenchmarkPresetGroup;
    static private string choiceText = "Type the number of your choice and press ENTER";

    static private string[] sectionsTitle =
    {
        "Step #1: TYPES TO COMPARE",
        "Step #2: BENCHMARK DURATION",
        "Step #3: BENCHMARK PRESET"
    };

    static string[] SectionText(int stepNum)
    {
        string[] textToReturn;
        string previousBenchmarkText = 
            (currentBenchmarkData == null || !currentBenchmarkData.IsValid) 
            ? "" 
            : "\n  - Type the letter \"p\" or the word \"prev\" to see the size of each type in bytes.";

        switch (stepNum)
        {
            case 0:
                string[] text1 =
                {
                    currentVersion,
                    "- Welcome to the console app for speedtesting the VarEnc features.",
                    "- If you already know the numbers of your choices, you can input them all together. (separated with spaces)",
                    "- Type the letter \"s\" or the word \"size\" to see the size of each type in bytes." + previousBenchmarkText,
                    "- These are the types you can compare:"
                };
                textToReturn = text1;
                break;

            case 1:
                string[] text2 =
                {
                    string.Format("You chose to compare the types {0} and {1}", currentBenchmarkData.benchmark1.typeName, currentBenchmarkData.benchmark2.typeName),
                    "Now choose how long you want the benchmark to be.",
                };
                textToReturn = text2;
                break;

            case 2:
                string[] text3 =
                {
                    string.Format("You chose to compare the types {0} and {1}", currentBenchmarkData.benchmark1.typeName, currentBenchmarkData.benchmark2.typeName),
                    string.Format("You chose to perform a benchmark of type {0}", currentBenchmarkPresetGroup.Name),
                    "When running, the benchmark will perform a certain amount tests for the variable types you chose.",
                    "and in each test, the application will perform changes to these variables a certain amount of time."
                };
                textToReturn = text3;
                break;

            default:
                textToReturn = null;
                break;
        }
        return textToReturn;
    }

    public static Action GetSelectionsList(int sectionNum)
    {
        Action returnThis;
        switch (sectionNum)
        {
            case 0:
                returnThis = DisplayComparisonsList;
                break;

            case 1:
                returnThis = DisplayBenchmarkPresetGroupList;
                break;

            case 2:
                returnThis = DisplayBenchmarkPresetGroup;
                break;

            default:
                returnThis = null;
                break;
        }
        return returnThis;
    }

    public static int GetMaxValid(int sectionNum)
    {
        int returnThis;
        switch (sectionNum)
        {
            case 0:
                returnThis = BenchmarksManager.comparisons.Length;
                break;

            case 1:
                returnThis = BenchmarksManager.benchmarkPresetGroups.Length;
                break;

            case 2:
                returnThis = currentBenchmarkPresetGroup.presets.Length;
                break;

            default:
                returnThis = 0;
                break;
        }
        return returnThis;
    }

    public static void DisplayBenchmarkPresetGroup(BenchmarkPresetGroup _group)
    {
        BenchmarkPresetGroup group = _group;
        WriteLine(string.Format("These are the {0} benchmark presets:", group.Name));
        for (int i = 0; i < group.presets.Length; i++)
        {
            int number = i + 1;
            int changesAmount =
                (currentBenchmarkData.ComparingStrings)
                ? group.presets[i].ChangesAmount / 100
                : group.presets[i].ChangesAmount;

            string[] lines =
            {
                "",
                string.Format("PRESET #{0}:", number),
                string.Format("-{0} Tests", group.presets[i].TestsAmount),
                string.Format("-{0} Changes", changesAmount)
            };
            WriteLines(lines);
        }
    }

    public static void DisplayBenchmarkPresetGroup()
    {
        DisplayBenchmarkPresetGroup(currentBenchmarkPresetGroup);
    }

    public static void DisplayBenchmarkPresetGroup(int groupNum)
    {
        DisplayBenchmarkPresetGroup(BenchmarksManager.benchmarkPresetGroups[groupNum]);
    }

    public static void DisplayBenchmarkPresetGroupList()
    {
        for (int i = 0; i < BenchmarksManager.benchmarkPresetGroups.Length; i++)
        {
            int number = i + 1;
            string spaces = new string(' ', 5 - HowManyDigits(number));
            WriteLine(string.Format("{0}." + spaces + "{1}", number, BenchmarksManager.benchmarkPresetGroups[i].Name));
        }
    }

    public static void DisplayComparisonsList()
    {
        int number = 0;
        for (int i1 = 0; i1 < BenchmarksManager.comparisonsChunks.Length; i1++)
        {
            for (int i2 = 0; i2 < BenchmarksManager.comparisonsChunks[i1]; i2++)
            {
                int currentL = BenchmarksManager.comparisons[number].benchmark1.typeName.Length;
                string spaces1 = new string(' ', 3 - HowManyDigits(number + 1));
                string spaces2 = new string(' ', GetTheSpacesLength() - currentL);
                string line = string.Format(
                        "{0}." + spaces1 + "{1}" + spaces2 + "vs {2}",
                        number + 1, BenchmarksManager.comparisons[number].benchmark1.typeName,
                        BenchmarksManager.comparisons[number].benchmark2.typeName);
                WriteLine(line);
                number++;
            }

            if (i1 < BenchmarksManager.comparisonsChunks.Length - 1)
            {
                WriteLine();
            }
        }
    }

    public static int GetTheSpacesLength()
    {
        int highest = 0;
        for (int i = 0; i < BenchmarksManager.comparisons.Length; i++)
        {
            int current = BenchmarksManager.comparisons[i].benchmark1.typeName.Length;
            if (current > highest) highest = current;
        }
        return highest + 1;
    }

    public static void GetInputForNextSection(int sectionNum)
    {
        // save input from user
        var line = Console.ReadLine();
        
        

        if (String.IsNullOrWhiteSpace(line))
        {
            ActiveError("Empty input");
        }

        // input for seeing the sizes of the types
        else if (currentState == ChoosingState.ChoosingComparisons && line.Contains("s"))
        {
            PrintSizesOfTypes();
        }

        // input for seeing the sizes of the types
        else if (currentState == ChoosingState.ChoosingComparisons && line.Contains("p") && currentBenchmarkData != null && currentBenchmarkData.IsValid)
        {
            BenchmarksManager.RunBenchmark(currentBenchmarkData);
        }

        // input for benchmark
        else
        {
            if (line.Contains(" ") && ContainingDigits(line))
            {
                string[] entries = line.Split(' ');
                List<int> e = new List<int>();

                for (int i = 0; i < entries.Length; i++)
                {
                    if (ContainingOnlyDigits(entries[i]))
                    {
                        e.Add(int.Parse(entries[i]));
                    }
                }

                for (int i = 0; i < e.Count; i++)
                {
                    bool choosing = (i + 1 == e.Count) ? true : false;
                    AddDataFromInput((int)currentState, e[i], choosing);
                }
            }
            else
            {
                if (ContainingOnlyDigits(line))
                {
                    int inputNum = int.Parse(line);
                    AddDataFromInput(sectionNum, inputNum);
                }
                else
                {
                    ActiveError("Invalid input");
                }
            }
        }
    }

    public static void StartProgram()
    {
        Console.Title = titleOfApplication;
        currentState = ChoosingState.ChoosingComparisons;
        PrintSection(0);
    }

    public static void PrintSection(int sectionNum)
    {
        // clear previous text
        Console.Clear();

        // section's description
        SeparationLine();
        WriteLines(SectionText(sectionNum));

        // section's title
        SeparationLineSmall();
        WriteLine(sectionsTitle[sectionNum]);
        SeparationLineSmall();

        // section's list of choices
        GetSelectionsList(sectionNum)();
        SeparationLineSmall();
        WriteLine(choiceText);
        SeparationLine();

        // get input for next section
        GetInputForNextSection(sectionNum);
    }

    public static void AddDataFromInput(int sectionNum, int input, bool printAfter = true)
    {
        // Adds the data by the user's input
        // Prints the next section
        // Or starts the benchmark if it is the last section
        if (IsNumberValid(input, GetMaxValid(sectionNum)))
        {
            int inputForArray = input - 1;
            switch (sectionNum)
            {
                case 0:
                    currentBenchmarkData = new BenchmarkData(BenchmarksManager.comparisons[inputForArray]);
                    currentState = ChoosingState.ChoosingDuration;
                    if (printAfter) PrintSection(1);
                    break;

                case 1:
                    currentBenchmarkPresetGroup = BenchmarksManager.benchmarkPresetGroups[inputForArray];
                    currentState = ChoosingState.ChoosingPreset;
                    if (printAfter) PrintSection(2);
                    break;

                case 2:
                    currentState = ChoosingState.Complete;
                    currentBenchmarkData.InputPreset(currentBenchmarkPresetGroup.presets[inputForArray], currentBenchmarkPresetGroup.Name, input);
                    BenchmarksManager.RunBenchmark(currentBenchmarkData);
                    break;

                default:
                    break;
            }
        }
        else
        {
            ActiveError("Number is invalid");
        }
    }

    public static void PrintSizesOfTypes()
    {
        Console.Clear();

        SeparationLine();
        WriteLine("These are the sizes of each type, in bytes.");
        WriteLine("EncInt & EncFloat use a different method for encryption. Large size in memory, but 150% more efficient.");
        WriteLine("These are the only types this method can work on.");
        SeparationLineSmall();

        WriteLine("int        size: {0}", 4);
        WriteLine("EncInt     size: {0}", 24);
        WriteLine();
        WriteLine("long       size: {0}", 8);
        WriteLine("EncLong    size: {0}", 16);
        WriteLine();
        WriteLine("float      size: {0}", 4);
        WriteLine("EncFloat   size: {0}", 24);
        WriteLine();
        WriteLine("double     size: {0}", 8);
        WriteLine("EncDouble  size: {0}", 16);
        WriteLine();
        WriteLine("decimal    size: {0}", 16);
        WriteLine("EncDecimal size: {0}", 32);

        SeparationLineSmall();
        WriteLine("Press any to return to the menu");
        SeparationLine();
        Console.ReadKey();
        StartProgram();
    }
}
