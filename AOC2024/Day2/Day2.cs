using System.Collections.Immutable;
using System.Diagnostics;

namespace AOC2024.Day2;

public class Day2
{
    private readonly string[] Input;
    public Day2(string filePath)
    {
        Input = File.ReadAllLines(filePath);
        Part1();
        Part2();
    }

    private void Part1()
    {
        int safeReports = 0;
        // Read file line by line converting into an int[] array
        foreach (string line in Input)
        {
            int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
            bool isIncreasing = numbers[0] < numbers[numbers.Length - 1];
            bool isSafe = true;
            // ensure the the distance between each sequential number is at least 1 and at most 3
            for (int i = 1; i < numbers.Length; i++)
            {
                int j = numbers[i - 1];
                if (Math.Abs(j - numbers[i]) is < 1 or > 3) {
                    isSafe = false;
                    break; // Distance between adjacent levels must be between 1 & 3
                }
                if ((j > numbers[i]) == isIncreasing) 
                {
                    isSafe = false;
                    break;   // Must be All increasing or All decreasing
                }
            }

            if (isSafe) safeReports++;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Part 1 Number of safe reports: {safeReports}");

    }
    
    private void Part2()
    {
        int safeReports = 0;
        // Read file line by line converting into an int[] array
        foreach (string line in Input)
        {
            int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
            bool isSafe = CheckSafe(numbers);
            if (isSafe) safeReports++;
            if (!isSafe)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{line}: {isSafe}");
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Part 2 Number of safe reports: {safeReports}");
    }

    private bool CheckSafe(int[] numbers)
    {
        bool isSafe = true;
        bool isSkip = false;
        bool isIncreasing = numbers[0] < numbers[numbers.Length - 1];
        // iterate the numbers starting at 2nd number
        for (int i = 1; i < numbers.Length; i++)
        {
            int j = isSkip ? numbers[i - 2] : numbers[i - 1];

            if ((j > numbers[i]) == isIncreasing) // broke rule all increasing or all decreasing
            {
                if (isSkip)
                {
                    isSafe = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{numbers[i]}\t");
                    break;
                }
                isSkip = true;
            }
            
            if (Math.Abs(j - numbers[i]) is < 1 or > 3) // broke rule distance at least 1 and max 3
            {
                if (isSkip)
                {
                    isSafe = false;
                    // Console.ForegroundColor = ConsoleColor.White;
                    // Console.Write($"{numbers[i]}\t");
                    break;
                }
                isSkip = true;
                continue;
            }

        }
        return isSafe;
    }
}