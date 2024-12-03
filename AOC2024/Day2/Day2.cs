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
            bool isIncreasing = numbers[0] < numbers[1];
            bool isSafe = true;
            // ensure the the distance between each sequential number is at least 1 and at most 3
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (Math.Abs(numbers[i] - numbers[i + 1]) is < 1 or > 3) {
                    isSafe = false;
                    break; // Distance between adjacent levels must be between 1 & 3
                }
                if ((numbers[i] > numbers[i + 1]) == isIncreasing) 
                {
                    isSafe = false;
                    break;   // Must be All increasing or All decreasing
                }
            }

            if (isSafe) safeReports++;
        }

        Console.WriteLine($"Number of safe reports: {safeReports}");

    }
    
    private void Part2()
    {
        int safeReports = 0;
        // Read file line by line converting into an int[] array
        foreach (string line in Input)
        {
            int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
            bool isIncreasing = numbers[0] < numbers[1];
            bool isSafe = true;
            int dampner = 0;
            // ensure the the distance between each sequential number is at least 1 and at most 3
            
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (Math.Abs(numbers[i] - numbers[i + 1]) is < 1 or > 3) {
                    dampner++;
                    if (dampner > 1)
                    {
                        isSafe = false;
                       // numbers.RemoveAt(number.index);
                        break; // Distance between adjacent levels must be between 1 & 3
                    }
                    continue;
                }
                if ((numbers[i] > numbers[i + 1]) == isIncreasing) 
                {
                    dampner++;
                    if (dampner > 1)
                    {
                        isSafe = false;
                        break;   // Must be All increasing or All decreasing
                    }
                }
            }

            if (isSafe) safeReports++;
        }

        Console.WriteLine($"Number of safe reports: {safeReports}");
    }
}