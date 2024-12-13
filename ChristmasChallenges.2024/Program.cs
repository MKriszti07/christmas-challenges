using ChristmasChallenges.In2024.Days.DayOne;
using ChristmasChallenges.In2024.Days.DayTwo;

Console.WriteLine("Welcome to the 2024 Christmas Code Challenge!");
Console.WriteLine("Select the day! (DayOne, DayTwo, etc...)");

var day = Console.ReadLine();

switch (day)
{
    case "DayOne_PartOne":
        DayOne.PartOne();
        DayOne.PartTwo();
        break;
    case "DayTwo":
        DayTwo.PartOne();
        DayTwo.PartTwo();
        break;
    default:
        break;
}

Console.ReadLine();