namespace ChristmasChallenges.In2024.Days.DayOne;

public static class DayOne
{
    public static List<int> LeftColumn = new List<int>();
    public static List<int> RightColumn = new List<int>();
    public static List<int> Distances = new List<int>();

    public static void PartOne()
    {
        string inputPath = "Days/DayOne/Inputs/InputNumbers.txt";

        ReadTextFileLineByLine(inputPath);

        LeftColumn = LeftColumn.Order().ToList();
        RightColumn = RightColumn.Order().ToList();

        for (int i = 0; i < LeftColumn.Count(); i++)
        {
            int leftValue = LeftColumn[i];
            int rightValue = RightColumn[i];

            int distance = leftValue - rightValue;

            if (distance < 0)
            {
                Distances.Add(distance * -1);
            }
            else
            {
                Distances.Add(distance);
            }
        }

        Console.WriteLine(Distances.Sum());
    }

    public static void PartTwo()
    {
        string inputPath = "Days/DayOne/Inputs/InputNumbers.txt";

        ReadTextFileLineByLine(inputPath);

        LeftColumn = LeftColumn.Order().ToList();
        RightColumn = RightColumn.Order().ToList();

        for (int i = 0; i < LeftColumn.Count(); i++)
        {
            int leftValue = LeftColumn[i];
            int leftValueCount = RightColumn.Where(x => x == leftValue).Count();

            int similarity = leftValue * leftValueCount;

            Distances.Add(similarity);
        }

        Console.WriteLine(Distances.Sum());
    }

    private static void ReadTextFileLineByLine(string fileName)
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

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
                    var splitedLine = line.Split("   ");

                    if (splitedLine.Count() > 1)
                    {
                        int leftItem = int.Parse(splitedLine[0]);
                        int rightItem = int.Parse(splitedLine[1]);

                        LeftColumn.Add(leftItem);
                        RightColumn.Add(rightItem);
                    }
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
        }
    }
}
