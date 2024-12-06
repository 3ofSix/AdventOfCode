// See https://aka.ms/new-console-template for more information

using AOC2024.Day1;
using AOC2024.Day2;
using AOC2024.Day3;
using Version = AOC2024.Version;
using AOC2024.Day4;
using AOC2024.Day6;

uint day;
Version version = new Version();
bool isExit = false;

void Solve()
{
    string file = version == Version.Sample ? $@"../../../Day{day}/sample.txt" : $@"../../../Day{day}/puzzle.txt";
    switch (day)
    {
        case 1:
            Day1 day1 = new Day1(file);
            day1.Part1();
            day1.Part2();
            break;
        case 2:
            Day2 day2 = new Day2(file);
            break;
        case 3:
            Day3 day3 = new Day3(file);
            day3.Part1();
            day3.Part2();
            break;
        case 4:
            Day4 day4 = new Day4(file);
            day4.Part1("XMAS");
            day4.Part2();
            break;
        case 6:
            Day6 day6 = new Day6(file);
            // day6.Part1();
            day6.Part2();
            break;

        default:
            throw new Exception($"Day {day} is not supported");
    }
}

while (!isExit)
{
    Console.WriteLine("\n\tAdvent of Code 2024");
    Console.WriteLine("\nWhat day do you want to solve?\nType a number for the day?\n\t0 for exit");
    day = Convert.ToUInt32(Console.ReadLine());
    if (day == 0) break;
    Console.WriteLine("----------------");
    Console.WriteLine("Attempt solve for sample or puzzle input?");
    Console.WriteLine("\t1 - Sample \n\t2 - Puzzle");

    Console.WriteLine("\t0 - Exit");

    switch (Convert.ToUInt32(Console.ReadLine()))
    {
        case 1:
            version = Version.Sample;
            break;
        case 2:
            version = Version.Puzzle;
            break;
        default:
            isExit = true;
            break;
    }
    if (isExit) break;
    try
    {
        Solve();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }

}