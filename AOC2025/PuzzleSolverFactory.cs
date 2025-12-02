using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2025
{
    public class PuzzleSolverFactory : IPuzzleSolverFactory
    {
        public IPuzzleSolver CreateSolver(uint day, string filePath)
        {
            return day switch
            {
                1 => new Day1(filePath),
                2 => new Day2(filePath),
                _ => throw new ArgumentException($"No solver for day {day}")
            };
        }
    }
}
