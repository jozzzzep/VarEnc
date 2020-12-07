using System;
using static Utilities;

static class MenuSystem
{
    static BenchmarkData currentBenchmarkData;
    static BenchmarkPresetGroup currentBenchmarkPresetGroup;
    static private string choiceText = "Type the number of your choice and press ENTER";

    static private string[] sectionsTitle =
    {
        "Step #1: VARIABLE TYPE",
        "Step #2: BENCHMARK DURATION",
        "Step #3: BENCHMARK PRESET"
    };

    static string[] SectionText(int stepNum)
    {
        string[] textToReturn;
        switch (stepNum)
        {
            case 0:
                string[] text1 =
                {
                    "Current version - 0.8.0",
                    "Welcome to the console app for speedtesting the VarEnc features.",
                    "These are the types you can speedtest:"
                };
                textToReturn = text1;
                break;

            case 1:
                string[] text2 =
                {
                    string.Format("You chose to compare the types {0} and {1}", currentBenchmarkData.benchmark1.typeName, currentBenchmarkData.benchmark2.typeName),
                    "Now choose how long you want the benchmark to be.",
                    "Be aware that the \"Fastest\" benchmarks are the least accurate."
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
            string[] lines =
            {
                "",
                string.Format("PRESET #{0}:", number),
                string.Format("-{0} Tests", group.presets[i].TestsAmount),
                string.Format("-{0} Changes", group.presets[i].ChangesAmount)
            };
            Utilities.WriteLines(lines);
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
        for (int i = 0; i < BenchmarksManager.comparisons.Length; i++)
        {
            int number = i + 1;
            int currentL = BenchmarksManager.comparisons[i].benchmark1.typeName.Length;
            string spaces1 = new string(' ', 3 - HowManyDigits(number));
            string spaces2 = new string(' ', GetTheSpacesLength() - currentL);
            string line = string.Format(
                    "{0}." + spaces1 + "{1}" + spaces2 + "vs {2}",
                    number, BenchmarksManager.comparisons[i].benchmark1.typeName,
                    BenchmarksManager.comparisons[i].benchmark2.typeName);

            WriteLine(line);
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
        else
        {
            try
            {
                int inputNum = Convert.ToInt32(line);
                if (IsNumberValid(inputNum, GetMaxValid(sectionNum)))
                {
                    // if the input is valid,
                    // add the data from the user's input and print the next section
                    AddDataFromInput(sectionNum, inputNum);
                }
                else
                {
                    ActiveError("Number is invalid");
                }
            }
            catch (Exception ex)
            {
                ActiveError(string.Format("Input is not a number. Input: <{0}>. Exception message: <{1}>", line, ex.Message));
            }
        }
    }

    static bool IsNumberValid(int num, int max) => (num != 0 && num <= max);
    
    public static void StartProgram()
    {
        currentBenchmarkData = null;
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

    public static void AddDataFromInput(int sectionNum, int input)
    {
        // Adds the data by the user's input
        // Prints the next section
        // Or starts the benchmark if it is the last section

        int inputForArray = input - 1;
        switch (sectionNum)
        {
            case 0:
                currentBenchmarkData = new BenchmarkData(BenchmarksManager.comparisons[inputForArray]);
                PrintSection(1);
                break;

            case 1:
                currentBenchmarkPresetGroup = BenchmarksManager.benchmarkPresetGroups[inputForArray];
                PrintSection(2);
                break;

            case 2:
                currentBenchmarkData.InputPreset(currentBenchmarkPresetGroup.presets[inputForArray], currentBenchmarkPresetGroup.Name, input);
                BenchmarksManager.RunBenchmarks(currentBenchmarkData);
                break;

            default:
                break;
        }
    }
}