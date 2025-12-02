using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2025
{
    internal class PuzzleMenu
    {
        private readonly IPuzzleSolverFactory _solverFactory;

        public PuzzleMenu(IPuzzleSolverFactory solverFactory)
        {
            _solverFactory = solverFactory;
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n\t-- Advent of Code 2025 --");
                Console.WriteLine("\nWhat day do you want to solve?");
                Console.WriteLine("\nType a number for the day?\n\t(0 for exit)");

                if (!uint.TryParse(Console.ReadLine(), out uint day) || day == 0)
                    break;


                Console.WriteLine("----------------");
                Console.WriteLine("Attempt solve for sample or puzzle input?");
                Console.WriteLine("\t1 - Sample \n\t2 - Puzzle");
                Console.WriteLine("\t0 - Exit");

                if (!uint.TryParse(Console.ReadLine(), out uint version) || version == 0)
                    break;

                PuzzleType puzzleType = version switch
                {
                    1 => PuzzleType.Sample,
                    2 => PuzzleType.Puzzle,
                    _ => throw new ArgumentException("Invalid selection")
                };

                string filePath = puzzleType == PuzzleType.Sample
                    ? $@"../../../Day{day}/sample.txt"
                    : $@"../../../Day{day}/puzzle.txt";

                try
                {
                    var solver = _solverFactory.CreateSolver(day, filePath);
                    solver.Part1();
                    solver.Part2();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
