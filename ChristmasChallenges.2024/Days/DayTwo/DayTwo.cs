namespace ChristmasChallenges.In2024.Days.DayTwo;

public static class DayTwo
{
    public static void PartOne()
    {
        int safeReportCount = 0;
        string filePath = "Days/DayTwo/Inputs/InputNumbers.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var splitedLine = line.Split(" ").ToList();

                    if (splitedLine.Count() > 1)
                    {
                        var numSplitedLines = splitedLine.Select(int.Parse).ToList();

                        bool isSorted = IsSorted(numSplitedLines);
                        bool isOneDifference = MeetsAdjacentNumberConditions(numSplitedLines, 1);
                        bool isTwoDifference = MeetsAdjacentNumberConditions(numSplitedLines, 2);
                        bool isThreeDifference = MeetsAdjacentNumberConditions(numSplitedLines, 3);

                        if (isSorted && (isOneDifference || isTwoDifference || isThreeDifference))
                        {
                            safeReportCount = safeReportCount + 1;
                        }
                    }
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
        }

        Console.WriteLine(safeReportCount);
    }

    public static void PartTwo()
    {
        int safeReportCount = 0;
        string filePath = "Days/DayTwo/Inputs/InputNumbers.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var splitedLine = line.Split(" ");

                    if (splitedLine.Count() > 1)
                    {
                        // bool isX = CountSafeReports(splitedLine);
                        // var numSplitedLines = splitedLine.Select(int.Parse).ToList();

                        // bool isSorted = IsAlmostSorted(numSplitedLines);
                        // bool isGoodDifference = MeetsCriteria(numSplitedLines);

                        // if (isX)
                        // {
                        //     safeReportCount = safeReportCount + 1;
                        // }
                    }
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
        }

        Console.WriteLine(safeReportCount);
    }

    private static bool IsSorted(this List<int> list)
    {
        if (list.Count <= 1)
        {
            return true; // Lists with 0 or 1 element are always considered sorted
        }

        bool isAscending = true;
        bool isDescending = true;

        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] < list[i - 1])
            {
                isAscending = false;
            }
            if (list[i] > list[i - 1])
            {
                isDescending = false;
            }

            // If neither ascending nor descending is possible anymore, exit the loop
            if (!isAscending && !isDescending)
            {
                return false;
            }
        }

        return isAscending || isDescending;
    }

    private static bool MeetsAdjacentNumberConditions(this List<int> list, int maxDifference)
    {
        if (list.Count <= 1)
        {
            return true; // Lists with 0 or 1 element always meet the conditions
        }

        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] == list[i - 1]) 
            {
                return false; // Adjacent numbers cannot be the same
            }

            int difference = Math.Abs(list[i] - list[i - 1]);
            if (difference > maxDifference) 
            {
                return false; // Difference between adjacent numbers exceeds the limit
            }
        }

        return true; 
    }

    private static bool IsAlmostSorted(List<int> numbers)
    {
        if (numbers.Count <= 1) 
        {
            return true; // Lists with 0 or 1 elements are always considered sorted
        }

        bool isAscending = numbers[0] < numbers[1]; 

        int numberOfBreaks = 0;

        for (int i = 1; i < numbers.Count; i++)
        {
            if (isAscending)
            {
                if (numbers[i - 1] > numbers[i]) 
                {
                    numberOfBreaks++;
                }
            }
            else 
            {
                if (numbers[i - 1] < numbers[i]) 
                {
                    numberOfBreaks++;
                }
            }
        }

        return numberOfBreaks <= 1;
    }

    private static bool MeetsCriteria(List<int> numbers)
    {
        if (numbers.Count <= 1) 
        {
            return true; // Lists with 0 or 1 elements trivially meet the criteria
        }

        int errorCount = 0; 

        for (int i = 1; i < numbers.Count; i++)
        {
            int diff = Math.Abs(numbers[i] - numbers[i - 1]);

            // Check if adjacent numbers are equal
            if (numbers[i] == numbers[i - 1]) 
            {
                errorCount++;
            }

            // Check if the difference is within the allowed range
            if (diff < 1 || diff > 3) 
            {
                errorCount++;
            }

            // Early exit if more than one error is found
            if (errorCount > 1) 
            {
                return false; 
            }
        }

        return true;
    }

    public static int CountSafeReports(string[] reports)
    {
        int safeReports = 0;

        foreach (string reportLine in reports)
        {
            int[] levels = Array.ConvertAll(reportLine.Split(' '), int.Parse);

            // Check for strictly increasing or decreasing levels
            bool isIncreasing = true;
            bool isDecreasing = true;

            for (int i = 1; i < levels.Length; i++)
            {
                int diff = levels[i] - levels[i - 1];
                if (diff > 0)
                {
                    isDecreasing = false;
                }
                else if (diff < 0)
                {
                    isIncreasing = false;
                }

                // Check for invalid differences (greater than 3 or less than -3)
                if (Math.Abs(diff) > 3)
                {
                    isIncreasing = false;
                    isDecreasing = false;
                    break;
                }
            }

            // Check if the report is safe without any level removed
            if (isIncreasing || isDecreasing)
            {
                safeReports++;
                continue;
            }

            // Check if the report can be made safe by removing a single level
            for (int i = 0; i < levels.Length; i++)
            {
                // Create a new array without the current level
                int[] modifiedLevels = new int[levels.Length - 1];
                Array.Copy(levels, 0, modifiedLevels, 0, i);
                Array.Copy(levels, i + 1, modifiedLevels, i, levels.Length - i - 1);

                // Check if the modified array is safe
                isIncreasing = true;
                isDecreasing = true;

                for (int j = 1; j < modifiedLevels.Length; j++)
                {
                    int diff = modifiedLevels[j] - modifiedLevels[j - 1];
                    if (diff > 0)
                    {
                        isDecreasing = false;
                    }
                    else if (diff < 0)
                    {
                        isIncreasing = false;
                    }

                    if (Math.Abs(diff) > 3)
                    {
                        isIncreasing = false;
                        isDecreasing = false;
                        break;
                    }
                }

                if (isIncreasing || isDecreasing)
                {
                    safeReports++;
                    break;
                }
            }
        }

        return safeReports;
    }
}
