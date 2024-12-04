// See https://aka.ms/new-console-template for more information

using AOC2024.Day1;
using AOC2024.Day2;
using AOC2024.Day3;
using Version = AOC2024.Version;
using AOC2024.Day4;

int day = 2;
var v = Version.Sample;

        
string file = v == Version.Sample ? $@"../../../Day{day}/sample.txt" : $@"../../../Day{day}/puzzle.txt";
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
        
        
        
    default:
        throw new Exception($"Day {day} is not supported");
}