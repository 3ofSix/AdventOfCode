using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2025.Day3
{
    [PuzzleDay(3)]
    internal class Day3 : IPuzzleSolver
    {
        private readonly ILogger<Day3> _logger;
        private List<string> _lines;

        public Day3(ILogger<Day3> logger, string filePath)
        {
            _logger = logger;
            _lines = new List<string>(File.ReadAllLines(filePath));
        }

        public void Part1()
        {
            // Sample 357
            /// Your puzzle answer was 17100.
            var sum = 0;
            foreach (var line in _lines)
            {
                var largest = 0;
                char[] bank = line.ToArray();
                for (int i = 0; i < bank.Length - 1; i++)
                {
                    for (int j = i + 1; j < bank.Length; j++)
                    {
                        string joltageStr = string.Concat(bank[i], bank[j]);
                        int joltage = Int32.Parse(joltageStr);
                        if (joltage > largest)
                            largest = joltage;
                    }
                }
                sum += largest;
            }
            Console.WriteLine($"Part 1: joltage is {sum}");

        }

        public void Part2()
        {
            // sample 3121910778619
            // Your puzzle answer was 170418192256861
            long sum = 0;
            foreach (var line in _lines)
            {
                sum += ProcessLine(line);
            }
            Console.WriteLine($"Part 2: joltage is {sum}");
        }

        private long ProcessLine(string digits)
        {
            int k = 12;
            int toDrop = digits.Length - k;
            var stack = new Stack<char>();

            foreach(char d in digits)
            {
                while (stack.Count > 0 && toDrop > 0 && stack.Peek() < d)
                {
                    stack.Pop();
                    toDrop--;
                }
                stack.Push(d);
            }
            var result = new string(stack.Reverse().ToArray());
            var largest = result.Substring(0, k);
            return Int64.Parse(largest);
        }
    }
}
