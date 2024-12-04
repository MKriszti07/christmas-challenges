using ChristmasChallenges.In2024.Days.DayOne;

Console.WriteLine("Welcome to the 2024 Christmas Code Challenge!");
Console.WriteLine("Select the day! (DayOne_PartOne, DayOne_PartTwo, etc...)");

var day = Console.ReadLine();

switch (day)
{
    case "DayOne_PartOne":
        DayOne.PartOne();
        break;
    case "DayOne_PartTwo":
        DayOne.PartTwo();
        break;
    default:
        break;
}

Console.ReadLine();