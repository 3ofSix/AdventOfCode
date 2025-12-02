using Microsoft.Extensions.Logging;

namespace AOC2025;

[PuzzleDay(1)]
public class Day1 : IPuzzleSolver
{
    // Safe cracking 
    // Safe 0 - 99, read a line Left (minus the number), right (add the number)
    // Result is mod 100
    // Count how many times the result is 0
    // Part 1 answer 1084
    // Part 2 answer 6475

    private readonly ILogger<Day1> _logger;
    private readonly List<string> lines;
    private int dialPosition;
    private int password;
    private const int dialSize = 100;

    public Day1(ILogger<Day1> logger, string filePath)
    {
        _logger = logger;
        _logger.LogInformation($"Loading file {filePath}");
        lines = new List<string>(File.ReadAllLines(filePath));
    }

    private void Reset()
    {
        dialPosition = 50;
        password = 0;
    }

    public void Part1()
    {
        Reset();
        foreach (string line in lines)
        {
            int clicks = Int32.Parse(line.Substring(1));
            int direction = line[0] == 'R' ? 1 : -1;
            int totalMovement = direction * clicks;

            dialPosition = ((dialPosition + totalMovement) % 100 + 100) % 100;
            if (dialPosition == 0) password++;

        }
        Console.WriteLine($"Part 1 password is {password}");
    }

    public void Part2()
    {
        Reset();
        foreach (var line in lines)
        {
            int direction = line[0] == 'R' ? 1 : -1;
            int steps = int.Parse(line.Substring(1));

            for (int i = 1; i <= steps; i++)
            {
                dialPosition = (dialPosition + direction + dialSize) % dialSize;
                if (dialPosition == 0) password++;
            }
        }
        Console.WriteLine($"Part 2 password is {password}");
    }
}