using System.Diagnostics;

namespace AOC2024.Day2;

public class Day2
{
    private readonly string[] Input;
    public Day2(string filePath)
    {
        Input = File.ReadAllLines(filePath);
        Process();
    }

    private void Process()
    {
        int safeReports = 0;
        // Read file line by line converting into an int[] array
        foreach (string line in Input)
        {
            int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
            bool isIncreasing = numbers[0] < numbers[1];
            bool isSafe = false;
            // ensure the the distance between each sequential number is at least 1 and at most 3
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] != numbers[i + 1])
                {
                    int distance = numbers[i] - numbers[i + 1];
                    if (isIncreasing) distance *= -1;
                    if (distance is >= 1 and <= 3)
                    {
                        isSafe = true;
                    }
                    else
                    {
                        isSafe = false;
                        break;
                    }
                    
                }
                else
                {
                    isSafe = false;
                    break;
                }
            }

            if (isSafe) safeReports += 1;
        }
        Console.WriteLine($"Number of safe reports: {safeReports}");
        // figure out if asscending or descending
        // Count how many safe!
        
    }
}