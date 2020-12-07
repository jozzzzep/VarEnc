using System;
using System.Collections.Generic;
using System.Text;

static public class Utilities
{
    /// A class that contains utility methods for the VarEnc's benchmarking application
    /// Has methods such as a random double/string/character methods and more

    #region Debugging Methods

    static public void ActiveError(string _errorMessage = "Invalid input")
    {
        string[] errorMessage =
        {
                "Error: " + _errorMessage,
                "Press any key to return"
            };

        QuickDrawMenu(errorMessage);
        Console.ReadKey();
        MenuSystem.StartProgram();
    }

    static public void ActiveError(Exception exception, string msg = "Invalid input") => ActiveError(msg + ". Exeption message: <" + exception.Message + ">");

    static public void WriteLines(string[] content)
    {
        if (content != null)
        {
            for (int i = 0; i < content.Length; i++)
            {
                WriteLine(content[i]);
            }
        }
    }

    static public void WriteLine(string s)
    {
        if (s != null)
        {
            Console.WriteLine("  " + s);
        }
    }

    public static void WriteLine(string format, params object[] arg)
    {
        WriteLine(string.Format(format, arg));
    }

    static public void QuickDrawMenu(string[] content)
    {
        if (content != null)
        {
            Console.Clear();
            SeparationLine();
            WriteLines(content);
            SeparationLine();
        }
    }

    public static void SeparationLine()
    {
        Console.WriteLine(" ");
        Console.WriteLine("///////////////////////////////////////////////////");
        Console.WriteLine(" ");
    }

    public static void SeparationLineSmall()
    {
        Console.WriteLine("");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("");
    }

    public static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

    public static void PrintTestResults(int testNum, int testsAmount, TimeSpan timeSpan)
    {
        string maxText = testsAmount + "/" + testsAmount;
        string thisText = testNum + "/" + testsAmount;

        char[] spacesInChar = new char[(maxText.Length - thisText.Length) + 4];
        string spaces = new string(spacesInChar);

        WriteLine("Test {0}:{1}{2}", thisText, spaces, timeSpan);
    }

    public static void DisplayAverage(TimeSpan average) => WriteLine("Average time: " + average);

    #endregion

    #region Special Methods

    public static TimeSpan GetAverage(List<TimeSpan> ts_list)
    {
        TimeSpan timespansCombined = new TimeSpan(0);
        for (int i = 0; i < ts_list.Count; i++)
        {
            timespansCombined += ts_list[i];
        }
        return (timespansCombined / ts_list.Count);
    }

    /// ---
    /// It's the most effective way to get the length of an  integer
    /// See here: https://stackoverflow.com/a/51099524/14741320
    /// ---
    public static int HowManyDigits(int n)
    {
        if (n >= 0)
        {
            if (n < 10) return 1;
            if (n < 100) return 2;
            if (n < 1000) return 3;
            if (n < 10000) return 4;
            if (n < 100000) return 5;
            if (n < 1000000) return 6;
            if (n < 10000000) return 7;
            if (n < 100000000) return 8;
            if (n < 1000000000) return 9;
            return 10;
        }
        else
        {
            if (n > -10) return 2;
            if (n > -100) return 3;
            if (n > -1000) return 4;
            if (n > -10000) return 5;
            if (n > -100000) return 6;
            if (n > -1000000) return 7;
            if (n > -10000000) return 8;
            if (n > -100000000) return 9;
            if (n > -1000000000) return 10;
            return 11;
        }
    }

    public static string StringReplaceAt(string input, int index, char newChar)
    {
        if (input != null)
        {
            char[] chars = input.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }
        else return null;
    }

    public static int GetTheHigherLength(string s1, string s2) => (s1.Length >= s2.Length) ? s1.Length + 1 : s2.Length + 1;

    public static int GetTheHighestLength(string[] sr)
    {
        int highest = 0;
        for (int i = 0; i < sr.Length; i++)
        {
            if (sr[i].Length > highest)
            {
                highest = sr[i].Length;
            }
        }
        return highest + 1;
    }

    #endregion

    #region Get Random Stuff

    static Random random = new Random();

    static public double RandomDouble() => random.NextDouble();

    public static char RandomChar(int min = char.MinValue, int max = (char.MaxValue - 1))
    {
        return (char)(random.Next(min, max));
    }

    public static char RandomCharNormal() => RandomChar(48, 125);

    public static string RandomString()
    {
        char[] chars = new char[25];
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = RandomCharNormal();
        }
        return new string(chars);
    }

    #endregion
}
